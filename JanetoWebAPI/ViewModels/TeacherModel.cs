using ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JanetoWebAPI.ViewModels
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        public TeacherModel()
        {
        }

        public TeacherModel(Teacher teacher)
        {
            Id = teacher.Id;
            TeacherId = teacher.TeacherId;
            TeacherName = teacher.TeacherName;
            TeacherAddress = teacher.TeacherAddress;
        }
    }
    public class CreateTeacherModel
    {
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
    }
    public class UpdateTeacherModel : CreateTeacherModel
    {
        public int Id { get; set; }
    }
    public class DeleteTeacherModel : UpdateTeacherModel { }
}