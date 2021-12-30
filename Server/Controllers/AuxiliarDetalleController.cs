using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ModeloDatos;

namespace TalperExamen.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuxiliarDetalleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

  
      
    }
}
