using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockNotas
{

    public partial class Form1 : Form
    {
        //Instancia de objetos y variables a utiliza
        string directoryOpen, fileNameOpen;
        string open;
        SaveFileDialog saveFile = new SaveFileDialog();
        OpenFileDialog openFile = new OpenFileDialog();
        FileInfo file;

        public Form1()
        {
            InitializeComponent();
           

        }
        private void LoadFolder(TreeNodeCollection nodes, DirectoryInfo folder)
        {
            var newNode = nodes.Add(folder.Name);
            foreach (var childFolder in folder.EnumerateDirectories())
            {
                LoadFolder(newNode.Nodes, childFolder);
            }
            foreach (FileInfo file in folder.EnumerateFiles())
            {
                newNode.Nodes.Add(file.Name);
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Accion guardar como
            saveFile.Filter = "Archivo de Texto .txt|*.txt";
            saveFile.Title = "Guardar Texto";
            saveFile.ShowDialog();

            file = new FileInfo(saveFile.FileName);

 
            if (file.Name == string.Empty)
            {
                MessageBox.Show("Debe de agregar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (StreamWriter write = new StreamWriter(file.DirectoryName+file.Name))
                    {
                        write.Write(textBoxBody.Text);
                      
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("No se guardó el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }

            }
            //Añadir los direcctorios al treeView
            treeView1.BeginUpdate();
            treeView1.Nodes.Add(file.DirectoryName + file.Name);
            treeView1.EndUpdate();

        }

        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CortarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (textBoxBody.SelectedText != "")

                textBoxBody.Cut();
        }

        private void PegarStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBoxBody.Paste();
        }

        private void CopiarToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (textBoxBody.SelectionLength > 0)

                textBoxBody.Copy();
        }

        private void TreeView1_DoubleClick(object sender, EventArgs e)
        {
            
            if(treeView1 != null)
            {
                open = treeView1.SelectedNode.Text;
            }

            using (StreamReader sr = new StreamReader(open))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    textBoxBody.Text = line;
                }
                sr.Close();
            }
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Accion abrir

            try
            {
                openFile.ShowDialog();
                directoryOpen = openFile.InitialDirectory;
                fileNameOpen = openFile.FileName;

                using (StreamReader sr = new StreamReader(openFile.InitialDirectory + openFile.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        textBoxBody.Text = line;
                    }
                    sr.Close();
                }
                
            }

            catch (IOException )
            {

                MessageBox.Show("Error While Opening the File "+ directoryOpen + fileNameOpen,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
;
            }

        }

        private void estiloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Accion cambiar fuente
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            var font = fontDialog.Font;
            var size = font.Size;
            var style = font.Style;
            FontFamily fontFamily = font.FontFamily;

            textBoxBody.Font = new Font(fontFamily, size, style);


        }
    }
}
