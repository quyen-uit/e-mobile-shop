using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSystem.Models
{
    public class DataAccess
    {

        public static List<AspNetUsers> ViewSanPham()
        {
            using (var context = new ECTH2012JDataContext())
            {
                return context.AspNetUsers.ToList();
            }
        }

    }
}
