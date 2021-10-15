﻿using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ElementalHearts
{
    public class ElementalHeartsSystem : ModSystem
    {
		public static bool downedMenacingHeart = false;

		public override void OnWorldLoad()
		{
			downedMenacingHeart = false;
		}

		public override void OnWorldUnload()
		{
			downedMenacingHeart = false;
		}

		public override void SaveWorldData(TagCompound tag)
		{
			if (downedMenacingHeart)
            {
				tag["downedMenacingHeart"] = true;
            }
		}

		public override void LoadWorldData(TagCompound tag)
		{
			downedMenacingHeart = tag.ContainsKey("downedMenacingHeart");
		}

		public override void NetSend(BinaryWriter writer)
		{
			var flags = new BitsByte();
			flags[0] = downedMenacingHeart;
			writer.Write(flags);
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedMenacingHeart = flags[0];
		}
	}
}
