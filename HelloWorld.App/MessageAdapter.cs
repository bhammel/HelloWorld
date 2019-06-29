namespace HelloWorld.App
{
    public abstract class MessageAdapter
    {
        public static MessageAdapter GetAdapter(string mode)
        {
            switch (mode.Trim().ToLower())
            {
                case "console":
                    return new ConsoleMessageAdapter();
                case "database":
                    return new DatabaseMessageAdapter();
                default:
                    return new ConsoleMessageAdapter();
            }
        }

        public abstract void Write(string value);
    }
}
