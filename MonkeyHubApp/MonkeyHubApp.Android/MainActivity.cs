using System;

using Android.App;
using Android.Content.PM;
using Android.OS;

using Gcm.Client;
using MonkeyHubApp.Droid.Services;
using FormsPlugin.Iconize.Droid;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name =
"com.google.android.c2dm.permission.RECEIVE")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
//GET_ACCOUNTS is only needed for android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]

namespace MonkeyHubApp.Droid
{
    [Activity(Label = "MonkeyHubApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static MainActivity instance = null;

        public static MainActivity CurrentActivity
        {
            get
            {
                return instance;
            }
        }
        

        protected override void OnCreate(Bundle bundle)
        {
            instance = this;
           // IconControls.Init(Resource.Id.toolbar, Resource.Id.tabs);
          

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();

            IconControls.Init(Resource.Layout.Toolbar, Resource.Layout.Tabbar);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                                .With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                                .With(new Plugin.Iconize.Fonts.IoniconsModule())
                                .With(new Plugin.Iconize.Fonts.MaterialModule())
                                .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                                .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                                .With(new Plugin.Iconize.Fonts.TypiconsModule())
                                .With(new Plugin.Iconize.Fonts.WeatherIconsModule());


   

           

            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            LoadApplication(new App());

            CheckGcmClient();
        }

        private void CheckGcmClient()
        {
            try
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);

                GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog("There was an error creating the client. Verify theURL.", "Error");
}
            catch (Exception e)
            {
                CreateAndShowDialog(e.Message, "Error");
            }
        }


        private void CreateAndShowDialog(String message, String title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}

