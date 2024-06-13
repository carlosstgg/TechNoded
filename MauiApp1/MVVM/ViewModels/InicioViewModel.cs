using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.Views;
using Microsoft.Maui.Controls;

namespace MauiApp1.MVVM.ViewModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public List<Compo> _Compos { get; set; } = new List<Compo>();
        private string _search;
        private Compo _selectedCompo;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand EliminarCommand => new Command(Eliminar);
        public ICommand CalculadoraCommand => new Command(Calculadora);
        public ICommand OpenDatasheetCommand => new Command<Compo>(OpenDatasheet);

        public async void Calculadora()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CalculadoraView());
        }

        public InicioViewModel()
        {
            FilteredCompos = App.CompoRepo.GetAll();
            SearchCommand = new Command<string>(OnSearch);
        }

        public List<Compo> FilteredCompos
        {
            get => _Compos;
            set
            {
                _Compos = value;
                OnPropertyChanged();
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                if (_search != value)
                {
                    _search = value;
                    OnPropertyChanged();
                    OnSearch(_search);
                }
            }
        }

        public Compo SelectedCompo
        {
            get => _selectedCompo;
            set
            {
                if (_selectedCompo != value)
                {
                    _selectedCompo = value;
                    OnPropertyChanged();
                    OpenDatasheetCommand.Execute(_selectedCompo);
                }
            }
        }

        public ICommand SearchCommand { get; }

        private void OnSearch(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                FilteredCompos = App.CompoRepo.GetAll();
            }
            else
            {
                var filtered = App.CompoRepo.GetAll()
                    .Where(c => c.Tipo.Contains(query, StringComparison.Ordinal) ||
                                c.Codigo.Contains(query, StringComparison.Ordinal))
                    .ToList();
                FilteredCompos = filtered;
            }
        }

        private void Eliminar()
        {
            var primeros5Compos = FilteredCompos.Take(5).ToList();
            foreach (var compo in primeros5Compos)
            {
                App.CompoRepo.Delete(compo.Id);
            }
            FilteredCompos = App.CompoRepo.GetAll();
        }

        private void OpenDatasheet(Compo compo)
        {
            if (compo != null && !string.IsNullOrEmpty(compo.Datasheet))
            {
                Launcher.OpenAsync(new Uri(compo.Datasheet));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
