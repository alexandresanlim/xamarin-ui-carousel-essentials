using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Models
{
    public class ToolsMenu : MenuItem
    {
        public ToolsMenu()
        {
            Child = new List<ToolsMenu>();
        }

        public Color PrimaryColor { get; set; }

        public Color OnPrimaryColor { get; set; }

        public Color SecondaryColor { get; set; }

        public Color OnSecondaryColor { get; set; }

        public string Icon { get; set; }

        public List<ToolsMenu> Child { get; private set; }

        public ToolsMenu AddChild(List<ToolsMenu> childrens)
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
