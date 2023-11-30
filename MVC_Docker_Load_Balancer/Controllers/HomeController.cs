using Microsoft.AspNetCore.Mvc;
using MVC_Docker_Load_Balancer.Models;

namespace MVC_Docker_Load_Balancer.Controllers;
public class HomeController : Controller
{
    private readonly IRepository repository;
    private readonly string message;
    public HomeController(IRepository repo, IConfiguration config)
    {
        repository = repo;
        message = $"Docker - ({config["HOSTNAME"]})";
    }
    public IActionResult Index()
    {
        ViewBag.Message = message;
        return View(repository.LBProdutos);
    }
}
