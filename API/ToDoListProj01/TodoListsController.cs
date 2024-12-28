using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListProj01.Models;
using TodoApi.Models;

namespace ToDoListProj01
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoListsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoItems(string clientID)
        {
            return await _context.TodoItems.ToListAsync();
        }
        //UserAuthectication
        [HttpPost("login")]
        public async Task<ActionResult<IEnumerable<UserCls>>> Login(string userName)
        {
            var user = await _context.UserCls.FirstOrDefaultAsync(x=>x.Name==userName);
            if (user == null)
            {
                return null;
            }
            return Ok(user);
        }
        [HttpPost("GetToken")]

        [HttpPost("AddUser")]
        //public async Task<ActionResult<>>
        // GET: api/TodoLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TodoList>>> GetTodoList(int id)
        {
            return await _context.TodoItems.Where(x => x.clientId == id).ToListAsync();

            
        }

        // PUT: api/TodoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(TodoList todoList)
        {
            if (todoList.clientId != todoList.TaskId)
            {    
                return BadRequest();
            }
            
            _context.Entry(todoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoListExists(todoList.clientId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList(TodoList todoList)
        {
            _context.TodoItems.Add(todoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoList", new { id = todoList.TaskId }, todoList);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoList(int id)
        {
            var todoList = await _context.TodoItems.FindAsync(id);
            if (todoList == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoListExists(int id)
        {
            return _context.TodoItems.Any(e => e.TaskId == id);
        }
    }
}
