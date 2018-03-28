using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;

namespace Task_1.Models
{
    /// <summary>
    /// Allows to works with files for User model
    /// </summary>
    public class UserList
    {
        /// <summary>
        /// Absolute path to file
        /// </summary>
        static string absolutePathToFile;


        /// <summary>
        /// Creates a userlist and downloads it from server
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <returns></returns>
        public static string DownloadUserList(out string fileName)
        {
            //Sets the path to file
            string appDataPath = HttpContext.Current.Server.MapPath(@"~/Files");
            fileName = "UserList.txt";
            absolutePathToFile = Path.Combine(appDataPath, fileName);

            
            using (StreamWriter sr = new StreamWriter(absolutePathToFile, false, System.Text.Encoding.Default))
            {
                Context db = new Context();

                ///writes the values to file
                foreach (var item in db.Users.ToList())
                {
                    sr.Write(item.Id + " ");
                    sr.Write(item.Name + " ");
                    sr.Write(item.Birthdate.ToLongDateString() + " ");
                    sr.WriteLine(item.Age);

                }

                db.Dispose();
            }


            return absolutePathToFile;
        }

        
    }
}