using System.ComponentModel.DataAnnotations;

namespace layoutProject.Models
{
    public enum Locations
    {
        [Display(Name ="Amman West")] AW,
        [Display(Name = "Amman North")] AN,
        Amman,
        Madaba,
        Salt,
        Karak,
        Irbid,
        Aqaba,
    }
}
