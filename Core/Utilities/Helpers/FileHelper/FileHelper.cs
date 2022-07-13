using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Text.RegularExpressions;
=======
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelper
    {
<<<<<<< HEAD
        static string uploadPath = Environment.CurrentDirectory + @"\wwwroot\uploads\";
        public static IResult Upload(IFormFile file, string directory)
=======
        public static IResult Upload(IFormFile file,string directory)
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        {
            var fileType = Path.GetExtension(file.FileName);
            if (!CheckIfFileExists(file))
            {
                return new ErrorResult();
            }
<<<<<<< HEAD
            if (!CheckIfFileTyoeValid(fileType))
            {
                return new ErrorResult();
            }
            CheckIfDirecoryExists(directory);
=======
            if (!CheckIfFileTypeValid(fileType))
            {
                return new ErrorResult();
            }
            CheckIfDirectoryExists(directory);
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
            var result = CreateImageFile(file, directory, fileType);
            return new SuccesResult(result);
        }

<<<<<<< HEAD

        public static IResult Update(IFormFile file, string filePath,string directory)
=======
        

        public static IResult Update(IFormFile file,string filePath,string directory)
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        {
            var fileType=Path.GetExtension(file.FileName);
            if (!CheckIfFileExists(file))
            {
                return new ErrorResult();
            }
<<<<<<< HEAD
            if (!CheckIfFileTyoeValid(fileType))
=======
            if (!CheckIfFileTypeValid(fileType))
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
            {
                return new ErrorResult();
            }
            DeleteOldFile(filePath);
<<<<<<< HEAD
            CheckIfDirecoryExists(directory);
=======
            CheckIfDirectoryExists(directory);
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
            var result = CreateImageFile(file, directory, fileType);
            return new SuccesResult(result);
        }

        public static IResult Delete(string filePath)
        {
            DeleteOldFile(filePath);
            return new SuccesResult();
        }
<<<<<<< HEAD
        private static void DeleteOldFile(string filePath)
        {
            throw new NotImplementedException();
        }

        private static string CreateImageFile(IFormFile file, string directory, string fileType)
        {
            string guid= Guid.NewGuid().ToString();
            using (FileStream fileStream = File.Create(directory + guid + fileType))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return(directory+guid+fileType);
        }
        public static string Add(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(uploading);
                }
            }
            var result = newPath(file);
            File.Move(sourcepath, uploadPath + result);
            return result;
        }
        private static void CheckIfDirecoryExists(string directory)
=======
        /*---------------------------------------------------------*/

        private static bool CheckIfFileTypeValid(string fileType)
        {
            if (fileType != ".jpg" && fileType != ".jpeg" && fileType != ".png")
            {
                return false;
            }
            return true;
        }

        private static bool CheckIfFileExists(IFormFile file)
        {
            if (file != null && file.Length>0)
            {
                return true;
            }
            return false;
        }

        private static void CheckIfDirectoryExists(string directory)
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

<<<<<<< HEAD
        private static bool CheckIfFileTyoeValid(string fileType)
        {
            if (fileType != ".jpg"&& fileType != ".jpeg" && fileType != ".png")
            {
                return false;
            }
            return true;
        }

        private static bool CheckIfFileExists(IFormFile file)
        {
            if (file != null && file.Length>0)
            {
                return true;
            }
            return false;
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var newPath = DateTime.Now.ToString("HH/mm/ss MM/dd/yyyy ") + Guid.NewGuid().ToString() + fileExtension;

            string result = Regex.Replace(newPath, "[/|:| ]", "-");

            //string result = $@"{path}\{newPath}";
            return result;
=======
        private static void DeleteOldFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private static string CreateImageFile(IFormFile file, string directory, string fileType)
        {
            string guid = Guid.NewGuid().ToString();
            using (FileStream fileStream=File.Create(directory+guid+fileType))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return (directory + guid + fileType);
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        }
    }
}
