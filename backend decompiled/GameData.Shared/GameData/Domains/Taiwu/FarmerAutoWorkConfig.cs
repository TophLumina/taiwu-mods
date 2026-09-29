using System;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[Flags]
[SerializeTo(typeof(ushort))]
public enum FarmerAutoWorkConfig : ushort
{
	Default = 0,
	BanMigrate0 = 1,
	BanMigrate1 = 2,
	BanMigrate2 = 4,
	BanMigrate3 = 8,
	BanMigrate4 = 0x10,
	BanMigrate5 = 0x20
}
