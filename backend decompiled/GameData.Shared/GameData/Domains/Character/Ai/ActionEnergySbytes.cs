using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Ai;

/// <summary>
/// 各种AI行动类型对应的能量
/// </summary>
public struct ActionEnergySbytes : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.Ai.ActionEnergyType" />
	/// </summary>
	public unsafe fixed byte Items[5];

	/// <summary>
	/// 允许的最大值
	/// </summary>
	public const byte MaxValue = 200;

	/// <summary>
	/// 允许的最小值
	/// </summary>
	public const byte MinValue = 0;

	/// <summary>
	/// 每次行动消耗的能量
	/// </summary>
	public const byte EnergyCostPerAction = 100;

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 ActionEnergyType.Count == 5.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (byte* items = Items)
		{
			*(int*)items = 0;
			items[4] = 0;
		}
	}

	public unsafe void Change(sbyte energyType, byte delta)
	{
		Items[energyType] = (byte)MathUtils.Clamp(Items[energyType] + delta, 0, 200);
	}

	public unsafe void SpendEnergyOnAction(sbyte actionEnergyType)
	{
		Tester.Assert(Items[actionEnergyType] >= 100);
		ref byte reference = ref Items[actionEnergyType];
		reference -= 100;
	}

	public unsafe bool HasEnoughForAction(sbyte actionEnergyType)
	{
		return Items[actionEnergyType] >= 100;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 5;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (byte* pItems = Items)
		{
			*(int*)pData = *(int*)pItems;
			pData[4] = pItems[4];
		}
		return 5;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (byte* items = Items)
		{
			*(int*)items = *(int*)pData;
			items[4] = pData[4];
		}
		return 5;
	}
}
