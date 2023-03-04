using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBookProject.Database.Tables
{
    public partial class BOOK
    {
        [Key]
        public int bookid { get; set; }

        public string bookname { get; set; }

        [ForeignKey("tbl_CATEGORY")]
        public int categoryid { get; set; }  //foreign key

        

        public string author { get; set; }

        public string publisher { get; set; } 

        public decimal price { get; set; }

        public virtual CATEGORY CATEGORY { get; set; } //navigation propety

        
    }
}
