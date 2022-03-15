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
        string directory, fileName;
        string directoryOpen, fileNameOpen;
        public Form1()
        {
            InitializeComponent();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Accion guardar como
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivo de Texto .txt|*.txt";
            saveFile.Title = "Guardar Texto";
            saveFile.ShowDialog();
            fileName = saveFile.FileName;
            directory = saveFile.InitialDirectory;
            if (fileName == string.Empty)
            {
                MessageBox.Show("Debe de agregar un nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (StreamWriter write = new StreamWriter(directory + fileName))
                    {
                        write.Write(textBoxBody.Text);
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("Guardado con exito");
                    throw;
                }

            }

        }

        private void SaveFile_FileOk(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pegarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Accion pegar en el block
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Accion cortar en el documento
        }

        private void copiarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Accion copiar en el documento
        }

        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog();
            
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

            catch (IOException x)
            {

                MessageBox.Show("Error While Opening the File "+ directoryOpen + fileNameOpen,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error );
                Console.WriteLine(x.Message);
            }

        }

        private void estiloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
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
