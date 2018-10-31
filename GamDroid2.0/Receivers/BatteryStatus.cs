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
using Android.Net.Wifi;

namespace GamDroid2._0.Receivers
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new [] { Intent.ActionPowerConnected, Intent.ActionPowerDisconnected })]
    public class BatteryStatus : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {          
            if(intent.Action == Intent.ActionPowerConnected)
            {
                Toast.MakeText(context, "Connected", ToastLength.Short).Show();
            
            }else if(intent.Action == Intent.ActionPowerConnected)
            {
                Toast.MakeText(context, "Disconnected", ToastLength.Short).Show();
            }         
        }
    }
}