namespace ConvertImageBase64
{
    public static class ConvertImage
    {
        public static string ToBase64String(string file)
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
