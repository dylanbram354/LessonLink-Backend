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


namespace capstoneBackend.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LessonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create/studentId={studentId}"), Authorize(Roles = "Teacher")]
        public IActionResult PostLesson([FromBody] Lesson lesson, string studentId)
        {
            var userId = User.FindFirstValue("id");
            var relationshipId = _context.Relationships.Where(r => r.TeacherId == userId && r.StudentId == studentId).Select(r => r.RelationshipId).SingleOrDefault();
            lesson.RelationshipId = relationshipId;
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return StatusCode(201, lesson);
        }

        [HttpGet("{lessonId}"), Authorize]

        public IActionResult GetLessonById(int lessonId)
        {
            var lesson = _context.Lessons.Where(l => l.LessonId == lessonId).SingleOrDefault();
            return Ok(lesson);
        }

        [HttpGet("all"), Authorize]
        public IActionResult GetMyLessons()
        {
            var userId = User.FindFirstValue("id");
            var relationshipId = _context.Relationships.Where(r => r.TeacherId == userId).Select(r => r.RelationshipId).SingleOrDefault();
            var myLessons = _context.Lessons.Where(l => l.RelationshipId == relationshipId).ToList();
            return Ok(myLessons);
        }

        [HttpPut("edit/{lessonId}"), Authorize(Roles = "Teacher")]
        public IActionResult EditLessonById(int lessonId, [FromBody] Lesson newLesson)
        {
            var userId = User.FindFirstValue("id");
            var lessonToEdit = _context.Lessons.Include(l => l.Relationship).Include(l => l.Relationship.Student).Where(l => l.LessonId == lessonId).SingleOrDefault();
            var student = lessonToEdit.Relationship.Student;
            if (lessonToEdit.Relationship.TeacherId == userId)
            {
                lessonToEdit.Comments = newLesson.Comments;
                if (newLesson.FeeAmount != 0)
                {
                    lessonToEdit.FeeAmount = newLesson.FeeAmount;
                }
                lessonToEdit.isNoShow = newLesson.isNoShow;
                _context.SaveChanges();
                var editedLesson = _context.Lessons.Where(l => l.LessonId == lessonToEdit.LessonId).SingleOrDefault();
                return Ok(editedLesson);
            }
            else
            {
                return StatusCode(401);
            }
        }

        [HttpDelete("delete/{lessonId}"), Authorize(Roles = "Teacher")]
        public IActionResult DeleteLessonById(int lessonId)
        {
            var userId = User.FindFirstValue("id");
            var relationshipId = _context.Relationships.Where(r => r.TeacherId == userId).Select(r => r.RelationshipId).SingleOrDefault();
            var lessonToDelete = _context.Lessons.Where(l => l.LessonId == lessonId).SingleOrDefault();
            if (lessonToDelete.RelationshipId == relationshipId)
            {
                _context.Remove(lessonToDelete);
                _context.SaveChanges();
                return StatusCode(204);
            }
            else
            {
                return StatusCode(403);
            }
        }
    }
}
