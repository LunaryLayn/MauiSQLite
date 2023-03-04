using MauiSQLite.Viewmodel;
namespace MauiSQLite.View;

public partial class ThirdPage : ContentPage
{
	public ThirdPage(Model.Hechizo hechizoSeleccionado)
	{
		InitializeComponent();

        BindingContext = new ThirdPageViewmodel(hechizoSeleccionado);
    }
}