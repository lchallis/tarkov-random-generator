﻿using System;
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
				GenerateLoadOut();

			}
			while (cki.Key != ConsoleKey.Escape);

		}

		public static JsonItems GetItemsFromFile(string file)
		{
			string text = System.IO.File.ReadAllText($@"items\{file}.json");

			JsonItems items = JsonSerializer.Deserialize<JsonItems>(text);

			return items;
		}

		public static void GenerateLoadOut()
		{
			// set up yo items
			var armors = GetItemsFromFile("armor").items;
			var armoredRigs = GetItemsFromFile("armoredrigs").items;
			var rigs = GetItemsFromFile("rigs").items;
			var guns = GetItemsFromFile("guns").items;
			var gunBuilds = GetItemsFromFile("gunbuilds").items;
			var ammo = GetItemsFromFile("ammo").items;
			var backpacks = GetItemsFromFile("backpacks").items;
			var maps = GetItemsFromFile("maps").items;

			// get some random on
			Random random = new Random();

			// we need a list of armors for knowing if armored rig etc. 

			List<Armor> ArmorList = new List<Armor>();

			foreach (var armor in armors)
			{
				ArmorList.Add(new Armor(armor, false));
			}

			foreach (var armor in armoredRigs)
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
				Console.WriteLine($"Rig: {GetRandom(rigs)}");
			}

			// Then EZ-Mode for all the other types 

			Console.WriteLine($"Gun: {GetRandom(guns)}");

			Console.WriteLine($"Backpack: {GetRandom(backpacks)}");

			Console.WriteLine($"Gun Build: {GetRandom(gunBuilds)}");

			Console.WriteLine($"Ammo: {GetRandom(ammo)}");

			Console.WriteLine($"Map: {GetRandom(maps)}");

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
