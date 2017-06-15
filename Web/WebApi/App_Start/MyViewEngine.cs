using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMMvc
{
    public sealed class MyViewEngine:System.Web.Mvc.RazorViewEngine
    {
        public MyViewEngine()
        {
            ViewLocationFormats = new[] { 
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/Backend/{1}/{0}.cshtml",//自定义的规则
                "~/Views/Api/{1}/{0}.cshtml",//自定义的规则
            };
        }
    }
}