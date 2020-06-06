using App.CardTools.Controls;
using App.CardTools.Data;
using App.CardTools.Models;
using App.CardTools.Models.Icon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.CardTools.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            ResetProps();

            LoadItemsCommand.Execute(null);
        }

        private void ResetProps()
        {
            ToolsList = new ObservableCollection<ToolMenu>();
            CurrentSelectedTool = new ToolMenu();
            ContentData = new ObservableCollection<View>();
            CurrentStylePage = MenuStyle.GetCombination();
        }

        public Command LoadItemsCommand => new Command(() =>
        {
            try
            {
                IsBusy = true;


                var items = new List<ToolMenu>()
                {
                    DataTools.Connection.SetCommand(new Command(() =>
                    {
                        var isConnection = Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Internet;
                        var text = isConnection? "Online" : "Offline";

                        ContentData.Clear();

                        ContentData.Add(new Label { Text = text, TextColor = Color.White, FontSize = 50, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand});
                    })),
                    DataTools.FlashLight.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        bool flashOn = false;

                        var tap = new TapGestureRecognizer
                        {
                            Command = new Command(async () =>
                            {
                                await RequirePermission(async () =>
                                {
                                    await RequirePermission(async() =>
                                    {
                                        if(!flashOn)
                                            await Flashlight.TurnOnAsync();

                                        else
                                            await Flashlight.TurnOffAsync();

                                        flashOn = !flashOn;

                                    }, new Permissions.Camera());

                                }, new Permissions.Flashlight());
                            })
                        };

                        var button = new CustomFrame
                        {
                            Padding = new Thickness(15),
                            CornerRadius = new CornerRadius(30),
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Margin = new Thickness(15),
                            BackgroundColor = (Color)App.Current.Resources["secondaryColor"],
                            Content = new Label{ Text = !flashOn ? "Turn On" : "Turn Off", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = (Color)App.Current.Resources["secondaryTextColor"]}
                        };
                        button.GestureRecognizers.Add(tap);

                        ContentData.Add(new StackLayout
                        {
                            Children =
                            {
                                button
                            }
                        });
                    })),
                };

                //await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    ToolsList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        });

        public Command ChangeSelectToolCommand => new Command(() =>
        {

            CurrentStylePage = MenuStyle.GetCombination();

            App.Current.Resources["primaryColor"] = CurrentStylePage.PrimaryColor;
            App.Current.Resources["secondaryColor"] = CurrentStylePage.SecondaryColor;
            App.Current.Resources["primaryDarkColor"] = CurrentStylePage.PrimaryDarkColor;
            App.Current.Resources["secondaryDarkColor"] = CurrentStylePage.SecondaryDarkColor;

            if (CurrentSelectedTool.Command != null)
            {
                CurrentSelectedTool.Command.Execute(CurrentSelectedTool.CommandParameter);
            }
        });


        private MenuStyle _currentStylePage;
        public MenuStyle CurrentStylePage
        {
            set { SetProperty(ref _currentStylePage, value); }
            get { return _currentStylePage; }
        }

        private ObservableCollection<View> _contentData;
        public ObservableCollection<View> ContentData
        {
            set { SetProperty(ref _contentData, value); }
            get { return _contentData; }
        }

        private ToolMenu _currentSelectedTool;
        public ToolMenu CurrentSelectedTool
        {
            set { SetProperty(ref _currentSelectedTool, value); }
            get { return _currentSelectedTool; }
        }

        private ObservableCollection<ToolMenu> _toolsList;
        public ObservableCollection<ToolMenu> ToolsList
        {
            set { SetProperty(ref _toolsList, value); }
            get { return _toolsList; }
        }
    }
}
