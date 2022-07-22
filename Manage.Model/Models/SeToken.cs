using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Model.Models
{
    public class SeToken
    {
        public int id { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        
        public int user_id { get; set; }


    }
}
