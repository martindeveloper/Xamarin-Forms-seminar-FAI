using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Views
{
    internal class MainPage : ContentPage
    {
        public MainPage()
        {
            Label demoLabel = new Label
            {
                Text = "Hello Forms!",
                HorizontalOptions = LayoutOptions.Center
            };

            Button demoButton = new Button
            {
                Text = "Tap ME!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            demoButton.Clicked += async (object target, EventArgs args) => {
                bool answer = await DisplayAlert("Magic", "Ta daaa", "Like it", "Nope");

                if (answer)
                {
                    // True
                }
                else
                {
                    // False
                }
            };

            StackLayout layout = new StackLayout
            {
                Children =
                {
                    demoLabel,
                    demoButton,
                }
            };

            Padding = new Thickness(1, Device.OnPlatform(20, 0, 0), 1, 5);

            Content = layout; 
        }
    }
}
