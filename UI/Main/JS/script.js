// Get references to DOM elements
const todoInput = document.getElementById('todo-input');
const addButton = document.getElementById('add-button');
const todoList = document.getElementById('todo-list');

// Add event listener to the Add button
addButton.addEventListener('click', () => {
  const taskText = todoInput.value.trim();
  if (taskText) {
    // Create a new list item
    const listItem = document.createElement('li');
    listItem.textContent = taskText;

    // Add a delete button to the list item
    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => {
      listItem.remove();
    });

    listItem.appendChild(deleteButton);
    todoList.appendChild(listItem);

    // Clear the input field
    todoInput.value = '';
  }
});
