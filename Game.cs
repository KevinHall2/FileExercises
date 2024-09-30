using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileExercises
{
    internal class Game
    {
        public void Run()
        {
            

            SerializeIO serialize = new SerializeIO();
            serialize.Run();
        }
    }
}
