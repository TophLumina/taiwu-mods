using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.MainStory;

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

	[SerializableGameDataField(FieldIndex = 0)]
	public bool IsUnlocked;

	[SerializableGameDataField(FieldIndex = 1)]
	public int FollowingCharId = -1;

	[SerializableGameDataField(FieldIndex = 2)]
	public int CooldownDate;

	public static readonly int CooldownDuration = 1;

	public void SetFollowingCharId(int charId)
	{
		FollowingCharId = charId;
	}

	public void SetCooldownDate(int data)
	{
		CooldownDate = data;
	}

	public void SetIsUnlocked(bool isUnlocked)
	{
		IsUnlocked = isUnlocked;
	}

	public bool IsCooldownEnd(int curDate)
	{
		return curDate >= CooldownDate;
	}

	public IronPlateData()
	{
	}

	public IronPlateData(IronPlateData other)
	{
		IsUnlocked = other.IsUnlocked;
		FollowingCharId = other.FollowingCharId;
		CooldownDate = other.CooldownDate;
	}

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
