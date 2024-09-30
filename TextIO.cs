using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace FileExercises
{
    internal class TextIO
    {
        public void Run()
        {

            string path = @"test.txt";

            //writes the file
            if (!File.Exists(path))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    writer.WriteLine("Hello");
                    writer.WriteLine("And");
                    writer.WriteLine("Welcome");
                    writer.Close();

                    //disposing of the object since a stream is being used
                    try
                    {
                        writer.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            //reads the file
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string str;
                    while ((str = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
