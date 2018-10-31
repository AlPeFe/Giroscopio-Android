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
using Android.Hardware;

namespace GamDroid2._0.Servicios
{
    [Service]
    public class SensorService : Service, ISensorEventListener
    {
        private Sensor mSensorGyroscope;
        private Sensor mSensorAccelerometer;
        private SensorManager mSensorManager;

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {

        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public void OnSensorChanged(SensorEvent e)
        {

            if (e.Sensor.Type == SensorType.Orientation)
            {
                var roll = e.Values[2]; //values[2]: Roll, rotation around the y-axis (-90 to 90) increasing as the device moves clockwise.

                if (roll >= -45 && roll <= 45)
                {
                    Toast.MakeText(this, "grados mas de 45", ToastLength.Long).Show();
                }
            }
            else if (e.Sensor.Type == SensorType.Accelerometer)
            {
                var x = e.Values[0];
                var y = e.Values[1];
                var z = e.Values[2];

                float gX = x / SensorManager.GravityEarth;
                float gY = y / SensorManager.GravityEarth;
                float gZ = z / SensorManager.GravityEarth;

                var gForce = Math.Sqrt(gX * gX + gY * gY + gZ * gZ);

                if (gForce > 5)
                {
                    Toast.MakeText(this, "GForce over 2.7", ToastLength.Long).Show();
                }
            }
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            mSensorManager = (SensorManager)this.GetSystemService(SensorService);
            mSensorAccelerometer = mSensorManager.GetDefaultSensor(SensorType.Accelerometer);
            mSensorGyroscope = mSensorManager.GetDefaultSensor(SensorType.Orientation);

            mSensorManager.RegisterListener(this, mSensorAccelerometer, SensorDelay.Normal);
            mSensorManager.RegisterListener(this, mSensorGyroscope, SensorDelay.Normal);

            return base.OnStartCommand(intent, flags, startId);
        }
    }
}