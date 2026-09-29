using GameData.Serializer;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

public struct PrioritizedActionCooldownSbytes : ISerializableGameData
{
	public unsafe fixed sbyte Items[9];

	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			items[8] = 0;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 9;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			pData[8] = (byte)pItems[8];
		}
		return 9;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			items[8] = (sbyte)pData[8];
		}
		return 9;
	}

	public unsafe void AddAllActionCooldown(sbyte cooldown)
	{
		for (sbyte actionType = 0; actionType < 9; actionType++)
		{
			int value = Items[actionType] + cooldown;
			if (value > 127)
			{
				value = 127;
			}
			Items[actionType] = (sbyte)value;
		}
	}

	public unsafe void SetAllActionCooldown(sbyte cooldown)
	{
		for (sbyte actionType = 0; actionType < 9; actionType++)
		{
			Items[actionType] = cooldown;
		}
	}

	public unsafe void ClearCooldown(sbyte prioritizedActionType)
	{
		Items[prioritizedActionType] = 0;
	}

	public unsafe bool UpdateAllCooldown()
	{
		bool isChanged = false;
		for (sbyte prioritizedActionType = 0; prioritizedActionType < 9; prioritizedActionType++)
		{
			if (Items[prioritizedActionType] > 0)
			{
				ref sbyte reference = ref Items[prioritizedActionType];
				reference--;
				isChanged = true;
			}
		}
		return isChanged;
	}

	public unsafe bool IsOffCooldown(sbyte prioritizedActionType)
	{
		return Items[prioritizedActionType] <= 0;
	}
}
