using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneBackend.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }

        [ForeignKey("RelationshipId")]
        public int RelationshipId { get; set; }
        public Relationship Relationship { get; set; }

    }

    public class DocumentViewModel
    {
        public string DocumentName { get; set; }
        public IFormFile Document { get; set; }
    }
}
