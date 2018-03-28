using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task_1.Models.Interfaces;

namespace Task_1.Models
{
    /// <summary>
    /// Discribes a user
    /// </summary>
    public class User: IImage
    {
        /// <summary>
        /// Gets or sets an id of a user
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets a name of a user
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or sets a birthdate of a user
        /// </summary>
        public DateTime Birthdate { get; set; }
        /// <summary>
        /// Contains an age of  a user
        /// </summary>
        private int age;

        /// <summary>
        /// Gets or sets an age of a user
        /// </summary>
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

        /// <summary>
        /// Gets or sets an image as a byte array
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets a type of image
        /// </summary>
        public string ImageType { get; set; }


    }
}