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
            Text = "Text to speech",
            //Style = MenuStyle.GetCombination(),
            //Icon = FontAwesomeSolid.Wifi,
        };

        public static ToolMenu UnitConveter => new ToolMenu
        {
            Text = "Unit Converter",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeSolid.ExchangeAlt,
        };

        public static ToolMenu SendWhatsAppMessage => new ToolMenu
        {
            Text = "WhatsApp without contact",
            //Style = MenuStyle.GetCombination(),
            Icon = FontAwesomeBrands.Whatsapp,
            IconIsBrand = true
            
        };

        public static ToolMenu MyDeviceInfo => new ToolMenu
        {
            Text = "My device info",
            Icon = FontAwesomeSolid.MobileAlt
        };

        public static ToolMenu SetCommand(this ToolMenu toolsMenu, Command command)
        {
            toolsMenu.Command = command;
            return toolsMenu;
        }
    }
}
