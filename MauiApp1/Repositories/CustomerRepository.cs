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
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMess {  get; set; }
        public CustomerRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath,Constants.Flags);
            connection.CreateTable<Person>();
        }
        
        public void AddOrUpdate(Person person)
        {
            int res = 0;
            try
            {
                if(person.Id!=0) 
                {
                    res = connection.Update(person);
                    StatusMess = $"{res} row()s updated";
                }
                else
                {
                    res= connection.Insert(person);
                    StatusMess = $"{res} row()s added";

                }
                
            }
            catch(Exception ex)
            {
                StatusMess = $"Error: {ex.Message}";
            }
        }

        public List<Person> GetAll()
        {
            try
            {
                return connection.Table<Person>().ToList();
            }
            catch (Exception ex)
            {

                StatusMess = $"Error: {ex.Message}";
            }
            return null;
        }

        public Person Get(int id)
        {
            try
            {
                return connection.Table<Person>().FirstOrDefault(x=> x.Id==id);
            }
            catch (Exception ex)
            {

                StatusMess = $"Error: {ex.Message}";
            }
            return null;
        }
        public List<Person> GetAll2()
        {
            try
            {
                return connection.Query<Person>("SELECT * FROM Personas").ToList();
            }
            catch (Exception ex)
            {

                StatusMess = $"Error: {ex.Message}";
            }
            return null;
        }
        public void Delete(int personId)
        {
            try
            {
                var person = Get(personId);
                connection.Delete(person);
            }
            catch (Exception ex)
            {
                StatusMess = $"Error: {ex.Message}";

            }
        }
    }
}
