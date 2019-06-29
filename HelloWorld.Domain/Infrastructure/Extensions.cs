using System;
using System.Text;

namespace HelloWorld.Domain.Infrastructure
{
    public static class Extensions
    {
        public static string GetFullMessage(this Exception exception)
        {
            if (exception == null)
            {
                return null;
            }

            var result = new StringBuilder(exception.Message);
            for (var current = exception.InnerException; current != null; current = current.InnerException)
            {
                result.Append($"{Environment.NewLine}{current.Message}");
            }

            return result.ToString();
        }
    }
}
