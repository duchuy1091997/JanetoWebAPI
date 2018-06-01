using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using JanetoWebAPI.ViewModels;
using ApiModels;

namespace JanetoWebAPI.Controllers
{
    public class ClassController : ApiController
    {
        private ApiDBContext _db;
        public ClassController()
        {
            this._db = new ApiDBContext();
        }

        /**
         * @api {Post} /class/CreateClass Create one class
         * @apigroup Class
         * @apiPermission none Teacher
         * 
         * @apiParam {string} ClassId Id of class
         * @apiParam {string} ClassName Name of class
         * @apiParam {DateTime} LearningTime 
         * @apiParam {int} Homeroom_Teacher
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      ClassId:"123",
         *      ClassName:"CNTT"
         * }
         * @apiSuccess {string} ClassId Id of class has been create
         * @apiSuccess {string} ClassName Name of class has been create
         * @apiSuccess {int} Id Id of class has been create
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      Id: 1,
         *      ClassId:"123",
         *      ClassName:"CNTT"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample:{json}
         * {
         *      "Error":[
         *          "ClassId" is required
         *      ]
         * }
         */



        //Tạo lớp
        [HttpPost]
        public IHttpActionResult CreateClass(CreateClassModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            if (string.IsNullOrEmpty(model.ClassId))
            {
                error.Add("Mã lớp là bắt buộc");
            }
            if (string.IsNullOrEmpty(model.ClassName))
            {
                error.Add("Tên lớp là bắt buộc");
            }
            if (_db.Teacher.FirstOrDefault(m => m.Id == model.Homeroom_Teacher) == null)
            {
                error.Add("Giáo viên không tồn tại");
            }
            if (error.Errors.Count == 0)
            {
                Class oneClass = new Class();
                oneClass.ClassName = model.ClassName;
                oneClass.ClassId = model.ClassId;
                oneClass.LearningTime = model.LearningTime;
                oneClass.Homeroom = _db.Teacher.FirstOrDefault(m => m.Id == model.Homeroom_Teacher);
                oneClass = this._db.Class.Add(oneClass);
                this._db.SaveChanges();
                ClassModel viewModel = new ClassModel(oneClass);
                httpActionResult = Ok(viewModel);
            }
            else
            {
                httpActionResult = Ok(error);
            }
            return httpActionResult;
        }
        //Sửa lớp
        [HttpPut]
        public IHttpActionResult UpdateClass(UpdateClassModel model)
        {
            IHttpActionResult httpActionresult;
            ErrorModel error = new ErrorModel();
            Class lop = this._db.Class.FirstOrDefault(x => x.Id == model.Id);
            if (lop == null)
            {
                error.Add("Không tìm thấy lớp!");
                httpActionresult = Ok(error);
            }
            else
            {
                lop.ClassId = model.ClassId ?? model.ClassId;
                lop.ClassName = model.ClassName ?? model.ClassName;
                lop.LearningTime = model.LearningTime;
                lop.Homeroom = _db.Teacher.FirstOrDefault(x => x.Id == model.Homeroom_Teacher);
                this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;
                this._db.SaveChanges();
                httpActionresult = Ok(new ClassModel(lop));
            }
            return httpActionresult;
        }
        //Lấy tất cả lớp
        [HttpGet]
        public IHttpActionResult GetAllClass()
        {
            var lstClass = this._db.Class.Select(x => new ClassModel()
            {
                ClassId = x.ClassId,
                ClassName = x.ClassName,
                LearningTime=x.LearningTime,
                Homeroom_Teacher=x.Homeroom.Id,
                Id = x.Id
            });
            return Ok(lstClass);
        }
        //Lấy lớp theo id
        [HttpGet]
        public IHttpActionResult GetClassByClassId(string classId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var lop = _db.Class.FirstOrDefault(x => x.ClassId == classId);
            if (lop == null)
            {
                error.Add("Không tìm thấy lớp!");
                httpActionResult = Ok(error);
            }
            else
            {
                httpActionResult = Ok(new ClassModel(lop));
            }
            return httpActionResult;
        }
        //Xóa lớp
        [HttpDelete]
        public IHttpActionResult DeleteClass(int id)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            var lop = _db.Class.FirstOrDefault(x => x.Id == id);
            if (lop == null)
            {
                error.Add("Mã lớp không tồn tạo!");
                httpActionResult = Ok(error);
            }
            else
            {
                this._db.Class.Remove(lop);
                this._db.SaveChanges();
                httpActionResult = Ok("Đã xóa lớp " + lop.ClassId);
            }
            return httpActionResult;
        }
    }
}