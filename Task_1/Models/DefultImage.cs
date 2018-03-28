using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Task_1.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DefultImage
    {
        /// <summary>
        /// Sets the default image
        /// </summary>
        /// <param name="image">An object in which to insert an image</param>
        public static void GetDefultImage(Models.Interfaces.IImage image)
        {
            //vitrual path
            string appDataPath = System.Web.HttpContext.Current.Server.MapPath(@"~/Images");
            string fileName = "undefined.png";
            //absolute path
            string absolutePathToFile = System.IO.Path.Combine(appDataPath, fileName);

            
            byte[] defultImage = System.IO.File.ReadAllBytes(absolutePathToFile);
            
            image.ImageType = "image/png";
            image.Image = defultImage;

        }

    }
}