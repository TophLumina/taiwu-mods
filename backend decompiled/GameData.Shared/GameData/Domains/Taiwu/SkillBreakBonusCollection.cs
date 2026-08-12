using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells.Character;
using GameData.Serializer;

namespace GameData.Domains.Taiwu;

public class SkillBreakBonusCollection : ISerializableGameData, IEquatable<SkillBreakBonusCollection>
{
	/// <summary>
	/// 角色属性加成（运功），属性类型 (<see cref="T:ECharacterPropertyReferencedType" />) 为Key, 加成总量为Value
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, short> CharacterPropertyBonusDict = new Dictionary<short, short>();

	/// <summary>
	/// 功法加成，功法属性类型 (<see cref="T:Config.CombatSkillProperty" /> 为Key, 加成总量为Value)
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, short> CombatSkillPropertyBonusDict = new Dictionary<short, short>();

	/// <summary>
	/// 新增加成效果
	/// </summary>
	/// <param name="bonusTypeTemplateId">加成格的模板Id <see cref="F:Config.SkillBreakPlateGridBonusTypeItem.TemplateId" /></param>
	public void AddBonusType(short bonusTypeTemplateId)
	{
		SkillBreakPlateGridBonusTypeItem bonusTypeCfg = SkillBreakPlateGridBonusType.Instance[bonusTypeTemplateId];
		PropertyAndValue[] characterPropertyBonusList = bonusTypeCfg.CharacterPropertyBonusList;
		for (int i = 0; i < characterPropertyBonusList.Length; i++)
		{
			PropertyAndValue charBonus = characterPropertyBonusList[i];
			if (CharacterPropertyBonusDict.ContainsKey(charBonus.PropertyId))
			{
				int totalBonus = CharacterPropertyBonusDict[charBonus.PropertyId] + charBonus.Value;
				if (totalBonus == 0)
				{
					CharacterPropertyBonusDict.Remove(charBonus.PropertyId);
				}
				else
				{
					CharacterPropertyBonusDict[charBonus.PropertyId] = (short)totalBonus;
				}
			}
			else
			{
				CharacterPropertyBonusDict.Add(charBonus.PropertyId, charBonus.Value);
			}
		}
		characterPropertyBonusList = bonusTypeCfg.CombatSkillPropertyBonusList;
		for (int i = 0; i < characterPropertyBonusList.Length; i++)
		{
			PropertyAndValue skillBonus = characterPropertyBonusList[i];
			if (CombatSkillPropertyBonusDict.ContainsKey(skillBonus.PropertyId))
			{
				int totalBonus2 = CombatSkillPropertyBonusDict[skillBonus.PropertyId] + skillBonus.Value;
				if (totalBonus2 == 0)
				{
					CombatSkillPropertyBonusDict.Remove(skillBonus.PropertyId);
				}
				else
				{
					CombatSkillPropertyBonusDict[skillBonus.PropertyId] = (short)totalBonus2;
				}
			}
			else
			{
				CombatSkillPropertyBonusDict.Add(skillBonus.PropertyId, skillBonus.Value);
			}
		}
	}

