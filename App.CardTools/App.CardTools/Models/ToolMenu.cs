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
