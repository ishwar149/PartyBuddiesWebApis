using DataAccess.EF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyBuddiesWebApis.Controllers
{
    public class UserImageController : Controller
    {
        // UserImage
        [AllowAnonymous]
        [Route("UserImage/UploadImage")]
        [HttpPost]
        public void UploadImage(UserImage userImage)
        {
            var file = System.Web.HttpContext.Current.Request.Files.Count > 0 ?
                         System.Web.HttpContext.Current.Request.Files[0] : null;
            if (file != null)
            {
                string ImageName = $"{userImage.Email}_{file.FileName}";
                var fileSave = Server.MapPath("~/UserImage/UserImages");
                if (!Directory.Exists(fileSave))
                {
                    Directory.CreateDirectory(fileSave);
                }
                var fileSavePath = Path.Combine(fileSave, ImageName);
                if (!System.IO.File.Exists(fileSavePath))
                {    /*To save files at server*/
                    file.SaveAs(fileSavePath);
                    HttpResponse Response = System.Web.HttpContext.Current.Response;
                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.StatusDescription = "File uploaded succesfully";
                    Response.End();
                }
                else
                {
                    HttpResponse Response = System.Web.HttpContext.Current.Response;
                    Response.Clear();
                    Response.Status = "400 File already exists";
                    Response.StatusCode = 400;
                    Response.StatusDescription = "File already exists";
                    Response.End();
                }
                userImage.ImageUrl = $"UserImage/UserImages/{ImageName}";
                DataAccess.UserImageDA.Add(userImage);
            }

        }

        [AllowAnonymous]
        [Route("UserImage/GetImages")]
        public string GetImages(UserImage userImage)
        {
            List<UserImage> userImages = DataAccess.UserImageDA.GetCustomQuery($"Select * from UserImage where Email='{userImage.Email}'");
            return JsonConvert.SerializeObject(userImages);
        }

    }
}