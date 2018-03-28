using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task_1.Models.Interfaces;

namespace Task_1.Models
{
    public class User: IImage
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime Birthdate { get; set; }
        private int age;

        public int Age
        {
            get { return age; }
            private set {

                age =  DateTime.Now.Year - Birthdate.Year;
                if (DateTime.Now.Month < Birthdate.Month || (DateTime.Now.Month == Birthdate.Month && DateTime.Now.Day < Birthdate.Day))
                {
                    age--;
                }
                

            }
        }

        public byte[] Image { get; set; }

        public string ImageType { get; set; }


    }
}