using GameData.Serializer;

namespace GameData.Domains.Character.Ai.PrioritizedAction;

/// <summary>
/// 优先行为冷却
/// </summary>
public struct PrioritizedActionCooldownSbytes : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.Ai.PrioritizedActionType" />
	/// </summary>
	public unsafe fixed sbyte Items[9];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 <see cref="F:GameData.Domains.Character.Ai.PrioritizedActionType.Count" /> == 9.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 给所有行为添加额外冷却
	/// </summary>
	/// <param name="cooldown"></param>
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

	/// <summary>
	/// 设置所有行动冷却
	/// </summary>
	/// <param name="cooldown"></param>
	public unsafe void SetAllActionCooldown(sbyte cooldown)
	{
		for (sbyte actionType = 0; actionType < 9; actionType++)
		{
			Items[actionType] = cooldown;
		}
	}

	/// <summary>
	/// 清空指定行动的冷却
	/// </summary>
	/// <param name="prioritizedActionType"></param>
	public unsafe void ClearCooldown(sbyte prioritizedActionType)
	{
		Items[prioritizedActionType] = 0;
	}

	/// <summary>
	/// 更新所有行动的冷却，使当前冷却大于0的-1
	/// </summary>
	/// <returns>是否有发生改变</returns>
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

	/// <summary>
	/// 检查指定行动是否不在冷却
	/// </summary>
	/// <param name="prioritizedActionType"></param>
	/// <returns></returns>
	public unsafe bool IsOffCooldown(sbyte prioritizedActionType)
	{
		return Items[prioritizedActionType] <= 0;
	}
}
