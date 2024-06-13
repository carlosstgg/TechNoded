
using MauiApp1.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.MVVM;
using System.Windows.Input;
using PropertyChanged;
using System.Diagnostics;




namespace MauiApp1.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]

    public class CrearCuentaViewModel
    {
        private Person currentPerson;

        public string ConfirmarContra {  get; set; }
        public List<Person> Persons { get; set; }
        public Person CurrentPerson { get => currentPerson; set => currentPerson = value; }
        public CrearCuentaViewModel()
        {

            CurrentPerson = new Person();
            
           Refresh();
        }
        public ICommand RegresarCommand => new Command(Regresar);
        public ICommand AddOrUpdateCommand => new Command(AddOrUpdate);
        

        public async void AddOrUpdate()
        {
           if (CurrentPerson.Correo == null | CurrentPerson.Contrasena ==null | CurrentPerson.Name==null | ConfirmarContra==null) 
           {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "Ok");
           }
            else
            {
                if (ConfirmarContra==CurrentPerson.Contrasena) 
                { App.CustomerRepo.AddOrUpdate(CurrentPerson);
                Debug.WriteLine(App.CustomerRepo.StatusMess);
                Refresh();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "Ok");

            }
        }

        public async void Regresar()
        {   
            Refresh();
            Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            
        }

        private async void Refresh()
        {
            Persons=App.CustomerRepo.GetAll();
        }
    }
}
