using Microsoft.AspNetCore.Mvc;
using TodoList.Contexts;
using TodoList.Models;
using TodoList.ViewModels;

namespace TodoList.Controllers
{
    public class TodoListController : Controller
    {
        private readonly TodoListDbContex _context;

        public TodoListController(TodoListDbContex context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var todoList = _context.TodoList.OrderBy(x => x.Date).ToList();
            var viewModel = new ListTodoListViewModel { TodoList = todoList };
            ViewData["Title"] = "Lista de Tarefas";
            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var todoList = _context.TodoList.Find(id);
            if (todoList is null)
            {
                return NotFound();
            }
            _context.Remove(todoList);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Cadastrar Tarefa";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(FormTodoListViewModel data)
        {
            var todoList = new TodoListModel(data.Title, data.Date);
            _context.Add(todoList);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var todoList = _context.TodoList.Find(id);
            if (todoList is null)
            {
                return NotFound();
            }
            ViewData["Title"] = "Editar Tarefa";
            var viewModel = new FormTodoListViewModel { Title = todoList.Title, Date = todoList.Date };
            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, FormTodoListViewModel data)
        {
            var todoList = _context.TodoList.Find(id);
            if (todoList is null)
            {
                return NotFound();
            }
            todoList.Title = data.Title;
            todoList.Date = data.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ToComplete(int id)
        {
            var todoList = _context.TodoList.Find(id);
            if (todoList is null)
            {
                return NotFound();
            }
            todoList.IsCompleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
