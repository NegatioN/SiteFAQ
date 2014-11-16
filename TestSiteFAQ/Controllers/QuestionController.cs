using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using TestSiteFAQ.Models;

namespace TestSiteFAQ.Controllers
{
    public class QuestionController : ApiController
    {
        private FAQContext db = new FAQContext();

        // GET: api/Question
        public HttpResponseMessage Get()
        {

            List<Question> list = db.getAllQuestions();
            JavaScriptSerializer json = new JavaScriptSerializer();

            String JsonString = json.Serialize(list);

            Debug.WriteLine(JsonString);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // GET: api/Question/5
        [ResponseType(typeof(PendingFAQ))]
        public IHttpActionResult GetPendingFAQ(int id)
        {
            Question pendingFAQ = db.pendingFaqs.Find(id);
            if (pendingFAQ == null)
            {
                return NotFound();
            }

            return Ok(pendingFAQ);
        }

        // PUT: api/Question/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPendingFAQ(int id, Question pendingFAQ)
        {

            Debug.WriteLine("Email: " + pendingFAQ.Email + "\nDescription: " + pendingFAQ.Description);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pendingFAQ.QuestionId)
            {
                return BadRequest();
            }

            db.Entry(pendingFAQ).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendingFAQExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Question
        [ResponseType(typeof(PendingFAQ))]
        public IHttpActionResult PostPendingFAQ(Question pendingFAQ)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pendingFaqs.Add(pendingFAQ);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pendingFAQ.QuestionId }, pendingFAQ);
        }

        // DELETE: api/Question/5
        [ResponseType(typeof(PendingFAQ))]
        public IHttpActionResult DeletePendingFAQ(int id)
        {
            Question pendingFAQ = db.pendingFaqs.Find(id);
            if (pendingFAQ == null)
            {
                return NotFound();
            }

            db.pendingFaqs.Remove(pendingFAQ);
            db.SaveChanges();

            return Ok(pendingFAQ);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PendingFAQExists(int id)
        {
            return db.pendingFaqs.Count(e => e.QuestionId == id) > 0;
        }
    }
}