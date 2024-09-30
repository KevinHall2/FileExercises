using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace FileExercises
{
    struct Contact
    {
        public string name;
        public string email;
        public int id;

        public Contact(string name, string email, int id)
        {
            this.name = name;
            this.email = email;
            this.id = id;
        }
        public void Print()
        {
            Console.WriteLine(name + " | " + email + " | " + id);
        }

        //writes values into a file
        public void Serialize(string path)
        {
            
            if (!File.Exists(path))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path);
                    writer.WriteLine(name);
                    writer.WriteLine(email);
                    writer.WriteLine(id);
                    writer.Close();

                    
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
        }

        //takes values out of a file and puts them into variables
        public void DeSerialize(string path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string str;
                    int incrementor = 1;
                    while ((str = reader.ReadLine()) != null)
                    {
                        // the if statements are to make sure the varaibles are assigned the right properties from the right lines of text from the files,
                        // same with the incrementor variable
                        if (incrementor == 1)
                        {
                            name = str;
                        }
                        if (incrementor == 2)
                        {
                            email = str;
                        }
                        if (incrementor == 3)
                        {
                            if (Int32.TryParse(str, out int num))
                            {
                              id = num;
                            }
                        }
                        incrementor++;
                       
                        
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }


    internal class SerializeIO
    {


        public void Run()
        {

           

            Contact bob = new Contact("Bob", "bob@email", 123);
            Contact fred = new Contact("Fred", "fred@email", 456);
            Contact jane = new Contact("Jane", "jane@email", 789);

            bob.Serialize(@"contacts\bob.txt");
            fred.Serialize(@"contacts\fred.txt");
            jane.Serialize(@"contacts\jane.txt");

            bob = new Contact();
            fred = new Contact();
            jane = new Contact();

            bob.DeSerialize(@"contacts\bob.txt");
            fred.DeSerialize(@"contacts\fred.txt");
            jane.DeSerialize(@"contacts\jane.txt");

            bob.Print();
            fred.Print();
            jane.Print();
           
        }
    }
}
