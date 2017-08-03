using AngularJs_Inline_Editing_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJs_Inline_Editing_WebApi.Controllers
{
    public class StudentApiController : ApiController
    {
        dbEntities db = new dbEntities();

        //Get All Student
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return db.Students.AsEnumerable();
        }

        //Get Student By Id
        public Student Get(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return Student;
        }

        //Insert Student
        public HttpResponseMessage Post(Student Student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(Student);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Student.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        //Update Student
        public HttpResponseMessage Put(int id, Student Student)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != Student.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(Student).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //Delete Student By Id
        public HttpResponseMessage Delete(int id)
        {
            Student Student = db.Students.Find(id);
            if (Student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Students.Remove(Student);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Student);
        }

        // Memory Management
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
