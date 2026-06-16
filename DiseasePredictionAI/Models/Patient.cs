namespace DiseasePredictionAI.Models
{
    public class Patient
    {
        public string Department { get; set; } = "";

        // ---------- Cardiology ----------
        public int Age { get; set; }
        public int Gender { get; set; }
        public int ChestPain { get; set; }
        public int ShortnessBreath { get; set; }
        public int Dizziness { get; set; }
        public int Palpitations { get; set; }
        public int Fatigue { get; set; }
        public int Sweating { get; set; }
        public int Nausea { get; set; }
        public double BloodPressure { get; set; }
        public double HeartRate { get; set; }
        public double Cholesterol { get; set; }
        public int DiabetesHistory { get; set; }
        public int Smoking { get; set; }
        public int Obesity { get; set; }
        public int FamilyHistoryHeartDisease { get; set; }

        // ---------- Orthopedic ----------
        public int BackPain { get; set; }
        public int NeckPain { get; set; }
        public int JointPain { get; set; }
        public int KneePain { get; set; }
        public int HipPain { get; set; }
        public int ShoulderPain { get; set; }
        public int MuscleWeakness { get; set; }
        public int Stiffness { get; set; }
        public int Swelling { get; set; }
        public int DifficultyWalking { get; set; }
        public int PreviousInjury { get; set; }
        public double BoneDensity { get; set; }
        public double BMI { get; set; }

        // ---------- Psychology ----------
        public int StressLevel { get; set; }
        public double SleepHours { get; set; }
        public int AnxietyLevel { get; set; }
        public int MoodSwings { get; set; }
        public int ConcentrationProblem { get; set; }
        public int SocialWithdrawal { get; set; }
        public int AppetiteChange { get; set; }
        public int PanicAttack { get; set; }
        public int WorkPressure { get; set; }
        public int FamilyProblems { get; set; }
        public int DepressionScore { get; set; }

        // ---------- Diabetes (General Medicine) ----------
        public double Glucose { get; set; }
        public double Insulin { get; set; }
        public double SkinThickness { get; set; }
        public double DiabetesPedigreeFunction { get; set; }
        public int FrequentUrination { get; set; }
        public int ExcessiveThirst { get; set; }
        public int SuddenWeightLoss { get; set; }
        public int BlurredVision { get; set; }
        public int FamilyHistoryDiabetes { get; set; }
    }
}
