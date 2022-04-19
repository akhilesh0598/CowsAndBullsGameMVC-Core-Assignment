using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CowsAndBullsGame.Controllers
{
    [Authorize]
    public class GamePlayController : Controller
    {
        public IActionResult Play()
        {
            return View();
        }
    }
}
