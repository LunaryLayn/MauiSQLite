using MauiSQLite.Conexiones;
using MauiSQLite.Model;
using MauiSQLite.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiSQLite.Viewmodel
{
    public class SecondPageViewmodel : BindableObject
    {

        public Conexion dataCon = new Conexion();

        private ICommand _addCommand { get; set; }
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new Command(() =>
                {
                    Hechizo hechizo = new Hechizo();
                    hechizo.Nombre = Nombre;
                    hechizo.Descripcion = Descripcion;

                    dataCon.addHechizo(hechizo);
                    App.Current.MainPage.Navigation.PushAsync(new FirstPage());
                }));
            }
        }

        private String nombre;
        public String Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private String descripcion;
        public String Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }

        


    public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
