using System;
using GameData.Serializer;

namespace GameData.Domains.Character.Ai;

[SerializableGameData(NotForDisplayModule = true)]
public struct AiActionKey(sbyte actionType, sbyte actionSubType) : ISerializableGameData, IEquatable<AiActionKey>
{
	public sbyte ActionType = actionType;

	public sbyte ActionSubType = actionSubType;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 2;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (byte)ActionType;
		pData[1] = (byte)ActionSubType;
		return 2;
	}

	public unsafe int Deserialize(byte* pData)
	{
		ActionType = (sbyte)(*pData);
		ActionSubType = (sbyte)pData[1];
		return 2;
	}

	public bool Equals(AiActionKey other)
	{
		return ActionType == other.ActionType && ActionSubType == other.ActionSubType;
	}

	public override bool Equals(object obj)
	{
		return obj is AiActionKey other && Equals(other);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(ActionType, ActionSubType);
	}
}
