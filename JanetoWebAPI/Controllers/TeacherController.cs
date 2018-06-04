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
        /**
         * @api {POST} /teacher/CreateTeacher Create one teacher
         * @apigroup Teacher
         * @apiPermission none
         * 
         * 
         * @apiParam {string} TeacherId TeacherId of teacher
         * @apiParam {string} TeacherName Name of teacher
         * @apiParam {string} TeacherAddress Address of teacher
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      TeacherId:"1",
         *      TeacherName:"Nguyễn Văn A"
         *      TeacherAddress:"TPHCM"
         *     
         * }
         * @apiSuccess {string} TeacherId TeacherId of teacher has been created
         * @apiSuccess {string} TeacherName Name of teacher has been created
         * @apiSuccess {string} TeacherAddress Address of teacher has been created
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      Id: 1,
         *      TeacherId:"1",
         *      TeacherName:"Nguyễn Văn A",
         *      TeacherAddress:"TPHCM"
         * }
         * 
         * @apiError [400] {string[]} Errors Array of error
         * @apiErrorExample:{json}
         * {
         *      "Error":[
         *          "TeacherId" is required
         *          "TeacherName" is required
         *      ]
         * }
         */

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
        /**
       * @api {GET} /teacher/GetAllTeacher Get all teacher 
       * @apigroup Teacher
       * @apiPermission none
       * 
       * 
       * 
       * @apiSuccessExample {json} Response:
       * {
       *      Id: 1,
       *      TeacherId:"1",
       *      TeacherName:"Nguyễn Văn A",
       *      TeacherAddress:"TPHCM"
       *      
       *      Id: 2,
       *      TeacherId:"2",
       *      TeacherName:"Nguyễn Văn B",
       *      TeacherAddress:"BR-VT"
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
        /**
        * @api {PUT} /teacher/UpdateTeacher Update one teacher
        * @apigroup Teacher
        * @apiPermission none
        * 
        * @apiParam {Int} Id Id of Teacher
        * @apiParam {string} TeacherId TeacherId of teacher
        * @apiParam {string} TeacherName Name of teacher
        * @apiParam {string} TeacherAddress Address of teacher
        * 
        * @apiParamExample {json} Request-Example:
        * {
        *      Id: 1,
        *      TeacherId:"1",
        *      TeacherName:"Nguyễn Văn A",
        *      TeacherAddress:"TPHCM"
        * }
        * @apiSuccess {string} TeacherId TeacherId of teacher has been updated
        * @apiSuccess {string} TeacherName Name of teacher has been updated
        * @apiSuccess {string} TeacherAddress Address of teacher has been updated
        * 
        * @apiSuccessExample {json} Response:
        * {
        *      Id: 1,
        *      TeacherId:"1",
        *      TeacherName:"Nguyễn Văn A",
        *      TeacherAddress:"TPHCM"
        * }
        * 
        * @apiError [400] {string[]} Errors Array of error
        * @apiErrorExample:{json}
        * {
        *      "Error":[
        *          "TeacherId" is required
        *          "TeacherName" is required
        *      ]
        * }
        */

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
        /**
     * @api {GET} /teacher/GetTeacherByTeacherId?teacherId=:teacherId Get one teacher by teacher id
     * @apigroup Teacher
     * @apiPermission none
     * 
     * @apiParam {string} teacherId teacherId of teacher
     * 
     * @apiExample Example usage: 
     * 
     * /teacher/GetTeacherByTeacherId?teacherId=1
     * 
     * @apiSuccessExample {json} Response:
     * {
     *      Id: 1,
     *      TeacherId:"1",
     *      TeacherName:"Nguyễn Văn A",
     *      TeacherAddress:"TPHCM"
     * }
     * 
     * @apiError [400] {string[]} Errors Array of error
     * @apiErrorExample:{json}
     * {
     *      "Error":[
     *          Không tìm thấy giáo viên!
     *      ]
     * }
     */
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
        /**
    * @api {DELETE} /teacher/DeleteTeacher?teacherId=:teacherId Delete one teacher by teacherId
    * @apigroup Teacher
    * @apiPermission none
    * 
    * @apiParam {string} teacherId teacherId of teacher
    * 
    * @apiExample Example usage: 
    * 
    * /teacher/DeleteTeacher?teacherId=1
    * 
    * @apiSuccessExample {json} Response:
    * {
    *      Đã xóa giáo viên 1
    * }
    * 
    * @apiError [400] {string[]} Errors Array of error
    * @apiErrorExample:{json}
    * {
    *      "Error":[
    *          Mã giáo viên không tồn tạo!
    *      ]
    * }
    */
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
