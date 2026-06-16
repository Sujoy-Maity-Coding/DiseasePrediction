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

        // ---------- Shared ----------
        [BindProperty]
        public int Age { get; set; }

        [BindProperty]
        public int Gender { get; set; }

        [BindProperty]
        public int Fatigue { get; set; }

        // ---------- Cardiology ----------
        [BindProperty]
        public int ChestPain { get; set; }

        [BindProperty]
        public int ShortnessBreath { get; set; }

        [BindProperty]
        public int Dizziness { get; set; }

        [BindProperty]
        public int Palpitations { get; set; }

        [BindProperty]
        public int Sweating { get; set; }

        [BindProperty]
        public int Nausea { get; set; }

        [BindProperty]
        public double BloodPressure { get; set; }

        [BindProperty]
        public double HeartRate { get; set; }

        [BindProperty]
        public double Cholesterol { get; set; }

        [BindProperty]
        public int DiabetesHistory { get; set; }

        [BindProperty]
        public int Smoking { get; set; }

        [BindProperty]
        public int Obesity { get; set; }

        [BindProperty]
        public int FamilyHistoryHeartDisease { get; set; }

        // ---------- Orthopedic ----------
        [BindProperty]
        public int BackPain { get; set; }

        [BindProperty]
        public int NeckPain { get; set; }

        [BindProperty]
        public int JointPain { get; set; }

        [BindProperty]
        public int KneePain { get; set; }

        [BindProperty]
        public int HipPain { get; set; }

        [BindProperty]
        public int ShoulderPain { get; set; }

        [BindProperty]
        public int MuscleWeakness { get; set; }

        [BindProperty]
        public int Stiffness { get; set; }

        [BindProperty]
        public int Swelling { get; set; }

        [BindProperty]
        public int DifficultyWalking { get; set; }

        [BindProperty]
        public int PreviousInjury { get; set; }

        [BindProperty]
        public double BoneDensity { get; set; }

        [BindProperty]
        public double BMI { get; set; }

        // ---------- Psychology ----------
        [BindProperty]
        public int StressLevel { get; set; }

        [BindProperty]
        public double SleepHours { get; set; }

        [BindProperty]
        public int AnxietyLevel { get; set; }

        [BindProperty]
        public int MoodSwings { get; set; }

        [BindProperty]
        public int ConcentrationProblem { get; set; }

        [BindProperty]
        public int SocialWithdrawal { get; set; }

        [BindProperty]
        public int AppetiteChange { get; set; }

        [BindProperty]
        public int PanicAttack { get; set; }

        [BindProperty]
        public int WorkPressure { get; set; }

        [BindProperty]
        public int FamilyProblems { get; set; }

        [BindProperty]
        public int DepressionScore { get; set; }

        // ---------- Diabetes (General Medicine) ----------
        [BindProperty]
        public double Glucose { get; set; }

        [BindProperty]
        public double Insulin { get; set; }

        [BindProperty]
        public double SkinThickness { get; set; }

        [BindProperty]
        public double DiabetesPedigreeFunction { get; set; }

        [BindProperty]
        public int FrequentUrination { get; set; }

        [BindProperty]
        public int ExcessiveThirst { get; set; }

        [BindProperty]
        public int SuddenWeightLoss { get; set; }

        [BindProperty]
        public int BlurredVision { get; set; }

        [BindProperty]
        public int FamilyHistoryDiabetes { get; set; }

        // ---------- Result ----------
        public string Disease { get; set; } = "";
        public string Medicine { get; set; } = "";
        public string ErrorMessage { get; set; } = "";

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
                    ChestPain,
                    ShortnessBreath,
                    Dizziness,
                    Palpitations,
                    Fatigue,
                    Sweating,
                    Nausea,
                    BloodPressure,
                    HeartRate,
                    Cholesterol,
                    DiabetesHistory,
                    Smoking,
                    Obesity,
                    FamilyHistoryHeartDisease
                };
            }
            else if (Department == "Orthopedic")
            {
                requestData = new
                {
                    Department,
                    Age,
                    Gender,
                    BackPain,
                    NeckPain,
                    JointPain,
                    KneePain,
                    HipPain,
                    ShoulderPain,
                    MuscleWeakness,
                    Stiffness,
                    Swelling,
                    DifficultyWalking,
                    PreviousInjury,
                    BoneDensity,
                    BMI
                };
            }
            else if (Department == "Psychology")
            {
                requestData = new
                {
                    Department,
                    Age,
                    Gender,
                    StressLevel,
                    SleepHours,
                    AnxietyLevel,
                    MoodSwings,
                    ConcentrationProblem,
                    SocialWithdrawal,
                    Fatigue,
                    AppetiteChange,
                    PanicAttack,
                    WorkPressure,
                    FamilyProblems,
                    DepressionScore
                };
            }
            else // Medicine (Diabetes)
            {
                requestData = new
                {
                    Department,
                    Age,
                    Gender,
                    Glucose,
                    BMI,
                    BloodPressure,
                    Insulin,
                    SkinThickness,
                    DiabetesPedigreeFunction,
                    FrequentUrination,
                    ExcessiveThirst,
                    SuddenWeightLoss,
                    Fatigue,
                    BlurredVision,
                    FamilyHistoryDiabetes
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

            if (!response.IsSuccessStatusCode)
            {
                ErrorMessage = obj?.error ?? "Prediction failed. Please check your inputs.";
                return;
            }

            Disease = obj.disease;
            Medicine = obj.medicine;
        }
    }
}
