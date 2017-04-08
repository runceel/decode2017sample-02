using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDemoApp.Services
{
    public static class MobileCenterHolder
    {
        public static IMobileServiceClient Client { get; } = new MobileServiceClient("https://mobile-1b97eace-9367-4996-b1ed-eb2222dce5cf.azurewebsites.net/");
    }
}
