using System;
using System.IO;

namespace ImageProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] imageFiles = Directory.GetFiles(@"C:\Images\", "*.jpg");

            Func<Bitmap, Bitmap> imageProcessingDelegate = new Func<Bitmap, Bitmap>(ProcessImage);

            Action<Bitmap> displayDelegate = new Action<Bitmap>(DisplayImage);

            foreach (string imageFile in imageFiles)
            {
                Bitmap originalImage = new Bitmap(imageFile);
                Bitmap processedImage = imageProcessingDelegate(originalImage);
                displayDelegate(processedImage);
            }
        }

        static Bitmap ProcessImage(Bitmap image)
        {
            return image;
        }

        static void DisplayImage(Bitmap image)
        {
            image.Dispose();
        }
    }

    internal class Bitmap
    {
        private string imageFile;

        public Bitmap(string imageFile)
        {
            this.imageFile = imageFile;
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
