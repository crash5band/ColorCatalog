using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCatalog.Models
{
    internal class Color
    {
        private byte r;
        private byte g;
        private byte b;
        private byte a;

        public byte R => r;
        public byte G => g;
        public byte B => b;
        public byte A => a;

        public Color(byte _r, byte _g, byte _b, byte _a)
        {
            r = _r;
            g = _g;
            b = _b;
            a = _a;
        }
    }
}
