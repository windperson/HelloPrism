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

[assembly: Xamarin.Forms.Dependency(typeof(HelloPrism.Droid.SayHello))]
namespace HelloPrism.Droid
{
    class SayHello : ISayHello
    {
        public string Hello()
        {
            return "Hello Android";
        }
    }
}