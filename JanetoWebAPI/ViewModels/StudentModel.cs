using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JanetoWebAPI.Models;
using ApiModels;
using System.ComponentModel.DataAnnotations;

namespace JanetoWebAPI.ViewModels
{
    public class StudentModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime StudentBirth { get; set; }
        public string StudentAddress { get; set; }
        public string StudentName { get; set; }
        public int Class_Id { get; set; }
        public StudentModel()
        {
        }
        public StudentModel(Student oneStudent)
        {
            this.Id = oneStudent.Id;
            this.StudentId = oneStudent.StudentId;
            this.StudentBirth = oneStudent.StudentBirth;
            this.StudentAddress = oneStudent.StudentAddress;
            this.StudentName = oneStudent.StudentName;
            this.Class_Id = oneStudent.Class.Id;
        }
    }
    public class CreateStudentModel
    {
        public int StudentId { get; set; }
        public DateTime StudentBirth { get; set; }
        public string StudentAddress { get; set; }
        public string StudentName { get; set; }
        public int Class_Id { get; set; }
    }
    public class UpdateStudentModel : CreateStudentModel
    {
        public int Id { get; set; }
    }
    public class DeleteStudentModel : UpdateStudentModel { }
}