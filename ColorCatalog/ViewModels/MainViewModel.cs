using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCatalog.Models;
using Shuriken.Commands;
using HandyControl.Themes;

namespace ColorCatalog.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ColorViewModel> Colors { get; set; }

        public System.Windows.Media.SolidColorBrush ColorPick { get; set; }

        public void LoadColors()
        {
            if (!File.Exists("colors.txt"))
                return;

            StreamReader reader = new StreamReader("colors.txt");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string rCode = line.Substring(1, 2);
                string gCode = line.Substring(3, 2);
                string bCode = line.Substring(5, 2);
                int r = 0;
                int g = 0;
                int b = 0;

                int.TryParse(rCode, NumberStyles.HexNumber, null, out r);
                int.TryParse(gCode, NumberStyles.HexNumber, null, out g);
                int.TryParse(bCode, NumberStyles.HexNumber, null, out b);
                Colors.Add(new ColorViewModel((byte)r, (byte)g, (byte)b));
            }
        }

        public void SaveColors()
        {
            StreamWriter writer = new StreamWriter("colors.txt");
            foreach (ColorViewModel color in Colors)
            {
                writer.WriteLine(color.Hex);
            }

            writer.Flush();
            writer.Close();
        }

        public RelayCommand AddColorCmd { get; set; }
        public RelayCommand<ColorViewModel> RemoveColorCmd { get; set; }

        public void AddSelectedColor()
        {
            Colors.Add(new ColorViewModel(ColorPick.Color.R, ColorPick.Color.G, ColorPick.Color.B));
        }

        public void RemoveColor(object color)
        {
            if (color is ColorViewModel c)
            {
                Colors.Remove(c);
            }
        }

        public MainViewModel()
        {
            Colors = new ObservableCollection<ColorViewModel>();
            LoadColors();

            AddColorCmd = new RelayCommand(AddSelectedColor, null);
            RemoveColorCmd = new RelayCommand<ColorViewModel>(RemoveColor, null);
        }
    }
}
