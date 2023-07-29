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
        ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
        if (ViewBag.SpecialtyId.Items == null)
            return RedirectToAction("Create", "Specialties");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
        if (stylist.SpecialtyId == 0)
            return RedirectToAction("Create");
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}