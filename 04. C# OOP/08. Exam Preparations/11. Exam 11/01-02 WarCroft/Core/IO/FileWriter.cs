using System.IO;
using WarCroft.Core.IO.Contracts;

namespace WarCroft.Core.IO
{
    public class FileWriter : IWriter
    {
        public FileWriter()
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt", false))
            {
                writer.Write("");
            }
        }

        public void Write(string message)
        {
            using (StreamWriter write = new StreamWriter("../../../output.txt", true))
            {
                write.Write(message);
            }
        }

        public void WriteLine(string message)
        {
            using (StreamWriter write = new StreamWriter("../../../output.txt", true))
            {
                write.WriteLine(message);
            }
        }
    }
}
