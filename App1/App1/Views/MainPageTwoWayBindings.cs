using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Views
{
    internal class MainPageTwoWayBindings : ContentPage
    {
        public MainPageTwoWayBindings()
        {
            Label demoLabel = new Label
            {
                Text = "Hello Forms!",
                HorizontalOptions = LayoutOptions.Center
            };

            Label demoLabelBinding = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            demoLabelBinding.SetBinding(Label.TextProperty, "FirstName");

            Entry demoEntryBinding = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            demoEntryBinding.SetBinding<UserViewModel>(Entry.TextProperty, user => user.FirstName, BindingMode.TwoWay);

            Button demoButton = new Button
            {
                Text = "Tap ME!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            UserViewModel userViewModel = new UserViewModel();

            StackLayout layout = new StackLayout
            {
                Children =
                {
                    demoLabel,
                    demoLabelBinding,
                    demoEntryBinding,
                    demoButton
                },

                BindingContext = userViewModel
            };

            Padding = new Thickness(1, Device.OnPlatform(20, 0, 0), 1, 5);

            Content = layout; 
        }
    }
}
