using HairSalon.Models;

namespace HairSalon.Controllers;

public class ClientsController : Controller
{
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Create(int id)
    {
        ViewBag.StylistId = id;
        return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
        _db.Clients.Add(client);
        _db.SaveChanges();
        return RedirectToAction("Details", "Stylists", new { id = client.StylistId });
    }
}