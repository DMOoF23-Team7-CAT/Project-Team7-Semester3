using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Rally.Utility
{
    public class ImageConverter
    {
    public byte[] ImageToByteArray(Image image)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            image.Save(memoryStream, ImageFormat.Png);
            return memoryStream.ToArray();
        }
    }

    public Image ByteArrayToImage(byte[] byteArrayIn)
    {
        using (MemoryStream memoryStream = new MemoryStream(byteArrayIn))
        {
            Image image = Image.FromStream(memoryStream);
            return image;
        }
    }
    }
}