namespace ChinookSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    internal partial class Playlist
    {
        private string _UserName;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", 
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Playlist()
        {
            PlaylistTracks = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "Name is limited to 120 characters!")]
        public string Name { get; set; }

        [StringLength(120, ErrorMessage = "User name is limited to 120 characters!")]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = string.IsNullOrEmpty(value) ? null : value; }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaylistTrack> PlaylistTracks { get; set; }
    }
}
