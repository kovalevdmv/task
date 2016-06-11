/*
 * Created by SharpDevelop.
 * User: dimon
 * Date: 11.06.2016
 * Time: 1:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace task
{
	/// <summary>
	/// Description of FormEditNode.
	/// </summary>
	public partial class FormEditNode : Form
	{
		public bool ok=false;
		
		public FormEditNode()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			ok=true;
			Close();
		}
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
