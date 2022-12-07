using Easter.IO.Contracts;
using System.IO;

namespace Easter.IO
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
