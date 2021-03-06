﻿using DemoDemoApp.Services;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoDemoApp.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() =>
            {
                string name = null;
                name.ToLower();
            });

            LoginCommand = new Command(async () =>
            {
                try
                {
#if __ANDROID__
                    await MobileCenterHolder.Client.LoginAsync(
                        Forms.Context,
                        MobileServiceAuthenticationProvider.Twitter);
#elif __IOS__
                    await MobileCenterHolder.Client.LoginAsync(
                        UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController,
                        MobileServiceAuthenticationProvider.Twitter);
#elif WINDOWS_UWP
                    await MobileCenterHolder.Client.LoginAsync(
                        MobileServiceAuthenticationProvider.Twitter);
#endif
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });
		}

		/// <summary>
		/// Command to open browser to xamarin.com
		/// </summary>
		public ICommand OpenWebCommand { get; }

        public ICommand LoginCommand { get; }
	}
}
