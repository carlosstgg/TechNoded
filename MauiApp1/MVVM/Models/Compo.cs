using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.MVVM.Models
{   
    [Table("Compo")]
    public class Compo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Codigo { get; set; }
        [MaxLength(250)]
        public string Tipo { get; set; }
        [MaxLength(300)]
        public string Datasheet { get; set; }
        [MaxLength(300)]
        public string Imagen { get; set; }
    }
}
