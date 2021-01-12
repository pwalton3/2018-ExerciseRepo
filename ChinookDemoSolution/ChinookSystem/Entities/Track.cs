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
    [Table("Tracks")]
    internal class Track
    {
        private string _Composer;
        private int _AlbumId;
        [Key]
        public int TrackId { get; set; }
        [StringLength(200, ErrorMessage = "Name is limited to 200 characters!")]
        [Required(ErrorMessage = "Name is a required field!")]
        public string Name { get; set; }

        public int? AlbumId { get; set; }
        [Required(ErrorMessage = "Media type ID is a required value!")]
        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220, ErrorMessage = "Length is limited to 220 characters!")]
        public string Composer
        {
            get { return _Composer; }
            set { _Composer = string.IsNullOrEmpty(value) ? null : value; }
        }
        [Required(ErrorMessage = "Miliseconds is a required field!")]
        public int Miliseconds { get; set; }

        public int? Bytes { get; set; }
        [Required(ErrorMessage = "Unit Price is a required field!")]
        public decimal UnitPrice {get;set;}
    }
        
    
}
