using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drink_info
{
    public class FileReader
    {
        public void Write(string nameInput,string path)
        {
            if(!File.Exists(path))
            {
                using(StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(nameInput);
                }
            }
            using(StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(nameInput);
            }
        }
        public void Popular(string path)
        {
            if(File.Exists(path))
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    Dictionary<string, int> nameDic = new Dictionary<string, int>();
                    string s ="";
                    while((s=sr.ReadLine())!=null)
                    {
                        if(!nameDic.ContainsKey(s))
                        {
                            nameDic.Add(s,1);
                        }
                        else
                        {
                            nameDic[s]+=1;
                        }
                    }
                    string favOne;
                    favOne = nameDic.OrderByDescending(x=>x.Value).First().Key;
                    System.Console.WriteLine("Favorite Choice is: " + favOne);
                }
            }
            else
            {
                System.Console.WriteLine("No purchase history");
            }
        }

    }
}