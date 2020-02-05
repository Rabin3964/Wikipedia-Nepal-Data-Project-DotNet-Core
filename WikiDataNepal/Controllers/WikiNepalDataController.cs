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
        private readonly Helper _H;


        public WikiNepalDataController(Helper H)
        {
            _H = H;
        }
        public IActionResult Index()
        {

            var results = _H.GetData();

                 
            return View(results);
        }
     

    }
}