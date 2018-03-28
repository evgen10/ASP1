using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Interfaces
{

    /// <summary>
    /// Supports  a save an image
    /// </summary>
    public interface IImage
    {
        /// <summary>
        /// Gets or sets an image as a byte array
        /// </summary>
        byte[] Image { get; set; }

        /// <summary>
        /// Gets or sets a type of an image
        /// </summary>
        string ImageType { get; set; }

    }
}
