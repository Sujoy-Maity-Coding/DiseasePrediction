from flask import Flask, request, jsonify
import joblib

app = Flask(__name__)

# ------------------------------------------------------------------
# Load all models + encoders
# Each department has 4 files: disease_model, medicine_model,
# disease_encoder, medicine_encoder
# ------------------------------------------------------------------
heart_disease_model = joblib.load("heart_disease_model.pkl")
heart_medicine_model = joblib.load("heart_medicine_model.pkl")
heart_disease_encoder = joblib.load("heart_disease_encoder.pkl")
heart_medicine_encoder = joblib.load("heart_medicine_encoder.pkl")

orthopedic_disease_model = joblib.load("orthopedic_disease_model.pkl")
orthopedic_medicine_model = joblib.load("orthopedic_medicine_model.pkl")
orthopedic_disease_encoder = joblib.load("orthopedic_disease_encoder.pkl")
orthopedic_medicine_encoder = joblib.load("orthopedic_medicine_encoder.pkl")

psychology_disease_model = joblib.load("psychology_disease_model.pkl")
psychology_medicine_model = joblib.load("psychology_medicine_model.pkl")
psychology_disease_encoder = joblib.load("psychology_disease_encoder.pkl")
psychology_medicine_encoder = joblib.load("psychology_medicine_encoder.pkl")

diabetes_disease_model = joblib.load("diabetes_disease_model.pkl")
diabetes_medicine_model = joblib.load("diabetes_medicine_model.pkl")
diabetes_disease_encoder = joblib.load("diabetes_disease_encoder.pkl")
diabetes_medicine_encoder = joblib.load("diabetes_medicine_encoder.pkl")

# ------------------------------------------------------------------
# Feature order MUST match the column order used during training
# ------------------------------------------------------------------
CARDIOLOGY_FEATURES = [
    "Age", "Gender", "ChestPain", "ShortnessBreath", "Dizziness",
    "Palpitations", "Fatigue", "Sweating", "Nausea", "BloodPressure",
    "HeartRate", "Cholesterol", "DiabetesHistory", "Smoking",
    "Obesity", "FamilyHistoryHeartDisease"
]

ORTHOPEDIC_FEATURES = [
    "Age", "Gender", "BackPain", "NeckPain", "JointPain", "KneePain",
    "HipPain", "ShoulderPain", "MuscleWeakness", "Stiffness",
    "Swelling", "DifficultyWalking", "PreviousInjury", "BoneDensity", "BMI"
]

PSYCHOLOGY_FEATURES = [
    "Age", "Gender", "StressLevel", "SleepHours", "AnxietyLevel",
    "MoodSwings", "ConcentrationProblem", "SocialWithdrawal", "Fatigue",
    "AppetiteChange", "PanicAttack", "WorkPressure", "FamilyProblems",
    "DepressionScore"
]

DIABETES_FEATURES = [
    "Age", "Gender", "Glucose", "BMI", "BloodPressure", "Insulin",
    "SkinThickness", "DiabetesPedigreeFunction", "FrequentUrination",
    "ExcessiveThirst", "SuddenWeightLoss", "Fatigue", "BlurredVision",
    "FamilyHistoryDiabetes"
]


def build_row(data, feature_list):
    """Extract features in the exact trained order, fail loudly if missing."""
    missing = [f for f in feature_list if f not in data]
    if missing:
        raise KeyError(f"Missing required fields: {missing}")
    return [[float(data[f]) for f in feature_list]]


@app.route('/predict', methods=['POST'])
def predict():
    data = request.json
    department = data.get("Department", "")

    try:
        if department == "Cardiology":
            row = build_row(data, CARDIOLOGY_FEATURES)
            disease_pred = heart_disease_model.predict(row)
            medicine_pred = heart_medicine_model.predict(row)
            disease = heart_disease_encoder.inverse_transform(disease_pred)[0]
            medicine = heart_medicine_encoder.inverse_transform(medicine_pred)[0]

        elif department == "Orthopedic":
            row = build_row(data, ORTHOPEDIC_FEATURES)
            disease_pred = orthopedic_disease_model.predict(row)
            medicine_pred = orthopedic_medicine_model.predict(row)
            disease = orthopedic_disease_encoder.inverse_transform(disease_pred)[0]
            medicine = orthopedic_medicine_encoder.inverse_transform(medicine_pred)[0]

        elif department == "Psychology":
            row = build_row(data, PSYCHOLOGY_FEATURES)
            disease_pred = psychology_disease_model.predict(row)
            medicine_pred = psychology_medicine_model.predict(row)
            disease = psychology_disease_encoder.inverse_transform(disease_pred)[0]
            medicine = psychology_medicine_encoder.inverse_transform(medicine_pred)[0]

        elif department == "Medicine":
            row = build_row(data, DIABETES_FEATURES)
            disease_pred = diabetes_disease_model.predict(row)
            medicine_pred = diabetes_medicine_model.predict(row)
            disease = diabetes_disease_encoder.inverse_transform(disease_pred)[0]
            medicine = diabetes_medicine_encoder.inverse_transform(medicine_pred)[0]

        else:
            return jsonify({"error": "Invalid Department"}), 400

    except KeyError as e:
        return jsonify({"error": str(e)}), 400

    return jsonify({
        "disease": disease,
        "medicine": medicine,
        # kept for backward compatibility with older front-end code
        "prediction": disease
    })


if __name__ == "__main__":
    app.run(port=5000)
