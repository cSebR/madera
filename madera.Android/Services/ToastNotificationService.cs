using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using madera.Droid.Services;
using madera.Services;

[assembly: Xamarin.Forms.Dependency(typeof(ToastNotificationService))]
namespace madera.Droid.Services
{
    public class ToastNotificationService : IToastNotificationService
    {
        public void LongToast(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}