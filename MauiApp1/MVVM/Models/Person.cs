using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;

namespace MauiApp1.MVVM.Models
{
    [Table("Personas")]
    
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250), Unique]
        public string Correo { get; set; }
        [MaxLength(16)]
        public string Contrasena { get; set; }
    }
}
