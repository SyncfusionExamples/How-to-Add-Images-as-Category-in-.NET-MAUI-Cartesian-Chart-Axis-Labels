using AddImageInCategoryAxis;
using Microsoft.Maui.Graphics.Platform;
using Syncfusion.Maui.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AddImageInCategoryAxis
{
    public class DataViewModel
    {
        public float OffsetX { get; set; }
        public float OffsetY { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public ObservableCollection<DataModel> Data { get; set; }
        public List<Brush> CustomBrush { get; set; }
        public Dictionary<string, Stream> Streams { get; } = new Dictionary<string, Stream>();
        Stream stream;

        public DataViewModel()
        {
            Data = new ObservableCollection<DataModel>()
            {
                new DataModel(){ Country = "US", Vists = 725 },
                new DataModel(){ Country = "UK", Vists = 625 },
                new DataModel(){ Country = "China", Vists = 602 },
                new DataModel(){ Country = "Japan", Vists = 509 },
                new DataModel(){ Country = "Germany", Vists = 322 },
                new DataModel(){ Country = "France", Vists = 214 },
                new DataModel(){ Country = "India", Vists = 204 },
                new DataModel(){ Country = "Spain", Vists = 198 },
                new DataModel(){ Country = "Netherlands", Vists = 165 },
                new DataModel(){ Country = "SouthKorea", Vists = 93 },
                new DataModel(){ Country = "Canada", Vists = 41 }
            };
            CustomBrush = new List<Brush>()
            {
                new SolidColorBrush(Color.FromArgb("#440154")),
                new SolidColorBrush(Color.FromArgb("#482475")),
                new SolidColorBrush(Color.FromArgb("#414487")),
                new SolidColorBrush(Color.FromArgb("#355f8d")),
                new SolidColorBrush(Color.FromArgb("#2a788e")),
                new SolidColorBrush(Color.FromArgb("#21918c")),
                new SolidColorBrush(Color.FromArgb("#22a884")),
                
                new SolidColorBrush(Color.FromArgb("#44bf70")),
                new SolidColorBrush(Color.FromArgb("#7ad151")),
                
                new SolidColorBrush(Color.FromArgb("#bddf26")),
                new SolidColorBrush(Color.FromArgb("#fde725"))
            };
            Streams = GetImageSources();
            SetPlatformValues();
        }

        private void SetPlatformValues()
        {
            if(Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
            {
                OffsetX = 12;
                OffsetY = 48;
                Width = 25;
                Height = 25;
            }
            else
            {
                OffsetX = 10;
                OffsetY = 43;
                Width = 20;
                Height = 20;
            }
        }

        private Dictionary<string, Stream> GetImageSources()
        {
            Dictionary<string, Stream> keyValues = new Dictionary<string, Stream>();
            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            for(int i = 0; i < Data.Count; i++)
            {
                string imageName = $"{Data[i].Country.ToLower()}.png";
                stream = assembly.GetManifestResourceStream($"AddImageInCategoryAxis.Resources.Images.{imageName}");

                if(stream != null && Data[i].Country != null)
                {
                    keyValues.Add(Data[i].Country, stream);
                }
            }
            return keyValues;
        }
    }
}
