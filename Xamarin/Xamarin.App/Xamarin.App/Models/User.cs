using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.App.Models
{
   public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Nit { get; set; }
        public int NitType { get; set; }
        public DateTime NitDate { get; set; } 
        public DateTime BirthDay { get; set; }
        public int UserStatus { get; set; }
        public int Genre { get; set; }
        public string Email { get; set; } 
    }
}
