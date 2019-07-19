using Forms.Plugin.CardForm.Controls;
using Forms.Plugin.CardForm.Platforms.Helpers;
using Forms.Plugin.CardForm.UWP;
using System;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Card = Forms.Plugin.CardForm.Controls.CardEntry;

[assembly: ExportRenderer(typeof(Card), typeof(CardEntryRenderer))]
namespace Forms.Plugin.CardForm.UWP
{
    public class CardEntryRenderer : EntryRenderer
    {
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var view = (Card)Element;

            if (view != null)
            {
                SetIcon(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (Card)Element;
            if (e.PropertyName == CardEntry.ImageProperty.PropertyName)
                SetIcon(view);
        }

        private async void SetIcon(CardEntry view)
        {
            if (view.Image != null)
            {
                
                var ib = new ImageBrush
                {
                    ImageSource = await ImageHelper.GetImageFromImageSourceAsync(view.Image),
                    Stretch = Stretch.None,
                    AlignmentX = AlignmentX.Left
                };
                Control.Background = ib;

                var style = Windows.UI.Xaml.Application.Current.Resources["IconTextBoxStyle"];
                if (style != null)
                    Control.Style = (Windows.UI.Xaml.Style)style;
            }
        }
    }
}
