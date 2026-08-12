using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.Story.MainStory;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Map;

/// <summary>
/// 地块数据
/// </summary>
public class MapBlockData : ISerializableGameData
{
	/// <summary>
	/// 所属区域ID
	/// </summary>
	[SerializableGameDataField]
	public short AreaId;

	/// <summary>
	/// 在本地区（Area）的位置索引
	/// </summary>
	[SerializableGameDataField]
	public short BlockId;

	/// <summary>
	/// 模板数据ID[MapBlock]
	/// </summary>
	[SerializableGameDataField]
	public short TemplateId;

	/// <summary>
	/// 在本区域所属地块的地块Id位置索引
	/// </summary>
	[SerializableGameDataField]
	public short BelongBlockId;

	/// <summary>
	/// 本地块为虚地块时，所属根地块的ID，非虚地块为-1
	/// </summary>
	[SerializableGameDataField]
	public short RootBlockId;

	/// <summary>
	/// 是否可见
	/// </summary>
	[SerializableGameDataField]
	public bool Visible;

	/// <summary>
	/// 地块上的人物集合, 可能为 null
	/// </summary>
	[SerializableGameDataField]
	public HashSet<int> CharacterSet;

	/// <summary>
	/// 地块上的入魔人集合，可能为 null
	/// </summary>
	[SerializableGameDataField]
	public HashSet<int> InfectedCharacterSet;

	/// <summary>
	/// 地块上的 特殊 人物集合, 可能为 null
	/// </summary>
	[SerializableGameDataField]
	public HashSet<int> FixedCharacterSet;

	/// <summary>
	/// 地块上的坟墓集合, 可能为 null
	/// </summary>
	[SerializableGameDataField]
	public HashSet<int> GraveSet;

	/// <summary>
	/// 地块上无实例的模板敌人列表, 可能为 null
	/// </summary>
	[SerializableGameDataField]
	public List<MapTemplateEnemyInfo> TemplateEnemyList;

	/// <summary>
	/// 地块上的有实例的敌人列表
	/// </summary>
	[SerializableGameDataField]
	public HashSet<int> EnemyCharacterSet;

	/// <summary>
	/// 当前戾气值
	/// </summary>
	[SerializableGameDataField]
	public short Malice;

	/// <summary>
	/// 是否被破坏
	/// </summary>
	[SerializableGameDataField]
	public bool Destroyed;

	/// <summary>
	/// 资源上限
	/// </summary>
	[SerializableGameDataField]
	public MaterialResources MaxResources;

	/// <summary>
	/// 当前资源
	/// </summary>
	[SerializableGameDataField]
	public MaterialResources CurrResources;

	/// <summary>
	/// 地块上的道具集合, 可能为 null.
	/// (损毁日期, ItemKey) -&gt; 数量.
	/// </summary>
	[SerializableGameDataField]
	public SortedList<ItemKeyAndDate, int> Items;

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据
	/// </summary>
	private static readonly LocalObjectPool<HashSet<int>> IntHashSetPool = new LocalObjectPool<HashSet<int>>(6144, 30720);

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据
	/// </summary>
	private static readonly LocalObjectPool<List<MapTemplateEnemyInfo>> RandomEnemyListPool = new LocalObjectPool<List<MapTemplateEnemyInfo>>(3072, 15360);

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据.
	/// 可能在子线程修改因此改为了现成安全的对象池.
	/// </summary>
	private static readonly ObjectPool<SortedList<ItemKeyAndDate, int>> ItemCollectionPool = new ObjectPool<SortedList<ItemKeyAndDate, int>>(3072, 15360);

	/// <summary>
	/// 从属于本地块的虚地块列表
	/// </summary>
	public List<MapBlockData> GroupBlockList;

	/// <summary>
	/// 地格最大道具数量
	/// </summary>
	public const int MaxBlockItemCount = 500;

	/// <summary>
	/// 显示毁坏效果
	/// </summary>
	public bool ShowDestroyed
	{
		get
		{
			if (Destroyed)
			{
				return !GetConfig().IgnoreDestroyed;
			}
			return false;
		}
	}

	/// <summary>
	/// 通行消耗
	/// </summary>
	public sbyte MoveCost => GetConfig()?.MoveCost ?? (-1);

