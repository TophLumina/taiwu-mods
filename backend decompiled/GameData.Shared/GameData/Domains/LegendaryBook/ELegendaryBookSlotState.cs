using GameData.Serializer;

namespace GameData.Domains.LegendaryBook;

[SerializeTo(typeof(sbyte))]
public enum ELegendaryBookSlotState : sbyte
{
	Locked = -1,
	OnlyYin,
	OnlyYang,
	BothUnlocked
}
