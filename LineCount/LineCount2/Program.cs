using System;
using System.IO;
using System.Text;

namespace LineCount2
{
    class Program
    {
        /// <summary>
        /// 引数に指定されたファイルを読み取り専用で開き行数を標準出力します。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader sr = new StreamReader(args[0], Encoding.GetEncoding(932)))
                {
                    int count = 0;
                    while (!sr.EndOfStream)
                    {
                        sr.ReadLine();
                        count++;
                    }
                    Console.WriteLine(count.ToString());
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
