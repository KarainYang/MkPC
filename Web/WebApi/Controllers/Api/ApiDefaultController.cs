using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMMvc.Controllers.Api
{
    public class ApiDefaultController : BaseApi
    {
        //
        // GET: /Home/

        public ActionResult Get()
        {
            return View();
        }

        public void Index()
        {
            Response.Write("xxxx");
        }

    }
}
