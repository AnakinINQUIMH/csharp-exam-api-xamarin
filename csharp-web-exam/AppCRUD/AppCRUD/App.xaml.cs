using AppCRUD.Helpers;
using AppCRUD.Services;
using AppCRUD.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCRUD
{
    public partial class App : Application
    {
        public IHUDProvider _hud;
        static App _instance;

        public static App Instance
        {
            get
            {
                return _instance;
            }
        }

        public IHUDProvider Hud
        {
            get
            {
                return _hud ?? (_hud = DependencyService.Get<IHUDProvider>());
            }
        }
        public App()
        {
            _instance = this;
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
