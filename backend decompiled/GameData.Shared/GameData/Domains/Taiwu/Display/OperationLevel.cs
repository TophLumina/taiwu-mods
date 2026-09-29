using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

[SerializeTo(typeof(sbyte))]
public enum OperationLevel : sbyte
{
	None,
	Visible,
	Available
}
