using System.Text;

namespace ConvertImageBase64
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.AllowDrop = true;
            textBox1.DragEnter += (sender, e) =>
            {
                e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
            };
            textBox1.DragDrop += (sender, e) =>
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                StringBuilder sb = new();
                foreach (string file in filePaths) sb.Append(ToBase64String(file) + Environment.NewLine + Environment.NewLine);
                textBox1.Text = sb.ToString();
            };
        }
        private string ToBase64String(string file)
        {
            string rt = string.Empty;

            try
            {
                if (File.Exists(file))
                {
                    Bitmap bmp = new(file);
                    MemoryStream ms = new();
                    bmp.Save(ms, bmp.RawFormat);
                    byte[] b = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(b, 0, (int)ms.Length);
                    ms.Close();
                    rt = Convert.ToBase64String(b);
                }
            }
            catch (Exception ex)
            {
                rt = ex.Message;
            }

            return rt;
        }
    }
}