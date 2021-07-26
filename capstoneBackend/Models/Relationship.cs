using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public float Balance { get; set; } = 0;

        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        [ForeignKey("TeacherId")]
        public virtual User Teacher { get; set; }

    }
}
