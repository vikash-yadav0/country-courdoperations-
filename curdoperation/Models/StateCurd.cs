using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace curdoperation.Models
{
   
    public class StateCurd
    {
        public static String path1 = @"C:\Users\lalit kumar\Desktop\curd operations\state.dat";
        public static String path = @"C:\Users\lalit kumar\Desktop\curd operations\country.dat";
        public static List<Country> getAllCountry()
        {
            List<Country> country = new List<Country>();
            country = LoadCountryData(path);
            return country;
        }
        public static List<Country> LoadCountryData(String path)
        {
            List<Country> country = new List<Country>();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            country = bf.Deserialize(fs) as List<Country>;
            fs.Close();
            return country;
        }
        public static List<State> getAllStates(int id)
        {
           
            List<State> state = new List<State>();
            List<State> st = new List<State>();
            state = LoadStateData(path1);
            st= state.FindAll(e => e.country_id == id);
            return st as List<State>;
        }
        public static bool insertState(State st)
        {
            bool status = false;
            try
            {
                List<State> state = new List<State>();
                state = LoadStateData(path1);
                state.Add(st);
                SaveStateData(path1, state);
                status = true;
            }
            catch (Exception ex)
            {
                string exeMessage = ex.Message;
            }
            return status;
        }
        public static bool updateState(State updateto)
        {
            bool status = false;
            List<State> state = new List<State>();
            state = LoadStateData(path1);

            var result = from r in state
                         where r.state_id==updateto.state_id
                         select r;

            result.First().State_name = updateto.State_name;
            result.First().country_id = updateto.country_id;
            status = SaveStateData(path1, state); ;
            return status;
        }
        public static bool deleteState(int id)
        {
            bool status = false;
            List<State> state = new List<State>();
            state = LoadStateData(path1);
            int no = state.RemoveAll(emp => emp.state_id == id);
            if (no > 0)
            {
                SaveStateData(path1, state);
                status = true;
            }
            return status;
        }
        public static State getStateById(int id)
        {
            List<State> state = new List<State>();
            state = LoadStateData(path1);
            var st = state.Find(e => e.state_id == id);
            return st as State;


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

    }
}