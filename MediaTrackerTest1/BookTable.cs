

namespace MediaTrackerTest1
{ 
     using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

[Table("BookTable")]

public partial class BookTable : Entity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookTable()
        {
            BookTransitionTables = new HashSet<BookTransitionTable>();
        }

        [Key]
        public int BookID { get; set; }

        [Required]
        public string BookName { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookTransitionTable> BookTransitionTables { get; set; }




    }

   
}
