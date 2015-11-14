using System;
using System.IO;
using System.Text;

namespace LineCount
{
    class Program
    {
        /// <summary>
        /// 引数に指定されたファイルを読み取り専用で開き行数を標準出力します。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.Error.WriteLine("ファイル名を指定してください");
            }
            else
            {
                string fileName = args[0];
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                FileInfo fi = new FileInfo(fileName);
                if (!fi.Exists)
                {
                    fileName = Path.Combine(path, fileName);
                    fi = new FileInfo(fileName);
                }

                if (!fi.Exists)
                {
                    Console.Error.WriteLine("指定されたファイルは存在しません");
                }
                else
                {
                    using (FileStream fs = new FileStream(args[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(932)))
                    {
                        int count = 0;
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            count++;
                        }
                        Console.WriteLine(count.ToString());
                    }
                }
            }
        }
    }
}
