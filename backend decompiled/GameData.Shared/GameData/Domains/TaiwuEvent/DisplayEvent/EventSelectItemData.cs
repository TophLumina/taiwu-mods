using System;
using System.Collections.Generic;
using System.Text;
using Config;
using GameData.Domains.Character.Display;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

/// <summary>
/// 选择道具弹窗数据,FilterList的Count就是要选择物品的总数量，即使是相同的物品，也会每个物品占一个SelectItemFilter元素
/// </summary>
[SerializableGameData(NoCopyConstructors = true)]
public class EventSelectItemData : ISerializableGameData
{
	private static class TradeableContentListSerializationHandler
	{
		public static int GetSerializedSize(List<ITradeableContent> target)
		{
			if (target == null)
			{
				return 2;
			}
			int size = 2;
			foreach (ITradeableContent item in target)
			{
				size++;
				size += item.GetSerializedSize();
			}
			return size;
		}

		public unsafe static int Serialize(byte* pData, List<ITradeableContent> target)
		{
			byte* pCurr = pData;
			if (target != null)
			{
				*(ushort*)pCurr = (ushort)target.Count;
				pCurr += 2;
				foreach (ITradeableContent item in target)
				{
					*pCurr = (byte)item.GetContentType();
					pCurr++;
					pCurr += item.Serialize(pCurr);
				}
			}
			else
			{
				*(short*)pCurr = 0;
				pCurr += 2;
			}
			return (int)(pCurr - pData);
		}

		public unsafe static int Deserialize(byte* pData, ref List<ITradeableContent> target)
		{
			byte* pCurr = pData;
			ushort count = *(ushort*)pCurr;
			pCurr += 2;
			if (count > 0)
			{
				if (target == null)
				{
					target = new List<ITradeableContent>(count);
				}
				target.Clear();
				for (int i = 0; i < count; i++)
				{
					sbyte type = (sbyte)(*pCurr);
					pCurr++;
					ITradeableContent item = type switch
					{
						0 => new ItemDisplayData(), 
						1 => new KidnapCharDisplayDataForInteraction(), 
						3 => new InformationDisplayDataForInteraction(), 
						2 => new InformationSecretDisplayDataForInteraction(), 
						5 => new ItemDisplayData(), 
						4 => new RawItemDisplayDataForInteraction(), 
						6 => default(ItemKey), 
						_ => new ItemDisplayData(), 
					};
					pCurr += item.Deserialize(pCurr);
					target.Add(item);
				}
			}
			else
			{
				target?.Clear();
			}
			return (int)(pCurr - pData);
		}
	}

	/// <summary>
	/// 所有可以被选择的物品显示数据列表
	/// </summary>
	[SerializableGameDataField(SerializationHandler = "TradeableContentListSerializationHandler")]
	public List<ITradeableContent> CanSelectItemList = new List<ITradeableContent>();

	/// <summary>
	/// 对选择物品的类别要求（1把武器，1个食物）之类的组合
	/// </summary>
	[SerializableGameDataField]
	public List<SelectItemFilter> FilterList = new List<SelectItemFilter>();

	/// <summary>
	/// 对筛选规则列表使用或者运算，一旦使用或者运算，则只要筛选规则列表中任意一条满足条件，整体选择过程即判定为通过
	/// </summary>
	[SerializableGameDataField]
	public bool FilterWithOrOperate;

	/// <summary>
	/// 最少选择数量；为-1时，规则与之前相同
	/// </summary>
	[SerializableGameDataField]
	public int MinSelectAmount = -1;

	/// <summary>
	/// 槽位模式
	/// </summary>
	[SerializableGameDataField]
	public bool SlotMode;

	/// <summary>
	/// 物品操作类型，参考前端的<see cref="T:GameData.Domains.Item.ItemOperationType.EItemOperationType" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemOperationType = 2;

	[SerializableGameDataField]
	public CharacterLoveAndHateItemInfo LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo
	{
		CharacterId = -1,
		LovingItemSubType = -1,
		HatingItemSubType = -1
	};

	/// <summary>
	/// 确认按钮置灰时的tips文本key，不传则没有tips
	/// </summary>
	[SerializableGameDataField]
	public string ConfirmDisableTips;

