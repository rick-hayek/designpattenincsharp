using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattensInCSharp.SingletonPatten
{
    public class LazySingleton
    {
        /// <summary>
        /// Set the constructor as private, so it cannot be instantiated from outside the class
        /// </summary>
        private LazySingleton() { }

        // Uses lazy initialization to gain a performance optimization
        // The object will only be created when you actually need it
        // Set LazyThreadSafetyMode.ExecutionAndPublication for thread safety
        private static Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(
            () => new LazySingleton(),
            LazyThreadSafetyMode.ExecutionAndPublication);

        public static LazySingleton Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }

    public class Singleton
    {
        /// <summary>
        /// Set the constructor as private, so it cannot be instantiated from outside the class
        /// </summary>
        private Singleton() { }

        private static Singleton _instance = null;

        // Sync object for thead-safe
        private static readonly object sync = new object();

        public static Singleton Instance
        {
            get
            {
                lock (sync)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }

                    return _instance;
                }
            }
        }
    }

    public class LazySingletonImp2
    {
        /// <summary>
        /// Set the constructor as private, so it cannot be instantiated from outside the class
        /// </summary>
        private LazySingletonImp2() { }

        private static LazySingletonImp2 _instance = null;

        // Sync object for thead-safe
        private static readonly object sync = new object();

        public static LazySingletonImp2 GetInstance()
        {
            lock (sync)
            {
                if (_instance == null)
                {
                    _instance = new LazySingletonImp2();
                }

                return _instance;
            }
        }
    }

    public sealed class LazySingletonImp3
    {
        private LazySingletonImp3()
        {
        }

        // Here, instantiation is triggered by the first reference to the static member of the nested class, which only occurs in Instance.
        // This means the implementation is fully lazy.
        public static LazySingletonImp3 Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
                Console.WriteLine("static constructor for Nested is invoked.");
            }

            internal static readonly LazySingletonImp3 instance = new LazySingletonImp3();
        }
    }
}
