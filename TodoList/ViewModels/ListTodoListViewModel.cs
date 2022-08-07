using TodoList.Models;

namespace TodoList.ViewModels
{
    public class ListTodoListViewModel
    {
        public ICollection<TodoListModel> TodoList { get; set; } = new List<TodoListModel>();
    }
}
