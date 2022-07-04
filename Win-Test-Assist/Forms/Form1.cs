
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Win_Test_Assist;

public partial class Form1 : Form {

	public Form1() { InitializeComponent(); }

	private void Form1_Load(object sender, EventArgs e) { }
	private void button1_Click(object sender, EventArgs e) { }

	private async void btnRead_APIS_Click(object sender, EventArgs e) {

		// var json = await HttpClient_Helper.GetFromJsonAsync<object>(txtWebApiURL.Text, "").ConfigureAwait(false);
		var a1 = HttpClient_Helper.GetFromJsonAsync<object>(txtWebApiURL.Text, "");
		var a3 = await a1.ConfigureAwait(false);
		var json = a3?.ToString();
		Add2Txt(txtLog2, json);

		var json2 = Win_Test_Assist.HttpClient_Helper.Get1(txtWebApiURL.Text);
		Add2Txt(txtLog, json2);

		//txtLog.Text = JsonSerializer.Deserialize(json); //.ToString();

		//var hClient = new HttpClient { BaseAddress = new Uri(txtWebApiURL.Text) };
		//using var rq = new HttpRequestMessage(HttpMethod.Post, "");
		////rq.Headers.Add("user_key", tokens [0]);
		////rq.Headers.Add("Session_key", tokens [1]);

		//var json = JsonSerializer.Serialize("sms");
		//rq.Content = new StringContent(json, System.Text.Encoding.UTF8) {
		//	Headers = { ContentType = new("application/json") }
		//	};

		//using var rs = await hClient.SendAsync(rq);
		//rs.EnsureSuccessStatusCode();
		//var SRs = await rs.Content.ReadAsStringAsync();



		}

	private void Add2Txt(TextBox txtLog, object json1) {
		////if (txtLog.InvokeRequired) { txtLog.Invoke(() => txtLog.Text =  json1.ToString()); }
		//if (txtLog.InvokeRequired) { txtLog.Invoke(() => Add2Txt(txtLog, json1)); }
		//else { txtLog.Text = $"{DateTime.Now.TimeOfDay} : {json1.ToString()} "; }
		if (json1 is null) { return; }
		Add2Txt(txtLog, json1.ToString());
		}

	private void Add2Txt(TextBox txtLog, string json1) {
		try {
			if (txtLog.InvokeRequired) { txtLog.Invoke(() => Add2Txt(txtLog, json1)); }
			// else { txtLog.Text = $"{DateTime.Now.TimeOfDay.ToString("\\:hh\\:mm\\:ss")} : {json1} "; }
			else {
				// var jo = JsonSerializer.Deserialize<object>(json1);
				// json1 = JsonSerializer.Serialize(jo, new JsonSerializerOptions { WriteIndented = true });
				// json1 = JsonSerializer.Serialize(json1, new JsonSerializerOptions { WriteIndented = true });
				json1 = JsonConvert.SerializeObject(json1, Formatting.Indented).Replace("\\n", "\n").Replace("\\", "");

				txtLog.Text = $"{DateTime.Now.TimeOfDay.ToString("\\:hh\\:mm\\:ss")} : {json1} ";
				}
			}
		catch (Exception ex) { throw ex; }
		}
	}