using System.Text;

namespace ConvertImageBase64
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string path = string.Join(" ", args);
            if (args.Length > 0 && !string.IsNullOrEmpty(path) && File.Exists(path))
            {
                var txt = ConvertImage.ToBase64String(path);
                Clipboard.SetText(txt);
                var lbl = new Label()
                {
                    Text = string.IsNullOrEmpty(txt) ? "格式錯誤" : "轉換成功",
                    AutoSize = true,
                    Font = new Font("微軟正黑體", 14, FontStyle.Bold),
                    ForeColor = Color.Black,
                    BackColor = Color.LightCyan,
                    Location = new Point(0, 0)
                };
                var f = new Form()
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.CenterScreen,
                    TopMost = true,
                    ControlBox = false,
                    ShowInTaskbar = false,
                    Opacity = .8
                };
                f.Controls.Add(lbl);
                f.Show();
                f.Width = lbl.Width;
                f.Height = lbl.Height;
                f.Refresh();
                Thread.Sleep(2000);
                f.Close();
                return;
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}