using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JanetoWebAPI.ViewModels;
using ApiModels;

namespace JanetoWebAPI.Controllers
{
    public class TeacherController : ApiController
    {
        private ApiDBContext _db;
        public TeacherController()
        {
            this._db = new ApiDBContext();
        }
        //Tạo
        [HttpPost]
        public IHttpActionResult CreateTeacher(CreateTeacherModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            if (string.IsNullOrEmpty(model.TeacherId))
            {
                error.Add("Mã giáo viên không được để trống");
            }

            if (string.IsNullOrEmpty(model.TeacherName))
            {
                error.Add("Họ tên giáo viên không được để trống");
            }

            if (error.Errors.Count == 0)
            {
                Teacher teacher = new Teacher();
                teacher.TeacherId = model.TeacherId;
                teacher.TeacherName = model.TeacherName;
                teacher.TeacherAddress = model.TeacherAddress;
                teacher = _db.Teacher.Add(teacher);

                _db.SaveChanges();
                TeacherModel vienModel = new TeacherModel(teacher);
                httpActionResult = Ok(vienModel);
            }
            else
            {
                httpActionResult = Ok(error);
            }

            return httpActionResult;
        }
        //Lấy tất cả
        [HttpGet]
        public IHttpActionResult GetAllTeacher()
        {
            var list = _db.Teacher.Select(x => new TeacherModel
            {
                Id = x.Id,
                TeacherId = x.TeacherId,
                TeacherName = x.TeacherName,
                TeacherAddress = x.TeacherAddress
            });
            return Ok(list);
        }
        //Sửa
        [HttpPut]
        public IHttpActionResult UpdateTeacher(UpdateTeacherModel model)
        {
            IHttpActionResult httpActionresult;
            ErrorModel error = new ErrorModel();
            Teacher tc = this._db.Teacher.FirstOrDefault(x => x.Id == model.Id);
            if (tc == null)
            {
                error.Add("Không tìm thấy Giáo viên!");
                httpActionresult = Ok(error);
            }
            else
            {
                tc.TeacherName = model.TeacherName ?? model.TeacherName;
                tc.TeacherId = model.TeacherId;
                tc.TeacherAddress = model.TeacherAddress ?? model.TeacherAddress;
                this._db.Entry(tc).State = System.Data.Entity.EntityState.Modified;
                this._db.SaveChanges();
                httpActionresult = Ok(new TeacherModel(tc));
            }
            return httpActionresult;
        }
        //Lấy theo mã
        [HttpGet]
        public IHttpActionResult GetTeacherByTeacherId(string teacherId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var tc = _db.Teacher.FirstOrDefault(x => x.TeacherId == teacherId);
            if (tc == null)
            {
                error.Add("Không tìm thấy giáo viên!");
                httpActionResult = Ok(error);
            }
            else
            {
                httpActionResult = Ok(new TeacherModel(tc));
            }
            return httpActionResult;
        }
        //Xóa theo mã
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(string teacherId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var tc = _db.Teacher.FirstOrDefault(x => x.TeacherId == teacherId);
            if (tc == null)
            {
                error.Add("Mã giáo viên không tồn tạo!");
                httpActionResult = Ok(error);
            }
            else
            {
                this._db.Teacher.Remove(tc);
                this._db.SaveChanges();
                httpActionResult = Ok("Đã xóa giáo viên " + tc.TeacherId);
            }
            return httpActionResult;
        }
    }
}
