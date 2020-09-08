using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Binder.Services;
using Binder.Views;

namespace Binder
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;

        public App()
        {
            InitializeComponent();
            ScreenHeight = DeviceDisplay.MainDisplayInfo.Height;
            ScreenWidth = DeviceDisplay.MainDisplayInfo.Width;

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
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
