using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.MainStory;

/// <summary>
/// 主线铁盘数据，存档数据
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class IronPlateData : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort IsUnlocked = 0;

		public const ushort FollowingCharId = 1;

		public const ushort CooldownDate = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "IsUnlocked", "FollowingCharId", "CooldownDate" };
	}

	/// <summary>
	/// 是否解锁
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public bool IsUnlocked;

	/// <summary>
	/// 选择跟随的人物
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int FollowingCharId = -1;

	/// <summary>
	/// 冷却结束时间
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int CooldownDate;

	/// <summary>
	/// 冷却时间
	/// </summary>
	public static readonly int CooldownDuration = 1;

	/// <summary>
	/// 设置选人
	/// </summary>
	/// <param name="charId"></param>
	public void SetFollowingCharId(int charId)
	{
		FollowingCharId = charId;
	}

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
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public IronPlateData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public IronPlateData(IronPlateData other)
	{
		IsUnlocked = other.IsUnlocked;
		FollowingCharId = other.FollowingCharId;
		CooldownDate = other.CooldownDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(IronPlateData other)
	{
		IsUnlocked = other.IsUnlocked;
		FollowingCharId = other.FollowingCharId;
		CooldownDate = other.CooldownDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*num = (IsUnlocked ? ((byte)1) : ((byte)0));
		byte* num2 = num + 1;
		*(int*)num2 = FollowingCharId;
		byte* num3 = num2 + 4;
		*(int*)num3 = CooldownDate;
		int totalSize = (int)(num3 + 4 - pData);
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
			FollowingCharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
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
