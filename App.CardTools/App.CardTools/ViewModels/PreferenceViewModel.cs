using App.CardTools.Extention;
using App.CardTools.Models._2___Layout;
using App.CardTools.Services.DeviceApi;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var colorList = MaterialColor.NiceCombinationList;
            NiceThemes = colorList.ToObservableCollection();
        });

        public Command ChangeThemeCommand => new Command(() =>
        {
            if (SelectedTheme == null)
                return;

            PreferenceService.ThemePreference = SelectedTheme.Name;

            App.LoadTheme(SelectedTheme);
        });

        private ObservableCollection<MaterialColor> _niceThemes;
        public ObservableCollection<MaterialColor> NiceThemes
        {
            set { SetProperty(ref _niceThemes, value); }
            get { return _niceThemes; }
        }

        private MaterialColor _selectedTheme;
        public MaterialColor SelectedTheme
        {
            set { SetProperty(ref _selectedTheme, value); }
            get { return _selectedTheme; }
        }
    }
}
