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
                studentUsername = r.Student.UserName,
                balance = r.Balance
            });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost(), Authorize]

        public IActionResult PostNewRelationshipAsStudent([FromBody] User partner)
        {
            var userId = User.FindFirstValue("id");
            var partnerId = partner.Id;
            try
            {
                if (User.IsInRole("Student"))
                {
                    Relationship newRelationship = new Relationship
                    {
                        StudentId = userId,
                        TeacherId = partnerId
                    };
                    _context.Relationships.Add(newRelationship);
                    _context.SaveChanges();
                    return Ok(newRelationship);
                }
                else
                {
                    Relationship newRelationship = new Relationship
                    {
                        StudentId = partnerId,
                        TeacherId = userId
                    };
                    _context.Relationships.Add(newRelationship);
                    _context.SaveChanges();
                    return Ok(newRelationship);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            
        }

        [HttpDelete("breakup"), Authorize]

        public IActionResult RemoveRelationship([FromBody] User partner)
        {
            try
            {
                if (User.IsInRole("Student"))
                {
                    var userId = User.FindFirstValue("id");
                    var relationship = _context.Relationships.Where(r => (r.StudentId == userId) && (r.TeacherId == partner.Id)).SingleOrDefault();
                    if (relationship != null)
                    {
                        _context.Remove(relationship);
                        _context.SaveChanges();
                        return StatusCode(204);
                    }
                    else
                    {
                        return StatusCode(404);
                    }
                }
                else
                {
                    var userId = User.FindFirstValue("id");
                    var relationship = _context.Relationships.Where(r => (r.TeacherId == userId) && (r.StudentId == partner.Id)).SingleOrDefault();
                    if (relationship != null)
                    {
                        _context.Remove(relationship);
                        _context.SaveChanges();
                        return StatusCode(204);
                    }
                    else
                    {
                        return StatusCode(404);
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("update_balance"), Authorize(Roles = "Teacher")]

        public IActionResult UpdateStudentBalance([FromBody] Relationship body)
        {
            var myId = User.FindFirstValue("id");
            var relationship = _context.Relationships.Where(r => r.TeacherId == myId && r.StudentId == body.StudentId).SingleOrDefault();
            if (relationship == null)
            {
                return StatusCode(401, "Not your student.");
            }
            relationship.Balance = body.Balance;
            _context.SaveChanges();
            var returnInfo = _context.Relationships.Where(r => r.TeacherId == myId && r.StudentId == body.StudentId).Include(r => r.Teacher).Include(r => r.Student).Select(r => new
            {
                relationshipId = r.RelationshipId,
                teacherId = r.TeacherId,
                studentId = r.StudentId,
                teacherUsername = r.Teacher.UserName,
                studentUsername = r.Student.UserName,
                balance = r.Balance
            }).SingleOrDefault();
            return Ok(returnInfo);
        }

    }
}
