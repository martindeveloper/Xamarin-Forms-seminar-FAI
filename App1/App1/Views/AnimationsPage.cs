using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace App1.Views
{
    class AnimationsPage : ContentPage
    {
        public AnimationsPage()
        {
            BoxView boxView = new BoxView
            {
                Color = Color.Accent,
                WidthRequest = 150,
                HeightRequest = 150,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Button animateButton = new Button
            {
                Text = "Animate!"
            };

            animateButton.Clicked += async (object target, EventArgs args) =>
            {
                animateButton.IsEnabled = false;

                UInt16 time = 750;

                List<Task> tasks = new List<Task>();
                tasks.Add(boxView.ScaleTo(2.0f, time));
                tasks.Add(boxView.RotateTo(30.0f, time));
                tasks.Add(boxView.FadeTo(.5f, time));

                await Task.WhenAll(tasks);

                tasks.Clear();
                tasks.Add(boxView.ScaleTo(1.0f, time));
                tasks.Add(boxView.RotateTo(0.0f, time));
                tasks.Add(boxView.FadeTo(1.0f, time));

                await Task.WhenAll(tasks);

                animateButton.IsEnabled = true;
            };

            Content = new StackLayout
            {
                Children = 
                {
                    boxView,
                    animateButton
                }
            };
        }
    }
}
