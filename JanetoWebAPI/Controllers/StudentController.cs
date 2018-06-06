using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using JanetoWebAPI.ViewModels;
using ApiModels;
using JanetoWebAPI.Infrastructure;

namespace JanetoWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private ApiDBContext _db;
        public StudentController()
        {
            this._db = new ApiDBContext();
        }
        /**
         * @api {POST} /student/CreateStudent Create one student
         * @apigroup Student
         * @apiPermission none
         * 
         * 
         * @apiParam {int} StudentId StudentId of student
         * @apiParam {DateTime} StudentBirth  Birthday of student
         * @apiParam {string} StudentAddress Address of student
         * @apiParam {string} StudentName Name of student
         * @apiParam {int} Class_Id Id class of student
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      StudentId:"123",
         *      StudentBirth:"09/09/1997",
         *      StudentAddress:"CMT8",
         *      StudentName:"Đỗ Đức Huy",
         *      Class_Id: 1
         * }
         * 
         * @apiSuccess {int} StudentId StudentId of student has been created
         * @apiSuccess {DateTime} StudentBirth  Birthday of student has been created
         * @apiSuccess {string} StudentAddress Address of student has been created
         * @apiSuccess {string} StudentName Name of student has been created
         * @apiSuccess {int} Class_Id Id class of student has been created
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      Id: 1,
         *      StudentId:123,
         *      StudentBirth:"09/09/1997",
         *      StudentAddress:"CMT8",
         *      StudentName:"Đỗ Đức Huy",
         *      Class_Id: 1
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample:{json}
         * {
         *      "Error":[
         *          "StudentName" is required
         *          "StudentAddress" is required
         *      ]
         * }
         */
        //Tạo 
        [HttpPost]
        public IHttpActionResult CreateStudent(CreateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            if (string.IsNullOrEmpty(model.StudentName))
            {
                error.Add("Họ tên là bắt buộc!");
            }
            if (string.IsNullOrEmpty(model.StudentAddress))
            {
                error.Add("Địa chỉ là bắt buộc!");
            }
            if (error.Errors.Count == 0)
            {
                Student sv = new Student();
                sv.StudentName = model.StudentName;
                sv.StudentAddress = model.StudentAddress;
                sv.StudentBirth = model.StudentBirth;
                sv.StudentId = model.StudentId;
                sv.Class= _db.Class.FirstOrDefault(x => x.Id == model.Class_Id);
                sv = this._db.Student.Add(sv);
                this._db.SaveChanges();
                StudentModel viewModel = new StudentModel(sv);
                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            return httpActionResult;
        }
        /**
        * @api {PUT} /student/UpdateStudent Update one student
        * @apigroup Student
        * @apiPermission none
        * 
        * @apiSuccess {int} StudentId StudentId of student 
        * @apiSuccess {DateTime} StudentBirth  Birthday of student 
        * @apiSuccess {string} StudentAddress Address of student 
        * @apiSuccess {string} StudentName Name of student 
        * @apiSuccess {int} Class_Id Id class of student 
        * 
        * @apiParamExample {json} Request-Example:
        * {
        *       Id: 1,
        *       StudentId:123,
        *       StudentBirth:"09/09/1997",
        *       StudentAddress:"CMT8",
        *       StudentName:"Đỗ Đức Huy",
        *       Class_Id: 1
        * }
        * 
        * @apiSuccess {int} StudentId StudentId of student has been updated
        * @apiSuccess {DateTime} StudentBirth  Birthday of student has been updated
        * @apiSuccess {string} StudentAddress Address of student has been updated
        * @apiSuccess {string} StudentName Name of student has been updated
        * @apiSuccess {int} Class_Id Id class of student has been updated
        *  
        * @apiSuccessExample {json} Response:
        * {
        *       Id: 1,
        *       StudentId:123,
        *       StudentBirth:"09/09/1997",
        *       StudentAddress:"CMT8",
        *       StudentName:"Đỗ Đức Huy",
        *       Class_Id: 1
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample:{json}
        * {
        *      "Error":[
        *          "StudentName" is required
        *          "StudentAddress" is required
        *      ]
        * }
        */
        //Sửa 
        [HttpPut]
        public IHttpActionResult UpdateStudent(UpdateStudentModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            Student sv = this._db.Student.FirstOrDefault(x => x.Id == model.Id);
            if (sv == null)
            {
                error.Add("Không tìm thấy Sinh viên!");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            else
            {
                sv.StudentName = model.StudentName ?? model.StudentName;
                sv.StudentId = model.StudentId;
                sv.StudentBirth = model.StudentBirth;
                sv.StudentAddress = model.StudentAddress ?? model.StudentAddress;
                //sv.Class.Id = model.ClassId;
                this._db.Entry(sv).State = System.Data.Entity.EntityState.Modified;
                this._db.SaveChanges();
                httpActionResult = Ok(new StudentModel(sv));
            }
            return httpActionResult;
        }
        /**
       * @api {GET} /student/GetAllStudent Get all student 
       * @apigroup Student
       * @apiPermission none
       * 
       * 
       * 
       * @apiSuccessExample {json} Response:
       * {
       *      Id: 1,
       *      StudentId:123,
       *      StudentBirth:"09/09/1997",
       *      StudentAddress:"CMT8",
       *      StudentName:"Đỗ Đức Huy",
       *      Class_Id: 1
       *      
       *      Id: 2,
       *      StudentId:124,
       *      StudentBirth:"09/09/1998",
       *      StudentAddress:"Hoàng Diệu",
       *      StudentName:"Đỗ Đức Phát",
       *      Class_Id: 1
       * }
       * 
       * @apiError [400] {string[]} Errors Array of error
       * @apiErrorExample:{json}
       * {
       *      "Error":[
       *          
       *      ]
       * }
       */
        //Lấy tất cả 
        [HttpGet]
        public IHttpActionResult GetAllStudent()
        {
            var lstStudent = this._db.Student.Select(x => new StudentModel()
            {
                Id = x.Id,
                StudentId = x.StudentId,
                StudentName = x.StudentName,
                StudentBirth = x.StudentBirth,
                StudentAddress = x.StudentAddress,
                Class_Id = x.Class.Id
            });
            return Ok(lstStudent);
        }
        /**
    * @api {GET} /student/GetStudentByStudentId?studentId=:studentId Get one class by studentid
    * @apigroup Student
    * @apiPermission none
    * 
    * @apiParam {int} StudentId StudentId of student
    * 
    * @apiExample Example usage: 
    * 
    * /student/GetStudentByStudentId?studentId=123
    * 
    * @apiSuccessExample {json} Response:
    * {
    *      Id: 1,
    *      StudentId:123,
    *      StudentBirth:"09/09/1997",
    *      StudentAddress:"CMT8",
    *      StudentName:"Đỗ Đức Huy",
    *      Class_Id: 1
    * }
    * 
    * @apiError [400] {string[]} Errors Array of error
    * @apiErrorExample:{json}
    * {
    *      "Error":[
    *          Không tìm thấy sinh viên!
    *      ]
    * }
    */
        //Lấy theo mã
        [HttpGet]
        public IHttpActionResult GetStudentByStudentId(int studentId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var sv = _db.Student.FirstOrDefault(x => x.StudentId == studentId);
            if (sv == null)
            {
                error.Add("Không tìm thấy sinh viên!");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }
            return httpActionResult;
        }
        /**
    * @api {DELETE} /student/DeleteStudent?studentId=:studentId Delete one student by studentId
    * @apigroup Student
    * @apiPermission none
    * 
    * @apiParam {int} studentId StudentId of student
    * 
    * @apiExample Example usage: 
    * 
    * /student/DeleteStudent?studentId=123
    * 
    * @apiSuccessExample {json} Response:
    * {
    *      Đã xóa sinh viên 123
    * }
    * 
    * @apiError [400] {string[]} Errors Array of error
    * @apiErrorExample:{json}
    * {
    *      "Error":[
    *          Mã sinh viên không tồn tạo!
    *      ]
    * }
    */
        //Xóa sinh viên
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int studentId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var sv = _db.Student.FirstOrDefault(x => x.StudentId == studentId);
            if (sv == null)
            {
                error.Add("Mã sinh viên không tồn tạo!");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            else
            {
                this._db.Student.Remove(sv);
                this._db.SaveChanges();
                httpActionResult = Ok("Đã xóa sinh viên " + sv.StudentId);
            }
            return httpActionResult;
        }

    }
}