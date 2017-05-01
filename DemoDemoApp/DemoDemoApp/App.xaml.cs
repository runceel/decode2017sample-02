using DemoDemoApp.Views;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoDemoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Xamarin.Forms.Device.OnPlatform<string>("tab_feed.png",null,null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Xamarin.Forms.Device.OnPlatform<string>("tab_about.png",null,null)
                    },
                }
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            try
            {
                MobileCenter.Start("ios=8cef8dda-c9a4-48a2-be55-a88946aa73c9;" +
                       "android=17df10dd-34f3-44d6-ae48-0d89f070793a",
                    typeof(Analytics),
                    typeof(Crashes));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }
    }
}
