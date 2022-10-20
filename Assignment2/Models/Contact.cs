using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment21.Models
{
    public class Contact
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // generar ett nytt Guid id varje gång en ny kontakt skapas
        public string FirstName { get; set; } // null!  berättar för programmet att det kommer komma ett värde
        public string LastName { get; set; } // ? berättar för programmet att det är okej att inte få ett värde
        public string Email { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string FullName => $"{FirstName} {LastName}"; // lägger ihop värdena som är satta
    }
}
