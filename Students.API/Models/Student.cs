using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Students.API.Models
{
    public class Student
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Address { get; set; }
    }

    public class AllStudent
    {
        public IEnumerable<Student> AllStudents { get; set; }
    }
}
