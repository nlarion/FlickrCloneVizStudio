using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlickrClone.Models
{
    [Table("Photos")]
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }    
        public string Comment { get; set; }
        public string Location { get; set; }
        public bool Public { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
