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
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentsController(ApplicationDbContext context)
        {
            _context = context;
        }


        public class PaymentSubmission
        {
            public string StudentId { get; set; }
            public int MethodId { get; set; }
            public float Amount { get; set; }
        }

        [HttpPost, Authorize(Roles = "Teacher")]

        public IActionResult PostNewPayment([FromBody] PaymentSubmission paymentSubmission)
        {
            var myId = User.FindFirstValue("id");
            var relationshipId = _context.Relationships.Where(r => r.TeacherId == myId && r.StudentId == paymentSubmission.StudentId).Select(r => r.RelationshipId).SingleOrDefault();
            var relationship = _context.Relationships.Where(r => r.RelationshipId == relationshipId).SingleOrDefault();
            var student = _context.Relationships.Where(r => r.RelationshipId == relationshipId).Include(r => r.Student).Select(r => r.Student).SingleOrDefault();
            var date = DateTime.Now;
            if (relationshipId != 0)
            {
                Payment payment = new Payment
                {
                    Amount = paymentSubmission.Amount,
                    DateTime = date,
                    RelationshipId = relationshipId,
                    MethodId = paymentSubmission.MethodId
                };
                _context.Payments.Add(payment);
                relationship.Balance -= paymentSubmission.Amount;
                _context.SaveChanges();
                var returnItem = _context.Payments.Where(p => p.PaymentId == payment.PaymentId).Include(p => p.Method).Include(p => p.Relationship).Include(p => p.Relationship.Student).Select(p => new 
                {
                    PaymentId = p.PaymentId,
                    Amount = p.Amount,
                    DateTime = p.DateTime,
                    RelationshipId = p.RelationshipId,
                    MethodId = p.MethodId,
                    MethodName = p.Method.Name,
                    Balance = p.Relationship.Balance,
                    Student = p.Relationship.Student
                }).SingleOrDefault();
                return StatusCode(201, returnItem);
            }
            else
            {
                return StatusCode(404, "Relationship not found");
            }
        }

        [HttpGet("all"), Authorize]

        public IActionResult GetAllMyPayments()
        {
            var myId = User.FindFirstValue("id");
            var myRelationshipIds = _context.Relationships.Where(r => r.TeacherId == myId || r.StudentId == myId).Select(r => r.RelationshipId).ToList();
            var myPayments = _context.Payments.Where(p => myRelationshipIds.Contains(p.RelationshipId)).Include(p => p.Relationship.Student).Include(p => p.Relationship.Teacher).Select(p => new
            {
                paymentId = p.PaymentId,
                amount = p.Amount,
                methodId = p.MethodId,
                methodName = p.Method.Name,
                dateTime = p.DateTime,
                relationshipId = p.RelationshipId,
                student = p.Relationship.Student,
                teacher = p.Relationship.Teacher
            });
            return Ok(myPayments);
        }

        [HttpDelete("delete/{paymentId}"), Authorize(Roles = "Teacher")]

        public IActionResult DeletePayment(int paymentId)
        {
            var myId = User.FindFirstValue("id");
            var paymentToDelete = _context.Payments.Where(p => p.PaymentId == paymentId).Include(p => p.Relationship.Teacher).SingleOrDefault();
            if(paymentToDelete.Relationship.Teacher.Id != myId)
            {
                return StatusCode(401, "Payment can only be deleted by teacher who created it.");
            }
            try
            {
                _context.Remove(paymentToDelete);
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }
    }
}
