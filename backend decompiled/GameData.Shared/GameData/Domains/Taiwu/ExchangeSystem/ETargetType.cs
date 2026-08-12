using GameData.Serializer;

namespace GameData.Domains.Taiwu.ExchangeSystem;

[SerializeAs(typeof(byte))]
public enum ETargetType : byte
{
	GoodNpc,
	GoodSect,
	NeutralNpc,
	NeutralSect,
	TownNpc,
	Town,
	EvilNpc,
	EvilSect
}
