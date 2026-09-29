using GameData.Serializer;

namespace GameData.Domains.World;

[SerializeTo(typeof(sbyte))]
public enum EGuidingChapterState
{
	NewTriggered,
	AlreadyRead,
	Finished
}
