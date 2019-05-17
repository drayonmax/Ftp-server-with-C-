using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ftp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        private void cmdSuirArchivo_Click(object sender, EventArgs e)
        {
            //creando el request
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://files.000webhost.com/public_html/" + "/" + Path.GetFileName("C:\\Users\\Eduardo\\Desktop\\a20144175.txt"));
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("test1pweb", "computadora321");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = false;
            //esto es para cargar el archivo en un array
            FileStream stream = File.OpenRead("C:\\Users\\Eduardo\\Desktop\\a20144175.txt");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            stream.Close();
            //subir archivo
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(buffer, 0, buffer.Length);
            reqStream.Close();

        }
    }
}

