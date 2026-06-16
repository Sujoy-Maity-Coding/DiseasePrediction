# Disease Prediction AI

## Overview

Disease Prediction AI is a healthcare prediction system built using ASP.NET Core Razor Pages, Python Flask, and Machine Learning.

The application allows doctors to:

- Select a medical department
- Enter patient symptoms
- Predict diseases using trained ML models
- Recommend medicines based on predicted diseases

---

## Technologies Used

- ASP.NET Core Razor Pages
- Python Flask API
- Scikit-Learn
- Pandas
- NumPy
- Joblib
- Jupyter Notebook

---

## Project Structure

```text
DiseasePrediction/
│
├── Datasets/
│   ├── cardiology_dataset.csv
│   ├── diabetes_dataset.csv
│   ├── orthopedic_dataset.csv
│   └── psychology_dataset.csv
│
├── DiseasePredictionAI/
│   ├── Models/
│   ├── Pages/
│   ├── Properties/
│   ├── wwwroot/
│   ├── Program.cs
│   └── DiseasePredictionAI.csproj
│
├── Notebooks/
│   ├── HeartPrediction.ipynb
│   ├── OrthopedicPrediction.ipynb
│   ├── PsychologyPrediction.ipynb
│   └── DiabetesPrediction.ipynb
│
├── PythonAPI/
│   ├── app.py
│   │
│   ├── heart_disease_model.pkl
│   ├── heart_disease_encoder.pkl
│   ├── heart_medicine_model.pkl
│   ├── heart_medicine_encoder.pkl
│   │
│   ├── orthopedic_disease_model.pkl
│   ├── orthopedic_disease_encoder.pkl
│   ├── orthopedic_medicine_model.pkl
│   ├── orthopedic_medicine_encoder.pkl
│   │
│   ├── psychology_disease_model.pkl
│   ├── psychology_disease_encoder.pkl
│   ├── psychology_medicine_model.pkl
│   ├── psychology_medicine_encoder.pkl
│   │
│   ├── diabetes_disease_model.pkl
│   ├── diabetes_disease_encoder.pkl
│   ├── diabetes_medicine_model.pkl
│   └── diabetes_medicine_encoder.pkl
│
├── DiseasePredictionAI.sln
└── README.md
```

---

## Machine Learning Workflow

1. Create Dataset
2. Train Disease Prediction Model
3. Train Medicine Recommendation Model
4. Save Models using Joblib
5. Load Models in Flask API
6. Connect Flask API with ASP.NET Core
7. Display Disease and Medicine Predictions

---

## Departments Supported

- Cardiology
- Orthopedic
- Psychology
- Diabetes

---

## Running the Project

### Run Flask API

```bash
cd PythonAPI
python app.py
```

### Run ASP.NET Application

```bash
Open DiseasePredictionAI.sln
Press Ctrl + F5
```

---

## Author

**Sujoy Maity**

Machine Learning + ASP.NET Core Healthcare Prediction System.
