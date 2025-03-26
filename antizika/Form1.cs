using System.Security.Cryptography;

namespace antizika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //abir windows explorer (file dialog)
            using(OpenFileDialog dialogoAbirArquivo=new OpenFileDialog())
            {
                dialogoAbirArquivo.Filter = "Todos os Arquivos(*.*)|*.*";
                if (dialogoAbirArquivo.ShowDialog() == DialogResult.OK)
                {
                    //armazena o caminho do arquivo
                    string caminhoArquivo = dialogoAbirArquivo.FileName;

                    //calcaular a hash
                    string hashSHA256 =CalculaHashSHA256(caminhoArquivo);
                    Clipboard.SetText(hashSHA256);
                    MessageBox.Show("Hash Colado na area de transferencia");


                    
        }   }   } 
         
        //calcular hash SHA256
        private string CalculaHashSHA256(string caminhoArquivo)
        {
            using (FileStream fs = File.OpenRead(caminhoArquivo))
            using (SHA256 sHA256 = SHA256.Create())
            {
                //computa o hash do arquivo e converte os bytes para string
                byte[] hashBytes = sHA256.ComputeHash(fs);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }


        }
}   }
