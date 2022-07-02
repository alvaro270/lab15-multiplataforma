using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using TodoRESTS.Model;
using Xamarin.Forms;

namespace TodoRESTS.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        public List<TodoItem> Items { get; private set; }

        public RestService()
        {
#if DEBUG
            client = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
#else
            client = new HttpClient();
#endif
        }

        public async Task<List<TodoItem>> RefreshDataAsync()
        {
            Items = new List<TodoItem>();
            string action = "List";

            var uri = new Uri(string.Format(Constants.RestUrl, action));
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}",ex.Message);
            }
            return Items;
        }

        public async Task SaveTodoItemAsync(TodoItem item,bool isNewItem = false)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    var uri = new Uri(string.Format(Constants.RestUrl, "Create"));
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    var uri = new Uri(string.Format(Constants.RestUrl, "Edit"));
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem Successfully saved.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTodoItemAsync(string id)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem Successfully deleted");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
