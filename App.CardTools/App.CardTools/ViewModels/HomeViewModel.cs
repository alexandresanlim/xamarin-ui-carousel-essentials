using App.CardTools.Controls;
using App.CardTools.Data;
using App.CardTools.Models;
using App.CardTools.Models._1___Interface;
using App.CardTools.Models.Icon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

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

                        var button = new CustomFrameButton
                        {
                            TextButton = "Turn On",
                            TapButtonCommand = new Command(async () =>
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
                        //button.GestureRecognizers.Add(tap);

                        ContentData.Add(new StackLayout
                        {
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            Padding = new Thickness(30),
                            Children =
                            {
                                button
                            }
                        });
                    })),
                    DataTools.UnitConveter.SetCommand(new Command(async () =>
                    {
                        ContentData.Clear();

                        //var gridValues = new Grid();
                        //gridValues.ColumnDefinitions.Add(new ColumnDefinition{ Width = GridLength.Star});
                        //gridValues.ColumnDefinitions.Add(new ColumnDefinition{ Width = GridLength.Auto});
                        //gridValues.ColumnDefinitions.Add(new ColumnDefinition{ Width = GridLength.Star});

                        //gridValues.Children.Add(new Entry(),0,0);
                        //gridValues.Children.Add(new Entry(),2,0);

                         var optionSelected = new UnitConverter{ Title = "Unit to Unit" };
                         var resultText = new CustomLabel { VerticalOptions = LayoutOptions.Center };

                        var entry = new CustomEntry { Keyboard = Keyboard.Numeric };
                        entry.TextChanged +=(object sender, TextChangedEventArgs e) =>
                        {
                            if(string.IsNullOrEmpty(e?.NewTextValue))
                            {
                                resultText.Text = "0";
                                return;
                            }

                            var value = Convert.ToDouble(e.NewTextValue);

                            optionSelected.Command.Execute(value);
                        };


                        var optionSelectedText = new CustomLabel();
                       
                        //double resultConverter = 0;
                        var convertersAvailable = new List<UnitConverter>
                                        {
                                            new UnitConverter{Title = "Atmospheres To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.AtmospheresToPascals(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Celsius To Fahrenheit", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CelsiusToFahrenheit(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Celsius To Kelvin", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CelsiusToKelvin(entryValue).ToString(); })},
                                            //new UnitConverter{Title = "Coordinates To Kilometers", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CoordinatesToKilometers(entryValue).ToString(); })},
                                            //new UnitConverter{Title = "Coordinates To Miles", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CoordinatesToMiles(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Degrees Per Second To Hertz", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesPerSecondToHertz(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Degrees Per Second To RadiansPerSecond", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesPerSecondToRadiansPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Degrees To Radians", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesToRadians(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Fahrenheit To Celsius", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.FahrenheitToCelsius(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Hectopascals To Kilopascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HectopascalsToKilopascals(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Hectopascals To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HectopascalsToPascals(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Hertz To Degrees Per Second", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HertzToDegreesPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Hertz To RadiansPerSecond", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HertzToRadiansPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{Title = "International Feet To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.InternationalFeetToMeters(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Kelvin To Celsius", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KelvinToCelsius(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Kilograms To Pounds", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilogramsToPounds(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Kilometers To Miles", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilometersToMiles(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Kilopascals To Hectopascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilopascalsToHectopascals(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Kilopascals To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilopascalsToPascals(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Meters To International Feet", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MetersToInternationalFeet(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Meters To US Survey Feet", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MetersToUSSurveyFeet(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Miles To Kilometers", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MilesToKilometers(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Miles To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MilesToMeters(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Pascals To Atmospheres", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PascalsToAtmospheres(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Pounds To Kilograms", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PoundsToKilograms(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Pounds To Stones", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PoundsToStones(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Radians Per Second To Degrees Per Second", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansPerSecondToDegreesPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Radians Per Second To Hertz", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansPerSecondToHertz(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Radians To Degrees", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansToDegrees(entryValue).ToString(); })},
                                            new UnitConverter{Title = "Stones To Pounds", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.StonesToPounds(entryValue).ToString(); })},
                                            new UnitConverter{Title = "US Survey Feet To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.USSurveyFeetToMeters(entryValue).ToString(); })},
                                        };


                        var optionsButton = new CustomFrameButton
                                {
                                    TextButton = "Selected an option",
                                    TapButtonCommand = new Command(async () =>
                                    {
                                        var o = await App.Current.MainPage.DisplayActionSheet("Select an option", "Cancel", "", convertersAvailable.Select(x => x.Title).ToArray());

                                        if(o.Equals("Cancel"))
                                            return;

                                        optionSelected = convertersAvailable.FirstOrDefault(x => x.Title.Equals(o));
                                        optionSelectedText.Text = o;
                                        entry.Placeholder = o;
                                    })
                                };


                        ContentData.Add(new StackLayout
                        {
                            Padding = new Thickness(15),
                            Children =
                            {
                                optionsButton,
                                 optionSelectedText,
                                        entry,
                                        resultText
                                //new StackLayout
                                //{
                                //    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                //    VerticalOptions = LayoutOptions.CenterAndExpand,
                                //    Children =
                                //    {
                                       
                                //    }
                                //}
                            }
                        });
                    }))
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
            App.Current.Resources["primaryTextColor"] = CurrentStylePage.PrimaryTextColor;
            App.Current.Resources["secondaryTextColor"] = CurrentStylePage.SecondaryTextColor;

            var service = DependencyService.Get<IStatusBar>();
            service?.SetStatusBarColor(CurrentStylePage.PrimaryDarkColor);


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