	/// <summary>
	/// 控制ItemSortAndFilter中的筛选类型，不传是全部显示
	/// </summary>
	[SerializableGameDataField]
	public List<int> VisibleItemFilterTypes;

	/// <summary>
	/// 特殊的选择道具奖励模式。必须是单选，在此模式下，前端点击一个道具格子时，自动把数量拉满。
	/// </summary>
	[SerializableGameDataField]
	public bool IsSelectingItemReward;

	/// <summary>
	/// 可拿取的资源总价值，小于0时无效
	/// </summary>
	[SerializableGameDataField]
	public int ResourceMaxValue = -1;

	/// <summary>
	/// 不显示来源Toggle
	/// Note:据反馈，后端的基本都是不需要显示物品来源的
	/// </summary>
	[SerializableGameDataField]
	public bool HideSourceToggle = true;

	/// <summary>
	/// 单行选择模式
	/// </summary>
	[SerializableGameDataField]
	public bool SingleRowMode;

	/// <summary>
	/// 只有引用相同才视为同一物品（如 选择遗物，同一个Realkey可能有多行）
	/// </summary>
	[SerializableGameDataField]
	public bool CheckSameByReferenceOnly;

	/// <summary>
	/// 选择物品界面标题
	/// </summary>
	[SerializableGameDataField]
	public int ItemTitleKey = -1;

	/// <summary>
	/// 选择物品界面 选择区域标题
	/// </summary>
	[SerializableGameDataField]
	public int ItemSelectedTitleKey = -1;

	/// <summary>
	/// 选择物品界面 已选Toggle标题
	/// </summary>
	[SerializableGameDataField]
	public int ItemSelectedToggleKey = -1;

	/// <summary>
	/// 物品选择完毕后的操作函数，可以在这个函数里进行自定义额外逻辑处理.
	/// 该字段只在后端使用.
	/// </summary>
	public Action OnSelectFinish;

