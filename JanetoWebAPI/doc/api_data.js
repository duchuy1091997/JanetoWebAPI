define({ "api": [
  {
    "type": "Post",
    "url": "/class/CreateClass",
    "title": "Create one class",
    "group": "Class",
    "permission": [
      {
        "name": "none Teacher"
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
            "description": ""
          },
          {
            "group": "Parameter",
            "type": "int",
            "optional": false,
            "field": "Homeroom_Teacher",
            "description": ""
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "{\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n}",
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
            "description": "<p>Id of class has been create</p>"
          },
          {
            "group": "Success 200",
            "type": "string",
            "optional": false,
            "field": "ClassName",
            "description": "<p>Name of class has been create</p>"
          },
          {
            "group": "Success 200",
            "type": "int",
            "optional": false,
            "field": "Id",
            "description": "<p>Id of class has been create</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Response:",
          "content": "{\n     Id: 1,\n     ClassId:\"123\",\n     ClassName:\"CNTT\"\n}",
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
          "content": "{\n     \"Error\":[\n         \"ClassId\" is required\n     ]\n}",
          "type": "json"
        }
      ]
    },
    "version": "0.0.0",
    "filename": "./Controllers/ClassController.cs",
    "groupTitle": "Class",
    "name": "PostClassCreateclass"
  }
] });