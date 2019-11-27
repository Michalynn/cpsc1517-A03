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
    //annotation that will point this class to the appropriate
    //sql table
    //sometimes your sql database will be divided into groups;
    //   these groups are called schemas; you can recongize a
    //   shcema on a table using by the name ie HumanResources.tablename
    //IF your database does NOT have shcemas then you OMIT the schema
    //   attribute
    //syntax [Table("mytablename"[,Schema="the sqlschemaname"]]
    //the creation of this class is called MAPPING. You are supplying
    //    a definition of the sql table to your application

        [Table("Products")]
    public class Product
    {
        //remember the default access of a class is private.
        //change it to public

        //all sql attributes will have a coresponding class
        //  property
        //IF you use the attribute name as your property name
        //   the phyiscal order of the properties do NOT need to
        //   match your sql attribute order

        //you need a [Key] annotation for your primary key field
        //[Key] used on a identity pkey field
        //can also be coded as [Key,DataGenerated(DataGeneratedOption.Identity)]
        //[Key, Column[Order=n]] used for compound primary keys where
        //    n represents the PHYSICAL order of the components; 
        //    n starts at 1 (natural number)
        //[Key,DataGenerated(DataGeneratedOption.None)] used for
        //    primary keys that are NOT compound OR user supplied (NOT Identity)

        [Key]
        public int ProductID { get; set; }

        //entity validation goes in front of the property that is
        //  being validated
        [Required(ErrorMessage ="Product name is required")]
        [StringLength(160,ErrorMessage ="Product name is limited to 160 characters")]
        public string ProductName { get; set; }

        //there is a foreign key annotation [ForeignKey] BUT is is optionally
        //specifying the annotation is ONLY NEEDED IF your foreign key
        //    sql field name is NOT the same as the associated primary key
        //    field name OR if you use a different name in your mapping
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }

        [StringLength(20, ErrorMessage = "Quanity per Unit is limited to 20 characters")]
        public string QuantityPerUnit { get; set; }

        [Range(0.00,double.MaxValue,ErrorMessage ="Unit Price must be 0.00 or greater")]
        public decimal? UnitPrice { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "Unit in Stock must be 0 to 32767")]
        public Int16? UnitsInStock { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "Unit on Order must be 0 to 32767")]
        public Int16? UnitsOnOrder { get; set; }

        [Range(0, Int16.MaxValue, ErrorMessage = "Reorder level must be 0 to 32767")]
        public Int16? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        //optionally you can add your default and/or greedy constructors

        //other annotation examples
        //lets assume you would like to concatenate some fields together
        //    within your application on several occasion such as
        //    creating a full name out of two attributes FirstName and LastName

        //these are ready-only non mapped fields. 
        //these properties do NOT expect data to the given to them
        //EntityFramework will NOT expect data to be placed into these
        //    properties to be passed on to the database.

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
