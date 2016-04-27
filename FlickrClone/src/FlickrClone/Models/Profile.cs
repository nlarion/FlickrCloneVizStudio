using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlickrClone.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        public string About { get; set; }
        public string HomePage { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
