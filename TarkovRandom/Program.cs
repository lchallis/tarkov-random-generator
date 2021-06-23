using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
namespace TarkovRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to generate a loadout, Escape to quit :)");
                Console.WriteLine();
                cki = Console.ReadKey();
                GenerateItemSelection();
                GenerateArmorAndRig();


            }
            while (cki.Key != ConsoleKey.Escape);

        }



        // For non-complex stuff; use this. 
        public static void GenerateItemSelection()
        {
            string[] itemTypes = {
                "Map",
                "Ammo",
                "Gun" ,
                "Gunbuild" ,
                "Headphone",
                "Backpack",
                "Helmet"
            };

            foreach (var itemType in itemTypes)
            {
                var items = GetItemsFromFile(itemType);

                var selectedItem = GetRandom(items);

                Console.WriteLine($"{itemType} : {selectedItem}");
            }
        }

        // Read in a file to get a list of strings, which are going to be items. 

        public static string[] GetItemsFromFile(string file)
        {

            string text = System.IO.File.ReadAllText($@"items\{file}.json");

            JsonItems JsonItems = JsonSerializer.Deserialize<JsonItems>(text);

            return JsonItems.items;
        }

        // Armor + Rig OR Armoured Rig
        public static void GenerateArmorAndRig()
        {
            // Gather all the armors, armored rigs and rigs
            var armors = GetItemsFromFile("armor");
            var armoredRigs = GetItemsFromFile("armoredrig");
            var rigs = GetItemsFromFile("rig");

            // get some random on
            Random random = new Random();

            // we need a list of armors for knowing if armored rig etc. 
            List<Armor> ArmorList = new List<Armor>();

            // add the armors from normal list with isChestRig = false
            foreach (var armor in armors)
            {
                ArmorList.Add(new Armor(armor, false));
            }

            // Add armored rigs with isChestRig = true
            foreach (var armoredRig in armoredRigs)
            {
                ArmorList.Add(new Armor(armoredRig, true));
            }

            // Pick one
            var ChosenArmor = ArmorList[(random.Next(ArmorList.Count))];

            Console.WriteLine($"Armor: {ChosenArmor.name}");

            // if the rig is Armored, we don't need to get a Chest Rig too
            if (ChosenArmor.isChestRig)
            {
                Console.WriteLine($"{ChosenArmor.name} is also a chest rig :D skipping Rig selection");
            }
            else
            {
                Console.WriteLine($"Rig: {GetRandom(rigs)}");
            }
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
