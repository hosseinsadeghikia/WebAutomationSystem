using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WebAutomationSystem.ApplicationCore.Common.ExtensionMethods
{
    public static class ImageExtensionMethod
    {
        public static string UploadImage(this IFormFile file, string fileName, string filePath)
        {

            if (string.IsNullOrEmpty(fileName))
            {
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
            }
            filePath = Path.Combine(Directory.GetCurrentDirectory(), filePath, fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
