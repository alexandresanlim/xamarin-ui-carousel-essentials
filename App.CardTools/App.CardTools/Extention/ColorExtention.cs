using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Extention
{
    public static class ColorExtention
    {
        public static Color SetTransparence(this Color color, double alpha)
        {
            return new Color(color.R, color.G, color.B, alpha);
        }
    }
}
