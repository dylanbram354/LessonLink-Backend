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
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("teachers")]

        public IActionResult GetAllTeachers()
        {
            var teacherUserRole = _context.Roles.Where(r => r.NormalizedName == "TEACHER").Select(r => r.Id).SingleOrDefault();
            var allTeacherIds = _context.UserRoles.Where(ur => ur.RoleId == teacherUserRole).Select(ur => ur.UserId).ToList();
            List<User> allTeachers = new List<User>();
            foreach (string teacherId in allTeacherIds)
            {
                allTeachers.Add(_context.Users.Where(u => u.Id == teacherId).SingleOrDefault());
            }
            return Ok(allTeachers);
        }

        [HttpGet("students")]

        public IActionResult GetAllStudents()
        {
            var studentUserRole = _context.Roles.Where(r => r.NormalizedName == "STUDENT").Select(r => r.Id).SingleOrDefault();
            var allStudentIds = _context.UserRoles.Where(ur => ur.RoleId == studentUserRole).Select(ur => ur.UserId).ToList();
            List<User> allStudents = new List<User>();
            foreach (string studentId in allStudentIds)
            {
                allStudents.Add(_context.Users.Where(u => u.Id == studentId).SingleOrDefault());
            }
            return Ok(allStudents);
        }

        [HttpGet("my_teachers"), Authorize(Roles = "Student")]

        public IActionResult GetMyTeachers()
        {
            var myId = User.FindFirstValue("id");
            var myTeachers = _context.Relationships.Where(r => r.StudentId == myId).Include(r => r.Teacher).Select(r => new { relationshipId = r.RelationshipId, teacher = r.Teacher });
            return Ok(myTeachers);
        }

        [HttpGet("my_students"), Authorize(Roles = "Teacher")]

        public IActionResult GetMyStudents()
        {
            var myId = User.FindFirstValue("id");
            var myStudents = _context.Relationships.Where(r => r.TeacherId == myId).Include(r => r.Student).Select(r => new { relationshipId = r.RelationshipId, balance = r.Balance, student = r.Student });
            return Ok(myStudents);
        }

        [HttpGet(), Authorize]

        public IActionResult GetUserInfo([FromBody] User user)
        {
            var foundUser = _context.Users.Where(u => u.Id == user.Id).SingleOrDefault();
            return Ok(foundUser);
        }
    }
}
