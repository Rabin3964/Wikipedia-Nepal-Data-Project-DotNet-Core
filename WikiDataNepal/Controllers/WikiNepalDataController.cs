using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WikiDataNepal.Models;
using WikiNepalData;
using WikiNepalData.Model;
using WikiNepalDataClassLibrary;

namespace WikiDataNepal.Controllers
{
    public class WikiNepalDataController : Controller
    {
        private readonly Helper _cc;


        public WikiNepalDataController(Helper cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {

            var results = _cc.GetData();

                 
            return View(results);
        }
     

    }
}