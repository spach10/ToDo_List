using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo_List
{
	public class ToDoController
	{
		static public async Task<List<ToDo>> GetList()
		{
			string url = "http://192.168.176.37:5000/tasks";
			var response = await NetworkController.ApiCall(url);
			var json = JsonConvert.DeserializeObject<Dictionary<string, List<ToDo>>>(response);
			var list = json["tasks"];
			foreach (var item in list.ToList())
			{
				var itemInList = new ToDo();
				itemInList.title = item.title;
			}
			return list;
		}

		static public async Task<bool> AddItem(ToDo item)
		{
			var uri = "http://192.168.176.37:5000/tasks";
			var jsonString = "{\"title\":\"" + item.title + "\"}";
			var success = await NetworkController.Post(uri, jsonString);
			return success;
		}
	}
}
