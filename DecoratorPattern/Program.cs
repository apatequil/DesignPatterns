using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Console.ReadLine();
            Console.WriteLine("\nLet's start with a basic cookie\n");

            // Create a basic cookie
            Cookie baseCookie = new Cookie();
            PrintCookieInformation(baseCookie);

            Console.ReadLine();
            Console.WriteLine("\nThat cookie needs something sweet. Smother it with sugar!\n");

            // Add sugar to it!
            SugarDecorator sugarCookie = new SugarDecorator(baseCookie);
            PrintCookieInformation(sugarCookie);

            Console.ReadLine();
            Console.WriteLine("\nOh look, another cookie!\n");

            // Create a second cookie. This will be covered only in bacon
            Cookie baseCookie2 = new Cookie();
            PrintCookieInformation(baseCookie2);

            Console.ReadLine();
            Console.WriteLine("\n Now ruin it with some oatmeal...\n");

            // Let now add oatmeal on it
            OatmealDecorator oatmealCookie = new OatmealDecorator(baseCookie2);
            PrintCookieInformation(oatmealCookie);

            Console.ReadLine();
            Console.WriteLine("We can also add decorators at any point. Let's add some bacon to that first sugar-covered cookie:\n");

            // Mmm...bacon
            BaconDecorator baconCookie = new BaconDecorator(sugarCookie);
            PrintCookieInformation(baconCookie);

            Console.ReadLine();
        }

        public static void PrintCookieInformation(CookieComponent cookie)
        {
            Console.WriteLine($"{cookie.GetName()}");
            Console.WriteLine($"Delicious Level: {cookie.GetDeliciousness()}");
        }
        #endregion

        public abstract class CookieComponent
        {
            public abstract string GetName();
            public abstract int GetDeliciousness();
        }

        public class Cookie : CookieComponent
        {
            private string _name = "Cookie";
            private int _deliciousIndex = 0;
            public override string GetName()
            {
                return _name;
            }

            public override int GetDeliciousness()
            {
                return _deliciousIndex;
            }
        }

        public abstract class CookieDecorator : CookieComponent
        {
            private CookieComponent _baseComponent = null;

            protected string Name = "Abstract Decorator";
            protected int DeliciousIndex = 0;

            protected CookieDecorator(CookieComponent baseComponent)
            {
                _baseComponent = baseComponent;
            }

            #region CookieComponent
            public override string GetName()
            {
                return $"{_baseComponent.GetName()}, {Name}";
            }

            public override int GetDeliciousness()
            {
                return _baseComponent.GetDeliciousness() + DeliciousIndex;
            }
            #endregion
        }

        public class SugarDecorator : CookieDecorator
        {
            public SugarDecorator(CookieComponent baseComponent)
                : base(baseComponent)
            {
                this.Name = "Sugar";
                this.DeliciousIndex = 10;
            }
        }

        public class OatmealDecorator : CookieDecorator
        {
            public OatmealDecorator(CookieComponent baseComponent)
                : base(baseComponent)
            {
                this.Name = "Oatmeal";
                this.DeliciousIndex = -9999;
            }
        }

        public class BaconDecorator : CookieDecorator
        {
            public BaconDecorator(CookieComponent baseComponent)
                : base(baseComponent)
            {
                this.Name = "Bacon";
                this.DeliciousIndex = 9999;
            }
        }
    }
}
