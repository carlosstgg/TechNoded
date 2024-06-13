using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.Views;
using System;
using System.Windows.Input;
namespace MauiApp1.MVVM.ViewModels;

public class LoginViewModel : BaseViewModel
{
    
    
    private Person currentPerson;

    public List<Person> Persons { get; set; }
    public Person CurrentPerson
    {
        get => currentPerson;
        set
        {
            currentPerson = value;
            OnPropertyChanged(); // Notifica a la vista que la propiedad ha cambiado
        }
    }
    private string _correoIngresado;
    public string CorreoIngresado
    {
        get { return _correoIngresado; }
        set
        {
            _correoIngresado = value;
            OnPropertyChanged(); // Notifica a la vista que la propiedad ha cambiado
        }
    }

    private string _contrasenaIngresada;
    public string ContrasenaIngresada
    {
        get { return _contrasenaIngresada; }
        set
        {
            _contrasenaIngresada = value;
            OnPropertyChanged(); // Notifica a la vista que la propiedad ha cambiado
        }
    }

    

    public ICommand SesionCommand => new Command(ValidarSesion);
    public ICommand CrearCuenta => new Command(NuevaCuenta);
    public ICommand CambiarContraCommand => new Command(async () => await CambiarContra());

    

    private async Task CambiarContra()
    {
        await Application.Current.MainPage.Navigation.PushAsync(new CambiarContraView());
    }
    private async void Refresh()
    {
        Persons = App.CustomerRepo.GetAll();
    }
    public LoginViewModel()
    {
        
        Refresh();

        // Inicializar propiedades
        CorreoIngresado = "";
        ContrasenaIngresada = "";
    }
    public async void NuevaCuenta()
    {
        Application.Current.MainPage.Navigation.PushAsync(new CrearCuentaView());
    }
    public async void ValidarSesion()
    {
        Refresh();
        
        var person = Persons.FirstOrDefault(p => p.Correo == CorreoIngresado && p.Contrasena == ContrasenaIngresada);

        if (person != null)
        {
            
            await Application.Current.MainPage.Navigation.PushAsync(new InicioView());
        }
        else
        {
            
            await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
        }
    }

}
