using capstoneBackend.Data;
using capstoneBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace capstoneBackend.Controllers
{
    [Route("api/documents")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DocumentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("relationship={relationshipId}"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult> PostDocument([FromForm] DocumentViewModel file, int relationshipId)
        {
            try
            {
                if (file.Document != null) {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.DocumentName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await file.Document.CopyToAsync(stream);
                    }

                    Document doc = new Document();
                    doc.DocumentName = file.DocumentName;
                    doc.DocumentPath = path;
                    doc.RelationshipId = relationshipId;
                    _context.Add(doc);
                    await _context.SaveChangesAsync();
                    return StatusCode(201, doc);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("info/relationship={relationshipId}"), Authorize]
        public IActionResult GetDocumentInfo(int relationshipId)
        {
            try
            {
                var docs = _context.Documents.Where(d => d.RelationshipId == relationshipId);
                return Ok(docs);
            }
            catch (Exception)
            {
                return StatusCode(500, relationshipId);
            }
        }

        [HttpGet("download/{id}"), Authorize]
        public async Task<ActionResult> DownloadFile(int id)
        {
            var userId = User.FindFirstValue("id");
            var userRelationshipIds = _context.Relationships.Where(r => r.StudentId == userId || r.TeacherId == userId).Select(r => r.RelationshipId).ToList();
            var docToDownload = _context.Documents.Where(d => d.DocumentId == id).SingleOrDefault();
            if (userRelationshipIds.Contains(docToDownload.RelationshipId))
            {
                var provider = new FileExtensionContentTypeProvider();
                try
                {
                    string contentType;
                    if (!provider.TryGetContentType(docToDownload.DocumentName, out contentType))
                    {
                        contentType = "application/octet-stream";
                    }
                    var bytes = await System.IO.File.ReadAllBytesAsync(docToDownload.DocumentPath);
                    return File(bytes, contentType, Path.GetFileName(docToDownload.DocumentPath));
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(401, "Document not linked to any of user's relationships.");
            }

        }

        [HttpDelete("delete/{id}"), Authorize]
        public IActionResult DeleteFile(int id)
        {
            try
            {
                var userId = User.FindFirstValue("id");
                var userRelationshipIds = _context.Relationships.Where(r => r.StudentId == userId || r.TeacherId == userId).Select(r => r.RelationshipId).ToList();
                var docToDelete = _context.Documents.Where(d => d.DocumentId == id).SingleOrDefault();
                if (userRelationshipIds.Contains(docToDelete.RelationshipId))
                {
                    string path = docToDelete.DocumentPath;
                    _context.Documents.Remove(docToDelete);
                    _context.SaveChanges();
                    System.IO.File.Delete(path);
                    return StatusCode(204);
                }
                else
                {
                    return StatusCode(401, "Document not linked to any of user's relationships.");
                }
                
            }
            catch (Exception)
            {
                return StatusCode(500, id);
            }
        }

    }
}
