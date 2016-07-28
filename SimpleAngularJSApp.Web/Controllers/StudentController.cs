using SimpleAngularJSApp.Data.Repositories;
using SimpleAngularJSApp.Entities;
using SimpleAngularJSApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleAngularJSApp.Web.Controllers
{
    [RoutePrefix("api/student")]
    public class StudentController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Student> _studentRepository;

        public StudentController() : base()
        {
            _studentRepository = new EntityBaseRepository<Student>(); //studentRepository;
        }

        [HttpGet]
        public HttpResponseMessage Students(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                
                var stundents = _studentRepository.GetAll()
                    .Select(s => new StudentDTO() 
                    { 
                        ID = s.ID, 
                        FirstName = s.FirstName, 
                        LastName = s.LastName 
                    }).ToList();
                    
                response = request.CreateResponse(HttpStatusCode.OK, stundents);

                return response;
            });
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public HttpResponseMessage StudentDetail(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var student = _studentRepository.FindBy(s => s.ID == id)
                    .Select(s => new StudentDTO()
                    {
                        ID = s.ID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        BirthDate = s.BirthDate
                    }).FirstOrDefault();

                response = request.CreateResponse(HttpStatusCode.OK, student);

                return response;
            });
        }

        [HttpGet]
        [Route("edit/{id:int}")]
        public HttpResponseMessage EditStudent(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var student = _studentRepository.FindBy(s => s.ID == id)
                    .Select(s => new StudentDTO()
                    {
                        ID = s.ID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        BirthDate = s.BirthDate
                    }).FirstOrDefault();

                response = request.CreateResponse(HttpStatusCode.OK, student);

                return response;
            });
        }

        [HttpPost]
        [Route("edit")]
        public HttpResponseMessage EditStudent(HttpRequestMessage request, StudentDTO model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Student student = _studentRepository.GetSingle(model.ID);
                student.FirstName = model.FirstName;
                student.LastName = model.LastName;
                student.BirthDate = model.BirthDate;

                _studentRepository.Edit(student);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddStudent(HttpRequestMessage request, StudentDTO model)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Student student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate
                };

                _studentRepository.Add(student);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }

        [HttpGet]
        [Route("delete/{id:int}")]
        public HttpResponseMessage DeleteStudent(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                Student studet = new Student { ID = id };

                _studentRepository.Delete(studet);

                response = request.CreateResponse(HttpStatusCode.OK);

                return response;
            });
        }

    }
}