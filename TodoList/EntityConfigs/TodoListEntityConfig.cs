using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoList.Models;

namespace TodoList.EntityConfigs
{
    public class TodoListEntityConfig : IEntityTypeConfiguration<TodoListModel>
    {
        public void Configure(EntityTypeBuilder<TodoListModel> builder)
        {
            builder.ToTable("TodoList");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("Id");

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnName("Date")
                .HasColumnType("timestamp without time zone")
                .IsRequired();

            builder.Property(x => x.IsCompleted)
                .HasColumnName("IsCompleted")
                .HasColumnType("boolean")
                .IsRequired();
        }
    }
}
