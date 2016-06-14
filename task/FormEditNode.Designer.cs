/*
 * Created by SharpDevelop.
 * User: dimon
 * Date: 11.06.2016
 * Time: 1:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace task
{
	partial class FormEditNode
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		public System.Windows.Forms.CheckBox checkBox1;
		public System.Windows.Forms.CheckBox checkBox_important;
		public System.Windows.Forms.TextBox textBox_itil_obrashenie;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox_important = new System.Windows.Forms.CheckBox();
			this.textBox_itil_obrashenie = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(12, 27);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(408, 20);
			this.textBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Ок";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(93, 141);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(12, 92);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(93, 18);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Text = "Выполнено";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox_important
			// 
			this.checkBox_important.Location = new System.Drawing.Point(13, 116);
			this.checkBox_important.Name = "checkBox_important";
			this.checkBox_important.Size = new System.Drawing.Size(155, 18);
			this.checkBox_important.TabIndex = 4;
			this.checkBox_important.Text = "Важное";
			this.checkBox_important.UseVisualStyleBackColor = true;
			this.checkBox_important.CheckedChanged += new System.EventHandler(this.CheckBox2CheckedChanged);
			// 
			// textBox_itil_obrashenie
			// 
			this.textBox_itil_obrashenie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox_itil_obrashenie.Location = new System.Drawing.Point(12, 66);
			this.textBox_itil_obrashenie.Name = "textBox_itil_obrashenie";
			this.textBox_itil_obrashenie.Size = new System.Drawing.Size(406, 20);
			this.textBox_itil_obrashenie.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "Наименование";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(146, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Обращение в итилиуме";
			// 
			// FormEditNode
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(432, 176);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_itil_obrashenie);
			this.Controls.Add(this.checkBox_important);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "FormEditNode";
			this.Text = "FormEditNode";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
