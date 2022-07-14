using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Common
{
    public static class CheckId
    {
        public static async  Task<string> Check(int? id)
        {
            if (id == null)
                return "id can't null";
            return null;//=null
        }
    }
}
