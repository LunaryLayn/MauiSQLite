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
    public class FirstPageViewmodel : BindableObject
    {
        public Conexion dataCon = new Conexion();
        
        //Formas de hacer los commandos
        private ICommand _addHechizoCommand { get; set; }
        //Forma facil:
        /* ---------------------------------------------------------
           public ICommand AddHechizoCommand {
             get { return _addHechizoCommand = _addHechizoCommand ?? new Command(AddHechizoExecute); }
         }

         private void AddHechizoExecute()
         {
             Application.Current.MainPage.Navigation.PushAsync(new SecondPage());
         } */

        //Forma Copilot
        public ICommand AddHechizoCommand
        {
            get
            {
                return _addHechizoCommand ?? (_addHechizoCommand = new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new SecondPage());
                }));
            }
        }

        public FirstPageViewmodel()
        {
            if (!dataCon.compruebaSiExisteBD("BDD.db"))
            {
                dataCon.CreateDatabase();
                dataCon.addPrimerosHechizos();
            }
            listaHechizos = dataCon.LeerHechizos();
        }

        private List<Hechizo> listaHechizos;
        public List<Hechizo> ListaHechizos
        {
            get { return listaHechizos; }
            set
            {
                listaHechizos = value;
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
