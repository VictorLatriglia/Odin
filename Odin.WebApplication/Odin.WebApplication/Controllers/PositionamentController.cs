using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Odin.VisualRecognition.Models;

namespace Odin.WebApplication.Controllers
{
    public class PositionamentController : Controller
    {
        public PositionamentController()
        {

        }

        public IActionResult Index()
        {
            IRecognicedList elements = new RecognicedObjectList();
            foreach (var item in elements.CalculatePositions())
            {

            }
            return View();
        }
    }
}