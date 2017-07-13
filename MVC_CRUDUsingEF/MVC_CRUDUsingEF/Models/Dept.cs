using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVC_CRUDUsingEF.Models
{   [Table("Depts")]
    public class Dept
    {   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // to disable identity
        public int DeptNo { get; set; }

        [MaxLength(50)]
        public string DName { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }
    }
}