using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace App.CardTools.Services.DeviceApi
{
    public static class PreferenceService
    {

        public static string ThemePreference
        {
            get => Preferences.Get(nameof(ThemePreference), "");
            set
            {
                if (ThemePreference == value)
                    return;

                Preferences.Set(nameof(ThemePreference), value);
                //RaisePropertyChanged(nameof(IsActive));
            }
        }
    }
}
