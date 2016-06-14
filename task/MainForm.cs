/*
 * Created by SharpDevelop.
 * User: kovalevdv
 * Date: 08.06.2016
 * Time: 13:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.Serialization;


namespace task
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	

	
	public partial class MainForm : Form
	{
		
		TreeNode node_cur;
		Font font_uncheked;
		Font font_chekednew;
		Font font_important;
		
		public MainForm()
		{
			InitializeComponent();
			
			font_uncheked = new Font(treeView1.Font, treeView1.Font.Style);
			font_chekednew = new Font(treeView1.Font, FontStyle.Strikeout);
			font_important= new Font(treeView1.Font, FontStyle.Bold);

		}
		
		TreeNode add_node(String text = "")
		{
			TreeNode el;
			if (node_cur != null)
				el = node_cur.Nodes.Add(text);
			else
				el = treeView1.Nodes.Add(text);
		
			el.ContextMenuStrip = contextMenuStrip1;
			el.Tag = new Adv_data();
			
			save_to_file();
			
			return el;
		}
		
		void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			node_cur = e.Node;
			toolStripStatusLabel1.Text = e.Node.Text;
		}
		
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			node_cur = e.Node;
			toolStripStatusLabel1.Text = e.Node.Text;
		}

		void tree_to_model(TreeNodeCollection nodes, Model m, Model.Node parent = null)
		{
			foreach (TreeNode node in nodes) {
				Model.Node elem;
				if (parent != null) {
					elem = m.add(parent, node.Text);
				} else {
					elem = m.add(node.Text);
				}
				elem.check = node.Checked;
				elem.tag = (Adv_data)node.Tag;
				if (node.Nodes.Count > 0)
					tree_to_model(node.Nodes, m, elem);
			}
		}
		
		void model_to_tree(TreeNodeCollection TreeNodes, List<Model.Node> nodes)
		{
			foreach (Model.Node element in nodes) {
				TreeNode elem = TreeNodes.Add(element.name);
				elem.ContextMenuStrip = contextMenuStrip1;
				elem.Checked = element.check;
				elem.Tag = element.tag;
				setNodeFont(elem);
				if (element.nodes.Count > 0) {
					model_to_tree(elem.Nodes, element.nodes);
				}
			}
		}
		
		void setNodeFont(TreeNode node)
		{
			Adv_data tag;
			if (node.Tag!=null){
				tag = (Adv_data) node.Tag;
			} else {
				tag = new Adv_data();
			}
			if (node.Checked) {
				node.NodeFont = font_chekednew;
			} else if (tag.important) {
				node.NodeFont = font_important;
			}
			else {
				node.NodeFont = font_uncheked;
			} 		
		}
	

		void ЗаписатьToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			save_to_file();
		}
		void ПрочитатьToolStripMenuItemClick(object sender, EventArgs e)
		{
			Model m = MySerDeser.deser<Model>();
			model_to_tree(treeView1.Nodes, m.nodes);
		}

		void MainFormLoad(object sender, EventArgs e)
		{
			if (File.Exists("db.xml")) {
				Model m = MySerDeser.deser<Model>();
				model_to_tree(treeView1.Nodes, m.nodes);
				treeView1.ExpandAll();
			}
		}
		
		void save_to_file()
		{
			Model m = new Model();
			tree_to_model(treeView1.Nodes, m);
			MySerDeser.ser<Model>(m);
			toolStripStatusLabel1.Text = "Записано";

		}

		
		void del_node()
		{
			treeView1.Nodes.Remove(node_cur);
			save_to_file();
		}
		
		void AddrootToolStripMenuItemClick(object sender, EventArgs e)
		{
			node_cur = null;
			edit_node(true);
		}
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			del_node();
		}
		void AddToolStripMenuItemClick(object sender, EventArgs e)
		{
			edit_node(true);
		}
		void EditToolStripMenuItemClick(object sender, EventArgs e)
		{
			edit_node();
		}
		
		void edit_node(bool new_node = false)
		{
			
			FormEditNode form_edit = new FormEditNode();
			if (node_cur != null) {
				form_edit.textBox1.Text = node_cur.Text;	
				form_edit.checkBox1.Checked = node_cur.Checked;
				if (node_cur.Tag!=null){
					Adv_data tag = (Adv_data) node_cur.Tag;
					form_edit.checkBox_important.Checked = tag.important;
					form_edit.textBox_itil_obrashenie.Text = tag.itil_obrashenie;
				}
			}
			form_edit.ShowDialog();
			if (!form_edit.ok) { 
				return;
			}
			
			if (new_node)
				add_node(form_edit.textBox1.Text);
			else {
				node_cur.Text = form_edit.textBox1.Text;
				node_cur.Checked = form_edit.checkBox1.Checked;
				if (node_cur.Tag == null) {
					node_cur.Tag = (Adv_data)new Adv_data();
				}
				Adv_data tag = (Adv_data)node_cur.Tag;
				tag.important = form_edit.checkBox_important.Checked;
				tag.itil_obrashenie = form_edit.textBox_itil_obrashenie.Text;
				node_cur.Tag = (Adv_data)tag;
				setNodeFont(node_cur);
			}
			
			save_to_file();
	
		}
		void TreeView1NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			node_cur = e.Node;
			edit_node();
		}

	}
	
	public class Adv_data
	{
		public bool important = false;
		public String itil_obrashenie;
	}
	
	public class Model
	{
		public class Node
		{
			public Node parent;
			public bool check = false;
			public String name = "";
			public List<Node> nodes = new List<Node>();
			public Adv_data tag;
		}

		public List<Node> nodes = new List<Node>();
		
		public Node add(Node parent, String name)
		{
			Node new_node = new Node();
			new_node.name = name;
			parent.nodes.Add(new_node);
			
			return new_node;		
		}
		public Node add(String name)
		{
			Node new_node = new Node();
			new_node.name = name;
			nodes.Add(new_node);
			return new_node;
		}
		
	}
	
	public static class MySerDeser
	{
		
		public static void ser<T>(T obj)
		{
			XmlSerializer mySerializer = new XmlSerializer(obj.GetType());
			StreamWriter myWriter = new StreamWriter("db.xml");
			mySerializer.Serialize(myWriter, obj);
			myWriter.Close();
		}
		
		public static T deser<T>()
		{
			XmlSerializer mySerializer = new XmlSerializer(typeof(T));
			FileStream myFileStream = new FileStream("db.xml", FileMode.Open);
			T t = (T)mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			
			return t;
		}
	}
}
