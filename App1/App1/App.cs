using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using App1.Views;

namespace App1
{
    public class App
    {
        public static Page GetMainPage()
        {
            // Demo 1
            //return new MainPage();

            // Demo 2
            //return new MainPageTwoWayBindings();

            // Demo 3
            return new TodoPage();

            // Demo 4
            //return new AnimationsPage();
        }
    }
}
