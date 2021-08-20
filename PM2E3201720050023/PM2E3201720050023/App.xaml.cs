﻿using PM2E3201720050023.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E3201720050023
{
    public partial class App : Application
    {
        public static string UBICACIONDB = string.Empty;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string dblocal)
        {

            InitializeComponent();
            UBICACIONDB = dblocal;
            MainPage = new NavigationPage(new MainPage());

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
