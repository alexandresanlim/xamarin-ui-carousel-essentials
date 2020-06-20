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

        public Color PrimaryTransparence => Primary.SetTransparence(0.5);

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
                Name = "hoppe",
                PrimaryDark = Color.FromHex("#00969a"),
                Primary = Color.FromHex("#4ac7cb"),
                TextOnPrimary = Color.FromHex("#FFFFFF"),
                SecondaryDark = Color.FromHex("#3c0006"),
                Secondary = Color.FromHex("#6b1230"),
                TextOnSecondary = Color.FromHex("#FFFFFF")
            },
            new MaterialColor
            {
                Name = "any",
                PrimaryDark = Color.FromHex("#4e0857"),
                Primary = Color.FromHex("#7d3984"),
                TextOnPrimary = Color.FromHex("#FFFFFF"),
                SecondaryDark = Color.FromHex("#940035"),
                Secondary = Color.FromHex("#cb2b5e"),
                TextOnSecondary = Color.FromHex("#FFFFFF")
            },
            new MaterialColor
            {
                Name = "mises",
                PrimaryDark = Color.FromHex("#000000"),
                Primary = Color.FromHex("#212121"),
                TextOnPrimary = Color.FromHex("#FFFFFF"),
                Secondary = Color.FromHex("#FF5722"),
                SecondaryDark = Color.FromHex("#FF5722"),
                TextOnSecondary = Color.FromHex("#000000")
            },
            new MaterialColor
            {
                Name = "libertary",
                PrimaryDark = Color.FromHex("#000000"),
                Primary = Color.FromHex("#212121"),
                PrimaryLight = Color.FromHex("#484848"),
                TextOnPrimary = Color.FromHex("#ffffff"),
                Secondary = Color.FromHex("#f1c40f"),
                SecondaryDark = Color.FromHex("#ba9400"),
                SecondaryLight = Color.FromHex("#fff653"),
                TextOnSecondary = Color.FromHex("#000000")
            },
            new MaterialColor
            {
                Name = "lime",
                PrimaryDark = Color.FromHex("#333333"),
                Primary = Color.FromHex("#5c5c5c"),
                PrimaryLight = Color.FromHex("898989"),
                TextOnPrimary = Color.FromHex("#ffffff"),
                Secondary = Color.FromHex("#cbea07"),
                SecondaryDark = Color.FromHex("#96b800"),
                SecondaryLight = Color.FromHex("#ffff56"),
                TextOnSecondary = Color.FromHex("#000000")
            }
        };

        public static MaterialColor GetRandom()
        {
            return NiceCombinationList.PickRandom();
        }

        public static void SetOnCurrentResourceThemeColor(MaterialColor themeParameter = null)
        {
            var colors = themeParameter ?? GetRandom();

            App.Current.Resources["primary"] = colors.Primary;
            App.Current.Resources["primaryLight"] = colors.PrimaryLight;
            App.Current.Resources["primaryDark"] = colors.PrimaryDark;

            App.Current.Resources["secondary"] = colors.Secondary;
            App.Current.Resources["secondaryLight"] = colors.SecondaryLight;
            App.Current.Resources["secondaryDark"] = colors.SecondaryDark;


            App.Current.Resources["textOnPrimary"] = colors.TextOnPrimary;
            App.Current.Resources["textOnSecondary"] = colors.TextOnSecondary;
        }

        public static MaterialColor GetByCurrentResourceThemeColor()
        {
            return new MaterialColor
            {
                Primary = (Color)App.Current.Resources["primary"],
                PrimaryLight = (Color)App.Current.Resources["primaryLight"],
                PrimaryDark = (Color)App.Current.Resources["primaryDark"],

                Secondary = (Color)App.Current.Resources["secondary"],
                SecondaryLight = (Color)App.Current.Resources["secondaryLight"],
                SecondaryDark = (Color)App.Current.Resources["secondaryDark"],

                TextOnPrimary = (Color)App.Current.Resources["textOnPrimary"],
                TextOnSecondary = (Color)App.Current.Resources["textOnSecondary"],
            };
        }
    }
}
