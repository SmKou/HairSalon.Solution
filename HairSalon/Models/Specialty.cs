namespace HairSalon.Models;

public class Specialty
{
    public int SpecialtyId { get; set; }
    public string Name { get; set; }

    public List<Stylist> Stylists { get; set; }
}