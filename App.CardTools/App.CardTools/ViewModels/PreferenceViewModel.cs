using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App.CardTools.ViewModels
{
    public class PreferenceViewModel : BaseViewModel
    {
        public PreferenceViewModel()
        {
            LoadThemesCommand.Execute(null);
        }

        public Command LoadThemesCommand => new Command(() =>
        {

        });
    }
}
