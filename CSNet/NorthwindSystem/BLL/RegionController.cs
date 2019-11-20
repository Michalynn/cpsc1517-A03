
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.DAL;
#endregion

namespace NorthwindSystem.BLL
{
    public class RegionController
    {
        //EntityFramework realizes that certain requests for data are common
        //EntityFramework has created methods that can be called to do the common
        //requests

        //method that will return all region records
        public List<Region> Regions_List()
        {
            //connect to the context class that will handle the data request
            //most of CRUD requires using a transaction
            //To ensure that your data request is handled as a transaction
            //   we will encase all controller action within a transaction
            using(var context = new NorthwindContext())
            {
                //transaction code
                return context.Regions.ToList();
            }

        }

        //method that will return a specific region record based on its pkey
        public Region Regions_FindByID(int regionid)
        {
            //connect to the context class that will handle the data request
            //most of CRUD requires using a transaction
            //To ensure that your data request is handled as a transaction
            //   we will encase all controller action within a transaction
            using (var context = new NorthwindContext())
            {
                //transaction code
                return context.Regions.Find(regionid);
            }

        }
    }
}
