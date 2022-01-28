using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToogetherApp.Views
{
    /* Enumeration which allows to specify the level chosen when the current position of the PanContainer must be updated */
    public enum CurrentPosType
    {
        Min,
        Middle,
        Max
    }
    /* Pop-up that rises with several levels of positions (see the associated renderings for additional informations) */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PanContainer : Frame
    {
        public static CurrentPosType initial_position;
        public static float[] Pos = new float[3];
        //Event 
        public delegate void CurrentChangedEvent(CurrentPosType pos);
        public delegate void PosChangedEvent();
        public delegate void PosUpdated();
        public delegate void CurrentScrolled(float scrollY);
        // Event Handlers
        public event CurrentChangedEvent HandlerCurrentPosChanged;
        public event PosChangedEvent HandlerPosChanged;
        public event PosChangedEvent HandlerPosUpdated;
        public event CurrentScrolled HandlerCurrentScrolled;
        public PanContainer(CurrentPosType _initial_position = CurrentPosType.Max)
        {
            initial_position = _initial_position;
        }
        /* Method to call to change the current position 
         * Invoke an event of type CurrentChangedEvent */
        public void SetCurrentPos(CurrentPosType pos)
        {
            HandlerCurrentPosChanged?.Invoke(pos);
        }
        /* Method to call to change level pos (the argument must have the same size as the attribute Pos)
         * Invoke an event of type PosChangedEvent */
        public void SetPos(float[] pos)
        {
            Pos = pos;
            HandlerPosChanged?.Invoke();
        }
        /* Method to call to refresh the current position (if a new position has been assigned by a layout for example) 
         * Invoke an event of type PosChangedEvent */
        public void Update()
        {
            HandlerPosUpdated?.Invoke();
        }
        public void Scrolled(float scrollY)
        {
            HandlerCurrentScrolled?.Invoke(scrollY);
        }
    }
}