	/// <summary>
	/// 是否是一个有效的选择结果
	/// </summary>
	/// <param name="selectResult"></param>
	/// <returns></returns>
	public bool IsAvailableSelectResult(List<ItemKey> selectResult)
	{
		if (selectResult == null)
		{
			return false;
		}
		if (FilterList == null || FilterList.Count <= 0)
		{
			return true;
		}
		if (!selectResult[0].IsValid())
		{
			return true;
		}
		short subType = ItemTemplateHelper.GetItemSubType(selectResult[0].ItemType, selectResult[0].TemplateId);
		if (FilterList.Count == 1 && subType == 1202)
		{
			return true;
		}
		Dictionary<ItemKey, ITradeableContent> canSelectItemMap = new Dictionary<ItemKey, ITradeableContent>(CanSelectItemList.Count);
		CanSelectItemList.ForEach(delegate(ITradeableContent e)
		{
			canSelectItemMap[e.Key] = e;
		});
		List<ItemKey> usedKeysList = new List<ItemKey>();
		for (int i = 0; i < FilterList.Count; i++)
		{
			SelectItemFilter filter = FilterList[i];
			ItemFilterRulesItem config = ItemFilterRules.Instance.GetItem(filter.FilterTemplateId);
			bool matchFlag = false;
			foreach (ItemKey itemKey in selectResult)
			{
				if (usedKeysList.Contains(itemKey))
				{
					continue;
				}
				if (filter.DisplayDataFilterId != 0)
				{
					Predicate<ITradeableContent> filterPredicate = ItemDisplayDataFilters.GetFilter(filter.DisplayDataFilterId);
					if (filterPredicate == null)
					{
						continue;
					}
					bool isMiscResource = ItemTemplateHelper.IsMiscResource(itemKey.ItemType, itemKey.TemplateId);
					bool filterIsItemTransferable = filter.DisplayDataFilterId == 2;
					if (canSelectItemMap.TryGetValue(itemKey, out var data) && ((filterIsItemTransferable && isMiscResource) || filterPredicate(data)))
					{
						matchFlag = true;
						usedKeysList.Add(itemKey);
						if (FilterWithOrOperate)
						{
							return true;
						}
					}
				}
				else if (ItemTemplateHelper.MatchItemFilterRule(itemKey.ItemType, itemKey.TemplateId, config))
				{
					matchFlag = true;
					usedKeysList.Add(itemKey);
					if (FilterWithOrOperate)
					{
						return true;
					}
					break;
				}
			}
			if (!matchFlag)
			{
				return false;
			}
		}
		return true;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 47;
		totalSize += TradeableContentListSerializationHandler.GetSerializedSize(CanSelectItemList);
		if (FilterList != null)
		{
			totalSize += 2;
			int elementsCount = FilterList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				totalSize += FilterList[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ConfirmDisableTips == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ConfirmDisableTips.Length)));
		totalSize = ((VisibleItemFilterTypes == null) ? (totalSize + 2) : (totalSize + (2 + 4 * VisibleItemFilterTypes.Count)));
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
		pCurrData += TradeableContentListSerializationHandler.Serialize(pCurrData, CanSelectItemList);
		if (FilterList != null)
		{
			int elementsCount = FilterList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int subDataSize = FilterList[i].Serialize(pCurrData);
				pCurrData += subDataSize;
				Tester.Assert(subDataSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (FilterWithOrOperate ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = MinSelectAmount;
		pCurrData += 4;
		*pCurrData = (SlotMode ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (byte)ItemOperationType;
		pCurrData++;
		pCurrData += LoveAndHateItemInfo.Serialize(pCurrData);
		if (ConfirmDisableTips != null)
		{
			int elementsCount2 = ConfirmDisableTips.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar = ConfirmDisableTips)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VisibleItemFilterTypes != null)
		{
			int elementsCount3 = VisibleItemFilterTypes.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = VisibleItemFilterTypes[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsSelectingItemReward ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ResourceMaxValue;
		pCurrData += 4;
		*pCurrData = (HideSourceToggle ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (SingleRowMode ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (CheckSameByReferenceOnly ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = ItemTitleKey;
		pCurrData += 4;
		*(int*)pCurrData = ItemSelectedTitleKey;
		pCurrData += 4;
		*(int*)pCurrData = ItemSelectedToggleKey;
		pCurrData += 4;
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
		pCurrData += TradeableContentListSerializationHandler.Deserialize(pCurrData, ref CanSelectItemList);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FilterList == null)
			{
				FilterList = new List<SelectItemFilter>(elementsCount);
			}
			else
			{
				FilterList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				SelectItemFilter element = default(SelectItemFilter);
				pCurrData += element.Deserialize(pCurrData);
				FilterList.Add(element);
			}
		}
		else
		{
			FilterList?.Clear();
		}
		FilterWithOrOperate = *pCurrData != 0;
		pCurrData++;
		MinSelectAmount = *(int*)pCurrData;
		pCurrData += 4;
		SlotMode = *pCurrData != 0;
		pCurrData++;
		ItemOperationType = (sbyte)(*pCurrData);
		pCurrData++;
		if (LoveAndHateItemInfo == null)
		{
			LoveAndHateItemInfo = new CharacterLoveAndHateItemInfo();
		}
		pCurrData += LoveAndHateItemInfo.Deserialize(pCurrData);
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize = 2 * elementsCount2;
			ConfirmDisableTips = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			ConfirmDisableTips = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (VisibleItemFilterTypes == null)
			{
				VisibleItemFilterTypes = new List<int>(elementsCount3);
			}
			else
			{
				VisibleItemFilterTypes.Clear();
			}
			for (int j = 0; j < elementsCount3; j++)
			{
				VisibleItemFilterTypes.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			VisibleItemFilterTypes?.Clear();
		}
		IsSelectingItemReward = *pCurrData != 0;
		pCurrData++;
		ResourceMaxValue = *(int*)pCurrData;
		pCurrData += 4;
		HideSourceToggle = *pCurrData != 0;
		pCurrData++;
		SingleRowMode = *pCurrData != 0;
		pCurrData++;
		CheckSameByReferenceOnly = *pCurrData != 0;
		pCurrData++;
		ItemTitleKey = *(int*)pCurrData;
		pCurrData += 4;
		ItemSelectedTitleKey = *(int*)pCurrData;
		pCurrData += 4;
		ItemSelectedToggleKey = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
