using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        private int age;

        public int Age
        {
            get { return age; }
            private set { age = DateTime.Now.Year - Birthdate.Year; }
        }

    }
}