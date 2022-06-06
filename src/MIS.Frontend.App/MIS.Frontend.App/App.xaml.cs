using System;
using MIS.Frontend.App.Views;
using Xamarin.Forms.Xaml;

namespace MIS.Frontend.App
{
    public partial class App//: Application
    {
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            MainPage = serviceProvider.GetService<MainPage>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
