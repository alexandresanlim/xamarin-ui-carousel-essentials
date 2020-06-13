using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App.CardTools.Models
{
    public class WhatsApp
    {
        public static async Task SendMessage(string phoneNumber, string text)
        {
            try
            {
                if (string.IsNullOrEmpty(phoneNumber))
                    throw new Exception("WhatsApp phonenumber not found" + text);

                phoneNumber = phoneNumber.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");

                var phoneAndText = "send?phone=" + phoneNumber + "&text=" + Uri.EscapeDataString(text);

                var supportsUri = await Launcher.CanOpenAsync("whatsapp://");

                if (supportsUri)
                    await Launcher.OpenAsync(new Uri("whatsapp://" + phoneAndText));

                else
                    await Launcher.OpenAsync(new Uri("https://api.whatsapp.com/" + phoneAndText));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
