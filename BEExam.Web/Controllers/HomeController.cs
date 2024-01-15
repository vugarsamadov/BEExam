using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BEExam.Web.Models;
using BEExam.Business.Servies.Abstract;

namespace BEExam.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILatestNewsService latestNewsService;

    public HomeController(ILogger<HomeController> logger, ILatestNewsService latestNewsService)
    {
        _logger = logger;
        this.latestNewsService = latestNewsService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new IndexModel();
        model.LatestNews = await latestNewsService.GetLastNLatestNewsAsync(3);

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
