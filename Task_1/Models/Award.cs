using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models.Interfaces;

namespace Task_1.Models
{
    /// <summary>
    /// Describes an award
    /// </summary>
    public class Award : IImage
    {
        /// <summary>
        /// Gets or sets an id of an award
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets a title of an award
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Get or sets a description of an award
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///  Gets or sets an image as a byte array
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// Gets or sets a type of  an image
        /// </summary>
        public string ImageType { get; set; }
    }
}