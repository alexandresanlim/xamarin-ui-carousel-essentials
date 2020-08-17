//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using App.CardTools.Models._1___Interface;
//using Xamarin.Forms;
//using ZXing.Mobile;

//[assembly: Dependency(typeof(App.CardTools.Droid.Services.QrCodeScanningService))]
//namespace App.CardTools.Droid.Services
//{
//    public class QrCodeScanningService : IQrCodeScanningService
//    {
//        public async Task<string> ScanAsync(MobileBarcodeScannerBase scanner)
//        {
//            var scanResults = await scanner.Scan();

//            return (scanResults != null) ? scanResults.Text : string.Empty;
//        }

//        public async Task<string> ScanAsync(MobileBarcodeScannerBase scanner, MobileBarcodeScanningOptions options)
//        {
//            var scanResults = await scanner.Scan(options);

//            return (scanResults != null) ? scanResults.Text : string.Empty;
//        }
//    }

//}