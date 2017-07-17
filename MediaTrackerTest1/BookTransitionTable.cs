namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookTransitionTable")]
    public partial class BookTransitionTable //: Entity
    {
        [Key]
        public int BookTransitionID { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }

        [Required]
        public bool Read { get; set; }

        public int StatusID { get; set; }

       

        public virtual AppUserTable AppUserTable { get; set; }
        public virtual BookTable BookTable { get; set; }
        public virtual BookStatusTable BookStatusTable { get; set; }

        
    }
}
