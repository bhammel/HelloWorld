using System;

namespace HelloWorld.App
{
    public class ConsoleMessageAdapter : MessageAdapter
    {
        public override void Write(string value)
        {
            Console.WriteLine(value);
        }
    }
}
