using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColorCatalog.Models;

namespace ColorCatalog.ViewModels
{
    internal class ColorViewModel : ViewModelBase
    {
        public Color Data {get; set;}
        public byte R => Data.R;
        public byte G => Data.G;
        public byte B => Data.B;
        public byte A => Data.A;

        public string RGB => $"{R}, {G}, {B}";

        public string Float => $"{R / 255.0f:0.00}, {G / 255.0f:0.00}, {B / 255.0f:0.00}";

        public string Hex => $"#{R:X2}{G:X2}{B:X2}";

        public ColorViewModel(byte r, byte g, byte b, byte a = 255)
        {
            Data = new Color(r, g, b, a);
        }

        public ColorViewModel()
        {
            DisplayName = $"Color {Hex}";
            Data = new Color(255, 255, 255, 255);
        }
    }
}
