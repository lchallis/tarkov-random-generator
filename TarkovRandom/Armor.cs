using System;
using System.Collections.Generic;
using System.Text;

namespace TarkovRandom
{
	class Armor
	{
		public string name { get; set; }
		public bool isChestRig { get; set; }
		public Armor(string name, bool isArmored)
		{
			this.name = name;
			this.isChestRig = isArmored;
		}
	}
}
