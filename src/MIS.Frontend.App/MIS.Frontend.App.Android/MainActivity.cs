
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using MIS.Frontend.App.DependencyInjection;

namespace MIS.Frontend.App.Droid
{
    [PublicAPI]
    [Activity(Label = "MIS.Frontend.App", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
            IServiceCollection container = new ServiceCollection();
            container.AddXamarin();
            container.AddSingleton<App>();
            var provider = container.BuildServiceProvider();
            var app = provider.GetService<App>();
            this.Window?.AddFlags(WindowManagerFlags.Fullscreen);
            LoadApplication(app);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}