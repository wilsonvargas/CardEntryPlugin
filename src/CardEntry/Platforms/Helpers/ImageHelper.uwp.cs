using System.Threading.Tasks;
using UWPImage = Windows.UI.Xaml.Media.ImageSource;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinImageSource = Xamarin.Forms.ImageSource;

namespace Forms.Plugin.CardForm.Platforms.Helpers
{
    public class ImageHelper
    {
        private static IImageSourceHandler GetHandler(XamarinImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = null;
            }
            return returnValue;
        }

        public static async Task<UWPImage> GetImageFromImageSourceAsync(XamarinImageSource source)
        {
            var handler = GetHandler(source);
            var returnValue = (UWPImage)null;

            returnValue = await handler.LoadImageAsync(source);

            return returnValue;
        }
    }
}
