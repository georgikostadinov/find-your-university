namespace FindYourUniversity.Common.Extensions
{
    using System;
    using System.IO;

    public static class StringExtensions
    {
        public static bool IsImage(this string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);

            var stream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            try
            {
                stream.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
