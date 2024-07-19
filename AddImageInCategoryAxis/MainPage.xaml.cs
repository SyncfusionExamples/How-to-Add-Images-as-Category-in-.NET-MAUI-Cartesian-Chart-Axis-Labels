using Microsoft.Maui.Graphics.Platform;
using Syncfusion.Maui.Charts;

namespace AddImageInCategoryAxis
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CustomCategoryAxis : CategoryAxis
    {
        protected override void DrawAxis(ICanvas canvas, Rect arrangeRect)
        {
            base.DrawAxis(canvas, arrangeRect);

            foreach (ChartAxisLabel label in VisibleLabels)
            {
                string labelText = label.Content.ToString();
                if (this.BindingContext is DataViewModel viewModel && labelText != null && viewModel.Streams.ContainsKey(labelText))
                {
                    Stream stream = viewModel.Streams[labelText];
                    var image = PlatformImage.FromStream(stream);
                    var top = ValueToPoint(label.Position);
                    canvas.DrawImage(image, top - viewModel.OffsetX, (float)arrangeRect.Height - viewModel.OffsetY , viewModel.Width, viewModel.Height);
                }
            }
        }
    }
}
