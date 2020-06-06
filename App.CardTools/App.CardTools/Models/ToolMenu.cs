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

        public MenuStyle Style { get; set; }

        public string Icon { get; set; }
    }

    public class MenuStyle
    {
        public Color PrimaryDarkColor { get; set; }

        public Color PrimaryColor { get; set; }

        public Color OnPrimaryColor { get; set; }

        public Color SecondaryDarkColor { get; set; }

        public Color SecondaryColor { get; set; }

        public Color OnSecondaryColor { get; set; }

        public static List<MenuStyle> CombinationList => new List<MenuStyle>
        {
            new MenuStyle
            {
                PrimaryDarkColor = Color.FromHex("#00969a"),
                PrimaryColor = Color.FromHex("#4ac7cb"),
                OnPrimaryColor = Color.FromHex("#FFFFFF"),
                SecondaryDarkColor = Color.FromHex("#3c0006"),
                SecondaryColor = Color.FromHex("#6b1230"),
                OnSecondaryColor = Color.FromHex("#FFFFFF")
            },
            new MenuStyle
            {
                PrimaryDarkColor = Color.FromHex("#512DA8"),
                PrimaryColor = Color.FromHex("#673AB7"),
                OnPrimaryColor = Color.FromHex("#FFFFFF"),
                SecondaryDarkColor = Color.FromHex("#C2185B"),
                SecondaryColor = Color.FromHex("#E91E63"),
                OnSecondaryColor = Color.FromHex("#FFFFFF")
            },
            new MenuStyle
            {
                PrimaryDarkColor = Color.FromHex("#000000"),
                PrimaryColor = Color.FromHex("#212121"),
                OnPrimaryColor = Color.FromHex("#FFFFFF"),
                SecondaryColor = Color.FromHex("#FF5722"),
                SecondaryDarkColor = Color.FromHex("#FF5722"),
                OnSecondaryColor = Color.FromHex("#FFFFFF")
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
