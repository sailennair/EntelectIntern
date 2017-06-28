namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EpisodesTable")]

    public partial class EpisodesTable :Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EpisodesTable()
        {
            SeriesTransitionTables = new HashSet<SeriesTransitionTable>();

        }


        [Key]
        public int EpisodesID { get; set; }

        public int SeriesID { get; set; }


        [Required]
        public int Season { get; set; }




        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeriesTransitionTable> SeriesTransitionTables { get; set; }

        public virtual SeriesTable SeriesTable { get; set; }

    }
}