using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteClientB();
            Console.ReadKey();
        }

        public static void ExecuteClientA()
        {
            var oreoDatabaseManagementSystem = new OreoDatabaseManagementSystem();

            oreoDatabaseManagementSystem.InsertRowLikeItsSucculentCreamFilling(5);

            oreoDatabaseManagementSystem.AlterRowWithUpdatedInformation(5);

            oreoDatabaseManagementSystem.DestroyRow(10);
        }

        public class OreoDatabaseManagementSystem
        {
            public void InsertRowLikeItsSucculentCreamFilling(int oreod)
            {
                Console.WriteLine($"Inserting delicious cream filling with id {oreod}");
            }

            public void AlterRowWithUpdatedInformation(int oreod)
            {
                Console.WriteLine($"Altering row with id {oreod}");
            }

            public void PrepareRowForDestruction(int oreod)
            {
                Console.WriteLine($"Preparing row with id {oreod} for destruction");
            }

            public void DestroyRow(int oreod)
            {
                Console.WriteLine($"Destroying row with id {oreod}");
            }
        }

        public class ChipsAhoyDatabaseManagementSystem
        {
            public void InsertAhoy(int ahoyid)
            {
                Console.WriteLine($"Insert Ahoy! Id: {ahoyid}");
            }

            public void PrepareAlterAhoy(int ahoyid)
            {
                Console.WriteLine($"Prepare Alter Ahoy! Id: {ahoyid}");
            }

            public void AlterAhoy(int ahoyid)
            {
                Console.WriteLine($"Alter Ahoy! Id: {ahoyid}");
            }

            public void RemoveAhoy(int ahoyid)
            {
                Console.WriteLine($"Remove Ahoy! Id: {ahoyid}");
            }
        }

        public class GirlScoutsOfAmericaDatabaseManagementSystem
        {
            public void PrepareToInsertRecord(int id)
            {
                Console.WriteLine($"Preparing to insert record with id {id}");
            }

            public void ThinMinsert(int id)
            {
                Console.WriteLine($"Thinminserting record with id {id}");
            }

            public void PeanupdateButterPatties(int id)
            {
                Console.WriteLine($"Peanupdatebutter Pattying record with id {id}");
            }

            public void CaramelDelete(int id)
            {
                Console.WriteLine($"CaramelDeLeting record with id {id}");
            }
        }

        public interface IDatabaseAdapter
        {
            void InsertRecord(int id);
            void UpdateRecord(int id);
            void DeleteRecord(int id);
        }

        public class OreoDatabaseAdapter : IDatabaseAdapter
        {
            private readonly OreoDatabaseManagementSystem _oreoSystem;

            public OreoDatabaseAdapter(OreoDatabaseManagementSystem oreoSystem)
            {
                _oreoSystem = oreoSystem;
            }

            public void InsertRecord(int id)
            {
                _oreoSystem.InsertRowLikeItsSucculentCreamFilling(id);
            }

            public void UpdateRecord(int id)
            {
                _oreoSystem.AlterRowWithUpdatedInformation(id);
            }

            public void DeleteRecord(int id)
            {
                _oreoSystem.PrepareRowForDestruction(id);
                _oreoSystem.DestroyRow(id);
            }
        }

        public class ChipsAhoyDatabaseAdapter : IDatabaseAdapter
        {
            private readonly ChipsAhoyDatabaseManagementSystem _chipsAhoySystem;

            public ChipsAhoyDatabaseAdapter(ChipsAhoyDatabaseManagementSystem chipsAhoySystem)
            {
                _chipsAhoySystem = chipsAhoySystem;
            }

            public void InsertRecord(int id)
            {
                _chipsAhoySystem.InsertAhoy(id);
            }

            public void UpdateRecord(int id)
            {
                _chipsAhoySystem.PrepareAlterAhoy(id);
                _chipsAhoySystem.AlterAhoy(id);
            }

            public void DeleteRecord(int id)
            {
                _chipsAhoySystem.RemoveAhoy(id);
            }
        }

        public class GirlScoutCookieDatabaseAdapter : IDatabaseAdapter
        {
            private readonly GirlScoutsOfAmericaDatabaseManagementSystem _girlScoutCookieSystem;

            public GirlScoutCookieDatabaseAdapter(GirlScoutsOfAmericaDatabaseManagementSystem girlScoutCookieSystem)
            {
                _girlScoutCookieSystem = girlScoutCookieSystem;
            }

            public void InsertRecord(int id)
            {
                _girlScoutCookieSystem.PrepareToInsertRecord(id);
                _girlScoutCookieSystem.ThinMinsert(id);
            }

            public void UpdateRecord(int id)
            {
                _girlScoutCookieSystem.PeanupdateButterPatties(id);
            }

            public void DeleteRecord(int id)
            {
                _girlScoutCookieSystem.CaramelDelete(id);
            }
        }

        public static void ExecuteClientB()
        {
            var databaseManagementSystem = new GirlScoutsOfAmericaDatabaseManagementSystem();

            IDatabaseAdapter databaseAdapter = new GirlScoutCookieDatabaseAdapter(databaseManagementSystem);

            databaseAdapter.InsertRecord(5);

            databaseAdapter.UpdateRecord(5);

            databaseAdapter.DeleteRecord(10);
        }
    }
}
