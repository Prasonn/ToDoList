// Get references to DOM elements
const todoInput = document.getElementById('todo-input');
const addButton = document.getElementById('add-button');
const todoList = document.getElementById('todo-list');

const baseUrl = "https://localhost:7059/api/TodoLists/";

// // Add event listener to the Add button
// addButton.addEventListener('click', () => {
//   const taskText = todoInput.value.trim();
//   if (taskText) {
//     // Create a new list item
//     const listItem = document.createElement('li');
//     listItem.textContent = taskText;

//     // Add a delete button to the list item
//     const deleteButton = document.createElement('button');
//     deleteButton.textContent = 'Delete';
//     deleteButton.addEventListener('click', () => {
//       listItem.remove();
//     });

//     listItem.appendChild(deleteButton);
//     todoList.appendChild(listItem);

//     // Clear the input field
//     todoInput.value = '';
//   }
// });


function InsertUserDetails() {
  var fullName = document.getElementById("fullName").value;
  var age = document.getElementById("age").value;
  if(fullName==='' || age==='')
  {
    alert("Please enter everything");
    return;
  }
  const taskData = {
    Name: fullName,
    Age: age,
    Sex:"Male"

  };

  fetch(apiUrl, {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(taskData)
  })
    .then(response => response.json())
    .then(data => {
      console.log('Task Created:', data);
      alert('Task Created!');
      readTasks();  // Refresh the task list
    })
    .catch(error => console.error('Error creating task:', error));
}


async function addUser() {
  const url = baseUrl+'AddUser';
  var fullName = document.getElementById("fullName").value;
  var age = document.getElementById("age").value;
  if(fullName==='' || age==='')
  {
    alert("Please enter everything");
    return;
  }
  const taskData = {
    name: fullName,
    age: age,
    sex:"Male"

  };
  // Payload data to be sent in the request body
  

  try {
      // Call the API using fetch
      const response = await fetch(url, {
          method: 'POST',
          headers: {
              'accept': 'text/plain',
              'Content-Type': 'application/json'
          },
          body: JSON.stringify(taskData) // Convert the user data to JSON string
      });

      // Check if the request was successful
      if (response.ok) {
          const result = await response.json();
          console.log('User added successfully:', result);
      } else {
          const errorText = await response.text();
          console.error('Error adding user:', response.status, errorText);
      }
  } catch (error) {
      console.error('An error occurred:', error);
  }
}
function fetchDate(data){
  return new Promise((resolve)=>{
    setTimeout(() => {  
      resolve(data);
    }, 1000);
  })
}
function LoadData(){
  ShowTask();
}
async function ShowTask() {
  const url = baseUrl+"GetToDoList";
  var dataShow = document.createElement('div');
  try{
    const resposne = await fetch(url, {
      method: 'GET',
      headers: {
        'accept': 'text/plain',
        'Content-Type': 'application/json'
    }
    })
    if(resposne.ok)
    {
      const result = await resposne.json();
      console.log('inside promise')
      fetchDate(result);
      var innerShow = document.createElement('div');
      result.forEach(element => {
        const taskDiv = document.createElement('div'); // Create a new div for each task
        taskDiv.innerHTML = `${element.taskName} - ${element.description}`;
        dataShow.appendChild(taskDiv); // Append the task div to dataShow
      });
      console.log('task shown');
      document.body.appendChild(dataShow);
    }
  }
  catch(error)
  {
    console.error('An error occured: '+error);
  }
} 
function redirectPageToTask()
{
  window.location.href = "http://localhost:5500/UI/Main/HTML/Tasks.html";
}

// Example usage
// addUser(0, 'Prasoon', 26, 'Male');
