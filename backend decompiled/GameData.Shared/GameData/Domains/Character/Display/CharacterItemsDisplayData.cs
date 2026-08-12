using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Story.MainStory;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 人物持有界面的显示数据
/// </summary>
[AutoGenerateSerializableGameData]
[SerializableGameData(NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class CharacterItemsDisplayData : ISerializableGameData
{
	/// <summary>
	/// 物品喜爱和厌恶信息
	/// </summary>
	[SerializableGameDataField]
	public CharacterLoveAndHateItemInfo CharacterLoveAndHateItemInfo;

	/// <summary>
	/// 人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData CharacterDisplayData;

	/// <summary>
	/// 太吾的人物显示数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData TaiwuCharacterDisplayData;

	/// <summary>
	/// 资源
	/// </summary>
	[SerializableGameDataField]
	public ResourceInts Resources;

	/// <summary>
	/// 技艺造诣
	/// </summary>
	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	/// <summary>
	/// 当前主属性
	/// </summary>
	[SerializableGameDataField]
	public MainAttributes CurMainAttributes;

	/// <summary>
	/// 当前内力
	/// </summary>
	[SerializableGameDataField]
	public int CurrNeili;

	/// <summary>
	/// 最大内力
	/// </summary>
	[SerializableGameDataField]
	public int MaxNeili;

	/// <summary>
	/// 历练
	/// </summary>
	[SerializableGameDataField]
	public int Exp;

	/// <summary>
	/// 当前负重
	/// </summary>
	[SerializableGameDataField]
	public int CurLoad;

	/// <summary>
	/// 最大负重
	/// </summary>
	[SerializableGameDataField]
	public int MaxLoad;

	[SerializableGameDataField]
	public int MoveTimeCostPercent;

	/// <summary>
	/// 当前人物可以借出给太吾的最高价值
	/// </summary>
	[SerializableGameDataField]
	public long MaxWorthCanBeLentToTaiwu;

	/// <summary>
	/// 验毒银针的数量
	/// </summary>
	[SerializableGameDataField]
	public int NeedleAmount;

	/// <summary>
	/// 行囊物品显示数据，包括资源和装备栏
	/// </summary>
	[SerializableGameDataField]
	public List<ItemDisplayData> InventoryItems;

	/// <summary>
	/// 服食栏
	/// </summary>
	[SerializableGameDataField]
	public EatingItems EatingItems;

	/// <summary>
	/// 最大可服食数量
	/// </summary>
	[SerializableGameDataField]
	public sbyte CanEatingMaxCount;

	/// <summary>
	/// 徒手工具
	/// </summary>
	[SerializableGameDataField]
	public ItemKey EmptyToolKey;

	/// <summary>
	/// 主线神火数据
	/// </summary>
	[SerializableGameDataField]
	public DivineFlameData DivineFlameData;

	/// <summary>
	/// 主线神火的目标条件是否满足
	/// </summary>
	[SerializableGameDataField]
	public bool[] DivineFlameTargetState;

	/// <summary>
	/// 神火线-剑柄目标角色-卫起效果
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData DivineFlameTargetCharacter;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 37;
		totalSize = ((CharacterLoveAndHateItemInfo == null) ? (totalSize + 2) : (totalSize + (2 + CharacterLoveAndHateItemInfo.GetSerializedSize())));
		totalSize = ((CharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterDisplayData.GetSerializedSize())));
		totalSize = ((TaiwuCharacterDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + TaiwuCharacterDisplayData.GetSerializedSize())));
		totalSize += Resources.GetSerializedSize();
		totalSize += LifeSkillAttainments.GetSerializedSize();
		totalSize += CurMainAttributes.GetSerializedSize();
		if (InventoryItems != null)
		{
			totalSize += 2;
			for (int i = 0; i < InventoryItems.Count; i++)
			{
				totalSize = ((InventoryItems[i] == null) ? (totalSize + 2) : (totalSize + (2 + InventoryItems[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += EatingItems.GetSerializedSize();
		totalSize += EmptyToolKey.GetSerializedSize();
		totalSize = ((DivineFlameData == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameData.GetSerializedSize())));
		totalSize = ((DivineFlameTargetState == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameTargetState.Length)));
		totalSize = ((DivineFlameTargetCharacter == null) ? (totalSize + 2) : (totalSize + (2 + DivineFlameTargetCharacter.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += CharacterLoveAndHateItemInfo.Serialize(pCurrData);
		if (CharacterDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TaiwuCharacterDisplayData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = TaiwuCharacterDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Resources.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += CurMainAttributes.Serialize(pCurrData);
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(int*)pCurrData = MaxNeili;
		pCurrData += 4;
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		*(int*)pCurrData = CurLoad;
		pCurrData += 4;
		*(int*)pCurrData = MaxLoad;
		pCurrData += 4;
		*(int*)pCurrData = MoveTimeCostPercent;
		pCurrData += 4;
		*(long*)pCurrData = MaxWorthCanBeLentToTaiwu;
		pCurrData += 8;
		*(int*)pCurrData = NeedleAmount;
		pCurrData += 4;
		if (InventoryItems != null)
		{
			int elementsCount = InventoryItems.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (InventoryItems[i] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = InventoryItems[i].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += EatingItems.Serialize(pCurrData);
		*pCurrData = (byte)CanEatingMaxCount;
		pCurrData++;
		pCurrData += EmptyToolKey.Serialize(pCurrData);
		if (DivineFlameData != null)
		{
			byte* intPtr4 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = DivineFlameData.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr4 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DivineFlameTargetState != null)
		{
			int elementsCount2 = DivineFlameTargetState.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (DivineFlameTargetState[j] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (DivineFlameTargetCharacter != null)
		{
			byte* intPtr5 = pCurrData;
			pCurrData += 2;
			int fieldSize5 = DivineFlameTargetCharacter.Serialize(pCurrData);
			pCurrData += fieldSize5;
			Tester.Assert(fieldSize5 <= 65535);
			*(ushort*)intPtr5 = (ushort)fieldSize5;
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		CharacterLoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
		pCurrData += CharacterLoveAndHateItemInfo.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharacterDisplayData = new CharacterDisplayData();
			pCurrData += CharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CharacterDisplayData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			TaiwuCharacterDisplayData = new CharacterDisplayData();
			pCurrData += TaiwuCharacterDisplayData.Deserialize(pCurrData);
		}
		else
		{
			TaiwuCharacterDisplayData = null;
		}
		pCurrData += Resources.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += CurMainAttributes.Deserialize(pCurrData);
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		MaxNeili = *(int*)pCurrData;
		pCurrData += 4;
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		CurLoad = *(int*)pCurrData;
		pCurrData += 4;
		MaxLoad = *(int*)pCurrData;
		pCurrData += 4;
		MoveTimeCostPercent = *(int*)pCurrData;
		pCurrData += 4;
		MaxWorthCanBeLentToTaiwu = *(long*)pCurrData;
		pCurrData += 8;
		NeedleAmount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (InventoryItems == null)
			{
				InventoryItems = new List<ItemDisplayData>();
			}
			else
			{
				InventoryItems.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element;
				if (num3 > 0)
				{
					element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				InventoryItems.Add(element);
			}
		}
		else
		{
			InventoryItems?.Clear();
		}
		pCurrData += EatingItems.Deserialize(pCurrData);
		CanEatingMaxCount = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += EmptyToolKey.Deserialize(pCurrData);
		ushort num4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num4 > 0)
		{
			DivineFlameData = new DivineFlameData();
			pCurrData += DivineFlameData.Deserialize(pCurrData);
		}
		else
		{
			DivineFlameData = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (DivineFlameTargetState == null || DivineFlameTargetState.Length != elementsCount2)
			{
				DivineFlameTargetState = new bool[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				DivineFlameTargetState[j] = *pCurrData != 0;
				pCurrData++;
			}
		}
		else
		{
			DivineFlameTargetState = null;
		}
		ushort num5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num5 > 0)
		{
			DivineFlameTargetCharacter = new CharacterDisplayData();
			pCurrData += DivineFlameTargetCharacter.Deserialize(pCurrData);
		}
		else
		{
			DivineFlameTargetCharacter = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
