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
using App.CardTools.Services.DeviceApi;
using App.CardTools.Extention;
using ZXing.Mobile;

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
                    DataTools.UnitConveter.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var optionSelected = new UnitConverter{ Title = "Unit to Unit" };

                        var resultText = new CustomLabel { HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };

                        var entry = new CustomEntry { Keyboard = Keyboard.Numeric, IsVisible = false };

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


                        var optionSelectedText = new CustomLabel{ HorizontalOptions = LayoutOptions.Center };
                       
                        //double resultConverter = 0;
                        var convertersAvailable = new List<UnitConverter>
                                        {
                                            new UnitConverter{InputText = "Atmospheres", Title = "Atmospheres To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.AtmospheresToPascals(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Celsius", Title = "Celsius To Fahrenheit", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CelsiusToFahrenheit(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Celsius",Title = "Celsius To Kelvin", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CelsiusToKelvin(entryValue).ToString(); })},
                                            //new UnitConverter{Title = "Coordinates To Kilometers", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CoordinatesToKilometers(entryValue).ToString(); })},
                                            //new UnitConverter{Title = "Coordinates To Miles", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.CoordinatesToMiles(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Degrees",Title = "Degrees Per Second To Hertz", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesPerSecondToHertz(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Degrees",Title = "Degrees Per Second To RadiansPerSecond", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesPerSecondToRadiansPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Degrees",Title = "Degrees To Radians", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.DegreesToRadians(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Fahrenheit",Title = "Fahrenheit To Celsius", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.FahrenheitToCelsius(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Hectopascals",Title = "Hectopascals To Kilopascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HectopascalsToKilopascals(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Hectopascals",Title = "Hectopascals To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HectopascalsToPascals(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Hertz",Title = "Hertz To Degrees Per Second", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HertzToDegreesPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Hertz",Title = "Hertz To RadiansPerSecond", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.HertzToRadiansPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "International Feet",Title = "International Feet To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.InternationalFeetToMeters(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Kelvin",Title = "Kelvin To Celsius", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KelvinToCelsius(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Kilograms",Title = "Kilograms To Pounds", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilogramsToPounds(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Kilometers",Title = "Kilometers To Miles", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilometersToMiles(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Kilopascals",Title = "Kilopascals To Hectopascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilopascalsToHectopascals(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Kilopascals",Title = "Kilopascals To Pascals", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.KilopascalsToPascals(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Meters",Title = "Meters To International Feet", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MetersToInternationalFeet(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Meters",Title = "Meters To US Survey Feet", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MetersToUSSurveyFeet(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Miles",Title = "Miles To Kilometers", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MilesToKilometers(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Miles",Title = "Miles To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.MilesToMeters(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Pascals",Title = "Pascals To Atmospheres", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PascalsToAtmospheres(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Pounds",Title = "Pounds To Kilograms", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PoundsToKilograms(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Pounds",Title = "Pounds To Stones", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.PoundsToStones(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Radians",Title = "Radians Per Second To Degrees Per Second", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansPerSecondToDegreesPerSecond(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Radians",Title = "Radians Per Second To Hertz", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansPerSecondToHertz(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Radians",Title = "Radians To Degrees", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.RadiansToDegrees(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "Stones",Title = "Stones To Pounds", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.StonesToPounds(entryValue).ToString(); })},
                                            new UnitConverter{InputText = "US Survey Feet",Title = "US Survey Feet To Meters", Command = new Command<double>((entryValue) =>{ resultText.Text = UnitConverters.USSurveyFeetToMeters(entryValue).ToString(); })},
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
                                        entry.IsVisible = true;
                                        entry.Placeholder = optionSelected.PlaceholderPresentation;
                                        entry.Text = "";
                                    })
                                };


                        ContentData.Add(new StackLayout
                        {
                            Spacing = 15,
                            Padding = new Thickness(15),
                            Children =
                            {
                                optionsButton,
                                optionSelectedText,
                                entry,
                                resultText
                            }
                        });
                    })),
                    DataTools.MyDeviceInfo.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        ContentData.Add(new ScrollView
                        {
                            Content = new StackLayout
                            {
                                Padding = new Thickness(15),
                                Children =
                                {
                                    new CustomLabel
                                    {
                                        Text = "Model:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceInfo.Model
                                    },
                                    new CustomLabel
                                    {
                                        Margin = new Thickness(0,10,0,0),
                                        Text = "Manufacturer:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceInfo.Manufacturer
                                    },
                                    new CustomLabel
                                    {
                                        Margin = new Thickness(0,10,0,0),
                                        Text = "Name:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceInfo.Name
                                    },
                                    new CustomLabel
                                    {
                                        Margin = new Thickness(0,10,0,0),
                                        Text = "Operating System Version:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceInfo.VersionString
                                    },
                                    new CustomLabel
                                    {
                                        Margin = new Thickness(0,10,0,0),
                                        Text = "Platform:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceInfo.Platform == DevicePlatform.Android ? "Android" : DeviceInfo.Platform == DevicePlatform.iOS ? "iOS" : DeviceInfo.Platform == DevicePlatform.Tizen ? "Tizen" : DeviceInfo.Platform == DevicePlatform.tvOS ? "tvOS" : "Undefined"
                                    },
                                    new CustomLabel
                                    {
                                        Margin = new Thickness(0,10,0,0),
                                        Text = "Display:",
                                        FontAttributes = FontAttributes.Bold
                                    },
                                    new CustomLabel
                                    {
                                        Text = DeviceDisplay.MainDisplayInfo.ToString()
                                    }
                                }
                            }
                        });
                    })),
                    DataTools.SendWhatsAppMessage.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var number = new CustomEntry{ Keyboard = Keyboard.Telephone};
                        var message = new CustomEntry{Keyboard = Keyboard.Text, Placeholder = "Hello!"};
                        var button = new CustomFrameButton
                        {
                            TextButton = "Send to WhatsApp",
                            TapButtonCommand = new Command(async () =>
                            {
                                await WhatsApp.SendMessage(number.Text, message.Text);
                            })
                        };

                        ContentData.Add(new StackLayout
                        {
                            Padding = new Thickness(15),
                            Children =
                            {
                                new CustomLabel
                                {
                                    Text = "Number: "

                                },
                                number,
                                new CustomLabel
                                {
                                    Text = "Message: "
                                },
                                message,
                                button

                            }
                        });
                    })),
                    DataTools.MyGeolocation.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var options = new List<string>
                        {
                            GeolocationAccuracy.Default.ToString(),
                            GeolocationAccuracy.Lowest.ToString(),
                            GeolocationAccuracy.Low.ToString(),
                            GeolocationAccuracy.Medium.ToString(),
                            GeolocationAccuracy.High.ToString(),
                            GeolocationAccuracy.Best.ToString(),
                        };

                        var result = new CustomLabel{ };

                        var load = new StackLayoutLoad();

                        var button = new CustomFrameButton
                        {
                            TextButton = "Selected Precision",
                            TapButtonCommand = new Command(async () =>
                            {
                                var precision = await App.Current.MainPage.DisplayActionSheet("Selected Precision", "Cancel", "", options.ToArray());

                                try
                                {
                                    load.IsVisible = true;

                                    Enum.TryParse<GeolocationAccuracy>(precision, out GeolocationAccuracy selectedOption);

                                    var location = await LocationService.GetLastLocationAsync(selectedOption);

                                    if(location != null)
                                    {
                                        result.Text = $"Precision:  {precision} \n" +
                                                      $"Latitude:   {location.Latitude} \n" +
                                                      $"Latitude:   {location.Longitude} \n";

                                        if(location.Altitude.HasValue)
                                            result.Text += "Altitude: " + location.Altitude + "\n";

                                        if(location.Speed.HasValue)
                                            result.Text += "Speed in meter per secound: " + location.Speed + "\n";

                                        if(location.Accuracy.HasValue)
                                            result.Text += "Horizontal accuracy (meter): " + location.Accuracy + "\n";

                                        if(location.VerticalAccuracy.HasValue)
                                            result.Text += "Vertical accuracy (meter): " + location.VerticalAccuracy + "\n";

                                        result.Text += "Timestamp: " + location.Accuracy;
                                    }

                                    var placemark = await LocationService.GetPlacemarksAsync(location);

                                    if (placemark != null)
                                    {
                                        result.Text += "\n\n" +
                                            $"AdminArea:       {placemark.AdminArea}\n" +
                                            $"CountryCode:     {placemark.CountryCode}\n" +
                                            $"CountryName:     {placemark.CountryName}\n" +
                                            $"FeatureName:     {placemark.FeatureName}\n" +
                                            $"Locality:        {placemark.Locality}\n" +
                                            $"PostalCode:      {placemark.PostalCode}\n" +
                                            $"SubAdminArea:    {placemark.SubAdminArea}\n" +
                                            $"SubLocality:     {placemark.SubLocality}\n" +
                                            $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                                            $"Thoroughfare:    {placemark.Thoroughfare}\n";
                                    }
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                                finally
                                {
                                    load.IsVisible = false;
                                }
                            })
                        };

                        var main = new StackLayout
                        {
                            Padding = new Thickness(15),
                            Children =
                            {
                                button,
                                result.SetOnScrollView()
                            }
                        }
                        .SetLoad(load);

                        ContentData.Add(main);
                    })),
                    DataTools.Magnometer.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var options = new List<string>
                        {
                            SensorSpeed.Default.ToString(),
                            SensorSpeed.UI.ToString(),
                            SensorSpeed.Fastest.ToString(),
                            SensorSpeed.Game.ToString()
                        };

                        var result = new CustomLabel{ };

                        var load = new StackLayoutLoad();

                        var button = new CustomFrameButton
                        {
                            TextButton = "Selected Sensitivity Type",
                            TapButtonCommand = new Command(async () =>
                            {
                                var precision = await App.Current.MainPage.DisplayActionSheet("Selected Sensitivity Type", "Cancel", "", options.ToArray());

                                try
                                {
                                    load.IsVisible = true;

                                    Enum.TryParse<SensorSpeed>(precision, out SensorSpeed selectedOption);

                                    if (Magnetometer.IsMonitoring)
                                        Magnetometer.Stop();

                                    Magnetometer.Start(selectedOption);

                                    Magnetometer.ReadingChanged += (object sender, MagnetometerChangedEventArgs e) =>
                                    {
                                        var data = e.Reading;

                                        result.Text =
                                            precision +" sensor Reading: \n"+
                                            $"X:       {data.MagneticField.X}\n" +
                                            $"Y:       {data.MagneticField.Y}\n" +
                                            $"Z:       {data.MagneticField.Z}";
                                    };
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                finally
                                {
                                    load.IsVisible = false;
                                }
                            })
                        };

                        var main = new StackLayout
                        {
                            Padding = new Thickness(15),
                            Children =
                            {
                                button,
                                result
                            }
                        }
                        .SetLoad(load);

                        ContentData.Add(main.SetOnScrollView());
                    })),
                    DataTools.TextToSpeech.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var text = new CustomEditor{ VerticalOptions = LayoutOptions.FillAndExpand, Placeholder = "Enter text to speak" };

                        var pitchValue = new CustomLabel { Text = "Pitch: " };
                        var volumeValue = new CustomLabel { Text = "Volume: "};

                        var pitch = new CustomSlider
                        {
                            Minimum = 0,
                            Maximum = 2.0,
                            Value = 1.0
                        };

                        pitchValue.Text += pitch.Value;

                        pitch.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                        {
                            pitchValue.Text = "Pitch: " + e.NewValue.ToString();
                        };

                        var volume = new CustomSlider
                        {
                            Minimum = 0,
                            Maximum = 1.0,
                            Value = 0.5
                        };

                        volumeValue.Text += volume.Value;

                        volume.ValueChanged += (object sender, ValueChangedEventArgs e) =>
                        {
                            volumeValue.Text = "Volume: " + e.NewValue.ToString();
                        };

                        var button = new CustomFrameButton
                        {
                            VerticalOptions = LayoutOptions.EndAndExpand,
                            TextButton = "Speak",
                            TapButtonCommand = new Command(async () =>
                            {
                                if(string.IsNullOrEmpty(text?.Text))
                                    return;

                                await TextToSpeech.SpeakAsync(text.Text, new SpeechOptions
                                {
                                    Pitch = float.Parse(pitch.Value.ToString()),
                                    Volume = float.Parse(volume.Value.ToString())
                                });
                            })
                        };

                        ContentData.Add(new StackLayout
                        {
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            Padding = new Thickness(15),
                            Children =
                            {
                                text,
                                pitchValue,
                                pitch,
                                volumeValue,
                                volume,
                                button
                            }
                        });
                    })),
                    DataTools.BarcodeReader.SetCommand(new Command(() =>
                    {
                        ContentData.Clear();

                        var result = new CustomLabel();

                        var button = new CustomFrameButton
                        {
                            TapButtonCommand = new Command(async () =>
                            {

                                await RequirePermission(async () =>
                                {
                                    await RequirePermission(async() =>
                                    {
                                        var scanner = DependencyService.Get<IQrCodeScanningService>();
                                        var resultScan = await scanner.ScanAsync(new MobileBarcodeScanner
                                        {
                                            TopText = "Centralized on code",
                                            BottomText = "Tap to focus",
                                            CameraUnsupportedMessage = "Your camera don't support",
                                            FlashButtonText = "Turn on flash",
                                            CancelButtonText = "Cancel"
                                        });

                                        result.Text = "Result: \n"+ resultScan;

                                    }, new Permissions.Camera());

                                }, new Permissions.Flashlight());


                            }),
                            TextButton = "Scan Code"
                        };

                        ContentData.Add(new StackLayout
                        {
                            Padding = new Thickness(15),
                            Children =
                            {
                                button,
                                result,
                            }
                        });
                    }))

                };

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
