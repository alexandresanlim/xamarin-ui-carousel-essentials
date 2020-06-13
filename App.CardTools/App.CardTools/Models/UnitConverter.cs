using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Models
{
    public class UnitConverter
    {
        public string Title { get; set; }

        public string InputText { get; set; }

        public Command Command { get; set; }

        public string PlaceholderPresentation => "Entry " + InputText + " to converter";
    }
}
