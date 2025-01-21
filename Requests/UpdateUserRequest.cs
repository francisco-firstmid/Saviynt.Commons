using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saviynt.Commons.Requests
{
    public class UpdateUserRequest : UserRequest
    {
        public string propertytosearch { get; set; }
    }
}
