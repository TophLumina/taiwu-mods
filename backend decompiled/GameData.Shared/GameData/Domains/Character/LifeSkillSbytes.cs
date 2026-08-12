using GameData.Serializer;

namespace GameData.Domains.Character;

/// <summary>
/// 各种技艺类型对应的值
/// </summary>
public struct LifeSkillSbytes : ISerializableGameData
{
	/// <summary>
	/// *** 定长数组中的数据在创建对象时并未初始化 ***
	/// 排列顺序参见 <see cref="T:GameData.Domains.Character.LifeSkillType" />
	/// </summary>
	public unsafe fixed sbyte Items[16];

	/// <summary>
	/// 初始化对象, 为 fixed size buffer 填充默认值.
	/// 其实现依赖 LifeSkillType.Count == 16.
	/// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/unsafe-code#definite-assignment-checking" />
	/// </summary>
	/// <returns></returns>
	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 16;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
		}
		return 16;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
		}
		return 16;
	}

	/// <summary>
	/// 计算并返回两者的差值
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public unsafe LifeSkillSbytes Subtract(LifeSkillSbytes other)
	{
		LifeSkillSbytes delta = default(LifeSkillSbytes);
		for (int i = 0; i < 16; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	/// <summary>
	/// 获取倒转了正负号后的对象
	/// </summary>
	public unsafe LifeSkillSbytes GetReversed()
	{
		LifeSkillSbytes reversed = default(LifeSkillSbytes);
		for (int i = 0; i < 16; i++)
		{
			reversed.Items[i] = (sbyte)(-Items[i]);
		}
		return reversed;
	}
}
