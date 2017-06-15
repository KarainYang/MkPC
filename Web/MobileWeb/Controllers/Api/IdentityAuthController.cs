using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YK.Common;
using YK.Services.Examination;
using YK.Service;

namespace MobileWeb.Controllers.Api
{
    public class IdentityAuthController : BaseApi
    {
        //
        // GET: /IdentityAuth/
        public void Index()
        {
            if (isAuth)
            {
                YK.Models.Examination.ExamVisionResult result = new YK.Models.Examination.ExamVisionResult();
                result.Module = "1";
                result.Type = Request["type"];
                result.Result = Request["result"];
                result.CreatedOn = DateTime.Now;
                result.Creater = member.ChengNi;
                result.UserId = member.ID;
                VisionService.ExamVisionResultService.Insert(result);
                System.Web.HttpContext.Current.Response.Write(CommonClass.AjaxReponse(true, "保存成功", null));
            }
        }
    }
}
