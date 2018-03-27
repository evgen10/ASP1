using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.Models.Interfaces
{
    public interface IImage
    {
        byte[] Image { get; set; }

        string ImageType { get; set; }

    }
}
