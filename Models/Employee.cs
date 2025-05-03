using System.ComponentModel.DataAnnotations; // Add this for data annotations

namespace GYM.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public string gender { get; set; }
        public string role { get; set; }
        public string experience { get; set; }
        public string schedule { get; set; }
    }
}
