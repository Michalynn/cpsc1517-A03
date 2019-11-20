using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.DAL;
using System.Data.SqlClient;  //needed  for SqlParameter class
#endregion

namespace NorthwindSystem.BLL
{
    public class ProductController
    {
        //lookup of data from the database using a non-primary key field
        public List<Product> Products_FindByCategory(int categoryid)
        {
            using (var context = new NorthwindContext())
            {
                //syntax
                //context.Database.SqlQuery<T>("sqlprocname [@parameterid[,@parameterid]]"
                //    [, new SqlParameter("parameterid", parametervalue)[,...]]);
                //context.Database.SqlQuery<T>("sqlprocname");  no parameters
                //context.Database.SqlQuery<T>("sqlprocname @parameterid"
                //    , new SqlParameter("parameterid", parametervalue)); one parameter
                //context.Database.SqlQuery<T>("sqlprocname @parameterid,@parameterid"
                //    , new SqlParameter("parameterid", parametervalue)
                //    , new SqlParameter("parameterid", parametervalue)); > 1 parameter

                //the parameterid is the spelling of the parameter name located on your sql procedure
                //the results from this query are returned as a datatype of:  IEnumerable<T>
                IEnumerable<Product> results =
                    context.Database.SqlQuery<Product>("Products_GetByCategories @CategoryID"
                            , new SqlParameter("CategoryID", categoryid));
                return results.ToList();
                
            }
        }
    }
}
