using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetElective
{

    class User
    {
        public String role { get; set; }
        public String id { get; set; }
        public String email { get; set; }
        public String name { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String address { get; set; }
        public String iban { get; set; }

        public User user { get; set; }

        public User() {}
        
        public User(String role, String id, String email, String name, String firstname, String lastname, String address, String iban)
        {
            this.role = role;
            this.id = id;
            this.email = email;
            this.name = name;
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.iban = iban;
            this.user = this;

        }
    }

}
