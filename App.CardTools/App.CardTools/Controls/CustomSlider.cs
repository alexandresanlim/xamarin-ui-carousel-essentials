using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Controls
{
    public class CustomSlider : Slider
    {
        public CustomSlider()
        {
            ThumbColor = App.ThemeColors.Secondary;
            MinimumTrackColor = App.ThemeColors.Secondary;
        }
    }
}
