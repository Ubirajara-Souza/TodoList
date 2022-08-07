using System.ComponentModel.DataAnnotations.Schema;

namespace TodoList.Models
{
    [Table("TodoList")]
    public class TodoListModel: EntityBase
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public TodoListModel(string title, DateTime date, bool isCompleted = false)
        {
            Title = title;
            Date = date;
            IsCompleted = isCompleted;
        }

        public TodoListModel(int id, string title, DateTime date, bool isCompleted = false)
        {
            Id = id;
            Title = title;
            Date = date;
            IsCompleted = isCompleted;
        }
    }
}
