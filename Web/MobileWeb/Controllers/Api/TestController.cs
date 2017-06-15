using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YK.Common;

namespace MobileWeb.Controllers.Api
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public void Index()
        {
            Response.Write("yankun".ToEncryptStr());
        }

    }
}
