namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusTable")]
    public partial class StatusTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusTable()
        {
            MovieTransitionTables = new HashSet<MovieTransitionTable>();
        }

        [Key]
        public int StatusID { get; set; }

        [Required]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieTransitionTable> MovieTransitionTables { get; set; }

        public virtual ICollection<SeriesTransitionTable> SeriesTransitionTables { get; set; }
    }
}
