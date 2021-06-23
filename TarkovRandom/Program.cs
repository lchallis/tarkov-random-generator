using System;

namespace TarkovRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Armor: {(GetRandom(items.Armor))}");

            Console.WriteLine($"Gun: {(GetRandom(items.Gun))}");

            Console.WriteLine($"Rig: {(GetRandom(items.Rig))}");

            Console.WriteLine($"Backpack: {(GetRandom(items.Backpack))}");

            Console.WriteLine($"Gun Build: {(GetRandom(items.GunBuild))}");

            Console.WriteLine($"Ammo: {(GetRandom(items.Ammo))}");

            Console.WriteLine($"Map: {(GetRandom(items.Map))}");

            Console.ReadKey();

        }

        public static string GetRandom(string[] itemArray)
        {
            Random random = new Random();
                        
            var randomItem = random.Next(0, itemArray.Length);

            var itemPick = itemArray[randomItem];

            return itemPick;
        }
    }
}
