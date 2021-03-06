﻿using System;
using Android.App;
using Android.Runtime;
using ConferenceApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Plugin.CurrentActivity;

namespace ConferenceApp.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CrossCurrentActivity.Current.Init(this);

            Shiny.AndroidShinyHost.Init(this, new Startup(), builder =>
            {
                //TODO: register Android specific dependencies here
            });
        }
    }
}
