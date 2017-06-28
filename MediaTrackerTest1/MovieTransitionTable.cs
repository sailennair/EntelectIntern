namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MovieTransitionTable")]
    public partial class MovieTransitionTable : Entity
    {
        [Key]
        public int TransitionID { get; set; }

        public int MovieID { get; set; }

        public int UserID { get; set; }

        public int StatusID { get; set; }
         


        public virtual AppUserTable AppUserTable { get; set; }

        public virtual MovieTable MovieTable { get; set; }

        public virtual StatusTable StatusTable { get; set; }
    }
}
