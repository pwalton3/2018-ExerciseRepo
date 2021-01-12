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
    [Table("Albums")]
   internal class Album
    {
        private string _ReleaseLabel;
        private int _ReleaseYear;

        [Key]
        public int AlbumId { get; set; }
        
        [Required(ErrorMessage = "Album title is required!")]
        [StringLength(160, ErrorMessage = "Album title is limited to 160 characters!")]
        public string Title { get; set; }

        public int ArtistId { get; set; }

        public int ReleaseYear
        {
            
            get { return _ReleaseYear; }
            set
            {
                if (_ReleaseYear < 1950  || _ReleaseYear > DateTime.Today.Year)
                {
                    throw new Exception("Album release year is before 1950 or a year in the future");
                }
                else
                {
                    _ReleaseYear = value;
                }
            }

        }

        [StringLength(150, ErrorMessage = "Release Label is limited to 120 characters.")]
        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set { _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value; }
        }
        //you can still use your [NotMapped] annotations 

        //navigational properties
        //ClassInstanceName.ProperyName.FieldPropertyName (all lowercase)

        //many to 1 relationship
        //create the 1 end of the relationship in this entity
        //navigational properties refer to the relationship between two tables
        public virtual Artist Artist { get; set; }

        //not valid UNTIL the Track entity is coded.
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
