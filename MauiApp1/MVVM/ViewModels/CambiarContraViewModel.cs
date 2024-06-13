using MauiApp1.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.MVVM.ViewModels
{
    public class CambiarContraViewModel : BaseViewModel
    {
        private string correo;
        private string contrasenaActual;
        private string nuevaContrasena;
        private string confirmarNuevaContrasena;
        public List<Person> Persons { get; set; }

        public string Correo
        {
            get => correo;
            set
            {
                correo = value;
                OnPropertyChanged();
            }
        }

        public string ContrasenaActual
        {
            get => contrasenaActual;
            set
            {
                contrasenaActual = value;
                OnPropertyChanged();
            }
        }

        public string NuevaContrasena
        {
            get => nuevaContrasena;
            set
            {
                nuevaContrasena = value;
                OnPropertyChanged();
            }
        }
        public ICommand VolverCommand => new Command(Volver);
        private async void Volver()
        {
            Refresh();
            await App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
        public CambiarContraViewModel()
        {
            Refresh();
        }
        public string ConfirmarNuevaContrasena
        {
            get => confirmarNuevaContrasena;
            set
            {
                confirmarNuevaContrasena = value;
                OnPropertyChanged();
            }
        }

        public ICommand CambiarContrasenaCommand => new Command(async () => await CambiarContrasena());

        private async Task CambiarContrasena()
        {
            
            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(ContrasenaActual) || string.IsNullOrEmpty(NuevaContrasena) || string.IsNullOrEmpty(ConfirmarNuevaContrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            
            if (NuevaContrasena != ConfirmarNuevaContrasena)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las nuevas contraseñas no coinciden", "OK");
                return;
            }

            
            var person = App.CustomerRepo.GetAll().FirstOrDefault(p => p.Correo == Correo);

            
            if (person == null || person.Contrasena != ContrasenaActual)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña actual incorrectos", "OK");
                return;
            }

            
            person.Contrasena = NuevaContrasena;
            App.CustomerRepo.AddOrUpdate(person);

            await Application.Current.MainPage.DisplayAlert("Éxito", "Contraseña cambiada con éxito", "OK");
            Refresh();
        }
        private async void Refresh()
        {
            Persons = App.CustomerRepo.GetAll();
        }
    } 
}

