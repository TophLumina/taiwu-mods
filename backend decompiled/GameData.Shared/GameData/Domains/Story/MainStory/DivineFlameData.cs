using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.MainStory;

/// <summary>
/// 主线神火线数据，存档数据
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class DivineFlameData : ISerializableGameData
{
	public enum TargetType
	{
		None,
		SelectCharacter,
		SelectBlock,
		CheckCharacter,
		CheckBlock
	}

	public static class FieldIds
	{
		public const ushort IsUnlocked = 0;

		public const ushort CooldownDate = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "IsUnlocked", "CooldownDate" };
	}

	/// <summary>
	/// 是否解锁
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public bool IsUnlocked;

	/// <summary>
	/// 冷却结束时间
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int CooldownDate;

	/// <summary>
	/// 冷却时间
	/// </summary>
	public static readonly int CooldownDuration = 1;

	/// <summary>
	/// 设置冷却结束时间
	/// </summary>
	/// <param name="data"></param>
	public void SetCooldownDate(int data)
	{
		CooldownDate = data;
	}

	/// <summary>
	/// 设置是否解锁
	/// </summary>
	/// <param name="isUnlocked"></param>
	public void SetIsUnlocked(bool isUnlocked)
	{
		IsUnlocked = isUnlocked;
	}

	/// <summary>
	/// 是否冷却完毕
	/// </summary>
	/// <param name="curDate"></param>
	/// <returns></returns>
	public bool IsCooldownEnd(int curDate)
	{
		return curDate >= CooldownDate;
	}

	/// <summary>
	/// 获取神火线-剑柄效果的目标类型
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	/// <param name="isGood"></param>
	/// <returns></returns>
	public static TargetType GetTargetType(sbyte xiangshuAvatarId, bool isGood)
	{
		switch (xiangshuAvatarId)
		{
		case 0:
			return TargetType.SelectCharacter;
		case 1:
			return TargetType.SelectCharacter;
		case 2:
			return TargetType.CheckBlock;
		case 3:
			return TargetType.SelectCharacter;
		case 4:
			return TargetType.CheckCharacter;
		case 5:
			return TargetType.SelectCharacter;
		case 6:
			return TargetType.SelectCharacter;
		case 7:
			if (!isGood)
			{
				return TargetType.CheckBlock;
			}
			return TargetType.SelectCharacter;
		case 8:
			return TargetType.SelectCharacter;
		default:
			return TargetType.None;
		}
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DivineFlameData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DivineFlameData(DivineFlameData other)
	{
		IsUnlocked = other.IsUnlocked;
		CooldownDate = other.CooldownDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DivineFlameData other)
	{
		IsUnlocked = other.IsUnlocked;
		CooldownDate = other.CooldownDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		*num = (IsUnlocked ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = CooldownDate;
		int totalSize = (int)(num2 + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			IsUnlocked = *pCurrData != 0;
			pCurrData++;
		}
		if (num > 1)
		{
			CooldownDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
