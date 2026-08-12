using System.Collections.Generic;
using Config;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item.Display;

/// <summary>
/// 功法书修改书页显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class SkillBookModifyDisplayData : ISerializableGameData, IFilterableCombatSkill
{
	/// <summary>
	/// 物品显示数据，用于 Tips
	/// </summary>
	[SerializableGameDataField]
	public ItemDisplayData ItemDisplayData;

	/// <summary>
	/// 普通书页消耗历练数
	/// </summary>
	[SerializableGameDataField]
	public int NormalPageCostExp;

	/// <summary>
	/// 总纲书页消耗历练数
	/// </summary>
	[SerializableGameDataField]
	public int OutlinePageCostExp;

	/// <summary>
	/// 功法页类型
	/// 获取总纲 - <see cref="M:GameData.Domains.Item.SkillBookStateHelper.GetOutlinePageType(System.Byte)" />
	/// 获取正逆 - <see cref="M:GameData.Domains.Item.SkillBookStateHelper.GetNormalPageType(System.Byte,System.Byte)" />
	/// </summary>
	[SerializableGameDataField]
	public byte PageTypes;

	/// <summary>
	/// 书页残缺程度
	/// <see cref="M:GameData.Domains.Item.SkillBookStateHelper.GetPageIncompleteState(System.UInt16,System.Byte)" />
	/// </summary>
	[SerializableGameDataField]
	public ushort PageIncompleteState;

	/// <inheritdoc />
	public sbyte Type => SkillConfig.Type;

	/// <inheritdoc />
	public sbyte SectId => SkillConfig.SectId;

	/// <inheritdoc />
	public short TemplateId => SkillBook.Instance[ItemDisplayData.Key.TemplateId].CombatSkillTemplateId;

	/// <summary>
	/// 功法配置
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SkillBookModifyDisplayData()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
