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
    public class CategoryController
    {
        public List<Category> Categories_List()
        {
            //connect to the context class that will handle the data request
            //most of CRUD requires using a transaction
            //To ensure that your data request is handled as a transaction
            //   we will encase all controller action within a transaction
            using (var context = new NorthwindContext())
            {
                //transaction code
                return context.Categories.ToList();
            }

        }
    }
}
