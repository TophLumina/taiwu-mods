using GameData.Serializer;

namespace GameData.Domains.Taiwu;

[SerializeTo(typeof(sbyte))]
public enum ESkillBreakPlateBonusType
{
	None,
	Item,
	Relation,
	Exp,
	Friend
}
