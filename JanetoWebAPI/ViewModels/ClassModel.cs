using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JanetoWebAPI.Models;
using ApiModels;

namespace JanetoWebAPI.ViewModels
{
    public class ClassModel
    {
        public int Id { get; set; }
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime LearningTime { get; set; }
        public int Homeroom_Teacher { get; set; }
        public ClassModel()
        {

        }
        public ClassModel(Class oneClass)
        {
            this.Id = oneClass.Id;
            this.ClassId = oneClass.ClassId;
            this.ClassName = oneClass.ClassName;
            this.LearningTime = oneClass.LearningTime;
            this.Homeroom_Teacher = oneClass.Homeroom.Id;
        }
    }
    public class CreateClassModel
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime LearningTime { get; set; }
        public int Homeroom_Teacher { get; set; }
    }
    public class UpdateClassModel : CreateClassModel
    {
        public int Id { get; set; }
    }
    public class DeleteClassModel : UpdateClassModel { }
}
