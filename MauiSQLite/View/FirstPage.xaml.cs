using MauiSQLite.Viewmodel;

namespace MauiSQLite.View;

public partial class FirstPage : ContentPage
{
	public FirstPage()
	{
		InitializeComponent();

		BindingContext =  new FirstPageViewmodel();
	}
}