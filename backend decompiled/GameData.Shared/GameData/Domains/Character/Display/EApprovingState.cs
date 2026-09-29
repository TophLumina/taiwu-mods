using GameData.Serializer;

namespace GameData.Domains.Character.Display;

[SerializeTo(typeof(byte))]
public enum EApprovingState : byte
{
	None,
	ApproveDirectly,
	Duke
}
