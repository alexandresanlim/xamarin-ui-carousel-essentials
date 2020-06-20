using App.CardTools.Extention;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Models._2___Layout
{
    public class MaterialColor
    {
        public string Name { get; set; }

        public Color Primary { get; set; }

        public Color PrimaryLight { get; set; }

        public Color PrimaryDark { get; set; }

        public Color Secondary { get; set; }

        public Color SecondaryLight { get; set; }

        public Color SecondaryDark { get; set; }
        
        public Color TextOnPrimary { get; set; }
        
        public Color TextOnSecondary { get; set; }

        public Color White => Color.White;

        public Color Black => Color.Black;

        public Color TextOnLightThemePrimary => Black;

        public Color TextOnLightThemeSecondary => TextOnLightThemePrimary.SetTransparence(0.8);

        public Color TextOnDarkThemePrimary => White;

        public Color TextOnDarkThemeSecondary => TextOnDarkThemePrimary.SetTransparence(0.8);

        public static List<MaterialColor> NiceCombinationList => new List<MaterialColor>
        {
            new MaterialColor
            {
                Name = "Hoppe",
                PrimaryDark = Color.FromHex("#00969a"),
                Primary = Color.FromHex("#4ac7cb"),
                TextOnPrimary = Color.FromHex("#000000"),
                SecondaryDark = Color.FromHex("#3c0006"),
                Secondary = Color.FromHex("#6b1230"),
                TextOnSecondary = Color.FromHex("#FFFFFF")
            },
            new MaterialColor
            {
                Name = "Any Range",
                PrimaryDark = Color.FromHex("#4e0857"),
                Primary = Color.FromHex("#7d3984"),
                TextOnPrimary = Color.FromHex("#000000"),
                SecondaryDark = Color.FromHex("#940035"),
                Secondary = Color.FromHex("#cb2b5e"),
                TextOnSecondary = Color.FromHex("#FFFFFF")
            },
            new MaterialColor
            {
                Name = "Mises",
                PrimaryDark = Color.FromHex("#000000"),
                Primary = Color.FromHex("#212121"),
                TextOnPrimary = Color.FromHex("#000000"),
                Secondary = Color.FromHex("#FF5722"),
                SecondaryDark = Color.FromHex("#FF5722"),
                TextOnSecondary = Color.FromHex("#FFFFFF")
            }
        };

        public static MaterialColor GetRandom()
        {
            return NiceCombinationList.PickRandom();
        }

        public static void SetOnCurrentResourceThemeColor()
        {
            var colors = GetRandom();

            App.Current.Resources["primaryColor"] = colors.Primary;
            App.Current.Resources["secondaryColor"] = colors.Secondary;
            App.Current.Resources["primaryDarkColor"] = colors.PrimaryDark;
            App.Current.Resources["secondaryDarkColor"] = colors.SecondaryDark;
            App.Current.Resources["primaryTextColor"] = colors.TextOnPrimary;
            App.Current.Resources["secondaryTextColor"] = colors.TextOnSecondary;
        }
    }
}
