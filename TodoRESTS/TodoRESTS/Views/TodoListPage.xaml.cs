using System;
using TodoRESTS.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoRESTS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.TodoManager.GetTaskAsync();
        }
        async void OnAddItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage(true)
            {
                BindingContext = new TodoItem
                {
                    ID =  Guid.NewGuid().ToString()
                }
            });
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TodoItemPage
            {
                BindingContext = e.SelectedItem as TodoItem
            });
        }
    }
}