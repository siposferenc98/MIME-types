using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


// HashSet && Dictionary használata.

class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.

        HashSet<string[]> fileok = new HashSet<string[]>();
        Dictionary<string, string> mime = new Dictionary<string, string>();

        for (int i = 0; i < N; i++)
        {
            int maxSizeExt = 10; // Hossz korlátozások
            int maxMimeSize = 50;
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0].ToLower(); // file extension
            if (EXT.Length > maxSizeExt)
                EXT = EXT.Substring(0, maxSizeExt);
            string MT = inputs[1]; // MIME type.
            if (MT.Length > maxMimeSize)
                MT = MT.Substring(0, maxMimeSize);
            mime.Add(EXT, MT);

        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine().ToLower(); // One file name per line.
            int maxSize = 256; // Korlátozás
            if (FNAME.Length > maxSize)
            {
                FNAME = FNAME.Substring(0, maxSize);
            }
            if (FNAME.Contains('.')) // Ha van kiterjesztése
            {
                string[] darab = FNAME.Split('.');
                fileok.Add(darab);
            }
            else
            {
                string[] nemfile = new string[] { "" };
                fileok.Add(nemfile);
            }

        }

        /*foreach (var c in mime)   // Test
        {
            Console.Error.WriteLine("MIME=" + c.Key);
        }*/



        foreach (string[] a in fileok)
        {

            try
            {
                Console.WriteLine(mime[a.Last()]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("UNKNOWN");
            }

        }




        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");


        // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.

    }
}