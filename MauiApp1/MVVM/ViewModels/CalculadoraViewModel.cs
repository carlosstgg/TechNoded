using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace MauiApp1.MVVM.ViewModels
{
    public class CalculadoraViewModel : INotifyPropertyChanged
    {
        private string _resultado;
        private string _color1;
        private string _color2;
        private string _multiplicador;
        private string _tolerancia;
        

        public string Color1
        {
            get => _color1;
            set
            {
                if (_color1 != value)
                {
                    _color1 = value;
                    OnPropertyChanged();
                    UpdateColorBanda1();
                }
            }
        }

        public string Color2
        {
            get => _color2;
            set
            {
                if (_color2 != value)
                {
                    _color2 = value;
                    OnPropertyChanged();
                    UpdateColorBanda2();
                }
            }
        }

        public string Multiplicador
        {
            get => _multiplicador;
            set
            {
                if (_multiplicador != value)
                {
                    _multiplicador = value;
                    OnPropertyChanged();
                    UpdateColorBanda3();
                }
            }
        }

        public string Tolerancia
        {
            get => _tolerancia;
            set
            {
                if (_tolerancia != value)
                {
                    _tolerancia = value;
                    OnPropertyChanged();
                    UpdateColorBanda4();
                }
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                if (_resultado != value)
                {
                    _resultado = value;
                    OnPropertyChanged();
                }
            }
        }
        

        
        public ICommand CalcularCommand { get; }

        public CalculadoraViewModel()
        {
            CalcularCommand = new Command(Calcular);
        }

        private void Calcular()
        {

            int valorColor1 = ObtenerValorColor(Color1);
            int valorColor2 = ObtenerValorColor(Color2);


            double multiplicador = ObtenerMultiplicador(Multiplicador);


            double resistencia = (valorColor1 * 10 + valorColor2) * multiplicador;


            double tolerancia = ObtenerTolerancia(Tolerancia);

            if (resistencia >= 1000000000)
            {   
                resistencia = resistencia / 1000000000;
                Resultado = $"Resistencia: {resistencia} GΩ, Tolerancia: ±{tolerancia}%"; 
            }
            else if (resistencia >= 1000000)
            {
                resistencia = resistencia / 1000000;
                Resultado = $"Resistencia: {resistencia} MΩ, Tolerancia: ±{tolerancia}%";
            }
            else if (resistencia>=1000)
            {
                resistencia = resistencia / 1000;
                Resultado = $"Resistencia: {resistencia} KΩ, Tolerancia: ±{tolerancia}%";
            }
            else if (resistencia <= 0.001)
            {
                resistencia = resistencia *1000;
                Resultado = $"Resistencia: {resistencia} mΩ, Tolerancia: ±{tolerancia}%";
            }
            else
                Resultado = $"Resistencia: {resistencia} Ω, Tolerancia: ±{tolerancia}%";
        }

        private int ObtenerValorColor(string color)
        {
            switch (color.ToLower())
            {
                case "negro": return 0;
                case "cafe": return 1;
                case "rojo": return 2;
                case "naranja": return 3;
                case "amarillo": return 4;
                case "verde": return 5;
                case "azul": return 6;
                case "violeta": return 7;
                case "gris": return 8;
                case "blanco": return 9;
                default: return 0; 
            }
        }

        private double ObtenerMultiplicador(string multiplicador)
        {
            switch (multiplicador.ToLower())
            {
                case "negro": return 1;
                case "cafe": return 10;
                case "rojo": return 100;
                case "naranja": return 1000;
                case "amarillo": return 10000;
                case "verde": return 100000;
                case "azul": return 1000000;
                case "violeta": return 10000000;
                case "gris": return 100000000;
                case "blanco": return 1000000000;
                case "dorado": return 0.1;
                case "plateado": return 0.01;
                default: return 1; 
            }
        }

        private double ObtenerTolerancia(string tolerancia)
        {
            switch (tolerancia.ToLower())
            {
                case "cafe": return 1;
                case "rojo": return 2;
                
                case "verde": return 0.5;
                case "azul": return 0.25;
                case "violeta": return 10;
                case "gris": return 0.05;
                case "dorado": return 5;
                case "plateado": return 10;
                default: return 5; 
            }
        }

        public Color ColorBanda1 { get; private set; }
        public Color ColorBanda2 { get; private set; }
        public Color ColorBanda3 { get; private set; }
        public Color ColorBanda4 { get; private set; }

        private void UpdateColorBanda1()
        {
            ColorBanda1 = GetColorFromName(Color1);
            OnPropertyChanged(nameof(ColorBanda1));
        }

        private void UpdateColorBanda2()
        {
            ColorBanda2 = GetColorFromName(Color2);
            OnPropertyChanged(nameof(ColorBanda2));
        }

        private void UpdateColorBanda3()
        {
            ColorBanda3 = GetColorFromName(Multiplicador);
            OnPropertyChanged(nameof(ColorBanda3));
        }
        private void UpdateColorBanda4()
        {
            ColorBanda4 = GetColorFromName(Tolerancia);
            OnPropertyChanged(nameof(ColorBanda4));
        }

        private Color GetColorFromName(string colorName)
        {
            switch (colorName)
            {
                case "Negro":
                    return Color.FromHex("#000000"); // Negro
                case "Cafe":
                    return Color.FromHex("#8B4513"); // Café
                case "Rojo":
                    return Color.FromHex("#FF0000"); // Rojo
                case "Naranja":
                    return Color.FromHex("#FFA500"); // Naranja
                case "Amarillo":
                    return Color.FromHex("#FFFF00"); // Amarillo
                case "Verde":
                    return Color.FromHex("#008000"); // Verde
                case "Azul":
                    return Color.FromHex("#0000FF"); // Azul
                case "Violeta":
                    return Color.FromHex("#800080"); // Violeta
                case "Gris":
                    return Color.FromHex("#808080"); // Gris
                case "Blanco":
                    return Color.FromHex("#FFFFFF"); // Blanco
                case "Dorado":
                    return Color.FromHex("#FFD700"); // Dorado
                case "Plateado":
                    return Color.FromHex("#C0C0C0"); // Plateado
                default:
                    return Color.FromHex("#000000");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
