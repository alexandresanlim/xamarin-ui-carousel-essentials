using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using App.CardTools.Models._1___Interface;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App.CardTools.Droid
{
    [Activity(Label = "App.CardTools", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //MobileBarcodeScanner.Initialize(this.Application);
            LoadApplication(new App());

            DependencyService.Register<IStatusBar, StatusBarChanger>();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public class StatusBarChanger : IStatusBar
        {
            public void SetStatusBarColor(System.Drawing.Color color)
            {
                if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                    return;

                var window = ((MainActivity)Forms.Context).Window;
                window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
                window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
                var androidColor = color.ToPlatformColor();

                window.SetStatusBarColor(androidColor);
            }
        }
    }
}