using System;
using System.IO;
using System.Net;

namespace DescargarDeHtmlUrl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce una URL para descargar la imagen:");

            string url = Console.ReadLine();

            HtmlConverter converter = new HtmlConverter();

            var bytes = converter.FromUrl(url);

            if (bytes != null)
            {
                File.WriteAllBytes("image.jpg", bytes);
                Console.WriteLine("Imagen descargada y guardada como 'image.jpg'");
            }
            else
            {
                Console.WriteLine("No se pudo descargar la imagen.");
            }

        }
    }

    public class HtmlConverter
    {
        public byte[] FromUrl(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    // Descarga los bytes de la imagen desde la URL.
                    byte[] bytes = webClient.DownloadData(url);
                    return bytes;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al descargar la imagen: " + ex.Message);
                return null;
            }
        }
    }
}
