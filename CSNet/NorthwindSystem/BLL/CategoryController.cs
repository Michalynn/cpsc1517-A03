using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.DAL;
using System.ComponentModel; //required to expose items for ODS
#endregion

namespace NorthwindSystem.BLL
{
    //expose the class to the ODS wizard
    [DataObject]
    public class CategoryController
    {
        //to expose a method for the ODS wizard
        //  use the DataObjectMethod annotation
        //this annotation goes in front of the method to exposed
        //NOT all methods need to be exposed
        [DataObjectMethod(DataObjectMethodType.Select,false)]
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
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public Category Categories_FindByID(int categoryid)
        {
            using(var context = new NorthwindContext())
            {
                return context.Categories.Find(categoryid);
            }
        }
    }
}
