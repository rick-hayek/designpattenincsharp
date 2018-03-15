using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattensInCSharp.SingletonPatten;

namespace DesignPattensInCSharp.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Starting ...");

            var inst1 = Singleton.Instance;
            var inst2 = Singleton.Instance;

            Console.WriteLine("(inst1 == inst2) = {0}", inst1 == inst2);

            var lazyInst1 = LazySingleton.Instance;
            var lazyInst2 = LazySingleton.Instance;

            Console.WriteLine("(lazyInst1 == lazyInst2) = {0}", lazyInst1 == lazyInst2);

            Console.ReadLine();
        }
    }

  }
