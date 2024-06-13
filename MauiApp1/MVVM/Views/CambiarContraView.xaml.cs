using MauiApp1.MVVM.ViewModels;

namespace MauiApp1.MVVM.Views;

public partial class CambiarContraView : ContentPage
{
	public CambiarContraView()
	{
		InitializeComponent();
		BindingContext = new CambiarContraViewModel();
	}
}