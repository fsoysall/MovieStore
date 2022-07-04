using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Win_Test_Assist {

	internal static class HttpClient_Helper {

		public static async Task<T?> GetFromJsonAsync<T>(string url, string rqUri) {
			using var client = new HttpClient() { BaseAddress = new Uri(url) };
			var request = new HttpRequestMessage(HttpMethod.Get, url);
			var rs = await client.GetFromJsonAsync<T>(rqUri, new JsonSerializerOptions { WriteIndented = true });
			return rs;
			}


		public static async Task<string> PutAsJsonAsync<T>(string url, string rqUri, T dto) {
			using var client = new HttpClient() { BaseAddress = new Uri(url) };
			var request = new HttpRequestMessage(HttpMethod.Get, url);
			var rs = client.PutAsJsonAsync(rqUri, value: dto, options: new JsonSerializerOptions { WriteIndented = true });
			var rStr = await rs.Result.Content.ReadAsStringAsync();
			return rStr;
			}

		public static string Get1(string url) {
			using var httpClient = new HttpClient();
			//var request = new HttpRequestMessage(HttpMethod.Get, "https://api.example.com/api/v1/get");
			var request = new HttpRequestMessage(HttpMethod.Get, url);
			var response = httpClient.Send(request);
			using var reader = new StreamReader(response.Content.ReadAsStream());
			var responseBody = reader.ReadToEnd();
			return responseBody;
			}

		public static string PostJson(string Url, string Uri, string jsonData) {

			var handler = new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };

			var client = new HttpClient(handler) { BaseAddress = new Uri(Url) };

			var webRequest = new HttpRequestMessage(HttpMethod.Post, Uri) {
				Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
				};

			//webRequest.Headers.Add("user_key", tokens [0]);
			//webRequest.Headers.Add("Session_key", tokens [1]);

			var response = client.Send(webRequest);
			var reader = new StreamReader(response.Content.ReadAsStream());
			var responseBody = reader.ReadToEnd();
			return responseBody;

			}

		}
	}
