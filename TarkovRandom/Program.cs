using System;
using System.Collections.Generic;

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
				GenerateLoadOut();

			}
			while (cki.Key != ConsoleKey.Escape);

		}

		public static void GenerateLoadOut()
		{
			Random random = new Random();

			List<Armor> ArmorList = new List<Armor>();

			foreach (var armor in items.armors)
			{
				ArmorList.Add(new Armor(armor, false));
			}

			foreach (var armor in items.ArmoredRig)
			{
				ArmorList.Add(new Armor(armor, true));
			}

			var ChosenArmorInt = random.Next(ArmorList.Count);

			var ChosenArmor = ArmorList[ChosenArmorInt];

			Console.WriteLine($"Armor: {ChosenArmor.name}");

			if (ChosenArmor.isArmored)
			{
				Console.WriteLine("Skipping rig, armored rig!");
			}
			else
			{
				Console.WriteLine($"Rig: {(GetRandom(items.Rig))}");
			}

			Console.WriteLine($"Gun: {(GetRandom(items.Gun))}");

			Console.WriteLine($"Backpack: {(GetRandom(items.Backpack))}");

			Console.WriteLine($"Gun Build: {(GetRandom(items.GunBuild))}");

			Console.WriteLine($"Ammo: {(GetRandom(items.Ammo))}");

			Console.WriteLine($"Map: {(GetRandom(items.Map))}");

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
