using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneBackend.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public float Amount { get; set; }

        public DateTime? DateTime { get; set; }
        
        [ForeignKey("RelationshipId")]
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

        [ForeignKey("MethodId")]

        public int MethodId { get; set; }
        public PaymentMethod Method { get; set; }
    }
}
