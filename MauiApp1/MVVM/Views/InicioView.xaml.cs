using MauiApp1.MVVM.ViewModels;

namespace MauiApp1.MVVM.Views;

public partial class InicioView : ContentPage
{
	public InicioView()
	{
		InitializeComponent();
		BindingContext = new InicioViewModel();
	}
}