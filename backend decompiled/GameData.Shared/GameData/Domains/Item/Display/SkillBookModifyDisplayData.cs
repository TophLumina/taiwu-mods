using System.Collections.Generic;
using Config;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item.Display;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class SkillBookModifyDisplayData : ISerializableGameData, IFilterableCombatSkill
{
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	[SerializableGameDataField]
	public int NormalPageCostExp;

	[SerializableGameDataField]
	public int OutlinePageCostExp;

	[SerializableGameDataField]
	public byte PageTypes;

	[SerializableGameDataField]
	public ushort PageIncompleteState;

	public sbyte Type => SkillConfig.Type;

	public sbyte SectId => SkillConfig.SectId;

	public short TemplateId => SkillBook.Instance[ItemDisplayData.Key.TemplateId].CombatSkillTemplateId;

	public CombatSkillItem SkillConfig => Config.CombatSkill.Instance[TemplateId];

	public ushort ActivationState { get; }

	public bool IsInAnyEquipPlans { get; }

	public bool HasSectEmeiSkillBreakBonus { get; }

	public short Power { get; }

	public List<sbyte> BreakBonusGrades { get; }

	public ushort ReadingState { get; }

	public short MaxObtainableNeili { get; }

	public short ObtainedNeili { get; }

	public sbyte FiveElementTransferTypeWhileLooping { get; set; }

	public sbyte FiveElementDestTypeWhileLooping { get; set; }

	public int CombatSkillProficiency => 0;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((ItemDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + ItemDisplayData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (ItemDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = ItemDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = NormalPageCostExp;
		pCurrData += 4;
		*(int*)pCurrData = OutlinePageCostExp;
		pCurrData += 4;
		*pCurrData = PageTypes;
		pCurrData++;
		*(ushort*)pCurrData = PageIncompleteState;
		pCurrData += 2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (ItemDisplayData == null)
			{
				ItemDisplayData = new ItemDisplayData();
			}
			pCurrData += ItemDisplayData.Deserialize(pCurrData);
		}
		else
		{
			ItemDisplayData = null;
		}
		NormalPageCostExp = *(int*)pCurrData;
		pCurrData += 4;
		OutlinePageCostExp = *(int*)pCurrData;
		pCurrData += 4;
		PageTypes = *pCurrData;
		pCurrData++;
		PageIncompleteState = *(ushort*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
