using System;
using Repeater.ViewModels;
using Xamarin.Forms;

namespace Repeater.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			var repeater1 = new RepeaterViewModel { RepeatCount = repeater.RepeatCount };
			repeater.ItemsSource = repeater1.RepeatItems;
		}

	    private void Employee_Tapped(object sender, EventArgs e)
	    {
	        var view = sender as View;

	        var employee = view?.BindingContext as string;

	        DisplayAlert("Tap Event", "You have selected " + employee, "Ok");
	    }

	    private void Student_Tapped(object sender, EventArgs e)
	    {
	         
	    }
	}
}
