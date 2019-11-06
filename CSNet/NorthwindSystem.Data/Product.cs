using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NorthwindSystem.Data
{
    //annotation that will point this class to the appropiate 
    //SQL table
    //sometimes your sql database will be divided into groups;
    // these groups are called schemas; you can recognize a 
    // schema on a table using by the name ie: Humanresources.tablename
    //IF your data base does NOT have schema then you OMIT the schema
    // attribute
    //Syntax: [Table("mytablename"[, Schema="the sqlschemaname"])]
    // the creation of this class is called MAPPING. You are supplying 
    //      a definition of the SQL table to your application

        [Table("Products")]
    public class Product
    {
        //remember the default access of a class is "private"
        //change it to public

        //all sql attributes will have a coresponding class
        // property
        //IF you use the attribute name as your property name
        // the physical order of the properties do NOT need to match
        // your sql attribute order

        // you need a [Key] annotation for your primary key field
        //[Key]: used on an identity pkey field
        //can also coded as [Key,DataGenerated(DataGeneratedOption.Identity)]

        //[Key,Colum[Order=n]]: used for compound primary keys
        // where n represents the PHYSICAL order of the components; 
        // n starts at 1 (natural number)

        //[Key,DataGenerated(DataGeneratedOption.None)]: used for
        // pkey's that are NOT compound OR user supplied (not identity)


        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }


        //there is a foreignkey annotation [ForeignKey] BUT is optionally
        //specifying the annotation is ONLY NEEDED IF your foreign key
        //  SQL field name is NOT the same as the associated primary key
        //  field name OR if you see a different name in your mapping

        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public Int16? UnitsInStock { get; set; }
        public Int16? UnitsOnOrder { get; set; }
        public Int16? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //optionally you can add your default and/or greedy constructors

        //other annotation examples
        //lets assume you would like to concatenate some fields together
        //  within your application on several occasions such as
        //  creating a full name out of two attributes FirstName and LastName

        //these are READONLY non map fields.
        //these properties do NOT expect data to be given to them
        //Entity framework will NOT expect data to be placed into these
        //  properties to be passed on to the database.

        [NotMapped]
        public string ProductandID
        {
            get
            {
                return ProductName + "(" + ProductID.ToString() + ")";
            }
        }
    }
}
