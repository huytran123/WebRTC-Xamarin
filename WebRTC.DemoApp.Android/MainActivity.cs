﻿


using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;

using WebRTC.DemoApp.Droid.Helpers.WebRTC.DemoApp.iOS.Helpers;

namespace WebRTC.DemoApp.Droid
{
    [Activity(Label = "WebRTC.DemoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MainActivity Instance { get; private set; }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            Window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.KeepScreenOn | WindowManagerFlags.ShowWhenLocked | WindowManagerFlags.TurnScreenOn);
            Window.DecorView.SystemUiVisibility = GetSystemUiVisibility();


            base.OnCreate(savedInstanceState);

            Instance = this;

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);           

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            WebRTCPlatform.Init(this);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #region HelperFunctions

        private StatusBarVisibility GetSystemUiVisibility()
        {
            var flags = SystemUiFlags.HideNavigation | SystemUiFlags.Fullscreen;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
                flags = SystemUiFlags.ImmersiveSticky;
            return (StatusBarVisibility)flags;
        }

        #endregion
    }
}