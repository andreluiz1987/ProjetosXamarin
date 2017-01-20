using System;
using System.Collections.Generic;
using System.Linq;
using TutorialDepService.Interface;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Locations;
using System.Threading.Tasks;
using TutorialDepService.Model;

using TutorialDepService.Droid.Library;

[assembly: Xamarin.Forms.Dependency(typeof(GpsDroid))]

namespace TutorialDepService.Droid.Library
{
    class GpsDroid : Java.Lang.Object, ILocationListener, IGps
    {
        public bool IsAvaliable = false;
        public EventHandler Geoposition;
        public Coordinate objCoordinate = new Coordinate();

        public void Initialize()
        {
            string strLocationProvider;
            LocationManager objLocationManager;

            try
            {
                objLocationManager = (LocationManager) Application.Context.GetSystemService(Context.LocationService);

                Criteria CriteriaForLocationService = new Criteria() { Accuracy = Accuracy.Fine, PowerRequirement = Power.NoRequirement };

                IList<string> AcceptableLocationProviders = objLocationManager.GetProviders(CriteriaForLocationService, true);

                strLocationProvider = (AcceptableLocationProviders.Any()) ? AcceptableLocationProviders.First() : string.Empty;

                objLocationManager.RequestLocationUpdates(strLocationProvider, 1000, 0, this);

                IsAvaliable = true;
            }
            catch (Exception ex)
            {
                IsAvaliable = false;
            }
        }

        public async Task<Coordinate> GetPosition()
        {
            EventHandler evPosition = null;
            var objTaskCompletionSource = new TaskCompletionSource<Coordinate>();

            if (!IsAvaliable) { Initialize(); }

            if (evPosition == null)
            {
                evPosition = (s, e) =>
                {
                    objTaskCompletionSource.TrySetResult((Coordinate)s);
                };
                Geoposition += evPosition;
            }

            return await objTaskCompletionSource.Task.ConfigureAwait(false);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnLocationChanged(Location location)
        {
            if (location != null)
            {
                objCoordinate.Latitude = location.Latitude;
                objCoordinate.Longitude = location.Longitude;

                Geoposition(objCoordinate, new EventArgs());
            }
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}