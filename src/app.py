"""
High School Management System API

A super simple FastAPI application that allows students to view and sign up
for extracurricular activities at Mergington High School.
"""

from fastapi import FastAPI, HTTPException
from fastapi.staticfiles import StaticFiles
from fastapi.responses import RedirectResponse
import os
from pathlib import Path

app = FastAPI(title="Mergington High School API",
              description="API for viewing and signing up for extracurricular activities")

# Mount the static files directory
current_dir = Path(__file__).parent
app.mount("/static", StaticFiles(directory=os.path.join(Path(__file__).parent,
          "static")), name="static")

# In-memory activity database
activities = {
    "Chess Club": {
        "description": "Learn strategies and compete in chess tournaments",
        "schedule": "Fridays, 3:30 PM - 5:00 PM",
        "max_participants": 12,
        "participants": ["michael@mergington.edu", "daniel@mergington.edu"]
    },
    "Programming Class": {
        "description": "Learn programming fundamentals and build software projects",
        "schedule": "Tuesdays and Thursdays, 3:30 PM - 4:30 PM",
        "max_participants": 20,
        "participants": ["emma@mergington.edu", "sophia@mergington.edu"]
    },
    "Gym Class": {
        "description": "Physical education and sports activities",
        "schedule": "Mondays, Wednesdays, Fridays, 2:00 PM - 3:00 PM",
        "max_participants": 30,
        "participants": ["john@mergington.edu", "olivia@mergington.edu"]
    },
    "Debate Team": {
        "description": "Practice public speaking and structured debate",
        "schedule": "Mondays, 3:45 PM - 5:00 PM",
        "max_participants": 16,
        "participants": ["liam@mergington.edu", "ava@mergington.edu"]
    },
    "Art Workshop": {
        "description": "Explore drawing, painting, and creative techniques",
        "schedule": "Wednesdays, 3:30 PM - 5:00 PM",
        "max_participants": 18,
        "participants": ["mia@mergington.edu", "noah@mergington.edu"]
    },
    "Science Club": {
        "description": "Run experiments and discuss scientific discoveries",
        "schedule": "Thursdays, 3:30 PM - 4:45 PM",
        "max_participants": 22,
        "participants": ["ethan@mergington.edu", "isabella@mergington.edu"]
    },
    "Drama Society": {
        "description": "Acting, stage presence, and theater production",
        "schedule": "Tuesdays, 4:00 PM - 5:30 PM",
        "max_participants": 20,
        "participants": ["charlotte@mergington.edu", "james@mergington.edu"]
    },
    "Robotics Lab": {
        "description": "Build and program robots for school competitions",
        "schedule": "Fridays, 4:00 PM - 5:30 PM",
        "max_participants": 15,
        "participants": ["benjamin@mergington.edu", "amelia@mergington.edu"]
    },
    "Photography Club": {
        "description": "Learn composition, lighting, and photo editing",
        "schedule": "Wednesdays, 2:30 PM - 4:00 PM",
        "max_participants": 14,
        "participants": ["lucas@mergington.edu", "harper@mergington.edu"]
    },
    "Math Circle": {
        "description": "Solve challenging math puzzles and problems",
        "schedule": "Tuesdays, 3:30 PM - 4:45 PM",
        "max_participants": 25,
        "participants": ["henry@mergington.edu", "evelyn@mergington.edu"]
    },
    "Music Ensemble": {
        "description": "Rehearse songs and perform at school events",
        "schedule": "Thursdays, 4:00 PM - 5:30 PM",
        "max_participants": 24,
        "participants": ["jack@mergington.edu", "abigail@mergington.edu"]
    },
    "Environmental Club": {
        "description": "Lead sustainability projects and campus cleanups",
        "schedule": "Mondays, 2:45 PM - 4:00 PM",
        "max_participants": 21,
        "participants": ["logan@mergington.edu", "ella@mergington.edu"]
    },
    "Creative Writing": {
        "description": "Write short stories, poems, and peer feedback",
        "schedule": "Fridays, 3:00 PM - 4:30 PM",
        "max_participants": 17,
        "participants": ["alexander@mergington.edu", "scarlett@mergington.edu"]
    }
}


@app.get("/")
def root():
    return RedirectResponse(url="/static/index.html")


@app.get("/activities")
def get_activities():
    return activities


@app.post("/activities/{activity_name}/signup")
def signup_for_activity(activity_name: str, email: str):
    """Sign up a student for an activity"""
    # Validate activity exists
    if activity_name not in activities:
        raise HTTPException(status_code=404, detail="Activity not found")

    # Get the specific activity
    activity = activities[activity_name]

    # Add student
    activity["participants"].append(email)
    return {"message": f"Signed up {email} for {activity_name}"}
