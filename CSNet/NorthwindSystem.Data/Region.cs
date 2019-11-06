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
    [Table ("Region")]
    public class Region
    {
        //The region primary key was created as a non identity field in the 
        // SQL database
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    }
}
