namespace MediaTrackerTest1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SeriesTransitionTable")]
    public partial class SeriesTransitionTable : Entity
    {
        [Key]
        public int SeriesTransitionID { get; set; }

        public int EpisodesID { get; set; }

        public int UserID { get; set; }

        public int StatusID { get; set; }
       

        public virtual AppUserTable AppUserTable { get; set; }

        public virtual EpisodesTable EpisodesTable { get; set; }

        public virtual StatusTable StatusTable { get; set; }


    }
}
