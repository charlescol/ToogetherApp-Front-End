using Android.Content;
using Android.Views;
using System;
using System.Diagnostics;
using ToogetherApp.Droid.Renderer;
using ToogetherApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

/* Class which implements a Custom Android Renderer for the PanContainer objects */
[assembly: ExportRenderer(typeof(PanContainer), typeof(PanContainerRenderer_Droid))]
namespace ToogetherApp.Droid.Renderer
{
    public class PanContainerRenderer_Droid : ViewRenderer<Frame, Android.Views.View>
    {
        float dY; // The distance between the top of the screen and the start of the window 
        float firstYTouch;// The ordered of the first touch
        float firstXTouch; // The abscissa of the first touch
        float currentScrollY = 0f;
        CurrentPosType currentPos; // The current position
        private bool disposedValue;

        /* Array that contains the converted values from Xamarin positions to Android. 
         * Correspond to the positions of each level of the PanContainer */
        float[] CurrentPos_Droid = new float[3];

        Stopwatch timer;// Timer to measure the time of a swap up

        public PanContainerRenderer_Droid(Context context) : base(context)
        {
            currentPos = PanContainer.initial_position;
            SetPos();
        }
        /* Set the current position with a translation animation */
        public void SetCurrentPos(CurrentPosType newPos)
        {
            Animate().TranslationY(CurrentPos_Droid[((int)newPos)]).SetDuration(80); // add a translation animation (80 ms)
            SetY(CurrentPos_Droid[((int)newPos)]);
            currentPos = newPos;// update pos
        }
        /* Convert positions of each level of the PanContainer Xamarin positions to Android positions */
        public void SetPos()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            for (int i = 0; i < PanContainer.Pos.Length; i++)
            {
                CurrentPos_Droid[i] = PanContainer.Pos[i] * (float)mainDisplayInfo.Density;
            }
        }
        /* Update the current position on the screen instantly */
        public void UpdatePos()
        { 
            SetY(CurrentPos_Droid[(int)currentPos]);
        }
        public void UpdateScrollPosY(float posY)
        {
            currentScrollY = posY;
        }
        /* Subscribe/Unsubscribe to event */
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                PanContainer view = e.NewElement as PanContainer;
                if (view != null)
                {
                    // Subscribe
                    view.HandlerCurrentPosChanged += SetCurrentPos;
                    view.HandlerPosChanged += SetPos;
                    view.HandlerPosUpdated += UpdatePos;
                    view.HandlerCurrentScrolled += UpdateScrollPosY;
                }
            }
            if (e.OldElement != null)
            {
                PanContainer view = e.OldElement as PanContainer;
                if (view != null)
                {
                    // Unsubscribe
                    view.HandlerCurrentPosChanged -= SetCurrentPos;
                    view.HandlerPosChanged -= SetPos;
                    view.HandlerPosUpdated -= UpdatePos;
                    view.HandlerCurrentScrolled -= UpdateScrollPosY;
                }
            }
        }
        /* Call first when a touch is detected */
        public override bool OnInterceptTouchEvent(MotionEvent e)
        {
            float y = e.RawY;
            switch (e.Action)
            {
                /* First intercepted position */
                case MotionEventActions.Down:
                    {
                        /* Save the first touch */
                        firstYTouch = GetY();
                        firstXTouch = e.RawX;
                        dY = y - GetY();
                        break;
                    }
                /* After the first touch */
                case MotionEventActions.Move:
                    {
                        if (currentScrollY == 0f && firstYTouch - (y - dY) < 0 || currentPos != CurrentPosType.Min)
                        {
                            /* If the movement is more in y than in x we continue on OnTouchEvent by returning true (else it's not a swap up/down) */
                            float distanceY = Math.Abs(firstYTouch - (y - dY));
                            float distanceX = Math.Abs(firstXTouch - e.RawX);
                            if (distanceY > distanceX)
                                return true;
                        }
                        break;
                    }
            }
            /* As long as this method returns false, OnTouchEvent is not call, and next touch will be intercept by this method */
            return false;
        }
        /* Method call if the swap is a swap up/down */
        public override bool OnTouchEvent(MotionEvent e)
        {
            float y = e.RawY;
            switch (e.Action)
            {
                /* First intercepted position */
                case MotionEventActions.Down:
                    {
                        /* We save the first touch position */
                        dY = y - GetY();
                        firstYTouch = GetY();
                        /* We launch the timer */
                        timer = new Stopwatch();
                        timer.Start();

                        return true;
                    }
                /* When touching */
                case MotionEventActions.Move:
                    {
                        float newPos = y - dY;
                        /* If the position is between the min and max position, the pan container follows the horizontal touch position */
                        if (newPos >= CurrentPos_Droid[(int)CurrentPosType.Min] && newPos <= CurrentPos_Droid[(int)CurrentPosType.Max])
                        {
                            SetY(newPos);
                        }
                        return true;
                    }
                /* End touch */
                case MotionEventActions.Up:
                    {
                        try
                        {
                            timer.Stop(); // First, stop the timer
                            float lastYouch = y - dY;
                            float limit = 400;

                            /* If touch duration < 0.3s and the distance travelled < limit then drag up or drag down to the next position */
                            if (timer.Elapsed < TimeSpan.FromSeconds(0.3) && Math.Abs(firstYTouch - lastYouch) < limit)
                            {
                                if (firstYTouch > lastYouch && currentPos != CurrentPosType.Min) // drag up
                                {
                                    SetCurrentPos(currentPos - 1);
                                    return true;
                                }
                                else if (firstYTouch < lastYouch && currentPos != CurrentPosType.Max) // drag down 
                                {
                                    SetCurrentPos(currentPos + 1);
                                    return true;
                                }

                            }
                            /*  Else if touch duration < 0.5s the distance travelled > limit then drag up or down to the extremum position */
                            else if (timer.Elapsed < TimeSpan.FromSeconds(0.5))
                            {
                                if (Math.Abs(firstYTouch - lastYouch) > limit)
                                {
                                    if (firstYTouch > lastYouch && currentPos != CurrentPosType.Min) // drag up
                                    {
                                        SetCurrentPos(CurrentPosType.Min);
                                        return true;
                                    }
                                    else if (firstYTouch < lastYouch && currentPos != CurrentPosType.Max) // drag down 
                                    {
                                        SetCurrentPos(CurrentPosType.Max);
                                        return true;
                                    }
                                }
                            }
                            // If touch duration > 0.3s go to the nearset position
                            float min = Math.Min(Math.Min(CurrentPos_Droid[(int)CurrentPosType.Max] - lastYouch, lastYouch - CurrentPos_Droid[(int)CurrentPosType.Min]), Math.Abs(lastYouch - CurrentPos_Droid[(int)CurrentPosType.Middle]));
                            if (min == CurrentPos_Droid[(int)CurrentPosType.Max] - lastYouch)
                            {
                                SetCurrentPos(CurrentPosType.Max);
                            }
                            else if (min == lastYouch - CurrentPos_Droid[(int)CurrentPosType.Min])
                            {
                                SetCurrentPos(CurrentPosType.Min);
                            }
                            else
                                SetCurrentPos(CurrentPosType.Middle);
                        }
                        catch
                        { }

                        return true;
                    }
            }
            return false;
        }
        protected override void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    RemoveHandlerPosUpdated();
                }
                disposedValue = true;
            }
            base.Dispose(disposing);
        }
        private void RemoveHandlerPosUpdated()
        {
            if (Element != null)
            {
                PanContainer view = Element as PanContainer;
                if (view != null)
                {
                    view.HandlerPosUpdated -= UpdatePos;
                }
            }
        }
    }
}