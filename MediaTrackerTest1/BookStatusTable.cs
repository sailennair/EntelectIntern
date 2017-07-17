﻿namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookStatusTable")]
    public partial class BookStatusTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookStatusTable()
        {
            BookTransitionTables = new HashSet<BookTransitionTable>();
        }

        [Key]
        public int StatusID { get; set; }

        [Required]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookTransitionTable> BookTransitionTables { get; set; }

       
    }
}
