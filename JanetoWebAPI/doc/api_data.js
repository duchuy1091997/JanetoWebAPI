define({ "api": [
  {
    "type": "DELETE",
    "url": "/class/DeleteClass?Id=:Id",
    "title": "Delete one class by Id",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/class/DeleteClass?ClassId=123",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Đã xóa lớp 123\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Mã lớp không tồn tạo!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "DeleteClassDeleteclassIdId"
  },
  {
    "type": "GET",
    "url": "/class/GetAllClass",
    "title": "Get all class",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n     \n     Id: 2,\n     ClassId:\"234\",\n     ClassName:\"CNSH\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "GetClassGetallclass"
  },
  {
    "type": "GET",
    "url": "/class/GetClassByClassId?ClassId=:ClassId",
    "title": "Get one class by class id",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ClassId",
            "description": "<p>Id of class</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/class/GetClassByClassId?ClassId=123",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Không tìm thấy lớp!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "GetClassGetclassbyclassidClassidClassid"
  },
  {
    "type": "POST",
    "url": "/class/CreateClass",
    "title": "Create one class",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ClassId",
            "description": "<p>Id of class</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ClassName",
            "description": "<p>Name of class</p>"
          },
          {
            "group": "Parameter",
            "type": "DateTime",
            "optional": false,
            "field": "LearningTime",
            "description": "<p>Learning Time of class</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Homeroom_Teacher",
            "description": "<p>Homeroom teacher id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "ClassId",
            "description": "<p>Id of class has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "ClassName",
            "description": "<p>Name of class has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "DateTime",
            "optional": false,
            "field": "LearningTime",
            "description": "<p>LearningTime of class has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Homeroom_Teacher",
            "description": "<p>Homeroom Teacher of class has been created</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"ClassId\" is required\n         \"ClassName\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "PostClassCreateclass"
  },
  {
    "type": "PUT",
    "url": "/class/UpdateClass",
    "title": "Update one class",
    "group": "Class",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id of class</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ClassId",
            "description": "<p>Id of class</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "ClassName",
            "description": "<p>Name of class</p>"
          },
          {
            "group": "Parameter",
            "type": "DateTime",
            "optional": false,
            "field": "LearningTime",
            "description": "<p>Learning Time of class</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Homeroom_Teacher",
            "description": "<p>Homeroom teacher id</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Id:1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "ClassId",
            "description": "<p>Id of class has been updated</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "ClassName",
            "description": "<p>Name of class has been updated</p>"
          },
          {
            "group": "Success 200",
            "type": "DateTime",
            "optional": false,
            "field": "LearningTime",
            "description": "<p>LearningTime of class has been updated</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Homeroom_Teacher",
            "description": "<p>Homeroom Teacher of class has been updated</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n     LearningTime:\"09/09/2018\"\n     Homeroon_Teacher:1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"ClassId\" is required\n         \"ClassName\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "PutClassUpdateclass"
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "D__LEARN_IT_Janeto_JanetoWebAPI_JanetoWebAPI_doc_main_js",
    "groupTitle": "D__LEARN_IT_Janeto_JanetoWebAPI_JanetoWebAPI_doc_main_js",
    "name": ""
  },
  {
    "type": "DELETE",
    "url": "/student/DeleteStudent?studentId=:studentId",
    "title": "Delete one student by studentId",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "studentId",
            "description": "<p>StudentId of student</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/student/DeleteStudent?studentId=123",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Đã xóa sinh viên 123\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Mã sinh viên không tồn tạo!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student",
    "name": "DeleteStudentDeletestudentStudentidStudentid"
  },
  {
    "type": "GET",
    "url": "/student/GetAllStudent",
    "title": "Get all student",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     StudentId:123,\n     StudentBirth:\"09/09/1997\",\n     StudentAddress:\"CMT8\",\n     StudentName:\"Đỗ Đức Huy\",\n     Class_Id: 1\n     \n     Id: 2,\n     StudentId:124,\n     StudentBirth:\"09/09/1998\",\n     StudentAddress:\"Hoàng Diệu\",\n     StudentName:\"Đỗ Đức Phát\",\n     Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student",
    "name": "GetStudentGetallstudent"
  },
  {
    "type": "GET",
    "url": "/student/GetStudentByStudentId?studentId=:studentId",
    "title": "Get one class by studentid",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "StudentId",
            "description": "<p>StudentId of student</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/student/GetStudentByStudentId?studentId=123",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     StudentId:123,\n     StudentBirth:\"09/09/1997\",\n     StudentAddress:\"CMT8\",\n     StudentName:\"Đỗ Đức Huy\",\n     Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Không tìm thấy sinh viên!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student",
    "name": "GetStudentGetstudentbystudentidStudentidStudentid"
  },
  {
    "type": "POST",
    "url": "/student/CreateStudent",
    "title": "Create one student",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "StudentId",
            "description": "<p>StudentId of student</p>"
          },
          {
            "group": "Parameter",
            "type": "DateTime",
            "optional": false,
            "field": "StudentBirth",
            "description": "<p>Birthday of student</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "StudentAddress",
            "description": "<p>Address of student</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "StudentName",
            "description": "<p>Name of student</p>"
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Class_Id",
            "description": "<p>Id class of student</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     StudentId:\"123\",\n     StudentBirth:\"09/09/1997\",\n     StudentAddress:\"CMT8\",\n     StudentName:\"Đỗ Đức Huy\",\n     Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "StudentId",
            "description": "<p>StudentId of student has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "DateTime",
            "optional": false,
            "field": "StudentBirth",
            "description": "<p>Birthday of student has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "StudentAddress",
            "description": "<p>Address of student has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "StudentName",
            "description": "<p>Name of student has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Class_Id",
            "description": "<p>Id class of student has been created</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     StudentId:123,\n     StudentBirth:\"09/09/1997\",\n     StudentAddress:\"CMT8\",\n     StudentName:\"Đỗ Đức Huy\",\n     Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"StudentName\" is required\n         \"StudentAddress\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student",
    "name": "PostStudentCreatestudent"
  },
  {
    "type": "PUT",
    "url": "/student/UpdateStudent",
    "title": "Update one student",
    "group": "Student",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "StudentId",
            "description": "<p>StudentId of student</p>"
          },
          {
            "group": "Success 200",
            "type": "DateTime",
            "optional": false,
            "field": "StudentBirth",
            "description": "<p>Birthday of student</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "StudentAddress",
            "description": "<p>Address of student</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "StudentName",
            "description": "<p>Name of student</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Class_Id",
            "description": "<p>Id class of student</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n      Id: 1,\n      StudentId:123,\n      StudentBirth:\"09/09/1997\",\n      StudentAddress:\"CMT8\",\n      StudentName:\"Đỗ Đức Huy\",\n      Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n      Id: 1,\n      StudentId:123,\n      StudentBirth:\"09/09/1997\",\n      StudentAddress:\"CMT8\",\n      StudentName:\"Đỗ Đức Huy\",\n      Class_Id: 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"StudentName\" is required\n         \"StudentAddress\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/StudentController.cs",
    "groupTitle": "Student",
    "name": "PutStudentUpdatestudent"
  },
  {
    "type": "DELETE",
    "url": "/teacher/DeleteTeacher?teacherId=:teacherId",
    "title": "Delete one teacher by teacherId",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "teacherId",
            "description": "<p>teacherId of teacher</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/teacher/DeleteTeacher?teacherId=1",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Đã xóa giáo viên 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Mã giáo viên không tồn tạo!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher",
    "name": "DeleteTeacherDeleteteacherTeacheridTeacherid"
  },
  {
    "type": "GET",
    "url": "/teacher/GetAllTeacher",
    "title": "Get all teacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\",\n     TeacherAddress:\"TPHCM\"\n     \n     Id: 2,\n     TeacherId:\"2\",\n     TeacherName:\"Nguyễn Văn B\",\n     TeacherAddress:\"BR-VT\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher",
    "name": "GetTeacherGetallteacher"
  },
  {
    "type": "GET",
    "url": "/teacher/GetTeacherByTeacherId?teacherId=:teacherId",
    "title": "Get one teacher by teacher id",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "teacherId",
            "description": "<p>teacherId of teacher</p>"
          }
        ]
      }
    },
    "examples": [
      {
        "title": "Example usage: ",
        "content": "\n/teacher/GetTeacherByTeacherId?teacherId=1",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\",\n     TeacherAddress:\"TPHCM\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         Không tìm thấy giáo viên!\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher",
    "name": "GetTeacherGetteacherbyteacheridTeacheridTeacherid"
  },
  {
    "type": "POST",
    "url": "/teacher/CreateTeacher",
    "title": "Create one teacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherId",
            "description": "<p>TeacherId of teacher</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherName",
            "description": "<p>Name of teacher</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherAddress",
            "description": "<p>Address of teacher</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\"\n     TeacherAddress:\"TPHCM\"\n    \n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherId",
            "description": "<p>TeacherId of teacher has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherName",
            "description": "<p>Name of teacher has been created</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherAddress",
            "description": "<p>Address of teacher has been created</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\",\n     TeacherAddress:\"TPHCM\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"TeacherId\" is required\n         \"TeacherName\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher",
    "name": "PostTeacherCreateteacher"
  },
  {
    "type": "PUT",
    "url": "/teacher/UpdateTeacher",
    "title": "Update one teacher",
    "group": "Teacher",
    "permission": [
      {
        "name": "none"
      }
    ],
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "Int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id of Teacher</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherId",
            "description": "<p>TeacherId of teacher</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherName",
            "description": "<p>Name of teacher</p>"
          },
          {
            "group": "Parameter",
            "type": "string",
            "optional": false,
            "field": "TeacherAddress",
            "description": "<p>Address of teacher</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     Id: 1,\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\",\n     TeacherAddress:\"TPHCM\"\n}",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherId",
            "description": "<p>TeacherId of teacher has been updated</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherName",
            "description": "<p>Name of teacher has been updated</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "TeacherAddress",
            "description": "<p>Address of teacher has been updated</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     TeacherId:\"1\",\n     TeacherName:\"Nguyễn Văn A\",\n     TeacherAddress:\"TPHCM\"\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "optional": true,
            "field": "400",
            "description": "<p>{string[]} Errors Array of error</p>"
          }
        ]
      },
      "examples": [
        {
          "title": ":{json}",
          "content": "{\n     \"Error\":[\n         \"TeacherId\" is required\n         \"TeacherName\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/TeacherController.cs",
    "groupTitle": "Teacher",
    "name": "PutTeacherUpdateteacher"
  }
] });
