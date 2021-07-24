using capstoneBackend.Data;
using capstoneBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Capstone_Backend.Controllers
{
    [Route("api/relationships")]
    [ApiController]
    public class RelationshipsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RelationshipsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        public IActionResult GetAllRelationships()
        {
            var result = _context.Relationships.Include(r => r.Teacher).Include(r => r.Student).Select(r => new
            {
                relationshipId = r.RelationshipId,
                teacherId = r.TeacherId,
                studentId = r.StudentId,
                teacherUsername = r.Teacher.UserName,
                studentUsername = r.Student.UserName
            });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost(), Authorize(Roles ="Student")]

        public IActionResult PostNewRelationshipAsStudent([FromBody] User teacher)
        {
            var userId = User.FindFirstValue("id");
            var teacherId = teacher.Id;
            Relationship newRelationship = new Relationship
            {
                StudentId = userId,
                TeacherId = teacherId
            };
            _context.Relationships.Add(newRelationship);
            _context.SaveChanges();
            return Ok(newRelationship);
        }
    }
}
