using HeyRed.Mime;

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
                    byte[] b = File.ReadAllBytes(file);
                    rt = $"data:{MimeTypesMap.GetMimeType(Path.GetExtension(file))};base64,{Convert.ToBase64String(b)}";
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
