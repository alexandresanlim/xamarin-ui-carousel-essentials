using App.CardTools.Extention;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Models
{
    public class MenuBase : MenuItem
    {
        public int Priority { get; set; }

        public bool RequiredInternet { get; set; }

        //public MenuStyle Style { get; set; }

        public string Icon { get; set; }

        public bool IconIsBrand { get; set; }
    }

    public class MenuStyle
    {
        public string Name { get; set; }

        public Color PrimaryDarkColor { get; set; }

        public Color PrimaryColor { get; set; }

        [Obsolete]
        public Color OnPrimaryColor { get; set; }

        public Color SecondaryDarkColor { get; set; }

        public Color SecondaryColor { get; set; }

        [Obsolete]
        public Color OnSecondaryColor { get; set; }

        public Color PrimaryTextColor { get; set; }

        public Color SecondaryTextColor { get; set; }

        public static List<MenuStyle> CombinationList => new List<MenuStyle>
        {
            new MenuStyle
            {
                Name = "Hoppe",
                PrimaryDarkColor = Color.FromHex("#00969a"),
                PrimaryColor = Color.FromHex("#4ac7cb"),
                PrimaryTextColor = Color.FromHex("#000000"),
                SecondaryDarkColor = Color.FromHex("#3c0006"),
                SecondaryColor = Color.FromHex("#6b1230"),
                SecondaryTextColor = Color.FromHex("#FFFFFF")
            },
            new MenuStyle
            {
                Name = "Any Range",
                PrimaryDarkColor = Color.FromHex("#4e0857"),
                PrimaryColor = Color.FromHex("#7d3984"),
                PrimaryTextColor = Color.FromHex("#000000"),
                SecondaryDarkColor = Color.FromHex("#940035"),
                SecondaryColor = Color.FromHex("#cb2b5e"),
                SecondaryTextColor = Color.FromHex("#FFFFFF")
            },
            new MenuStyle
            {
                Name = "Mises",
                PrimaryDarkColor = Color.FromHex("#000000"),
                PrimaryColor = Color.FromHex("#212121"),
                PrimaryTextColor = Color.FromHex("#000000"),
                SecondaryColor = Color.FromHex("#FF5722"),
                SecondaryDarkColor = Color.FromHex("#FF5722"),
                SecondaryTextColor = Color.FromHex("#FFFFFF")
            }
        };

        public static MenuStyle GetCombination()
        {
            return CombinationList.PickRandom();
        }
    }

    public class ToolMenu : MenuBase
    {
        public ToolMenu()
        {
            Child = new List<ToolMenu>();
        }

        public List<ToolMenu> Child { get; private set; }

        public ToolMenu AddChild(List<ToolMenu> childrens)
        {
            //childrens.SetColorInMenuList();

            //var back = new MenuBody
            //{
            //    Text = "Back",
            //    Icon = IconFont.AngleLeft,
            //    BackgroundColor = Color.FromHex("#bdc3c7")
            //};

            //childrens.Insert(0, back);

            this.Child = childrens;

            return this;
        }
    }
}
