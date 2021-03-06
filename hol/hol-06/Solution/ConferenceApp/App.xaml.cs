﻿using System;
using AsyncAwaitBestPractices;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace ConferenceApp
{
    public partial class App : Application
    {
        public const string AppLinkBaseUri = "https://conferenceapp-demo.azurewebsites.net";

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // DI registration is done in the Startup class
            AppCenter.Start("android=02573986-d693-493d-b2eb-069d0a50264f;" +
                  "ios=8700101a-157b-4ff8-8b84-9dac6ec14e58;", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            // need to prefix the uri with "/" so that the root becomes "//"
            var appShellUri = "/" + uri.PathAndQuery;
            Shell.Current.GoToAsync(appShellUri, animate: true)
                .SafeFireAndForget(onException: ex =>
                {
                    Console.WriteLine($"An error occurred while navigating to deeplink: {appShellUri}, {ex}");
                });

            base.OnAppLinkRequestReceived(uri);
        }
    }
}
