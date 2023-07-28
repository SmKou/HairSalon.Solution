namespace HairSalon.Models;

public class Stylist
{
    public int StylistId { get; set; }
    public string Name { get; set; }

    public int SpecialtyId { get; set; }
    public Specialty Specialty { get; set; }

    public List<Client> Clients { get; set; }
}