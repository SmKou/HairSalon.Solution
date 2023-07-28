using HairSalon.Models;

namespace HairSalon.Controllers;

public class HomeController : Controller
{
    private readonly HairSalonContext _db;

    public HomeController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Stylist> model = _db.Stylists
            .Include(stylist => stylist.Specialty)
            .ToList();
        return View(model);
    }
}