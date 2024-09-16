
namespace MinimalAPI
{
    public class HelloMethods
    {
        public static string HelloWorld() => "Hello world";

        internal static object HelloWorld(string name)
        {
            return $"hello {name}";
        }
    }
}
