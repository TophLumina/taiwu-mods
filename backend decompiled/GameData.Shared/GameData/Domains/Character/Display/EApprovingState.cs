using GameData.Serializer;

namespace GameData.Domains.Character.Display;

[SerializeAs(typeof(byte))]
public enum EApprovingState : byte
{
	None,
	ApproveDirectly,
	Duke
}
