using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;

namespace HairSalon.Controllers;

public class StylistsController : Controller
{
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Details(int id)
    {
        Stylist stylist = _db.Stylists
            .Include(stylist => stylist.Clients)
            .FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
    }

    public ActionResult Edit(int id)
    {
        Stylist stylist = _db.Stylists
            .FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
        _db.Stylists.Update(stylist);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = stylist.StylistId });
    }

    public ActionResult Delete(int id)
    {
        Stylist stylist = _db.Stylists
            .FirstOrDefault(stylist => stylist.StylistId == id);
        _db.Stylists.Remove(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}