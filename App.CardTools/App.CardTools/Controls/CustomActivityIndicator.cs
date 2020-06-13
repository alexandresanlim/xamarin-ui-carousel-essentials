using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Controls
{
    public class CustomActivityIndicator : ActivityIndicator
    {
        public CustomActivityIndicator()
        {
            IsRunning = true;
            VerticalOptions = LayoutOptions.CenterAndExpand;
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            Color = App.Style.SecondaryColor;
        }
    }
}
