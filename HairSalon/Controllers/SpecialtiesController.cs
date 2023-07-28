using HairSalon.Models;

namespace HairSalon.Controllers;

public class SpecialtiesController : Controller
{
    private readonly HairSalonContext _db;

    public SpecialtiesController(HairSalonContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Specialty> model = _db.Specialties
            .ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
        _db.Specialties.Add(specialty);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
        Specialty specialty = _db.Specialties
            .FirstOrDefault(specialty => specialty.SpecialtyId == id);
        return View(specialty);
    }

    [HttpPost]
    public ActionResult Edit(Specialty specialty)
    {
        _db.Specialties.Update(specialty);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Specialty specialty = _db.Specialties
            .FirstOrDefault(specialty => specialty.SpecialtyId == id);
        _db.Specialties.Remove(specialty);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}