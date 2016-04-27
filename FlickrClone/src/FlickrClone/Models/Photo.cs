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
        public bool Public { get; set; }
        public int ProifleId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
