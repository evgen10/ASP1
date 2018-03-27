using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Task_1.Models
{
    public class DefultImage
    {
        public static void GetDefultImage(Models.Interfaces.IImage image)
        {
            string appDataPath = System.Web.HttpContext.Current.Server.MapPath(@"~/Images");
            string fileName = "undefined.png";
            string absolutePathToFile = System.IO.Path.Combine(appDataPath, fileName);


            byte[] defultImage = System.IO.File.ReadAllBytes(absolutePathToFile);
            
            image.ImageType = "image/png";
            image.Image = defultImage;

        }

    }
}