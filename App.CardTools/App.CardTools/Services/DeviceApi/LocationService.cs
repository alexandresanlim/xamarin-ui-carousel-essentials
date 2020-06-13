using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace App.CardTools.Services.DeviceApi
{
    public abstract class LocationService
    {
        //public static Core.Data.DataModels.Address CurrentAddress { get; set; }

        public static async Task<Location> GetLastLocationAsync(GeolocationAccuracy geolocationAccuracy = GeolocationAccuracy.Medium, TimeSpan? timeOutParameter = null)
        {
            var location = new Location();

            var timeOut = timeOutParameter ?? new TimeSpan(0, 0, 15);

            //var hasPermission = await PermissionService.CheckPermission(Plugin.Permissions.Abstractions.Permission.Location);

            //if (hasPermission)
            //{

            await PermissionService.RequirePermissionToExecute(async () =>
            {
                var request = new GeolocationRequest(geolocationAccuracy, timeOut);

                location =
                    await Geolocation.GetLocationAsync(request) ??
                    await Geolocation.GetLastKnownLocationAsync();

            }, new Permissions.LocationWhenInUse());
            //}

            return location;
        }

        public static async Task<Location> GetLocationByFullAddress(string fullAddress)
        {
            var locations = await Geocoding.GetLocationsAsync(fullAddress);

            var firstLocation = locations?.FirstOrDefault();

            return firstLocation;
        }

        public static async Task<Placemark> GetPlacemarksAsync(Location location)
        {
            var locations = await Geocoding.GetPlacemarksAsync(location);

            var firstLocation = locations?.FirstOrDefault();

            return firstLocation;
        }

        public static double CalculateDistance(double latitudeStart, double longitudeStart, double latitudeEnd, double longitudeEnd, DistanceUnits units = DistanceUnits.Kilometers)
        {
            var distance = Location.CalculateDistance(latitudeStart, longitudeStart, latitudeEnd, longitudeStart, units);

            return distance;
        }
    }
}
