using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Controls
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            TextColor = App.Style.SecondaryTextColor;
        }
    }
}
