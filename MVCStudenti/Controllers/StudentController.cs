﻿using MVCStudenti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStudenti.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 },
                new Student() { StudentId = 2, StudentName = "Steve", Age = 21 },
                new Student() { StudentId = 3, StudentName = "Bill", Age = 25 },
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 },
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 },
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 },
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 },
            };

            // Get the students from the database in the real application
            return View(studentList);
        }

        public ActionResult Details() {

            var student = new Student() { StudentId = 1, StudentName = "John", Age = 18 };

            return View(student);
        }

        public ActionResult Edit(int id)
        {
            var studentList = new List<Student>{
                new Student() { StudentId = 1, StudentName = "John", Age = 18 },
                new Student() { StudentId = 2, StudentName = "Steve", Age = 21 },
                new Student() { StudentId = 3, StudentName = "Bill", Age = 25 },
                new Student() { StudentId = 4, StudentName = "Ram" , Age = 20 },
                new Student() { StudentId = 5, StudentName = "Ron" , Age = 31 },
                new Student() { StudentId = 4, StudentName = "Chris" , Age = 17 },
                new Student() { StudentId = 4, StudentName = "Rob" , Age = 19 },
            };

            var student = studentList.FirstOrDefault(x => x.StudentId == id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else 
            { 
                return View(student); 
            }
        }
    }
}