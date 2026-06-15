using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DiseasePredictionAI.Models;

namespace DiseasePredictionAI.Pages
{
    public class DoctorDetailsModel : PageModel
    {
        public Doctor Doctor { get; set; } = new();

        public void OnGet(int id)
        {
            var doctors = new List<Doctor>()
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

            Doctor = doctors.FirstOrDefault(d => d.Id == id)
                     ?? new Doctor();
        }
    }
}