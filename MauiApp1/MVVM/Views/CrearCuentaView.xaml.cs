using SQLite;
using System;
using MauiApp1;
using Microsoft.Maui;
using MauiApp1.MVVM.Models;
using MauiApp1.MVVM.ViewModels;
using System.Runtime.CompilerServices;
namespace MauiApp1.MVVM.Views;

public partial class CrearCuentaView : ContentPage
{
    
        
    public CrearCuentaView()
	{
        
		InitializeComponent();
        
        BindingContext=new CrearCuentaViewModel();
        
	}
    

    
}