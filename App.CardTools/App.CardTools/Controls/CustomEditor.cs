using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Controls
{
    public class CustomEditor : Editor
    {
        public CustomEditor()
        {
            TextColor = App.ThemeColors.TextOnPrimary;
            BackgroundColor = App.ThemeColors.Primary;
        }
    }
}
