using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.ViewModels;

namespace App1.Views
{
    internal class TodoPage : ContentPage
    {
        private Label TitleLabel;
        private Entry NewTaskEntry;
        private Button AddTaskButton;
        private Button ClearTasksButton;
        private ListView TodoListView;
        private TodoViewModel ViewModel = new TodoViewModel();

        public TodoPage()
        {
            TitleLabel = new Label
            {
                Text = "TODO list",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            NewTaskEntry = new Entry
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

			// Add two-way binding to TodoViewModel.NewTaskDraft
            NewTaskEntry.SetBinding<TodoViewModel>(Entry.TextProperty, model => model.NewTaskDraft, BindingMode.TwoWay);

            AddTaskButton = new Button
            {
                Text = "Add",
            };

            AddTaskButton.Clicked += (object target, EventArgs args) =>
            {
                ViewModel.AddTask();
            };

            ClearTasksButton = new Button
            {
                Text = "Clear all tasks",
                Font = Font.SystemFontOfSize(NamedSize.Large)
            };

            ClearTasksButton.Clicked += async (object target, EventArgs args) =>
            {
                bool answer = await DisplayAlert("Warning", "This action will clear ALL tasks. Are you sure?", "Yes", "No");

                if (answer)
                {
                    ViewModel.ClearAllTasks();
                }
            };

            TodoListView = new ListView
            {
                RowHeight = 40,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

			// Add two-way binding to TodoViewModel.Tasks which is list of strings
			// Whole ListView can be also filled using ObservableCollection, but purpose of this demo is two-way data binding
            TodoListView.SetBinding<TodoViewModel>(ListView.ItemsSourceProperty, model => model.Tasks, BindingMode.OneWay);

            TodoListView.ItemTapped += async (object target, ItemTappedEventArgs args) =>
            {
                bool answer = await DisplayAlert("Done", "Delete this task?", "Yes", "No");

                if (answer)
                {
                    ViewModel.DeleteTask((string)args.Item);
                }
            };

            StackLayout layout = new StackLayout
            {
                Children =
                {
                    TitleLabel,
                    NewTaskEntry,
                    AddTaskButton,
                    TodoListView,
                    ClearTasksButton
                },

				// Set binding context for layout, also can be set for whole page
                BindingContext = ViewModel
            };

            Padding = new Thickness(1, Device.OnPlatform(20, 0, 0), 1, 5);

            Content = layout;
        }
    }
}
