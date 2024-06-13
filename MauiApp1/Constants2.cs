using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
    public static class Constants2
    {
        private const string DBFileName2 = "SQLITE2.db3";
        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
        public static string DatabasePath2
        {
            get
            {
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName2);
            }
        }
    }
}
