using System;
using SQLite;
using SQLitePCL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp1.MVVM.Models;

namespace MauiApp1.Repositories
{
    public class CompoRepository
    {
        SQLiteConnection connection2;
        public string StatusMess2 {  get; set; }
        public CompoRepository()
        {
            connection2 = new SQLiteConnection(Constants2.DatabasePath2,Constants2.Flags);
            connection2.CreateTable<Compo>();

            PreloadData();
        }
       public void PreloadData()
        {
            try
            {
                if (!connection2.Table<Compo>().Any())
                {
                    List<Compo> initialData = new List<Compo>
                    {
                        new Compo { Tipo = "Diodo", Codigo = "1N4148", Datasheet = "https://resistencia.finaso.com.mx/1N4148.pdf", Imagen = "imagen1" },
                        new Compo { Tipo = "Diodo", Codigo = "1N4733A", Datasheet = "https://resistencia.finaso.com.mx/1N4733A.pdf", Imagen = "imagen2" },
                        new Compo { Tipo = "Diodo", Codigo = "1N5819", Datasheet = "https://resistencia.finaso.com.mx/1N5819.pdf", Imagen = "imagen3" },

                        new Compo { Tipo = "Transistor", Codigo = "2N5088", Datasheet = "https://resistencia.finaso.com.mx/2N5088.pdf", Imagen = "imagen4" },
                        new Compo { Tipo = "Transistor", Codigo = "BC388", Datasheet = "https://resistencia.finaso.com.mx/BC388.pdf", Imagen = "imagen13" },

                        new Compo { Tipo = "Circuito integrado", Codigo = "24C02", Datasheet = "https://resistencia.finaso.com.mx/24C02.pdf", Imagen = "imagen5" },
                        new Compo { Tipo = "Circuito integrado", Codigo = "555", Datasheet = "https://resistencia.finaso.com.mx/555.pdf", Imagen = "imagen11" },
                        new Compo { Tipo = "Circuito integrado", Codigo = "TDA7294", Datasheet = "https://resistencia.finaso.com.mx/TDA7294.pdf", Imagen = "imagen13" },

                        new Compo { Tipo = "Compuerta lógica NAND", Codigo = "74LS00", Datasheet = "https://resistencia.finaso.com.mx/74LS00.pdf", Imagen = "imagen6" },
                        new Compo { Tipo = "Compuerta lógica NOT", Codigo = "74LS04", Datasheet = "https://resistencia.finaso.com.mx/74LS04.pdf", Imagen = "imagen7" },
                        new Compo { Tipo = "Compuerta lógica AND", Codigo = "74LS08", Datasheet = "https://resistencia.finaso.com.mx/74LS08.pdf", Imagen = "imagen8" },
                        new Compo { Tipo = "Compuerta lógica OR", Codigo = "74LS32", Datasheet = "https://resistencia.finaso.com.mx/74LS32.pdf", Imagen = "imagen9" },
                        new Compo { Tipo = "Compuerta lógica XOR", Codigo = "74LS86", Datasheet = "https://resistencia.finaso.com.mx/74LS86.pdf", Imagen = "imagen10" },

                        new Compo { Tipo = "Regulador de voltaje", Codigo = "7808", Datasheet = "https://resistencia.finaso.com.mx/7808.pdf", Imagen = "imagen12" },
                        new Compo { Tipo = "Regulador de voltaje", Codigo = "LM317", Datasheet = "https://resistencia.finaso.com.mx/LM317.pdf", Imagen = "imagen13" },
                        new Compo { Tipo = "Regulador de voltaje", Codigo = "LM7805", Datasheet = "https://resistencia.finaso.com.mx/LM7805.pdf", Imagen = "imagen8" },

                        new Compo { Tipo = "Módulo Bluetooth", Codigo = "HC-06", Datasheet = "https://resistencia.finaso.com.mx/HC-06.pdf", Imagen = "imagen14" },
                        new Compo { Tipo = "Mosfet", Codigo = "IRF540", Datasheet = "https://resistencia.finaso.com.mx/IRF540.pdf", Imagen = "imagen9" },
                        new Compo { Tipo = "Controlador de motor", Codigo = "L298N", Datasheet = "https://resistencia.finaso.com.mx/L298N.pdf", Imagen = "imagen10" },

                        new Compo { Tipo = "Sensor ultrasónico", Codigo = "HC-SR04", Datasheet = "https://resistencia.finaso.com.mx/HC-SR04.pdf", Imagen = "imagen15" },
                        new Compo { Tipo = "Sensor de movimiento", Codigo = "HC-SR501", Datasheet = "https://resistencia.finaso.com.mx/HC-SR501.pdf", Imagen = "imagen8" },
                        new Compo { Tipo = "Sensor de temperatura", Codigo = "LM35", Datasheet = "https://resistencia.finaso.com.mx/LM35.pdf", Imagen = "imagen12" },

                        new Compo { Tipo = "Amplificador operacional", Codigo = "LM358", Datasheet = "https://resistencia.finaso.com.mx/LM358.pdf", Imagen = "imagen14" },
                        new Compo { Tipo = "Amplificador operacional", Codigo = "LM741", Datasheet = "https://resistencia.finaso.com.mx/LM741.pdf", Imagen = "imagen15" },
                        new Compo { Tipo = "Amplificador de audio", Codigo = "TDA2030", Datasheet = "https://resistencia.finaso.com.mx/TDA2030.pdf", Imagen = "imagen12" },

                        new Compo { Tipo = "LED", Codigo = "MV5754A", Datasheet = "https://resistencia.finaso.com.mx/MV5754A.pdf", Imagen = "imagen9" },
                        new Compo { Tipo = "Fotoresistencia", Codigo = "NORPS12", Datasheet = "https://resistencia.finaso.com.mx/NORPS12.pdf", Imagen = "imagen10" },

                        new Compo { Tipo = "Optoacoplador", Codigo = "PC817", Datasheet = "https://resistencia.finaso.com.mx/PC817.pdf", Imagen = "imagen12" },
                        new Compo { Tipo = "Potenciómetro", Codigo = "PDB181", Datasheet = "https://resistencia.finaso.com.mx/PDB181.pdf", Imagen = "imagen13" },
                        new Compo { Tipo = "Relé", Codigo = "SRD-05VDC-SL-C", Datasheet = "https://resistencia.finaso.com.mx/SRD-05VDC-SL-C.pdf", Imagen = "imagen14" }
                        
                        
                    };

                    connection2.InsertAll(initialData);
                    StatusMess2 = $"{initialData.Count} rows added as initial data";
                }
            }
            catch (Exception ex)
            {
                StatusMess2 = $"Error: {ex.Message}";
            }
        }
        public void AddOrUpdate(Compo compo)
        {
            int res = 0;
            try
            {
                if(compo.Id!=0) 
                {
                    res = connection2.Update(compo);
                    StatusMess2 = $"{res} row()s updated";
                }
                else
                {
                    res= connection2.Insert(compo);
                    StatusMess2 = $"{res} row()s added";

                }
                
            }
            catch(Exception ex)
            {
                StatusMess2 = $"Error: {ex.Message}";
            }
        }

        public List<Compo> GetAll()
        {
            try
            {
                return connection2.Table<Compo>().ToList();
            }
            catch (Exception ex)
            {

                StatusMess2 = $"Error: {ex.Message}";
            }
            return null;
        }

        public Compo Get(int id)
        {
            try
            {
                return connection2.Table<Compo>().FirstOrDefault(x=> x.Id==id);
            }
            catch (Exception ex)
            {

                StatusMess2 = $"Error: {ex.Message}";
            }
            return null;
        }
        public List<Compo> GetAll2()
        {
            try
            {
                return connection2.Query<Compo>("SELECT * FROM Compo").ToList();
            }
            catch (Exception ex)
            {

                StatusMess2 = $"Error: {ex.Message}";
            }
            return null;
        }
        public void Delete(int compoId)
        {
            try
            {
                var compo = Get(compoId);
                connection2.Delete(compo);
            }
            catch (Exception ex)
            {
                StatusMess2 = $"Error: {ex.Message}";

            }
        }
       
    }
}
