using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BusinessLogicLayer
{
    public static class Media
    {
        public static async Task<ImageSource> OpenGallery()
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Non supporté", "Votre appareil ne supporte pas cette fonctionalité.", "OK");
                return null;
            }
            var mediaOption = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Full
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOption);
            return ImageSource.FromStream(() => selectedImageFile.GetStream());
        }
        public static async Task<ImageSource> TakePicture()
        {
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await Application.Current.MainPage.DisplayAlert("Non supporté", "Votre appareil ne supporte pas cette fonctionalité.", "OK");
                return null;
            }
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());

            return photo == null ?  null : ImageSource.FromStream(() => photo.GetStream());
        }
    }
}
