using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Foundation;
using System.Net.Http;
using System.Text;
using UIKit;
using System.Collections.Generic;

namespace ToDo_List
{
	public class NetworkController
	{
		static public async Task<string> ApiCall(string path)
		{
			HttpClient client = new HttpClient();
			string product = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
				product = await response.Content.ReadAsStringAsync();
			}
			return product;
		}

		public static async Task<bool> Post(string url, string json)
		{
			var client = new WebClient();
			client.Headers[HttpRequestHeader.ContentType] = "application/json";
			try
			{
				await client.UploadStringTaskAsync(url, "POST", json);
			}
			catch
			{
				return false;
			}
			return true;
		}
	}
}
