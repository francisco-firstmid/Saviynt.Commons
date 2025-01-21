using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saviynt.Commons.Requests
{
    public class UserRequest
    {
        public string username { get; set; }
        public string firstname { get; set; }
        public string startdate { get; set; }
        public string preferedFirstName { get; set; }
        public string lastname { get; set; }
        public string departmentname { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string secondaryEmail { get; set; }
        public string statuskey { get; set; }
        public string middlename { get; set; }
        public string allowpastdate{ get; set; }
        public string customproperty20 { get; set; }
        public string passwordExpired { get; set; }
    }
}
