using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace EmbedStringInImage
{
    class Program
    {
        
        static string message = "merhaba";
        static int[] harfler = new int[message.Length];
        static void Main(string[] args)
        {
            
            // resim dosyasini acma
            FileStream file = new FileStream(@"C:\Users\vdrn7\Desktop\3.2 güncel dönem\Algoritmalar\0.jpg", FileMode.Open);
            Bitmap image1 = new Bitmap(file);
            int image1_Width = image1.Width;
            int image1_Height = image1.Height;
            // değişiklik yapılmış resmi kaydetme 
            Bitmap image2 = new Bitmap(image1_Width, image1_Height);
            int c = 1;
            int R, G, B;
            Color ReadPixel, WritePixel;
            for (int i = 0; i < message.Length; i++)
                harfler[i] = Convert.ToInt32(message[i]);
            int bitCount = -1;
            for (int i = 0; i < image1_Width; i++)
            {
                for (int j = 0; j < image1_Height; j++)
                {
                    ReadPixel = image1.GetPixel(i, j);
                    R = ReadPixel.R; G = ReadPixel.G; B = ReadPixel.B;                 
                    if (bitCount == -1) { R = message.Length*8; bitCount++; }           
                    if ((bitCount >= 0) && (bitCount < 7))                             
                    {
                        int harf = harfler[bitCount];
                        if ((harf & 0x80) == 1) { R = (R | 0x1); harf = harf >> 1;c++;  }
                        else { R = (R & 0xfe); harf = harf >> 1; c++;  }
                        if(c==8) { c = 0; bitCount++; }
                    }
                    WritePixel = Color.FromArgb(R, G, B);
                    image2.SetPixel(i, j, WritePixel);
                }
            }

           
            image2.Save(@"\gizlenenResim.jpg");
            file.Close();
            image1.Dispose();
            image2.Dispose();
            Console.WriteLine("islem tamamlandi");
            Console.ReadLine();

            //  okuma
    
            FileStream file2 = new FileStream(@"\gizlenenResim.jpg", FileMode.Open);
            Bitmap image = new Bitmap(file2);
            int image_Width = image.Width;
            int image_Height = image.Height;
            string okunan = "";
            Bitmap _image2 = new Bitmap(image_Width, image_Height);
            int _R = 0,_G = 0,_B = 0;

            Color _ReadPixel = image.GetPixel(0, 0), _WritePixel; 
            int dongu = _ReadPixel.R;
            int bitis = 0;
            for (int i = 0; i < image_Width; i++)
            {
                for (int j = 0; j < image_Height; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        _ReadPixel = image.GetPixel(i, j);
                        _R = _ReadPixel.R; _G = _ReadPixel.G; _B = _ReadPixel.B;
                        
                        if (dongu!=bitis)
                        {
                            if ((_R & 0x1) == 1) okunan = okunan + "1";
                            else okunan = okunan + "0";
                            bitis++;
                        }
                        WritePixel = Color.FromArgb(_R, _G, _B);
                        image.SetPixel(i, j, WritePixel);
                    }
                    
                }
            }

            image2.Save(@"\enSonResim.jpg");
            file2.Close();
            image.Dispose();
            Console.WriteLine("islem tamamlandi");
            Console.WriteLine(okunan);
            Console.WriteLine(okunan.Length);
            Console.ReadLine();
            
        }
    }
}
