using Microsoft.AspNetCore.Mvc.Rendering;
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

    public ActionResult Details(int id)
    {
        Client client = _db.Clients
            .Include(client => client.Stylist)
            .FirstOrDefault(client => client.ClientId == id);
        return View(client);
    }

    public ActionResult Edit(int id)
    {
        Client client = _db.Clients
            .FirstOrDefault(client => client.ClientId == id);
        ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name", client.StylistId);
        return View(client);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
        if (client.StylistId == 0)
            return RedirectToAction("Edit", new { id = client.ClientId });

        _db.Clients.Update(client);
        _db.SaveChanges();
        return RedirectToAction("Details", "Stylists", new { id = client.StylistId });
    }

    public ActionResult Delete(int id)
    {
        Client client = _db.Clients
            .FirstOrDefault(client => client.ClientId == id);
        int sId = client.StylistId;
        _db.Clients.Remove(client);
        _db.SaveChanges();
        return RedirectToAction("Details", "Stylists", new { id = sId });
    }
}