using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additional NameSpace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

#endregion

namespace ChinookSystem.Entities
{
    [Table("Artists")]
    internal class Artist
    {
        private string _Name;
        [Key]
        public int ArtistId { get; set; }


        [StringLength(120, ErrorMessage = "Artist Name is limited to 120 characters.")]
        public string Name
        {
            get { return _Name;}
            set {_Name = string.IsNullOrEmpty(value) ? null : value; }
        }
        //navigational properties
        //1 to many relationship; create the many relationship in this entity
        //think of it like this
        //Artist has a collection of Albums; an Album belongs to an Artist
        public virtual ICollection<Album> Albums { get; set; }
    }
}
