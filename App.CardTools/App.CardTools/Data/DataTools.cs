using App.CardTools.Models;
using App.CardTools.Models.Icon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.Data
{
    public static class DataTools
    {
        public static ToolMenu Connection => new ToolMenu
        {
            Text = "My Connection",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu FlashLight => new ToolMenu
        {
            Text = "Flash Ligth",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Sun,
        };

        public static ToolMenu DeviceInfo => new ToolMenu
        {
            Text = "My Device Info",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu Location => new ToolMenu
        {
            Text = "My Connection",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu ShareText => new ToolMenu
        {
            Text = "",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu TextToSpeech => new ToolMenu
        {
            Text = "My Connection",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu UnitConveter => new ToolMenu
        {
            Text = "Unit Converter",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.ExchangeAlt,
        };

        public static ToolMenu SetCommand(this ToolMenu toolsMenu, Command command)
        {
            toolsMenu.Command = command;
            return toolsMenu;
        }
    }
}
