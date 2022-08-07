using TodoList.Models;

namespace TodoList.ViewModels;

public class DetailsTodoListViewModel
{
    public TodoListModel TodoList { get; set; } = null!;
    public string PageTitle { get; set; } = string.Empty;
}
