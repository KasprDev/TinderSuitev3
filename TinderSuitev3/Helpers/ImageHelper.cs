using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TinderSuitev3.Helpers
{
    public static class ImageHelper
    {
        public static async Task<byte[]> DownloadImage(string url, bool savePicture)
        {
            using var http = new HttpClient();
            var imageBytes = await http.GetByteArrayAsync(url);

            await File.WriteAllBytesAsync(Path.Combine(Directories.BaseDir, $"{Guid.NewGuid()}.jpg"), imageBytes);

            return imageBytes;
        }

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
