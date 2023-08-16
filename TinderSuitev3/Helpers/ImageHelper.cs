using System.IO;
using System.Net.Http;
using System.Windows.Media.Imaging;

namespace TinderSuitev3.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Download the image from the specified URL.
        /// </summary>
        /// <param name="url">The URL to the image</param>
        /// <param name="savePicture">Whether or not to save the image to the user's computer.</param>
        /// <returns></returns>
        public static async Task<byte[]> DownloadImage(string url, bool savePicture)
        {
            using var http = new HttpClient();
            var imageBytes = await http.GetByteArrayAsync(url);

            if (savePicture)
                await File.WriteAllBytesAsync(Path.Combine(Directories.BaseDir, $"{Guid.NewGuid()}.jpg"), imageBytes);

            return imageBytes;
        }

        /// <summary>
        /// Convert a byte array to a Bitmap image to display the image.
        /// </summary>
        /// <param name="bytes">The bytes of the image.</param>
        /// <returns></returns>
        public static BitmapImage BytesToBitmap(byte[] bytes)
        {
            var bitmap = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(bytes);
            bitmap.EndInit();
            return bitmap;
        }
    }
}
