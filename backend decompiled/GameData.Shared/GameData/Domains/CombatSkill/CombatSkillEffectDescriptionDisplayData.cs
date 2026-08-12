using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法 效果描述 显示数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public struct CombatSkillEffectDescriptionDisplayData : ISerializableGameData
{
	/// <summary>
	/// 无效值
	/// </summary>
	public static readonly CombatSkillEffectDescriptionDisplayData Invalid = new CombatSkillEffectDescriptionDisplayData
	{
		EffectId = -1,
		AffectRequirePower = null
	};

	/// <summary>
	/// 特效 ID, 用于获取原始描述
	/// </summary>
	[SerializableGameDataField]
	public int EffectId;

	/// <summary>
	/// 生效所需成数
	/// </summary>
	[SerializableGameDataField]
	public List<int> AffectRequirePower;

	/// <summary>
	/// 深拷贝构造
	/// </summary>
	public CombatSkillEffectDescriptionDisplayData(CombatSkillEffectDescriptionDisplayData other)
	{
		EffectId = other.EffectId;
		AffectRequirePower = ((other.AffectRequirePower != null) ? new List<int>(other.AffectRequirePower) : null);
	}

	/// <summary>
	/// 深拷贝赋值
	/// </summary>
	public void Assign(CombatSkillEffectDescriptionDisplayData other)
	{
		EffectId = other.EffectId;
		AffectRequirePower = ((other.AffectRequirePower != null) ? new List<int>(other.AffectRequirePower) : null);
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((AffectRequirePower == null) ? (totalSize + 2) : (totalSize + (2 + 4 * AffectRequirePower.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = EffectId;
		pCurrData += 4;
		if (AffectRequirePower != null)
		{
			int elementsCount = AffectRequirePower.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = AffectRequirePower[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
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
		EffectId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (AffectRequirePower == null)
			{
				AffectRequirePower = new List<int>(elementsCount);
			}
			else
			{
				AffectRequirePower.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				AffectRequirePower.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			AffectRequirePower?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
