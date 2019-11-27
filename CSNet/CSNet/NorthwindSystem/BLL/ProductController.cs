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
        #region Queries
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

        public List<Product> Products_List()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }
        }

        public Product Products_GetByID(int productid)
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }
        #endregion

        #region Add, Update and Delete
        public int Products_Add(Product item)
        {
            //at some point in time, your individual product fields
            //   must be placed in an instance of the class
            //this can be done on the web page or within this method

            //start a transaction
            using (var context = new NorthwindContext())
            {

                //Step one
                //Stage the data for execution by the commit statement
                //Staging is done in local memory
                //Staging DOES NOT create an identity value; this is done
                //   at commit time
                context.Products.Add(item);

                //commit your staged record to the database
                //IF there is ANY entity validation annotation, it will
                //    be executed during the .SaveChanges() processing
                //If any entity validation error is discovered, the message
                //    is returned AND the commit is ABORTED
                //if the commit command is successful, then the new
                //    identity value will exist in your data instance
                //if the commit command is NOT successful, the transaction
                //    is ROLLBACK
                context.SaveChanges();

                //optionally
                //you may decide to return the new identity value to the 
                //   web page
                //if you decide to return the value, then the method has a
                //   returndatatype of int; else the method should be using a
                //   returndatatype of void.
                return item.ProductID;

            }
        }

        //update
        //change the entire entity record
        //it does not matter LOGICALLY that you change a value to itself
        //by changing the entire entity you change all field that need to be altered
        //the value returned is the number of rows affected
        public int Products_Update(Product item)
        {
            using(var context = new NorthwindContext())
            {
                //Staging
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                //Commit and Feedback (rows affected)
                return context.SaveChanges();
            }
        }

        //delete
        //delete (physical) or change (logical update) the entire entity record
        //the value returned is the number of rows affected
        public int Products_Delete(int productid)
        {
            using (var context = new NorthwindContext())
            {
                //Physical Delete
                //the physical removal of a record from the database

                ////locate the instance of the entity to be removed
                //var existing = context.Products.Find(productid);
                ////is it there
                //if (existing == null)
                //{
                //    throw new Exception("Record has been remove already.");
                //}
                ////Stage
                //context.Products.Remove(existing);
                ////commit
                //return context.SaveChanges();

                //Logical delete
                //you normal set a property to a specific value to
                //    indicate the record should be considered gone
                //this is actually an update of the record

                //locate the instance of the entity to be removed
                var existing = context.Products.Find(productid);
                //set the property to the specific value
                existing.Discontinued = true;
                //Stage
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                //commit
                return context.SaveChanges();
            }
        }
        #endregion
    }
}
