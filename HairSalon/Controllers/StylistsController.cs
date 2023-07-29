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
        if (!_db.Specialties.Any())
            return RedirectToAction("Create", "Specialties");
        ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name");
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
        if (stylist.SpecialtyId == 0 
            || _db.Stylists.Any(other => other.Name == stylist.Name))
            return RedirectToAction("Create");
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    public ActionResult Edit(int id)
    {
        Stylist stylist = _db.Stylists
            .Include(stylist => stylist.Specialty)
            .FirstOrDefault(stylist => stylist.StylistId == id);
        ViewBag.SpecialtyId = new SelectList(_db.Specialties, "SpecialtyId", "Name", stylist.SpecialtyId);
        return View(stylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
        if (stylist.SpecialtyId == 0)
            return RedirectToAction("Edit", new { id = stylist.StylistId });
        _db.Stylists.Update(stylist);
        _db.SaveChanges();
        return RedirectToAction("Details", new { id = stylist.StylistId });
    }

    public ActionResult Details(int id)
    {
        Stylist stylist = _db.Stylists
            .Include(stylist => stylist.Specialty)
            .Include(stylist => stylist.Clients)
            .FirstOrDefault(stylist => stylist.StylistId == id);
        return View(stylist);
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