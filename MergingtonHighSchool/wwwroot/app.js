document.addEventListener("DOMContentLoaded", () => {
  const activitiesList = document.getElementById("activities-list");
  const searchInput = document.getElementById("activity-search");
  const activitySelect = document.getElementById("activity");
  const signupForm = document.getElementById("signup-form");
  const messageDiv = document.getElementById("message");
  let allActivities = [];

  function renderActivities(activities) {
    activitiesList.innerHTML = "";

    if (activities.length === 0) {
      activitiesList.innerHTML = "<p>No matching activities found.</p>";
      return;
    }

    activities.forEach(([name, details]) => {
      const activityCard = document.createElement("div");
      activityCard.className = "activity-card";

      const spotsLeft = details.spotsLeft || (details.maxParticipants - details.participants.length);

      activityCard.innerHTML = `
        <h4>${name}</h4>
        <p>${details.description}</p>
        <p><strong>Schedule:</strong> ${details.schedule}</p>
        <p><strong>Availability:</strong> ${spotsLeft} spots left</p>
      `;

      activitiesList.appendChild(activityCard);
    });
  }

  function applyActivityFilter() {
    const query = searchInput.value.trim().toLowerCase();

    if (!query) {
      renderActivities(allActivities);
      return;
    }

    const filteredActivities = allActivities.filter(([name, details]) => {
      const description = details.description || "";
      const schedule = details.schedule || "";

      return (
        name.toLowerCase().includes(query) ||
        description.toLowerCase().includes(query) ||
        schedule.toLowerCase().includes(query)
      );
    });

    renderActivities(filteredActivities);
  }

  // Function to fetch activities from API
  async function fetchActivities() {
    try {
      const response = await fetch("/activities");
      const activities = await response.json();

      allActivities = Object.entries(activities);

      activitySelect.innerHTML = '<option value="">-- Select an activity --</option>';

      allActivities.forEach(([name]) => {
        const option = document.createElement("option");
        option.value = name;
        option.textContent = name;
        activitySelect.appendChild(option);
      });

      renderActivities(allActivities);
    } catch (error) {
      activitiesList.innerHTML = "<p>Failed to load activities. Please try again later.</p>";
      console.error("Error fetching activities:", error);
    }
  }

  // Handle form submission
  signupForm.addEventListener("submit", async (event) => {
    event.preventDefault();

    const email = document.getElementById("email").value;
    const activity = document.getElementById("activity").value;

    try {
      const response = await fetch(
        `/activities/${encodeURIComponent(activity)}/signup?email=${encodeURIComponent(email)}`,
        {
          method: "POST",
        }
      );

      const result = await response.json();

      if (response.ok) {
        messageDiv.textContent = result.message;
        messageDiv.className = "message success";
        signupForm.reset();
        // Refresh activities to update participant counts
        fetchActivities();
      } else {
        messageDiv.textContent = result.message || "An error occurred";
        messageDiv.className = "message error";
      }

      messageDiv.classList.remove("hidden");

      // Hide message after 5 seconds
      setTimeout(() => {
        messageDiv.classList.add("hidden");
      }, 5000);
    } catch (error) {
      messageDiv.textContent = "Failed to sign up. Please try again.";
      messageDiv.className = "error";
      messageDiv.classList.remove("hidden");
      console.error("Error signing up:", error);
    }
  });

  // Initialize app
  searchInput.addEventListener("input", applyActivityFilter);
  fetchActivities();
});
