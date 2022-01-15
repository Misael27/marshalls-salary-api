using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarshallsSalary.Core.Entities
{
    public class Office
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfficeId { get; set; }
        public string Name { get; set; }
    }
}
