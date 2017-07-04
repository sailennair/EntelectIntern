using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTrackerTest1
{
    public abstract class Entity
    {
        [Required]
        public bool isDeleted { get; set; }
    }
}
