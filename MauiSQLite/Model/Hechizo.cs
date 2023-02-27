using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Model
{
    public class Hechizo
    {
        [PrimaryKey, AutoIncrement] public int Id { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Hechizo(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Hechizo()
        {
        }
    }

}
