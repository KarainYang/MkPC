using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using YK.Services.Examination;
using YK.Common;

namespace MobileWeb.Controllers
{
    public class VisionController : BaseApi
    {
        //
        // GET: /Vision/
        public ActionResult Color()
        {
            return View();
        }

        /// <summary>
        /// 保存颜色敏感度
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string saveVisionColor() {
            YK.Models.Examination.ExamVisionResult result = new YK.Models.Examination.ExamVisionResult();
            result.Module = "1";
            result.Type = "3";
            result.UserId = member.ID;
            result.Result = System.Web.HttpContext.Current.Request["result"];
            result.CreatedOn = DateTime.Now;
            result.Creater = member.MemberName;
            VisionService.ExamVisionResultService.Insert(result);
            return CommonClass.AjaxReponse(true, null, null);
        }

        public ActionResult ColorBlindness()
        {
            return View();
        }

        /// <summary>
        /// 保存色盲测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string saveColorBlindness()
        {
            YK.Models.Examination.ExamVisionResult result = new YK.Models.Examination.ExamVisionResult();
            result.Module = "1";
            result.Type = "2";
            result.UserId = member.ID;
            result.Result = System.Web.HttpContext.Current.Request["result"];
            result.CreatedOn = DateTime.Now;
            result.Creater = member.MemberName;
            VisionService.ExamVisionResultService.Insert(result);
            return CommonClass.AjaxReponse(true, null, null);
        }
        
    }
}
