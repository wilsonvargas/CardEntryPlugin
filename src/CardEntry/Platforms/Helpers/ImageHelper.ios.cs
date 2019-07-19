using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Forms.Plugin.CardForm.Platforms.Helpers
{
    public class ImageHelper
    {
        private static IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler returnValue = null;
            if (source is UriImageSource)
            {
                returnValue = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                returnValue = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                returnValue = new StreamImagesourceHandler();
            }
            return returnValue;
        }

        public static async Task<UIImage> GetUIImageFromImageSourceAsync(ImageSource source)
        {
            var handler = GetHandler(source);
            var returnValue = (UIImage)null;

            returnValue = await handler.LoadImageAsync(source);

            return returnValue;
        }
    }
}
