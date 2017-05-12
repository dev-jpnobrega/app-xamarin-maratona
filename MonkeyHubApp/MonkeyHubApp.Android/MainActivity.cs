using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MonkeyHubApp.Droid
{
    [Activity(Label = "MonkeyHubApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            FormsPlugin.Iconize.Droid.IconControls.Init(ToolbarResource, TabLayoutResource);

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

          //  Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
          //                       .With(new Plugin.Iconize.Fonts.FontAwesomeModule())
          //                       .With(new Plugin.Iconize.Fonts.IoniconsModule())
          //                       .With(new Plugin.Iconize.Fonts.MaterialModule())
          //                       .With(new Plugin.Iconize.Fonts.MeteoconsModule())
          //                       .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
          //                       .With(new Plugin.Iconize.Fonts.TypiconsModule())
          //                       .With(new Plugin.Iconize.Fonts.WeatherIconsModule());


            LoadApplication(new App());
        }
    }
}

