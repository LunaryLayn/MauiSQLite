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
    public class ThirdPageViewmodel : BindableObject
    {
        private Hechizo hechizoSeleccionado;
        public Conexion dataCon = new Conexion();
        public ThirdPageViewmodel(Hechizo hechizoSeleccionado)
        {
            Nombre = hechizoSeleccionado.Nombre;
            Descripcion = hechizoSeleccionado.Descripcion;
            this.hechizoSeleccionado = hechizoSeleccionado;
        }

        private ICommand _modifyCommand { get; set; }
        public ICommand ModifyCommand
        {
            get
            {
                return _modifyCommand ?? (_modifyCommand = new Command(() =>
                {
                    Hechizo hechizo = new Hechizo();
                    hechizo.Nombre = Nombre;
                    hechizo.Descripcion = Descripcion;

                    dataCon.modificarHechizo(hechizoSeleccionado.Id, Nombre, Descripcion);

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
