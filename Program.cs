using System;
using System.IO;
internal class Program
{
    private static void Main(string[] args)
    {
        string str;

        Console.WriteLine("Ingrese el path de la carpeta: ");
        str = Console.ReadLine();

        try
        {
            var files = Directory.GetFiles(str);

            foreach (string archivo in files)
            {
                Console.WriteLine(archivo);
            }
                using(StreamWriter indexador = new StreamWriter("index.csv"))
                {
                    indexador.WriteLine("Indice;Nombre;Extension");
                    for(int i=0; i<files.Length; i++)
                    {
                        indexador.WriteLine($"{i};{Path.GetFileNameWithoutExtension(files[i])};{Path.GetExtension(files[i])}");
                    }
                    
                    indexador.Close();
                }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}