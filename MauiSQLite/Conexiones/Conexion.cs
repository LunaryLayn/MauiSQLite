using MauiSQLite.Model;
using Microsoft.Maui.Controls.PlatformConfiguration;

namespace MauiSQLite.Conexiones
{
    public class Conexion
    {
        //public Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

       
        string path;
        //SQLite.Net.SQLiteConnection conn;

        SQLite.SQLiteConnection conn;

        public Conexion()
        {

        }

        
        public bool compruebaSiExisteBD(string nombreBD)
        {
            bool bdExiste = true;

            string a = FileSystem.AppDataDirectory;

            a = a + "\\" + nombreBD;
            if (!File.Exists(a))
            {
                bdExiste = false;
            }

            return bdExiste;
        }

        public void CreateDatabase()
        {
            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            conn.CreateTable<Hechizo>();
            conn.Close();

        }

        public void addPrimerosHechizos()
        {
            //Creamos una lista de usuarios
            var listaHechizos = new List<Hechizo>()
            {
                new Hechizo()
                {
                    Nombre = "Expelliarmus",
                    Descripcion = "Hechizo desarmador. Hace que la varita del oponente salga volando de su mano."
                },
                new Hechizo()
                {
                    Nombre = "Wingardium Leviosa",
                    Descripcion = "Hechizo levitador. Hace que los objetos se eleven en el aire y se muevan según la voluntad del mago."
                },
                new Hechizo()
                {
                    Nombre = "Avada Kedavra",
                    Descripcion = "Maldición asesina. Mata al objetivo instantáneamente sin dejar ningún rastro físico de daño."
                }
            };

            //Añadimos los usuarios a la tabla

            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            conn.InsertAll(listaHechizos);

            conn.Close();
        }

        public List<Hechizo> LeerHechizos()
        {
            List<Hechizo> ListaDeHechizos =
               new List<Hechizo>();

            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            var query = conn.Table<Hechizo>();
            // Hechizos = await query.ToListAsync();

            ListaDeHechizos = query.ToList<Hechizo>();

            return ListaDeHechizos;

        }

        public void addHechizo(Hechizo NHechizo)
        {


            //Añadimos  Hechizo a la tabla

            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            //Hechizo Hechizo = new Hechizo();
            //Hechizo.Nombre = nombre;
            //Hechizo.Telefono = telefono;
            //Hechizo.Direccion = direccion;

            conn.Insert(NHechizo);

            conn.Close();
        }




       public void deleteHechizo(int Identificador)
        {
            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            var Hechizo = conn.Table<Hechizo>().Where(x => x.Id == Identificador).FirstOrDefault();
            if (Hechizo != null)
            {
                conn.Delete(Hechizo);
            }

        }

        public void modificarHechizo(int Identificador, string nombre, string descripcion)
        {
            path = Path.Combine(FileSystem.AppDataDirectory, "BDD.db");

            //conn = new SQLite.Net.SQLiteConnection(new
            //SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);

            conn = new SQLite.SQLiteConnection(path);

            var Hechizo = conn.Table<Hechizo>().Where(x => x.Id == Identificador).FirstOrDefault();
            if (Hechizo != null)
            {
                Hechizo.Nombre = nombre;
                Hechizo.Descripcion = descripcion;

                conn.Update(Hechizo);
            }

        }

    }
}
