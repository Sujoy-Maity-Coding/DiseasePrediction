using DiseasePredictionAI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DiseasePredictionAI.Pages
{
    public class DoctorsModel : PageModel
    {
        public List<Doctor> Doctors { get; set; } = new();

        public void OnGet()
        {
            Doctors = new List<Doctor>()
            {
                new Doctor
                {
                    Id = 1,
                    Name = "Dr. Rajesh",
                    Department = "Cardiology",
                    ModelName = "heart_model.pkl"
                },

                new Doctor
                {
                    Id = 2,
                    Name = "Dr. Amit",
                    Department = "Orthopedic",
                    ModelName = "orthopedic_model.pkl"
                },

                new Doctor
                {
                    Id = 3,
                    Name = "Dr. Priya",
                    Department = "Psychology",
                    ModelName = "psychology_model.pkl"
                },

                new Doctor
                {
                    Id = 4,
                    Name = "Dr. Sharma",
                    Department = "Medicine",
                    ModelName = "diabetes_model.pkl"
                }
            };
        }
    }
}
