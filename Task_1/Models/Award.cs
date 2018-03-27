using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models.Interfaces;

namespace Task_1.Models
{
    public class Award : IImage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    }
}