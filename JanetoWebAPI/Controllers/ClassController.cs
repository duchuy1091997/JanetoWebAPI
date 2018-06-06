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
    public class ClassController : ApiController
    {
        private ApiDBContext _db;
        public ClassController()
        {
            this._db = new ApiDBContext();
        }

        /**
         * @api {POST} /class/CreateClass Create one class
         * @apigroup Class
         * @apiPermission none
         * 
         * @apiParam {string} ClassId Id of class
         * @apiParam {string} ClassName Name of class
         * @apiParam {DateTime} LearningTime Learning Time of class
         * @apiParam {int} Homeroom_Teacher Homeroom teacher id
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      ClassId:"123",
         *      ClassName:"CNTT"
         *      LearningTime:"09/09/2018"
         *      Homeroon_Teacher:1
         * }
         * @apiSuccess {string} ClassId Id of class has been created
         * @apiSuccess {string} ClassName Name of class has been created
         * @apiSuccess {DateTime} LearningTime LearningTime of class has been created
         * @apiSuccess {int} Homeroom_Teacher Homeroom Teacher of class has been created
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      Id: 1,
         *      ClassId:"123",
         *      ClassName:"CNTT"
         *      LearningTime:"09/09/2018"
         *      Homeroon_Teacher:1
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample:{json}
         * {
         *      "Error":[
         *          "ClassId" is required
         *          "ClassName" is required
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
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            return httpActionResult;
        }
        /**
        * @api {PUT} /class/UpdateClass Update one class
        * @apigroup Class
        * @apiPermission none
        * 
        * @apiParam {int} Id Id of class
        * @apiParam {string} ClassId Id of class
        * @apiParam {string} ClassName Name of class
        * @apiParam {DateTime} LearningTime Learning Time of class
        * @apiParam {int} Homeroom_Teacher Homeroom teacher id
        * 
        * @apiParamExample {json} Request-Example:
        * {
        *      Id:1,
        *      ClassId:"123",
        *      ClassName:"CNTT"
        *      LearningTime:"09/09/2018"
        *      Homeroon_Teacher:1
        * }
        * @apiSuccess {string} ClassId Id of class has been updated
        * @apiSuccess {string} ClassName Name of class has been updated
        * @apiSuccess {DateTime} LearningTime LearningTime of class has been updated
        * @apiSuccess {int} Homeroom_Teacher Homeroom Teacher of class has been updated
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      Id: 1,
        *      ClassId:"123",
        *      ClassName:"CNTT"
        *      LearningTime:"09/09/2018"
        *      Homeroon_Teacher:1
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample:{json}
        * {
        *      "Error":[
        *          "ClassId" is required
        *          "ClassName" is required
        *      ]
        * }
        */
        //Sửa lớp
        [HttpPut]
        public IHttpActionResult UpdateClass(UpdateClassModel model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel error = new ErrorModel();
            Class lop = this._db.Class.FirstOrDefault(x => x.Id == model.Id);
            if (lop == null)
            {
                error.Add("Không tìm thấy lớp!");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            else
            {
                lop.ClassId = model.ClassId ?? model.ClassId;
                lop.ClassName = model.ClassName ?? model.ClassName;
                lop.LearningTime = model.LearningTime;
                lop.Homeroom = _db.Teacher.FirstOrDefault(x => x.Id == model.Homeroom_Teacher);
                this._db.Entry(lop).State = System.Data.Entity.EntityState.Modified;
                this._db.SaveChanges();
                httpActionResult = Ok(new ClassModel(lop));
            }
            return httpActionResult;
        }
        /**
       * @api {GET} /class/GetAllClass Get all class 
       * @apigroup Class
       * @apiPermission none
       * 
       * 
       * 
       * @apiSuccessExample {json} Response:
       * {
       *      Id: 1,
       *      ClassId:"123",
       *      ClassName:"CNTT"
       *      LearningTime:"09/09/2018"
       *      Homeroon_Teacher:1
       *      
       *      Id: 2,
       *      ClassId:"234",
       *      ClassName:"CNSH"
       *      LearningTime:"09/09/2018"
       *      Homeroon_Teacher:1
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
        //Lấy tất cả lớp
        [HttpGet]
        public IHttpActionResult GetAllClass()
        {
            var lstClass = this._db.Class.Select(x => new ClassModel()
            {
                ClassId = x.ClassId,
                ClassName = x.ClassName,
                LearningTime = x.LearningTime,
                Homeroom_Teacher = x.Homeroom.Id,
                Id = x.Id
            });
            return Ok(lstClass);
        }
        /**
      * @api {GET} /class/GetClassByClassId?ClassId=:ClassId Get one class by class id
      * @apigroup Class
      * @apiPermission none
      * 
      * @apiParam {string} ClassId Id of class
      * 
      * @apiExample Example usage: 
      * 
      * /class/GetClassByClassId?ClassId=123
      * 
      * @apiSuccessExample {json} Response:
      * {
      *      Id: 1,
      *      ClassId:"123",
      *      ClassName:"CNTT"
      *      LearningTime:"09/09/2018"
      *      Homeroon_Teacher:1
      * }
      * 
      * @apiError [400] {string[]} Errors Array of error
      * @apiErrorExample:{json}
      * {
      *      "Error":[
      *          Không tìm thấy lớp!
      *      ]
      * }
      */
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
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, error);
            }
            else
            {
                httpActionResult = Ok(new ClassModel(lop));
            }
            return httpActionResult;
        }
        /**
    * @api {DELETE} /class/DeleteClass?Id=:Id Delete one class by Id
    * @apigroup Class
    * @apiPermission none
    * 
    * @apiParam {int} Id Id
    * 
    * @apiExample Example usage: 
    * 
    * /class/DeleteClass?ClassId=123
    * 
    * @apiSuccessExample {json} Response:
    * {
    *      Đã xóa lớp 123
    * }
    * 
    * @apiError [400] {string[]} Errors Array of error
    * @apiErrorExample:{json}
    * {
    *      "Error":[
    *          Mã lớp không tồn tạo!
    *      ]
    * }
    */
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
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest,error);
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