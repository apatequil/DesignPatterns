using System.Threading;

namespace PrototypePattern.Prototypes
{
    public class MyObject : IPrototype
    {
        public string Name { get; set; }

        public MyObject(string name, int sleepTime = 2000)
        {
            Name = name;

            // Artificially extend creation time
            Thread.Sleep(sleepTime);
        }

        public IPrototype Clone()
        {
            // Really basic clone for demonstration purposes. Deep
            // cloning would be fine here as well
            return (MyObject)MemberwiseClone();
        }
    }
}
