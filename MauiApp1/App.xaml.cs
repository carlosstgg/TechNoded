using MauiApp1.MVVM;
using MauiApp1.Repositories;
using Microsoft.Maui.Controls;
using SQLite;
using SQLitePCL;
namespace MauiApp1
{
    public partial class App : Application
    {
        public static CustomerRepository CustomerRepo { get; private set; }
        public static CompoRepository CompoRepo { get; private set; }
        public App(CustomerRepository repository, CompoRepository repository2)
        {
            InitializeComponent();

            CustomerRepo = repository;
            CompoRepo = repository2;
            MainPage = new NavigationPage(new MainPage());
            

        }
    }
}
