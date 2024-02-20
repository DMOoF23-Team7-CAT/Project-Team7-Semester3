using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rally.Models;

namespace Rally.Controllers;
public class TrackController : Controller
{
    private readonly ILogger<TrackController> _logger;

    public TrackController(ILogger<TrackController> logger)
    {
        _logger = logger;
    }

    [Route("Track")]
    public IActionResult Index()
    {
        return Ok("Track");
        //return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}