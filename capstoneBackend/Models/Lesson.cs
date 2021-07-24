using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneBackend.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string GoogleEventId { get; set; }
        public string GoogleRecurringId { get; set; }
        public string Comments { get; set; }
        public float FeeAmount { get; set; }
        public string Location { get; set; }
        public bool isNoShow { get; set; }

        [ForeignKey("RelationshipId")]
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

    }
}
