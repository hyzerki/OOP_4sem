using System.IO;
using System.Windows.Media.Imaging;

namespace YukariDesktop.Utility
{
    internal static class BitmapImageHelper
    {
        public static BitmapImage CreateFromBytes(byte[] screen)
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = new MemoryStream(screen);
            bitmapImage.EndInit();
            return bitmapImage;
        }
    }
}
