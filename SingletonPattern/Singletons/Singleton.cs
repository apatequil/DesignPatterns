
using System;

namespace SingletonPattern.Singletons
{
    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _singletonLock = new object();

        private static int _creationCount = 0;
        public static int CreationCount
        {
            get
            {
                return _creationCount;
            }
            set
            {
                if (_creationCount != value)
                {
                    _creationCount = value;
                }
            }

        }

        private static int _requestedCount = 0;
        public static int RequestedCount
        {
            get
            {
                return _requestedCount;
            }
            set
            {
                if (_requestedCount != value)
                {
                    _requestedCount = value;
                }
            }

        }

        public static Singleton Instance
        {
            get
            {
                // Without locking it would be possible for two theads to hit the conditional below
                // and both instantiate the singleton resulting in...not a singleton.
                lock (_singletonLock)
                {
                    RequestedCount++;

                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }

                    return _instance;
                }
            }
        }

        // Note the private constructor. We need to control construction of the object
        // so we can ensure only one instance is ever created. This could also be declared
        // as protected if we will need to subclass it in the future.
        private Singleton()
        {
            CreationCount++;
        }

        public void PrintSummary()
        {
            Console.WriteLine($"Runtime Statistics:");
            Console.WriteLine($"\t   created: { _creationCount } instances");
            Console.WriteLine($"\t requested: { _requestedCount } instances");
        }
    }
}
