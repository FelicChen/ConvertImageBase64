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
                foreach (string file in filePaths) sb.Append(ConvertImage.ToBase64String(file) + Environment.NewLine + Environment.NewLine);
                textBox1.Text = sb.ToString();
            };
        }
    }
}