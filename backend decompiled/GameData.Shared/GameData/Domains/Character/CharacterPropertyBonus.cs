using GameData.Combat.Math;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true)]
public struct CharacterPropertyBonus : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort AddValue = 0;

		public const ushort AddPercent = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "AddValue", "AddPercent" };
	}

	[SerializableGameDataField]
	public int AddValue;

	[SerializableGameDataField]
	public int AddPercent;

	public bool IsZero
	{
		get
		{
			if (AddValue == 0)
			{
				return AddPercent == 0;
			}
			return false;
		}
	}

	public static implicit operator CValueModify(CharacterPropertyBonus bonus)
	{
		return new CValueModify(bonus.AddValue, bonus.AddPercent);
	}

	public static int operator *(int value, CharacterPropertyBonus bonus)
	{
		return value * (CValueModify)bonus;
	}

	public void AddBonus(EDataModifyType bonusType, int bonusValue)
	{
		switch (bonusType)
		{
		case EDataModifyType.Add:
			AddValue += bonusValue;
			break;
		case EDataModifyType.AddPercent:
			AddPercent += bonusValue;
			break;
		default:
			AdaptableLog.Warning($"try add bonus {bonusValue} by invalid type {bonusType}");
			break;
		}
	}

	public int GetBonus(EDataModifyType bonusType)
	{
		return bonusType switch
		{
			EDataModifyType.Add => AddValue, 
			EDataModifyType.AddPercent => AddPercent, 
			_ => 0, 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
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
		*(int*)num = AddValue;
		byte* num2 = num + 4;
		*(int*)num2 = AddPercent;
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
			AddValue = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			AddPercent = *(int*)pCurrData;
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
