using System;

namespace Config;

[Serializable]
public struct HotkeyIndex(byte groupId, byte commandId)
{
	public byte GroupId = groupId;

	public byte CommandId = commandId;
}
