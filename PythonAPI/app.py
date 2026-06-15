from flask import Flask, request, jsonify
import joblib

app = Flask(__name__)

heart_model = joblib.load("heart_model.pkl")
orthopedic_model = joblib.load("orthopedic_model.pkl")
orthopedic_encoder = joblib.load("orthopedic_encoder.pkl")
psychology_model = joblib.load("psychology_model.pkl")
diabetes_model = joblib.load("diabetes_model.pkl")

@app.route('/predict', methods=['POST'])
def predict():

    data = request.json

    department = data["Department"]

    if department == "Cardiology":

        prediction = heart_model.predict([[
            float(data["Age"]),
            float(data["Gender"]),
            float(data["BloodPressure"]),
            float(data["Cholesterol"]),
            float(data["HeartRate"])
        ]])

        result = (
            "Heart Disease Risk"
            if prediction[0] == 1
            else "Normal"
        )

    elif department == "Orthopedic":

        prediction = orthopedic_model.predict([[
            float(data["PelvicIncidence"]),
            float(data["PelvicTilt"]),
            float(data["SacralSlope"])
        ]])

        result = orthopedic_encoder.inverse_transform(prediction)[0]

    elif department == "Psychology":

        prediction = psychology_model.predict([[
            float(data["Age"]),
            float(data["SleepHours"]),
            float(data["StressLevel"])
        ]])

        result = (
            "Depression Risk"
            if prediction[0] == 1
            else "Normal"
        )

    elif department == "Medicine":

        prediction = diabetes_model.predict([[
            float(data["Age"]),
            float(data["Glucose"]),
            float(data["BMI"])
        ]])

        result = (
            "Diabetes Risk"
            if prediction[0] == 1
            else "Normal"
        )

    else:
        result = "Invalid Department"

    return jsonify({
        "prediction": result
    })

if __name__ == "__main__":
    app.run(port=5000)