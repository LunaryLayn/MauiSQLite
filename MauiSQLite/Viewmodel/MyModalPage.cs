using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Viewmodel

{
    public class MyModalPage : ContentPage
    {
        public MyModalPage()
        {
            // Agrega el contenido que quieras mostrar en la ventana modal
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Contenido de la ventana modal" },
                    new Button { Text = "Cerrar", Command = new Command(() => Navigation.PopModalAsync()) }
                }
            };
        }
    }
}

