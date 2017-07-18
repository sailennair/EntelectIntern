

namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeriesTable")]

    public partial class SeriesTable : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeriesTable()
        {
            EpisodesTables = new HashSet<EpisodesTable>();
        }

        [Key]
        public int SeriesID { get; set; }

        [Required]
        public string SeriesName { get; set; }

        public string SeriesPicture { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EpisodesTable> EpisodesTables { get; set; }




    }


}