using System;
using System.Collections.Generic;
using System.Text;

namespace PayXpertLibrary
{
    class Utils
    {
        public static bool DEBUG = true;

        public static string Combine(string uri1, string uri2)
        {
            uri1 = uri1.TrimEnd('/');
            uri2 = uri2.TrimStart('/');
            return string.Format("{0}/{1}", uri1, uri2);
        }
    }

    public class PayXpertException : Exception
    {
        public PayXpertException(string message) : base(message)
        {
        }
    }
}