	/// <summary>
	/// 通行消耗行动力
	/// </summary>
	public int MoveCostActionPoint
	{
		get
		{
			int cost = MoveCost * 10;
			if (cost <= 0)
			{
				return cost;
			}
			cost *= ExternalDataBridge.Context.MoveTimeCostPercent;
			TwelveImmortalsCacheData cache = ExternalDataBridge.Context.TwelveImmortalsCache;
			Dictionary<Location, int> moveCostMultiplier = cache.MoveCostMultiplier;
			if (moveCostMultiplier != null && moveCostMultiplier.Count > 0)
			{
				cost *= cache.MoveCostMultiplier.GetOrDefault(GetLocation(), 1);
			}
			return Math.Max(1, cost);
		}
	}

	/// <summary>
	/// 地块大类
	/// </summary>
	public EMapBlockType BlockType => GetConfig()?.Type ?? EMapBlockType.Invalid;

	/// <summary>
	/// 地块细类
	/// </summary>
	public EMapBlockSubType BlockSubType => GetConfig()?.SubType ?? EMapBlockSubType.Invalid;

	public MapBlockData(short areaId, short blockId, short templateId)
	{
		AreaId = areaId;
		BlockId = blockId;
		TemplateId = templateId;
		BelongBlockId = -1;
		RootBlockId = -1;
		Visible = false;
	}

	/// <summary>
	/// 简单复制，只有基本数据，不包含集合数据
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public static MapBlockData SimpleClone(MapBlockData other)
	{
		return new MapBlockData
		{
			AreaId = other.AreaId,
			BlockId = other.BlockId,
			TemplateId = other.TemplateId,
			BelongBlockId = other.BelongBlockId,
			RootBlockId = other.RootBlockId,
			Visible = other.Visible
		};
	}

