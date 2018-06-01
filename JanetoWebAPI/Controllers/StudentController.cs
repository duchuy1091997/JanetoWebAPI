using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using JanetoWebAPI.ViewModels;
using ApiModels;

namespace JanetoWebAPI.Controllers
{
    public class StudentController : ApiController
    {
        private ApiDBContext _db;
        public StudentController()
        {
            this._db = new ApiDBContext();
        }
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
                httpActionResult = Ok(error);
            }
            return httpActionResult;
        }
        //Sửa 
        [HttpPut]
        public IHttpActionResult UpdateStudent(UpdateStudentModel model)
        {
            IHttpActionResult httpActionresult;
            ErrorModel error = new ErrorModel();
            Student sv = this._db.Student.FirstOrDefault(x => x.Id == model.Id);
            if (sv == null)
            {
                error.Add("Không tìm thấy Sinh viên!");
                httpActionresult = Ok(error);
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
                httpActionresult = Ok(new StudentModel(sv));
            }
            return httpActionresult;
        }
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
        //Lấy theo mssv
        [HttpGet]
        public IHttpActionResult GetStudentByStudentId(int studentId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var sv = _db.Student.FirstOrDefault(x => x.StudentId == studentId);
            if (sv == null)
            {
                error.Add("Không tìm thấy sinh viên!");
                httpActionResult = Ok(error);
            }
            else
            {
                httpActionResult = Ok(new StudentModel(sv));
            }
            return httpActionResult;
        }
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
                httpActionResult = Ok(error);
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