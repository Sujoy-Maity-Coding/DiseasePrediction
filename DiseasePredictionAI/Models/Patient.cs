namespace DiseasePredictionAI.Models
{
    public class Patient
    {
        public string Department { get; set; } = "";

        public int Age { get; set; }

        public int Gender { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public double BloodPressure { get; set; }

        public double Cholesterol { get; set; }

        public double HeartRate { get; set; }
    }
}