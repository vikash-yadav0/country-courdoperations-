using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using curdoperation.Models;
namespace curdoperation.Controllers
{
    public class CountryController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
               String path = @"C:\Users\lalit kumar\Desktop\curd operations\country.dat";
            List<Country> country = CountryCurd.LoadData(path);
            return View(country);
        }
        public ActionResult UpdateCountry(int id)
        {
            Country country = CountryCurd.getById(id);

            return View(country);
        }
        [HttpPost]
        public ActionResult UpdateCountry(int country_id ,string Country_name)
        {
            Country country = new Country
            {

                country_Id = country_id,
                country_name = Country_name
            };
            CountryCurd.update(country);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCountry(int id)
        {
            bool status = CountryCurd.delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult InsertCountry(Country country)
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertCountry(int country_id,String Country_name)
        {
            Country country = new Country
            {
                country_Id = country_id,
                country_name = Country_name
            };
            CountryCurd.insert(country);
            return RedirectToAction("Index");
        }
        public ActionResult StateDetail(int id)
        {
            List<State> state = StateCurd.getAllStates(id);

            return View(state);
        }
        public ActionResult UpdateState(int id)
        {
            State state = StateCurd.getStateById(id);

            return View(state);
        }
        [HttpPost]
        public ActionResult UpdateState(int country_id, int state_id, String State_name)
        {
            State state = new State
            {
                country_id = country_id,
                state_id = state_id,
                State_name=State_name
            
            };
            StateCurd.updateState(state);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteState(int id)
        {
           
            bool status = StateCurd.deleteState(id);

            return RedirectToAction("Index");
        }
        public ActionResult InsertState()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult InsertState(int country_id, int state_id, String State_name)
        {
            State state = new State
            {
                country_id = country_id,
                state_id = state_id,
                State_name = State_name

            };
            StateCurd.insertState(state);
            return RedirectToAction("Index");
        }
    }
}