	public MapBlockData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public unsafe int GetSerializedSize()
	{
		int totalSize = 38;
		totalSize = ((CharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * CharacterSet.Count)));
		totalSize = ((InfectedCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * InfectedCharacterSet.Count)));
		totalSize = ((FixedCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FixedCharacterSet.Count)));
		totalSize = ((GraveSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * GraveSet.Count)));
		totalSize = ((TemplateEnemyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * TemplateEnemyList.Count)));
		totalSize = ((EnemyCharacterSet == null) ? (totalSize + 2) : (totalSize + (2 + 4 * EnemyCharacterSet.Count)));
		totalSize = ((Items == null) ? (totalSize + 2) : (totalSize + (2 + (4 + sizeof(ItemKey) + 4) * Items.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = AreaId;
		pCurrData += 2;
		*(short*)pCurrData = BlockId;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*(short*)pCurrData = BelongBlockId;
		pCurrData += 2;
		*(short*)pCurrData = RootBlockId;
		pCurrData += 2;
		*pCurrData = (Visible ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (CharacterSet != null)
		{
			int elementsCount = CharacterSet.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (int charId in CharacterSet)
			{
				*(int*)pCurrData = charId;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InfectedCharacterSet != null)
		{
			int elementsCount2 = InfectedCharacterSet.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			foreach (int charId2 in InfectedCharacterSet)
			{
				*(int*)pCurrData = charId2;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FixedCharacterSet != null)
		{
			int elementsCount3 = FixedCharacterSet.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			foreach (int charId3 in FixedCharacterSet)
			{
				*(int*)pCurrData = charId3;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GraveSet != null)
		{
			int elementsCount4 = GraveSet.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			foreach (int charId4 in GraveSet)
			{
				*(int*)pCurrData = charId4;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (TemplateEnemyList != null)
		{
			int elementsCount5 = TemplateEnemyList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int i = 0; i < elementsCount5; i++)
			{
				pCurrData += TemplateEnemyList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EnemyCharacterSet != null)
		{
			int elementsCount6 = EnemyCharacterSet.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			foreach (int charId5 in EnemyCharacterSet)
			{
				*(int*)pCurrData = charId5;
				pCurrData += 4;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = Malice;
		pCurrData += 2;
		*pCurrData = (Destroyed ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += MaxResources.Serialize(pCurrData);
		pCurrData += CurrResources.Serialize(pCurrData);
		if (Items != null)
		{
			int elementsCount7 = Items.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			IList<ItemKeyAndDate> keys = Items.Keys;
			IList<int> values = Items.Values;
			for (int j = 0; j < elementsCount7; j++)
			{
				pCurrData += keys[j].Serialize(pCurrData);
				*(int*)pCurrData = values[j];
				pCurrData += 4;
			}
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
		AreaId = *(short*)pCurrData;
		pCurrData += 2;
		BlockId = *(short*)pCurrData;
		pCurrData += 2;
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		BelongBlockId = *(short*)pCurrData;
		pCurrData += 2;
		RootBlockId = *(short*)pCurrData;
		pCurrData += 2;
		Visible = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (CharacterSet == null)
			{
				CharacterSet = IntHashSetPool.Get();
			}
			else
			{
				CharacterSet.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				int charId = *(int*)pCurrData;
				pCurrData += 4;
				CharacterSet.Add(charId);
			}
		}
		else
		{
			CharacterSet?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (InfectedCharacterSet == null)
			{
				InfectedCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				InfectedCharacterSet.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				int charId2 = *(int*)pCurrData;
				pCurrData += 4;
				InfectedCharacterSet.Add(charId2);
			}
		}
		else
		{
			InfectedCharacterSet?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FixedCharacterSet == null)
			{
				FixedCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				FixedCharacterSet.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				int charId3 = *(int*)pCurrData;
				pCurrData += 4;
				FixedCharacterSet.Add(charId3);
			}
		}
		else
		{
			FixedCharacterSet?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (GraveSet == null)
			{
				GraveSet = IntHashSetPool.Get();
			}
			else
			{
				GraveSet.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				int charId4 = *(int*)pCurrData;
				pCurrData += 4;
				GraveSet.Add(charId4);
			}
		}
		else
		{
			GraveSet?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (TemplateEnemyList == null)
			{
				TemplateEnemyList = RandomEnemyListPool.Get();
			}
			else
			{
				TemplateEnemyList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				MapTemplateEnemyInfo element = default(MapTemplateEnemyInfo);
				pCurrData += element.Deserialize(pCurrData);
				TemplateEnemyList.Add(element);
			}
		}
		else
		{
			TemplateEnemyList?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (EnemyCharacterSet == null)
			{
				EnemyCharacterSet = IntHashSetPool.Get();
			}
			else
			{
				EnemyCharacterSet.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				int charId5 = *(int*)pCurrData;
				pCurrData += 4;
				EnemyCharacterSet.Add(charId5);
			}
		}
		else
		{
			EnemyCharacterSet?.Clear();
		}
		Malice = *(short*)pCurrData;
		pCurrData += 2;
		Destroyed = *pCurrData != 0;
		pCurrData++;
		pCurrData += MaxResources.Deserialize(pCurrData);
		pCurrData += CurrResources.Deserialize(pCurrData);
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (Items == null)
			{
				Items = ItemCollectionPool.Get();
			}
			else
			{
				Items.Clear();
			}
			for (int num = 0; num < elementsCount7; num++)
			{
				ItemKeyAndDate itemKeyAndDate = default(ItemKeyAndDate);
				pCurrData += itemKeyAndDate.Deserialize(pCurrData);
				int amount = *(int*)pCurrData;
				pCurrData += 4;
				Items.Add(itemKeyAndDate, amount);
			}
		}
		else
		{
			Items?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 使地格毁坏
	/// </summary>
	public void MakeDestroyed(List<ItemKey> destroyedUniqueItems)
	{
		if (GetConfig().Size <= 1)
		{
			Destroyed = true;
			CurrResources.Initialize();
			DestroyItemsDirect(destroyedUniqueItems);
		}
	}

	/// <summary>
	/// 结束毁坏状态 - 重置资源
	/// </summary>
	public void StopDestroyedByInitResources(IRandomSource random)
	{
		Destroyed = false;
		InitResources(random);
	}

	/// <summary>
	/// 结束毁坏状态 - 恢复资源
	/// </summary>
	public void StopDestroyedByRecover()
	{
		if (Destroyed && CurrResources.GetSum() > MaxResources.GetSum() / 2)
		{
			Destroyed = false;
		}
	}

	/// <summary>
	/// 添加角色
	/// </summary>
	/// <param name="charId"></param>
	public void AddCharacter(int charId)
	{
		if (CharacterSet == null)
		{
			CharacterSet = IntHashSetPool.Get();
		}
		CharacterSet.Add(charId);
	}

	/// <summary>
	/// 移除角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>是否找到并移除了指定项</returns>
	public bool RemoveCharacter(int charId)
	{
		if (CharacterSet != null && CharacterSet.Remove(charId))
		{
			if (CharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(CharacterSet);
				CharacterSet = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 添加入魔角色
	/// </summary>
	/// <param name="charId"></param>
	public void AddInfectedCharacter(int charId)
	{
		if (InfectedCharacterSet == null)
		{
			InfectedCharacterSet = IntHashSetPool.Get();
		}
		InfectedCharacterSet.Add(charId);
	}

	/// <summary>
	/// 移除入魔角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public bool RemoveInfectedCharacter(int charId)
	{
		if (InfectedCharacterSet != null && InfectedCharacterSet.Remove(charId))
		{
			if (InfectedCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(InfectedCharacterSet);
				InfectedCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 添加特殊角色
	/// </summary>
	/// <param name="charId"></param>
	public void AddFixedCharacter(int charId)
	{
		if (FixedCharacterSet == null)
		{
			FixedCharacterSet = IntHashSetPool.Get();
		}
		FixedCharacterSet.Add(charId);
	}

	/// <summary>
	/// 移除特殊角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>是否找到并移除了指定项</returns>
	public bool RemoveFixedCharacter(int charId)
	{
		if (FixedCharacterSet != null && FixedCharacterSet.Remove(charId))
		{
			if (FixedCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(FixedCharacterSet);
				FixedCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 添加实例敌人角色
	/// </summary>
	/// <param name="charId"></param>
	public void AddEnemyCharacter(int charId)
	{
		if (EnemyCharacterSet == null)
		{
			EnemyCharacterSet = IntHashSetPool.Get();
		}
		EnemyCharacterSet.Add(charId);
	}

	/// <summary>
	/// 移除实例敌人角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>是否找到并移除了指定项</returns>
	public bool RemoveEnemyCharacter(int charId)
	{
		if (EnemyCharacterSet != null && EnemyCharacterSet.Remove(charId))
		{
			if (EnemyCharacterSet.Count <= 0)
			{
				IntHashSetPool.Return(EnemyCharacterSet);
				EnemyCharacterSet = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 添加坟墓
	/// </summary>
	/// <param name="charId"></param>
	public void AddGrave(int charId)
	{
		if (GraveSet == null)
		{
			GraveSet = IntHashSetPool.Get();
		}
		GraveSet.Add(charId);
	}

	/// <summary>
	/// 移除坟墓
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>是否找到并移除了指定项</returns>
	public bool RemoveGrave(int charId)
	{
		if (GraveSet != null && GraveSet.Remove(charId))
		{
			if (GraveSet.Count <= 0)
			{
				IntHashSetPool.Return(GraveSet);
				GraveSet = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 存在指定的无实例模板敌人
	/// </summary>
	public bool AnyTemplateEnemy(short templateId)
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		foreach (MapTemplateEnemyInfo templateEnemy in TemplateEnemyList)
		{
			if (templateEnemy.TemplateId == templateId)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 存在范围内的无实例模板敌人
	/// </summary>
	public bool AnyTemplateEnemy(short templateIdMin, short templateIdMax)
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		foreach (MapTemplateEnemyInfo enemyInfo in TemplateEnemyList)
		{
			if (enemyInfo.TemplateId >= templateIdMin && enemyInfo.TemplateId <= templateIdMax)
			{
				return true;
			}
		}
		return false;
	}

	/// <summary>
	/// 添加无实例的模板敌人
	/// </summary>
	public void AddTemplateEnemy(MapTemplateEnemyInfo mapTemplateEnemyInfo)
	{
		if (TemplateEnemyList == null)
		{
			TemplateEnemyList = RandomEnemyListPool.Get();
		}
		TemplateEnemyList.Add(mapTemplateEnemyInfo);
	}

	/// <summary>
	/// 移除随机敌人
	/// </summary>
	/// <param name="templateEnemyInfo"></param>
	/// <returns>是否找到并移除了指定项</returns>
	public bool RemoveTemplateEnemy(MapTemplateEnemyInfo templateEnemyInfo)
	{
		if (TemplateEnemyList != null && TemplateEnemyList.Remove(templateEnemyInfo))
		{
			if (TemplateEnemyList.Count <= 0)
			{
				RandomEnemyListPool.Return(TemplateEnemyList);
				TemplateEnemyList = null;
			}
			return true;
		}
		return false;
	}

	/// <summary>
	/// 全体随机敌人持续时间-=1
	/// </summary>
	/// <returns>TemplateEnemyList是否发生了改变</returns>
	public bool CountDown()
	{
		if (TemplateEnemyList == null)
		{
			return false;
		}
		bool modified = false;
		int i = TemplateEnemyList.Count;
		while (i-- > 0)
		{
			if (TemplateEnemyList[i].Duration > 0)
			{
				MapTemplateEnemyInfo tmp = TemplateEnemyList[i];
				tmp.Duration--;
				if (tmp.Duration == 0)
				{
					TemplateEnemyList.RemoveAt(i);
				}
				else
				{
					TemplateEnemyList[i] = tmp;
				}
				modified = true;
			}
		}
		return modified;
	}

	/// <summary>
	/// 添加单个物品. 需要调用者修改该道具的持有者状态.
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="amount"></param>
	public void AddItem(ItemKey itemKey, int amount)
	{
		if (Items == null)
		{
			Items = ItemCollectionPool.Get();
		}
		int currDate = ExternalDataBridge.Context.CurrDate;
		ItemKeyAndDate itemKeyAndDate = new ItemKeyAndDate(GetDestroyedDate(itemKey, currDate), itemKey);
		if (Items.TryGetValue(itemKeyAndDate, out var oriAmount))
		{
			Items[itemKeyAndDate] = oriAmount + amount;
		}
		else
		{
			Items.Add(itemKeyAndDate, amount);
		}
	}

	/// <summary>
	/// 移除地块道具. 需要调用者修改该道具的持有者状态.
	/// </summary>
	/// <param name="itemKeyAndDate"></param>
	public void RemoveItem(ItemKeyAndDate itemKeyAndDate)
	{
		if (Items != null)
		{
			Items.Remove(itemKeyAndDate);
			if (Items.Count == 0)
			{
				ItemCollectionPool.Return(Items);
				Items = null;
			}
		}
	}

	/// <summary>
	/// 从地格移除指定数量的某种物品. 需要调用者修改该道具的持有者状态.
	/// </summary>
	/// <param name="itemKeyAndDate"></param>
	/// <param name="count"></param>
	public void RemoveItemByCount(ItemKeyAndDate itemKeyAndDate, int count)
	{
		if (Items[itemKeyAndDate] <= count)
		{
			RemoveItem(itemKeyAndDate);
		}
		else
		{
			Items[itemKeyAndDate] -= count;
		}
	}

	public void AddItems(List<(ItemKey itemKey, int amount)> items)
	{
		if (Items == null)
		{
			Items = ItemCollectionPool.Get();
		}
		int currDate = ExternalDataBridge.Context.CurrDate;
		int i = 0;
		for (int count = items.Count; i < count; i++)
		{
			(ItemKey itemKey, int amount) tuple = items[i];
			ItemKey itemKey = tuple.itemKey;
			int amount = tuple.amount;
			ItemKeyAndDate itemKeyAndDate = new ItemKeyAndDate(GetDestroyedDate(itemKey, currDate), itemKey);
			if (Items.TryGetValue(itemKeyAndDate, out var oriAmount))
			{
				Items[itemKeyAndDate] = oriAmount + amount;
			}
			else
			{
				Items.Add(itemKeyAndDate, amount);
			}
		}
	}

	/// <summary>
	/// 地块物品损毁.
	/// 损毁的物品不直接删除, 而是放入传入的集合中.
	/// </summary>
	/// <param name="currDate">截至日期. 摧毁日期超过该数字的道具不会被摧毁.</param>
	/// <param name="destroyedUniqueItems"></param>
	/// <returns>是否修改了此对象</returns>
	private bool DestroyItemsByDate(int currDate, List<ItemKey> destroyedUniqueItems)
	{
		if (Items == null || Items.Count <= 0)
		{
			return false;
		}
		IList<ItemKeyAndDate> keys = Items.Keys;
		int itemCount = Items.Count;
		int lastIndexToBeRemoved = -1;
		for (int i = 0; i < itemCount && keys[i].Date <= currDate; i++)
		{
			lastIndexToBeRemoved = i;
		}
		if (lastIndexToBeRemoved < 0)
		{
			return false;
		}
		for (int j = 0; j <= lastIndexToBeRemoved; j++)
		{
			ItemKey itemKey = keys[j].ItemKey;
			if (!ItemTemplateHelper.IsPureStackable(itemKey))
			{
				destroyedUniqueItems.Add(itemKey);
			}
		}
		if (lastIndexToBeRemoved < itemCount - 1)
		{
			SortedList<ItemKeyAndDate, int> newItems = ItemCollectionPool.Get();
			IList<int> values = Items.Values;
			for (int k = lastIndexToBeRemoved + 1; k < itemCount; k++)
			{
				newItems.Add(keys[k], values[k]);
			}
			Items.Clear();
			ItemCollectionPool.Return(Items);
			Items = newItems;
		}
		else
		{
			Items.Clear();
			ItemCollectionPool.Return(Items);
			Items = null;
		}
		return true;
	}

	/// <summary>
	/// 地块物品摧毁.
	/// 以当前游戏中的日期为截至时间, 摧毁该时间以及该时间之前的物品.
	/// 损毁的物品不直接删除, 而是放入传入的集合中.
	/// </summary>
	/// <param name="destroyedUniqueItems"></param>
	/// <returns></returns>
	public bool DestroyItems(List<ItemKey> destroyedUniqueItems)
	{
		int currDate = ExternalDataBridge.Context.CurrDate;
		return DestroyItemsByDate(currDate, destroyedUniqueItems);
	}

	/// <summary>
	/// 地块物品损毁.
	/// 无视日期.
	/// 损毁的物品不直接删除, 而是放入传入的集合中.
	/// </summary>
	/// <returns>是否修改了此对象</returns>
	public bool DestroyItemsDirect(List<ItemKey> destroyedUniqueItems)
	{
		return DestroyItemsByDate(2147483646, destroyedUniqueItems);
	}

	/// <summary>
	/// 获取物品的损毁日期 (假如从指定日期开始变为无主的话)
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="date"></param>
	/// <returns></returns>
	public static int GetDestroyedDate(ItemKey itemKey, int date)
	{
		short preserveDuration = ItemTemplateHelper.GetPreservationDuration(itemKey.ItemType, itemKey.TemplateId);
		if (preserveDuration < 0)
		{
			return int.MaxValue;
		}
		return date + preserveDuration;
	}

	/// <summary>
	/// 获取配置表
	/// </summary>
	public MapBlockItem GetConfig()
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock()?.GetConfig();
		}
		return MapBlock.Instance[TemplateId];
	}

	public ResourceCollectionItem GetResourceCollectionConfig()
	{
		return ResourceCollection.Instance[GetConfig().ResourceCollectionType];
	}

	/// <summary>
	/// 获取位置
	/// </summary>
	/// <returns>地块的位置</returns>
	public Location GetLocation()
	{
		return new Location(AreaId, BlockId);
	}

	/// <summary>
	/// 获取坐标
	/// </summary>
	public ByteCoordinate GetBlockPos()
	{
		byte mapSize = ExternalDataBridge.Context.GetAreaSize(AreaId);
		return ByteCoordinate.IndexToCoordinate(BlockId, mapSize);
	}

	/// <summary>
	/// 是否主城门派或城镇关寨
	/// </summary>
	public bool IsCityTown()
	{
		if (BlockType != EMapBlockType.City && BlockType != EMapBlockType.Sect)
		{
			return BlockType == EMapBlockType.Town;
		}
		return true;
	}

	/// <summary>
	/// 村庄
	/// </summary>
	/// <returns></returns>
	public bool IsVillage()
	{
		return BlockSubType == EMapBlockSubType.Village;
	}

	/// <summary>
	/// 太吾村
	/// </summary>
	/// <returns></returns>
	public bool IsTaiwuCun()
	{
		return BlockSubType == EMapBlockSubType.TaiwuCun;
	}

	/// <summary>
	/// 是否未开化地形
	/// </summary>
	/// <returns></returns>
	public bool IsNonDeveloped()
	{
		EMapBlockType t = BlockType;
		if (t != EMapBlockType.Normal && t != EMapBlockType.Wild && t != EMapBlockType.Bad)
		{
			return t == EMapBlockType.scenery;
		}
		return true;
	}

	/// <summary>
	/// 是否可以通行
	/// </summary>
	public bool IsPassable()
	{
		return MoveCost >= 0;
	}

	/// <summary>
	/// 是否可以被替换成别的地块类型
	/// </summary>
	public bool CanChangeBlockType()
	{
		if (TemplateId != 126 && RootBlockId == -1)
		{
			return !IsCityTown();
		}
		return false;
	}

	/// <summary>
	/// 是否可以采集指定类型的资源
	/// </summary>
	/// <param name="resourceType"></param>
	/// <returns></returns>
	public bool CanCollectResource(sbyte resourceType)
	{
		if (GetConfig().ResourceCollectionType >= 0)
		{
			return MaxResources[resourceType] > 0;
		}
		return false;
	}

	/// <summary>
	/// 获取当前地块的最大戾气值
	/// </summary>
	/// <returns></returns>
	public short GetMaxMalice()
	{
		return GetConfig().MaxMalice;
	}

	/// <summary>
	/// 动物生成的基础概率。
	/// 当前资源总数 /
	/// </summary>
	/// <returns></returns>
	public int GetAnimalBaseSpawnRate()
	{
		int sum = CurrResources.GetSum();
		int totalMaxRes = MaxResources.GetSum();
		return sum * 10 / totalMaxRes;
	}

	/// <summary>
	/// 获取地块所属组的根地块，如果不属于任何组则返回自身
	/// </summary>
	public MapBlockData GetRootBlock()
	{
		if (RootBlockId >= 0)
		{
			return ExternalDataBridge.Context.GetBlockData(new Location(AreaId, RootBlockId));
		}
		return this;
	}

	/// <summary>
	/// 获取指定坐标距离该地块(组)的曼哈顿距离
	/// </summary>
	public byte GetManhattanDistanceToPos(byte x, byte y)
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock().GetManhattanDistanceToPos(x, y);
		}
		ByteCoordinate targetByteCoordinate = new ByteCoordinate(x, y);
		int minManhattan = GetBlockPos().GetManhattanDistance(targetByteCoordinate);
		Location location = new Location(AreaId, BlockId);
		IEnumerable<short> groupBlockIds = ExternalDataBridge.Context.GetGroupBlockIds(location, this);
		byte mapSize = ExternalDataBridge.Context.GetAreaSize(AreaId);
		foreach (short item in groupBlockIds)
		{
			int blockManhattan = ByteCoordinate.IndexToCoordinate(item, mapSize).GetManhattanDistance(targetByteCoordinate);
			if (blockManhattan < minManhattan)
			{
				minManhattan = blockManhattan;
			}
		}
		return (byte)minManhattan;
	}

	/// <summary>
	/// 计算此地格与某位置的距离，不检查根地块
	/// </summary>
	public byte GetManhattanDistanceToPosWithoutRoot(byte x, byte y)
	{
		ByteCoordinate targetByteCoordinate = new ByteCoordinate(x, y);
		return (byte)GetBlockPos().GetManhattanDistance(targetByteCoordinate);
	}

	/// <summary>
	/// 获取采集到道具的几率
	/// </summary>
	/// <param name="resourceType"></param>
	/// <returns></returns>
	public unsafe int GetCollectItemChance(sbyte resourceType)
	{
		if (MaxResources.Items[resourceType] <= 0)
		{
			return 0;
		}
		return CurrResources.Items[resourceType] * 100 / MaxResources.Items[resourceType] - 25;
	}

	/// <summary>
	/// 计算在该地格采集资源的收获量
	/// </summary>
	public unsafe int GetCollectResourceAmount(sbyte resourceType)
	{
		return CurrResources.Items[resourceType] * GlobalConfig.Instance.CollectResourcePercent / 100 * GameData.Domains.World.SharedMethods.GetGainResourcePercent(2) / 100;
	}

	/// <summary>
	/// 获得该地格在大地格中的索引
	/// </summary>
	public int GetBlockIndexInBigBlock(byte areaSize)
	{
		MapBlockItem configData = GetConfig();
		if (configData != null && configData.Size > 1)
		{
			if (RootBlockId < 0)
			{
				if (configData.Size != 2)
				{
					return 6;
				}
				return 2;
			}
			int offset = BlockId - RootBlockId;
			if (configData.Size == 2)
			{
				if (offset != 1)
				{
					return (offset != areaSize) ? 1 : 0;
				}
				return 3;
			}
			switch (offset)
			{
			default:
				if (offset != areaSize)
				{
					if (offset != areaSize + 1)
					{
						if (offset != areaSize + 2)
						{
							if (offset != areaSize * 2)
							{
								if (offset != areaSize * 2 + 1)
								{
									return 2;
								}
								return 1;
							}
							return 0;
						}
						return 5;
					}
					return 4;
				}
				return 3;
			case 2:
				return 8;
			case 1:
				return 7;
			}
		}
		return -1;
	}

	public override string ToString()
	{
		return $"MapBlockData({AreaId},{BlockId})";
	}

	/// <summary>
	/// 初始化资源
	/// </summary>
	public unsafe void InitResources(IRandomSource random)
	{
		MapBlockItem configData = GetConfig();
		if (configData == null)
		{
			return;
		}
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			short maxResource = configData.Resources[resourceType];
			if (maxResource < 0)
			{
				maxResource = (short)(random.Next(Math.Abs(maxResource) / 2, Math.Abs(maxResource) + 1) * 5);
			}
			else if (maxResource != 0 && random.CheckPercentProb(50))
			{
				maxResource = (short)Math.Max(random.CheckPercentProb(35) ? (maxResource + random.Next(1, 6) * 5) : (maxResource - random.Next(1, 6) * 5), 0);
			}
			MaxResources.Items[resourceType] = maxResource;
			CurrResources.Items[resourceType] = (short)(maxResource * random.Next(50, 75) / 100 * GameData.Domains.World.SharedMethods.GetGainResourcePercent(0) / 100);
		}
	}

	/// <summary>
	/// 转换为指定类型的地块
	/// </summary>
	public void ChangeTemplateId(short newPresetId, bool checkCanChange = true)
	{
		if (!checkCanChange || CanChangeBlockType())
		{
			TemplateId = newPresetId;
			return;
		}
		throw new Exception($"{BlockSubType} can not change PresetId!");
	}

	/// <summary>
	/// 转换为某地块的从属虚地块
	/// </summary>
	public void SetToSizeBlock(MapBlockData groupRoot)
	{
		if (groupRoot != null)
		{
			TemplateId = groupRoot.TemplateId;
			RootBlockId = groupRoot.BlockId;
			if (groupRoot.GroupBlockList == null)
			{
				groupRoot.GroupBlockList = new List<MapBlockData>();
			}
			if (!groupRoot.GroupBlockList.Contains(this))
			{
				groupRoot.GroupBlockList.Add(this);
			}
		}
	}

	/// <summary>
	/// 获取采集道具的模板ID
	/// </summary>
	/// <param name="random"></param>
	/// <param name="resourceType"></param>
	/// <returns></returns>
	public short GetCollectItemTemplateId(IRandomSource random, sbyte resourceType)
	{
		ResourceCollectionItem collectionConfig = GetResourceCollectionConfig();
		if (collectionConfig == null || collectionConfig.ItemIdList == null || !collectionConfig.ItemIdList.CheckIndex(resourceType))
		{
			return -1;
		}
		List<short> itemList = collectionConfig.ItemIdList[resourceType].DataList;
		if (resourceType == 5)
		{
			List<Config.ShortList> itemIdList = collectionConfig.ItemIdList;
			Config.ShortList poisons = itemIdList[itemIdList.Count - 1];
			if (poisons.DataList.Count > 0 && random.CheckPercentProb(40))
			{
				itemList = poisons.DataList;
			}
		}
		if (itemList.Count == 0)
		{
			return -1;
		}
		return itemList[random.Next(0, itemList.Count)];
	}

	/// <summary>
	/// 获取所属组地块中距离目标坐标最近的一个地块
	/// </summary>
	public MapBlockData GetNearestBlockToTarget(ByteCoordinate pos)
	{
		if (RootBlockId >= 0)
		{
			return GetRootBlock().GetNearestBlockToTarget(pos);
		}
		MapBlockData target = this;
		int minManhattan = target.GetBlockPos().GetManhattanDistance(pos);
		if (GroupBlockList != null)
		{
			for (int i = 0; i < GroupBlockList.Count; i++)
			{
				MapBlockData block = GroupBlockList[i];
				int blockManhattan = block.GetBlockPos().GetManhattanDistance(pos);
				if (blockManhattan < minManhattan)
				{
					minManhattan = blockManhattan;
					target = block;
				}
			}
		}
		return target;
	}

	/// <summary>
	/// 计算寻宝成功率(用指定的物品数目)
	/// </summary>
	public int CalcFindTreasureChanceByItemsCount(sbyte luck, int itemsCount)
	{
		return itemsCount * (100 + luck * 3) / 100;
	}

	/// <summary>
	/// 计算寻宝成功率
	/// </summary>
	public int CalcFindTreasureChance(sbyte luck)
	{
		if (Items != null)
		{
			return CalcFindTreasureChanceByItemsCount(luck, Items.Count);
		}
		return 0;
	}
}
