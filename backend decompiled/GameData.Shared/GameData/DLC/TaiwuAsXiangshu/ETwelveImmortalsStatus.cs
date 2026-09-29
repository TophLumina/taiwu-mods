using GameData.Serializer;

namespace GameData.DLC.TaiwuAsXiangshu;

[SerializeTo(typeof(sbyte))]
public enum ETwelveImmortalsStatus : sbyte
{
	Default,
	Killed,
	Tamed
}
