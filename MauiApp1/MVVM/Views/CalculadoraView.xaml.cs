using MauiApp1.MVVM.ViewModels;

namespace MauiApp1.MVVM.Views;

public partial class CalculadoraView : ContentPage
{
	public CalculadoraView()
	{
		InitializeComponent();
		BindingContext = new CalculadoraViewModel();
	}
}