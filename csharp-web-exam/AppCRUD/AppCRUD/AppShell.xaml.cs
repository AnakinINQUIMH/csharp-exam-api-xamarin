using AppCRUD.ViewModels;
using AppCRUD.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppCRUD
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UpdateBirds), typeof(UpdateBirds));
            Routing.RegisterRoute(nameof(ReadListBirds), typeof(ReadListBirds));
        }

    }
}
