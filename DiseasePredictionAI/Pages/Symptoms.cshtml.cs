using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace DiseasePredictionAI.Pages
{
    public class SymptomsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Department { get; set; } = "";

        // Cardiology
        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public int Gender { get; set; }

        [BindProperty]
        public double BloodPressure { get; set; }

        [BindProperty]
        public double Cholesterol { get; set; }

        [BindProperty]
        public double HeartRate { get; set; }

        // Orthopedic
        [BindProperty]
        public double PelvicIncidence { get; set; }

        [BindProperty]
        public double PelvicTilt { get; set; }

        [BindProperty]
        public double SacralSlope { get; set; }

        // Psychology
        [BindProperty]
        public double SleepHours { get; set; }

        [BindProperty]
        public int StressLevel { get; set; }

        // Diabetes
        [BindProperty]
        public double Glucose { get; set; }

        [BindProperty]
        public double BMI { get; set; }

        public string Result { get; set; } = "";

        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            object requestData;

            if (Department == "Cardiology")
            {
                requestData = new
                {
                    Department,
                    Age,
                    Gender,
                    BloodPressure,
                    Cholesterol,
                    HeartRate
                };
            }
            else if (Department == "Orthopedic")
            {
                requestData = new
                {
                    Department,
                    PelvicIncidence,
                    PelvicTilt,
                    SacralSlope
                };
            }
            else if (Department == "Psychology")
            {
                requestData = new
                {
                    Department,
                    Age,
                    SleepHours,
                    StressLevel
                };
            }
            else
            {
                requestData = new
                {
                    Department,
                    Age,
                    Glucose,
                    BMI
                };
            }

            var client = new HttpClient();

            var content = new StringContent(
                JsonConvert.SerializeObject(requestData),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync(
                "http://127.0.0.1:5000/predict",
                content
            );

            var result = await response.Content.ReadAsStringAsync();

            dynamic obj = JsonConvert.DeserializeObject(result);

            Result = obj.prediction;
        }
    }
}