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

        public ICommand _deleteHechizoCommand;
        public ICommand DeleteHechizoCommand
        {
            get
            {
                return _deleteHechizoCommand ?? (_deleteHechizoCommand = new Command(() =>
                {
                    dataCon.deleteHechizo(HechizoSeleccionado.Id);
                    ListaHechizos = dataCon.LeerHechizos();
                }));
            }
        }

        public ICommand _modifyHechizoCommand;
        public ICommand ModifyHechizoCommand
        {
            get
            {
                return _modifyHechizoCommand ?? (_modifyHechizoCommand = new Command(() =>
                {

                    App.Current.MainPage.Navigation.PushAsync(new ThirdPage(hechizoSeleccionado));
                }));
            }
        }

        private ICommand _refreshListCommand { get; set; }
        public ICommand RefreshListCommand
        {
            get
            {
                return _refreshListCommand ?? (_refreshListCommand = new Command(() =>
                {
                    ListaHechizos = dataCon.LeerHechizos();
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
            ListaHechizos = dataCon.LeerHechizos();
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

        private Hechizo hechizoSeleccionado;
        public Hechizo HechizoSeleccionado
        {
            get { return hechizoSeleccionado; }
            set
            {
                hechizoSeleccionado = value;
                OnPropertyChanged();
            }
        }

        

    }
}
