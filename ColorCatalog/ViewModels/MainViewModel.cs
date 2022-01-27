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

        public readonly string ColorsDB = "colors.txt";

        public void LoadColors()
        {
            if (!File.Exists(ColorsDB))
                return;

            using var reader = new StreamReader(ColorsDB);
            while (!reader.EndOfStream)
            {
                string? line = reader.ReadLine();
                if (line == null)
                    continue;

                string[] split = line.Split(',', StringSplitOptions.TrimEntries);
                string name = "";
                int hexIndex = 0;

                // color was saved with a name
                if (split.Length >= 2)
                {
                    name = split[0];
                    hexIndex = 1;
                }

                byte.TryParse(split[hexIndex].AsSpan(1, 2), NumberStyles.HexNumber, null, out byte r);
                byte.TryParse(split[hexIndex].AsSpan(3, 2), NumberStyles.HexNumber, null, out byte g);
                byte.TryParse(split[hexIndex].AsSpan(5, 2), NumberStyles.HexNumber, null, out byte b);

                Colors.Add(new ColorViewModel(name, r, g, b));
            }
        }

        public void SaveColors()
        {
            using var writer = new StreamWriter(ColorsDB);
            foreach (ColorViewModel color in Colors)
                writer.WriteLine(color.Name.Length > 0 ? $"{color.Name}, {color.Hex}" : color.Hex);
        }

        public RelayCommand AddColorCmd { get; set; }
        public RelayCommand<ColorViewModel> RemoveColorCmd { get; set; }

        public void AddSelectedColor()
        {
            Colors.Add(new ColorViewModel("", ColorPick.Color.R, ColorPick.Color.G, ColorPick.Color.B));
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

            ColorPick = new System.Windows.Media.SolidColorBrush();
        }
    }
}
