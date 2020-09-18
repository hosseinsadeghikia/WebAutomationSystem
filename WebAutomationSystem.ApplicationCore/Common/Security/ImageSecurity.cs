using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace WebAutomationSystem.ApplicationCore.Common.Security
{
    public static class ImageSecurity
    {
        public static bool ImageValidator(IFormFile imgFile)
        {
            if (imgFile.Length > 0 && imgFile != null)
            {
                try
                {
                    Image.FromStream(imgFile.OpenReadStream());
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
