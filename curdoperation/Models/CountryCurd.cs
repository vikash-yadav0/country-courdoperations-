using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace curdoperation.Models
{
    public class CountryCurd
    {
        public static String path1 = @"C:\Users\lalit kumar\Desktop\curd operations\state.dat";
        public static String path = @"C:\Users\lalit kumar\Desktop\curd operations\country.dat";
        public static List<Country> getAll()
        {
            List<Country> country = new List<Country>();
            country = LoadData(path);
            return country;
        }
        public static bool insert(Country count)
        {
            bool status = false;
            try
            {
                List<Country> country = new List<Country>();
                country = LoadData(path);
                country.Add(count);
                SaveData(path, country);
                status = true;
            }
            catch (Exception ex)
            {
                string exeMessage = ex.Message;
            }
            return status;
        }
        public static bool update(Country updateto)
        {
            bool status = false;
            List<Country> country = new List<Country>();
            country = LoadData(path);

            var result = from r in country
                         where r.country_Id == updateto.country_Id
                         select r;

            result.First().country_name = updateto.country_name;         
            status = SaveData(path, country); ;
            return status;
        }
        public static bool delete(int id) 
        {
            bool status = false;
            List<Country> country = new List<Country>();
            country = LoadData(path);
            int no = country.RemoveAll(emp => emp.country_Id == id);
            
            if (no > 0)
            {
                SaveData(path, country);
                status = true;
            }
            List<State> state = new List<State>();
            state = LoadStateData(path1);
            int no1 = state.RemoveAll(emp => emp.country_id == id);
            if (no1 > 0)
            {
                SaveStateData(path1, state);
                status = true;
            }

            return status;
        }
        public static List<State> LoadStateData(String path1)
        {
            List<State> state = new List<State>();
            FileStream fs = new FileStream(path1, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            state = bf.Deserialize(fs) as List<State>;
            fs.Close();
            return state;
        }
        public static bool SaveStateData(string path1, List<State> state)
        {
            bool status = false;
            FileStream fs = new FileStream(path1, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, state);
            fs.Close();
            return status;

        }
        public static Country getById( int id)
        {
            List<Country> country = new List<Country>();
            country = LoadData(path);
            var employee = country.Find(e => e.country_Id == id);
            return employee as Country;


        }
        public static List<Country> LoadData(String path)
        {
            List<Country> country = new List<Country>();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            country = bf.Deserialize(fs) as List<Country>;
            fs.Close();
            return country;
        }
        public static bool SaveData(string path, List<Country> country)
        {
            bool status = false;
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, country);
            fs.Close();
            return status;

        }
    }
}