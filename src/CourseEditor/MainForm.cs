﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using uLearn;

namespace CourseEditor
{
	public partial class MainForm : Form
	{
		private EditorModel model = new EditorModel();
		private CourseEditorSettings settings = new CourseEditorSettings();

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			model.Changed += () => UpdateContent();
			LoadSettings();
		}

		private void LoadSettings()
		{
			try
			{
				if (!File.Exists("settings.xml"))
					return;
				using (var reader = new StreamReader("settings.xml"))
					settings = (CourseEditorSettings)new XmlSerializer(typeof(CourseEditorSettings)).Deserialize(reader);
				if (settings.LastCourseDirectory != null)
				{
					model.LoadFrom(new DirectoryInfo(settings.LastCourseDirectory));
					model.RegenerateCourse();
					TocTree.ExpandAll();
				}
			}
			catch (Exception exception)
			{
				LogError(exception.ToString());
			}
		}

		private void LogError(string message)
		{
			MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void UpdateContent()
		{
			Text = model.Course.Title + " from " + model.CourseDirectory;
			UpdateToc();
		}

		private void UpdateToc()
		{
			TocTree.BeginUpdate();
			try
			{
				TocTree.Nodes.Clear();
				var units = model.Course.Slides.ToLookup(s => s.Info.UnitName);
				foreach (IGrouping<string, Slide> unit in units)
				{
					var unitNode = TocTree.Nodes.Add(unit.Key);
					foreach (var slide in unit)
						unitNode.Nodes.Add(slide.Title).Tag = slide;
				}
				TocTree.SelectedNode = TocTree.Nodes[0];
			}
			finally
			{
				TocTree.EndUpdate();
			}
		}

		private void openCourseDirecotryToolStripMenuItem_Click(object sender, EventArgs ev)
		{
			var dialog = new OpenFileDialog();
			dialog.DefaultExt = "xml";
			var dialogResult = dialog.ShowDialog();
			if (dialogResult == DialogResult.OK)
			{
				try
				{
					model.LoadFrom(dialog.FileName);
					model.RegenerateCourse();
					SaveSettings();
				}
				catch (Exception e)
				{
					MessageBox.Show(this, e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void SaveSettings()
		{
			settings.LastCourseDirectory = model.CourseDirectory.FullName;
			using (var w = new StreamWriter("settings.xml"))
				new XmlSerializer(typeof(CourseEditorSettings)).Serialize(w, settings);
		}

		private void TocTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var slide = e.Node.Tag as Slide;
			if (slide != null)
				UpdateWebBrowser(slide);
		}

		private void UpdateWebBrowser(Slide slide)
		{
			Process.Start(model.GetSlideHtmlFile(slide.Index).FullName);
		}
	}
}