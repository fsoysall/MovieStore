namespace Win_Test_Assist {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
				}
			base.Dispose(disposing);
			}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtLog = new System.Windows.Forms.TextBox();
			this.txtLog2 = new System.Windows.Forms.TextBox();
			this.txtWebApiURL = new System.Windows.Forms.TextBox();
			this.btnRead_APIS = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtLog
			// 
			this.txtLog.Location = new System.Drawing.Point(12, 338);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new System.Drawing.Size(488, 280);
			this.txtLog.TabIndex = 4;
			// 
			// txtLog2
			// 
			this.txtLog2.Location = new System.Drawing.Point(532, 338);
			this.txtLog2.Multiline = true;
			this.txtLog2.Name = "txtLog2";
			this.txtLog2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLog2.Size = new System.Drawing.Size(485, 280);
			this.txtLog2.TabIndex = 5;
			// 
			// txtWebApiURL
			// 
			this.txtWebApiURL.Location = new System.Drawing.Point(100, 12);
			this.txtWebApiURL.Margin = new System.Windows.Forms.Padding(4);
			this.txtWebApiURL.Name = "txtWebApiURL";
			this.txtWebApiURL.Size = new System.Drawing.Size(746, 29);
			this.txtWebApiURL.TabIndex = 0;
			this.txtWebApiURL.Text = "http://localhost:5088/swagger/v1/swagger.json";
			// 
			// btnRead_APIS
			// 
			this.btnRead_APIS.Location = new System.Drawing.Point(850, 12);
			this.btnRead_APIS.Name = "btnRead_APIS";
			this.btnRead_APIS.Size = new System.Drawing.Size(167, 29);
			this.btnRead_APIS.TabIndex = 2;
			this.btnRead_APIS.Text = "READ APIS";
			this.btnRead_APIS.Click += new System.EventHandler(this.btnRead_APIS_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1029, 630);
			this.Controls.Add(this.btnRead_APIS);
			this.Controls.Add(this.txtLog);
			this.Controls.Add(this.txtLog2);
			this.Controls.Add(this.txtWebApiURL);
			this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

			}


		public TextBox txtLog      ;
		public TextBox txtLog2     ;
		public TextBox txtWebApiURL;
		public Button  btnRead_APIS;

		#endregion


		}
	}