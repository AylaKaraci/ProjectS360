using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectS360.UI.Helpers
{
    public class ImageUploader
    {
        #region UploadSingleImage
        public static string UploadSingleImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                var uniquename = Guid.NewGuid();
                serverPath = serverPath.Replace("~", string.Empty);
                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                var fileName = uniquename + "." + extension;

                if (extension == "jpg" || extension == "png" || extension == "jpeg" || extension == "gif")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName))) //  o anki serverın üzerinde benim yukarıda oluştrumuş olduğum, serverpath ve filename i birleştirdiğimizde örneğin Uploads/ayla.jpg gibi bir şey varsa
                    {
                        // Eğer server üzerinde aynı isimde resim varsa.
                        return "1";
                    }
                    else
                    {
                        var filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                        file.SaveAs(filePath);
                        return serverPath + fileName;
                    }
                }
                else
                {
                    //eğer dosya bu dört uzantıya sahip değilse;
                    // Geçerli dosya uzantılarından birine sahip değil (.jpg, .jpeg, .png, .gif)
                    return "2";
                }
            }

            // Dosya boş ise, null ise
            return "0";
        } 
        #endregion
    }
}