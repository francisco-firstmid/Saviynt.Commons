using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saviynt.Commons.Requests
{
    public class GetUserDetailsRequest
    {
        public Filtercriteria filtercriteria { get; set; }
        public List<string> responsefields { get; set; }
        public class Filtercriteria
        {
            public string secondaryEmail { get; set; }
        }
    }
}
