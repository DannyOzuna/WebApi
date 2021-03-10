using System.ComponentModel.DataAnnotations;

namespace WebApi.Models{
    public class Vacuna{
        [Key]
        public int id {get; set;}
        public string  marca {get; set;}
        public int cantidad {get; set;}
        public int estado {get; set;}
    }
}