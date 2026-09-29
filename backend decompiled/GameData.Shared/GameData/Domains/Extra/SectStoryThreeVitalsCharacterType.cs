using GameData.Serializer;

namespace GameData.Domains.Extra;

[SerializeTo(typeof(sbyte))]
public enum SectStoryThreeVitalsCharacterType
{
	Heaven,
	Earth,
	Human
}
