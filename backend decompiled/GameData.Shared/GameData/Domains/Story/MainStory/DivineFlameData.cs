using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.MainStory;

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

	[SerializableGameDataField(FieldIndex = 0)]
	public bool IsUnlocked;

	[SerializableGameDataField(FieldIndex = 1)]
	public int CooldownDate;

	public static readonly int CooldownDuration = 1;

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

	public DivineFlameData()
	{
	}

	public DivineFlameData(DivineFlameData other)
	{
		IsUnlocked = other.IsUnlocked;
		CooldownDate = other.CooldownDate;
	}

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
