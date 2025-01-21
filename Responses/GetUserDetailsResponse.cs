using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saviynt.Commons.Responses
{
    public class GetUserDetailsResponse
    {
        public string msg { get; set; }
        public string displaycount { get; set; }
        public List<Userlist> userlist { get; set; }
        public string totalcount { get; set; }
        public string errorCode { get; set; }

        public class Userlist
        {
            public string secondaryEmail { get; set; }
            public string username { get; set; }
        }
    }
}
