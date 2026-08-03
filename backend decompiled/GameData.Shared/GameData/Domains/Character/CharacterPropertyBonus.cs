using GameData.Combat.Math;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 角色的属性加成
/// </summary>
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

	/// <summary>
	/// 加法变化 (A类)
	/// </summary>
	[SerializableGameDataField]
	public int AddValue;

	/// <summary>
	/// 累加百分比变化（B类）
	/// </summary>
	[SerializableGameDataField]
	public int AddPercent;

	/// <summary>
	/// 是否为空值
	/// </summary>
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

	/// <summary>
	/// 隐式转换为影响值
	/// </summary>
	public static implicit operator CValueModify(CharacterPropertyBonus bonus)
	{
		return new CValueModify(bonus.AddValue, bonus.AddPercent);
	}

	/// <summary>
	/// 乘法
	/// </summary>
	public static int operator *(int value, CharacterPropertyBonus bonus)
	{
		return value * (CValueModify)bonus;
	}

	/// <summary>
	/// 添加加成
	/// </summary>
	/// <param name="bonusType"></param>
	/// <param name="bonusValue"></param>
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

	/// <summary>
	/// 获取加成值
	/// </summary>
	/// <param name="bonusType"></param>
	/// <returns></returns>
	public int GetBonus(EDataModifyType bonusType)
	{
		return bonusType switch
		{
			EDataModifyType.Add => AddValue, 
			EDataModifyType.AddPercent => AddPercent, 
			_ => 0, 
		};
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 10;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
