using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace curdoperation.Models
{
    [Serializable]
    public class State
    {
        public int state_id { get; set; }
        public String State_name { get; set; }
        public int country_id { get; set; }
       
    }
}