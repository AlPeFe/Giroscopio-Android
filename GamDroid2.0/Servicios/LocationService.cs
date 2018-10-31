using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;

namespace GamDroid2._0.Servicios
{
    [Service]
    [IntentFilter(new string[] { "com.LocationService.GamDroid" })]
    public class LocationService : Service, ILocationListener
    {

        LocationManager _locationManager;
        Location _currentLocation;

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            _locationManager.RequestLocationUpdates(LocationManager.GpsProvider, 0, 0, this);
            _locationManager.RequestLocationUpdates(LocationManager.NetworkProvider, 0, 0, this);

            return base.OnStartCommand(intent, flags, startId);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public void OnLocationChanged(Location location)
        {
            _currentLocation = location;

            if (_currentLocation != null)
            {
                var lat = _currentLocation.Latitude;
                var lon = _currentLocation.Longitude;
            }
        }

        public void OnProviderDisabled(string provider)
        {
            //aqui va si se ha desactivado el gps
        }

        public void OnProviderEnabled(string provider)
        {
            //si se ha desactivado el GPS
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
            
        }

    }
}