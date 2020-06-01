

namespace ConsoleApp2
{
    class Minificator
    {
        public static string Minify(string data)
        {
            return data.Replace("\n", "").Replace("\r", "").Replace("\t", " ");
        }
    }
}
