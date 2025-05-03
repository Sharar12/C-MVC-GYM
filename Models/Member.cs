namespace GYM.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public int phone { get; set; }
        public int age { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public string package { get; set; }
        public string paymentMethod { get; set; }

        public string Tid { get; set; }

        public int amount { get; set; }

        
         public string Expire { get; set; }
        public string CreditCardNumber { get; set; } // Added for payment

        public string Class { get; set; } // Added Class property
        public string Schedule { get; set; } // Added Schedule property
    }
}
