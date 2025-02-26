const saveButton = document.querySelector("#btnSave");
const deleteButton = document.querySelector("#btnDelete");
const titleInput = document.querySelector("#title");
const descriptionInput = document.querySelector("#description");
const notesContainer = document.querySelector("#notes_container");

function displayNotes(notes) {
  let allNotes = "";
  notes.forEach((note) => {
    // console.log(note.id);
    const noteElement = `
            <div class="note" data-id="${note.id}">
                <h3>${note.title}</h3>
                <p>${note.description}</p>
            </div>
        `;
    allNotes += noteElement;
  });
  notesContainer.innerHTML = allNotes;

  document.querySelectorAll(".note").forEach((note) => {
    note.addEventListener("click", function () {
      populateForm(note.dataset.id);

      document.querySelectorAll(".note").forEach((n) => {
        n.classList.remove("active");
        this.classList.add("active");
      });
    });
  });
}

function getNoteById(id) {
  var route = "https://localhost:7050/api/notes/";
  fetch(route + encodeURIComponent(id))
    .then((data) => data.json())
    .then((response) => displayNoteInForm(response));
}
function displayNoteInForm(note) {
  titleInput.value = note.title;
  descriptionInput.value = note.description;
  deleteButton.classList.remove("hidden");
  deleteButton.setAttribute("data-id", note.id);
  saveButton.setAttribute("data-id", note.id);
}
function clearForm() {
  titleInput.value = "";
  descriptionInput.value = "";
  deleteButton.classList.add("hidden");
}
function populateForm(id) {
  getNoteById(id);
}

function getAllNotes() {
  try {
    fetch("https://localhost:7050/api/notes")
      .then((data) => data.json())
      .then((response) => displayNotes(response));
  } catch (error) {
    alert(error);
    console.log(error);
  }
}
function addNote(title, description) {
  const body = {
    title: title,
    description: description,
    isVisible: true,
  };

  fetch("https://localhost:7050/api/notes", {
    method: "Post",
    body: JSON.stringify(body),
    headers: {
      "content-type": "application/json",
    },
  })
    .then((data) => data.json())
    .then((response) => {
      console.log(response);
      clearForm();
      getAllNotes();
    });
}
function deleteNote(id) {
  var route = "https://localhost:7050/api/notes/";
  fetch(route + encodeURIComponent(id), {
    method: "Delete",
    headers: {
      "content-type": "application/json",
    },
  })
    .then((data) => data.json)
    .then((response) => {
      console.log(response);
      console.log("deleted the note");
      clearForm();
      getAllNotes();
    });
}

getAllNotes();

function updateNote(id, title, description) {
  const body = {
    title: title,
    description: description,
    isVisible: true,
  };
  console.log("id is: " + id);

  var route = "https://localhost:7050/api/notes/";
  fetch(route + encodeURIComponent(id), {
    method: "PUT",
    body: JSON.stringify(body),
    headers: {
      "content-type": "application/json",
    },
  })
    .then((data) => data.json())
    .then((response) => {
      console.log(response);
      clearForm();
      getAllNotes();
    });
}
saveButton.addEventListener("click", function () {
  const id = saveButton.dataset.id;
  if (id) {
    console.log("should update");
    updateNote(id, titleInput.value, descriptionInput.value);
    console.log("should be updated");
  } else {
    addNote(titleInput.value, descriptionInput.value);
  }
});

deleteButton.addEventListener("click", () => {
  const id = deleteButton.dataset.id;
  deleteNote(id);
});
