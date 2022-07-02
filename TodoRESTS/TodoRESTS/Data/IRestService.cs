using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoRESTS.Model;

namespace TodoRESTS.Data
{
    public interface IRestService
    {
        Task<List<TodoItem>> RefreshDataAsync();
        Task SaveTodoItemAsync(TodoItem item, bool isNewItem);
        Task DeleteTodoItemAsync(string id);
    }
}
