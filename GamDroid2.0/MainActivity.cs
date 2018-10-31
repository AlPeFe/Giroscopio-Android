using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace GamDroid2._0
{
    [Activity(Label = "GamDroid2._0", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Toolbar _toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(_toolbar);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

