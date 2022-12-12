using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using curdoperation.Models;
namespace curdoperation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            List<Country> country = new List<Country>();
            country.Add(new Country { country_Id = 1, country_name = "India" });
            country.Add(new Country { country_Id = 2, country_name = "Nepal" });
            country.Add(new Country { country_Id = 3, country_name = "China" });

           String path = @"C:\Users\lalit kumar\Desktop\curd operations\country.dat";
             bool status = CountryCurd.SaveData(path, country);

            List<State> state = new List<State>();
            state.Add(new State { state_id = 1, State_name = "Haryana" ,country_id=1});
            state.Add(new State { state_id = 2, State_name = "Punjab" ,country_id=1});
            state.Add(new State { state_id = 3, State_name = "Himachal",country_id=1 });
            state.Add(new State { state_id = 1, State_name = "Lumbani", country_id = 2 });
            state.Add(new State { state_id = 2, State_name = "Gandaki", country_id = 2 });
            state.Add(new State { state_id = 3, State_name = "Bagimati", country_id = 2 });
            state.Add(new State { state_id = 1, State_name = "Hubei", country_id = 3 });
            state.Add(new State { state_id = 2, State_name = "Qinghai", country_id = 3 });
            state.Add(new State { state_id = 3, State_name = "Yunnan", country_id = 3 });

            String path1 = @"C:\Users\lalit kumar\Desktop\curd operations\state.dat";
            bool status1 = StateCurd.SaveStateData(path1, state);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
