using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneBackend.Models
{
    public class Relationship
    {
        public int RelationshipId { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }

        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        [ForeignKey("TeacherId")]
        public virtual User Teacher { get; set; }

    }
}
