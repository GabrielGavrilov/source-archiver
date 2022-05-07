using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Archiver
{
    public async Task saveSourceToLocation(string fileLocation, string source)
    {
        Console.WriteLine("Archiving source...");

        FileStream fs = new FileStream(fileLocation, FileMode.Append, FileAccess.Write);
        StreamWriter w = new StreamWriter(fs);
        w.WriteLine(source);
        w.Close();
        fs.Close();

        Console.WriteLine("Archiving finished...");
    }
}

