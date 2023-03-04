using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBookProject.Database.Tables
{
    public partial class CATEGORY
    {
        [Key]
        public int categoryid { get; set; }

        public string categoryname { get; set; }


    }
}
