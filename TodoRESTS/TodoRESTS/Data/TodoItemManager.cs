using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoRESTS.Model;

namespace TodoRESTS.Data
{
    public class TodoItemManager
    {
        RestService restService;

        public TodoItemManager(RestService service)
        {
            restService = service;
        }

        public Task<List<TodoItem>> GetTaskAsync()
        {
            return restService.RefreshDataAsync();
        }

        public Task SaveTaskAsync (TodoItem item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }

        public Task DeleteTaskAsync(TodoItem item)
        {
            return restService.DeleteTodoItemAsync(item.ID);
        }
    }
}
