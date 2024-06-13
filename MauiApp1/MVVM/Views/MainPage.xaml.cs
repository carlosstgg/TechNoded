using MauiApp1.MVVM.ViewModels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
        

    }

}
