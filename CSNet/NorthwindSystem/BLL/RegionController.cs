
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
        //Entity Framework realizes that certain requests for data are common
        //Entity Framework has created methods that can be called to do the common
        //requests

        //method #1 that WILL return all region records
        public List<Region> Regions_List()
        {
            //need to connect to the context class, that will handle the data request
            //most of CRUD requires using a transaction
            //to ensure that your data request is handled as a transaction
            //   we will encase all controller action within a transaction
            using(var context = new NorthwindContext())
            {
                //trasaction code
                return context.Regions.ToList();
            }
            
        }

        //method #2 will return a SPECIFIC region based on its Pkey
        public Region Regions_FindByID(int regionid)
        {
            //need to connect to the context class, that will handle the data request
            //most of CRUD requires using a transaction
            //to ensure that your data request is handled as a transaction
            //   we will encase all controller action within a transaction
            using (var context = new NorthwindContext())
            {
                //trasaction code
                return context.Regions.Find(regionid);
            }

        }
    }
}
