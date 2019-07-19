using CoreAnimation;
using CoreGraphics;
using Forms.Plugin.CardForm.Platforms.Helpers;
using Forms.Plugin.CardForm.Controls;
using Forms.Plugin.CardForm.iOS;
using Forms.Plugin.CardForm.Shared.Helpers;
using System.Drawing;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Card = Forms.Plugin.CardForm.Controls.CardEntry;

[assembly: ExportRenderer(typeof(Card), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardForm.iOS
{
    public class CardEntryRenderer : EntryRenderer
    {
        protected override async void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            var element = (Card)Element;
            var textField = this.Control;
            if (element.Image != null)
            {
                switch (element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        textField.LeftViewMode = UITextFieldViewMode.Always;
                        textField.LeftView = await GetImageView(element.Image, 40, 50);
                        break;
                    case ImageAlignment.Right:
                        textField.RightViewMode = UITextFieldViewMode.Always;
                        textField.RightView = await GetImageView(element.Image, 40, 50);
                        break;
                }
            }

            textField.BorderStyle = UITextBorderStyle.None;
            CALayer bottomBorder = new CALayer
            {
                Frame = new CGRect(0.0f, element.HeightRequest - 1, this.Frame.Width, 1.0f),
                BorderWidth = 2.0f,
                BorderColor = element.LineColor.ToCGColor()
            };

            textField.Layer.AddSublayer(bottomBorder);
            textField.Layer.MasksToBounds = true;
        }

        private async Task<UIView> GetImageView(ImageSource imageSource, int height, int width)
        {
            UIImage image = await ImageHelper.GetUIImageFromImageSourceAsync(imageSource);
            var uiImageView = new UIImageView(image)
            {
                Frame = new RectangleF(0, 0, width, height)
            };
            UIView objLeftView = new UIView(new System.Drawing.Rectangle(0, 0, width + 10, height));
            objLeftView.AddSubview(uiImageView);

            return objLeftView;
        }
    }
}
