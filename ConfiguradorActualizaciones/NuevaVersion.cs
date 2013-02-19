using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using MundiAudit.ActualizadorApp.Definiciones;
using MundiAudit.ActualizadorApp.Definiciones.Helpers;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;

namespace MundiAudit.ConfiguradorActualizaciones
{
	public partial class NuevaVersion : Form
	{
		private string rutaRepositorio = string.Empty;
		private string versionActual;
		private MultiValueDictionary<string, string> forbiddenFiles;
		public NuevaVersion()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			//Cargamos los valores de configuración


			try
			{
				rutaRepositorio = ConfigurationSettings.AppSettings["RutaRepositorio"];
				if (!rutaRepositorio.EndsWith("\\"))
					rutaRepositorio += "\\";

				tbRepositorio.Text = rutaRepositorio;
			}
			catch
			{
				MessageBox.Show("Se ha producido un error leyendo el fichero de configuración, revise los parámetros");
			}

			if (!Directory.Exists(rutaRepositorio))
			{
				MessageBox.Show("No se ha encontrado la ruta del repositorio");
				Close();
			}

			//mostramos la lista de aplicaciones en el repositorio
			CargarListaAplicaciones();

		}

		private void cbAplicacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			PrepararVersion();
			tbSql.Text = string.Empty;
			tbRutaBinarios.Text = string.Empty;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}


		private void CargarListaAplicaciones()
		{
			var dirs = Directory.GetDirectories(rutaRepositorio);
			foreach (string dir in dirs)
				cbAplicacion.Items.Add(dir.Replace(rutaRepositorio, string.Empty));

		}

		private void PrepararVersion()
		{
			int ver = 0;
			//Ver última revisión
			var dirs = Directory.GetDirectories(string.Format("{0}\\{1}", rutaRepositorio, cbAplicacion.Text));
			if (dirs.Length > 0)
			{
				int maxV = dirs.Max((x) => Convert.ToInt32(Path.GetFileNameWithoutExtension(x)));
				ver = maxV + 1;
			}

			//Ver la última versión generada.
			versionActual = ver.ToString().PadLeft(10, '0');
			lbinfo.Text = "Nueva versión: " + versionActual;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(tbRutaBinarios.Text) && Directory.Exists(tbRutaBinarios.Text))
				folderDialog.SelectedPath = tbRutaBinarios.Text;

			if (folderDialog.ShowDialog() == DialogResult.OK)
				tbRutaBinarios.Text = folderDialog.SelectedPath;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				tbSql.Text = openFileDialog.FileName;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			//Comprobación ..
			if (!ComprobarConfig())
				return;
			try
			{
				CargarArchivosProhibidos();
				GeneradorVersion.GenerarVersion(tbRepositorio.Text, cbAplicacion.Text, versionActual, tbRutaBinarios.Text, tbSql.Text, tbComentarios.Text, tbVersionBBDDActual.Text, tbVersionBBDD.Text, forbiddenFiles);
				MessageBox.Show("Versión generada");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al generar:\n" + ex.Message);
				Close();
			}
		}

		private void CargarArchivosProhibidos()
		{
			if (!File.Exists("Excluded.txt")) return;
			var str = new StreamReader("Excluded.txt");
			string line = null;
			while (!string.IsNullOrEmpty(line = str.ReadLine()))
			{
				if (forbiddenFiles == null) forbiddenFiles = new MultiValueDictionary<string, string>();
				forbiddenFiles.Add(Path.GetFileNameWithoutExtension(line), Path.GetExtension(line));
			}
		}

		private bool ComprobarConfig()
		{
			string error = string.Empty;

			if (!Directory.Exists(string.Format("{0}\\{1}", rutaRepositorio, cbAplicacion.Text)))
				error += "No se encontró la ruta de la aplicación dentro del repositorio\n";

			if (Directory.Exists(string.Format("{0}\\{1}\\{2}", rutaRepositorio, cbAplicacion.Text, versionActual)))
				error += "La versión que está intentando crear parece existir en el repositorio\n";

			if (!string.IsNullOrEmpty(error))
				MessageBox.Show(error);

			return string.IsNullOrEmpty(error);
		}



		// Sign an XML file. 
		// This document cannot be verified unless the verifying 
		// code has the key with which it was signed.
		public static void SignXml(XmlDocument xmlDoc, RSA Key)
		{
			// Check arguments.
			if (xmlDoc == null)
				throw new ArgumentException("xmlDoc");
			if (Key == null)
				throw new ArgumentException("Key");

			// Create a SignedXml object.
			SignedXml signedXml = new SignedXml(xmlDoc);

			// Add the key to the SignedXml document.
			signedXml.SigningKey = Key;

			// Create a reference to be signed.
			Reference reference = new Reference();
			reference.Uri = string.Empty;

			// Add an enveloped transformation to the reference.
			XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
			reference.AddTransform(env);

			// Add the reference to the SignedXml object.
			signedXml.AddReference(reference);

			// Compute the signature.
			signedXml.ComputeSignature();

			// Get the XML representation of the signature and save
			// it to an XmlElement object.
			XmlElement xmlDigitalSignature = signedXml.GetXml();

			// Append the element to the XML document.
			xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));

		}
	}
}
