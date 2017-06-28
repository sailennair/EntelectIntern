namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppUserTable")]
    public partial class AppUserTable : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AppUserTable()
        {
            MovieTransitionTables = new HashSet<MovieTransitionTable>();
        }

        [Key]
        public int UserID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

      

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieTransitionTable> MovieTransitionTables { get; set; }
        public virtual ICollection<BookTransitionTable> BookTransitionTables { get; set; }

        public virtual ICollection<SeriesTransitionTable> SeriesTransitionTables { get; set; }
    }
}
