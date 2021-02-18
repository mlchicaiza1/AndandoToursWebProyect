using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.Models
{
    public class DailyForm
    {
        public string EmailLeads { set; get; }
        public DateTime Day { set; get; }
        public int Passenger { get; set; }
        public string Message { set; get; }
    }
}
