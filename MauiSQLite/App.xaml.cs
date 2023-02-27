using MauiSQLite.View;

namespace MauiSQLite;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new FirstPage());
	}
}
