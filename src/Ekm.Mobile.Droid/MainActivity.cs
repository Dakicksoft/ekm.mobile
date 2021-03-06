﻿using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Ekm.Mobile.Droid
{
    [Activity(Label = "@string/ApplicationName",
              Icon = "@mipmap/ic_launcher",
              Theme = "@style/MyTheme",
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            InitRenderersAndServices(savedInstanceState);


            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            global::ZXing.Net.Mobile
                      .Android
                      .PermissionsHandler
                      .OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void InitRenderersAndServices(Bundle savedInstanceState)
        {
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(Application);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            SQLitePCL.Batteries_V2.Init();

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            XF.Material.Droid.Material.Init(this, savedInstanceState);
            global::FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            global::FFImageLoading.ImageService.Instance.Initialize();
            Lottie.Forms.Droid.AnimationViewRenderer.Init();
            //SQLitePCL.raw.FreezeProvider();
            UserDialogs.Init(this);
            global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
        }
    }
}