	/// <summary>
	/// 移除加成效果
	/// </summary>
	/// <param name="bonusTypeTemplateId">加成格的模板Id <see cref="F:Config.SkillBreakPlateGridBonusTypeItem.TemplateId" /></param>
	public void RemoveBonusType(short bonusTypeTemplateId)
	{
		SkillBreakPlateGridBonusTypeItem bonusTypeCfg = SkillBreakPlateGridBonusType.Instance[bonusTypeTemplateId];
		PropertyAndValue[] characterPropertyBonusList = bonusTypeCfg.CharacterPropertyBonusList;
		for (int i = 0; i < characterPropertyBonusList.Length; i++)
		{
			PropertyAndValue charBonus = characterPropertyBonusList[i];
			if (CharacterPropertyBonusDict.ContainsKey(charBonus.PropertyId))
			{
				int totalBonus = CharacterPropertyBonusDict[charBonus.PropertyId] - charBonus.Value;
				if (totalBonus == 0)
				{
					CharacterPropertyBonusDict.Remove(charBonus.PropertyId);
				}
				else
				{
					CharacterPropertyBonusDict[charBonus.PropertyId] = (short)totalBonus;
				}
			}
			else
			{
				CharacterPropertyBonusDict.Add(charBonus.PropertyId, (short)(-charBonus.Value));
			}
		}
		characterPropertyBonusList = bonusTypeCfg.CombatSkillPropertyBonusList;
		for (int i = 0; i < characterPropertyBonusList.Length; i++)
		{
			PropertyAndValue skillBonus = characterPropertyBonusList[i];
			if (CombatSkillPropertyBonusDict.ContainsKey(skillBonus.PropertyId))
			{
				int totalBonus2 = CombatSkillPropertyBonusDict[skillBonus.PropertyId] - skillBonus.Value;
				if (totalBonus2 == 0)
				{
					CombatSkillPropertyBonusDict.Remove(skillBonus.PropertyId);
				}
				else
				{
					CombatSkillPropertyBonusDict[skillBonus.PropertyId] = (short)totalBonus2;
				}
			}
			else
			{
				CombatSkillPropertyBonusDict.Add(skillBonus.PropertyId, (short)(-skillBonus.Value));
			}
		}
	}

	/// <summary>
	/// 清空所有加成
	/// </summary>
	public void Clear()
	{
		CharacterPropertyBonusDict.Clear();
		CombatSkillPropertyBonusDict.Clear();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 2 + 4 * CharacterPropertyBonusDict.Count;
		totalSize += 2 + 4 * CombatSkillPropertyBonusDict.Count;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = (short)CharacterPropertyBonusDict.Count;
		pCurrData += 2;
		foreach (KeyValuePair<short, short> entry in CharacterPropertyBonusDict)
		{
			*(short*)pCurrData = entry.Key;
			pCurrData += 2;
			*(short*)pCurrData = entry.Value;
			pCurrData += 2;
		}
		*(short*)pCurrData = (short)CombatSkillPropertyBonusDict.Count;
		pCurrData += 2;
		foreach (KeyValuePair<short, short> entry2 in CombatSkillPropertyBonusDict)
		{
			*(short*)pCurrData = entry2.Key;
			pCurrData += 2;
			*(short*)pCurrData = entry2.Value;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		short count = *(short*)pCurrData;
		pCurrData += 2;
		CharacterPropertyBonusDict.Clear();
		for (int i = 0; i < count; i++)
		{
			short type = *(short*)pCurrData;
			pCurrData += 2;
			short value = *(short*)pCurrData;
			pCurrData += 2;
			CharacterPropertyBonusDict.Add(type, value);
		}
		count = *(short*)pCurrData;
		pCurrData += 2;
		CombatSkillPropertyBonusDict.Clear();
		for (int j = 0; j < count; j++)
		{
			short type2 = *(short*)pCurrData;
			pCurrData += 2;
			short value2 = *(short*)pCurrData;
			pCurrData += 2;
			CombatSkillPropertyBonusDict.Add(type2, value2);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool Equals(SkillBreakBonusCollection other)
	{
		if (other == null)
		{
			return false;
		}
		if (CharacterPropertyBonusDict.Count != other.CharacterPropertyBonusDict.Count)
		{
			return false;
		}
		if (CombatSkillPropertyBonusDict.Count != other.CombatSkillPropertyBonusDict.Count)
		{
			return false;
		}
		foreach (KeyValuePair<short, short> pair in CharacterPropertyBonusDict)
		{
			if (!other.CharacterPropertyBonusDict.TryGetValue(pair.Key, out var bonus) || bonus != pair.Value)
			{
				return false;
			}
		}
		foreach (KeyValuePair<short, short> pair2 in CombatSkillPropertyBonusDict)
		{
			if (!other.CombatSkillPropertyBonusDict.TryGetValue(pair2.Key, out var bonus2) || bonus2 != pair2.Value)
			{
				return false;
			}
		}
		return true;
	}
}
