using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using GameData.Utilities;

namespace GameData.Domains.Organization.TaiwuVillageStoragesRecord;

/// <summary>
/// 太吾村库房记录集合
/// </summary>
/// <summary>
/// 太吾村库房记录的集合 - 添加太吾村库房记录
/// </summary>
public class TaiwuVillageStoragesRecordCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有太吾村库房记录的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<TaiwuVillageStoragesRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			TaiwuVillageStoragesRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即太吾村库房记录模板ID）
	/// </summary>
	/// <param name="offset"></param>
	/// <returns></returns>
	public unsafe short GetRecordType(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return ((short*)(pRawData + offset + 1))[2];
		}
	}

	private unsafe int GetDate(int offset)
	{
		fixed (byte* pRawData = RawData)
		{
			return *(int*)(pRawData + offset + 1);
		}
	}

	/// <summary>
	/// 获取指定索引的太吾村库房记录的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe TaiwuVillageStoragesRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			sbyte storageType = (sbyte)(*pCurrData);
			pCurrData++;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			TaiwuVillageStoragesRecordItem config = Config.TaiwuVillageStoragesRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			TaiwuVillageStoragesRecordRenderInfo info = new TaiwuVillageStoragesRecordRenderInfo(recordType, config.Desc, date, storageType);
			int i = 0;
			for (int count = parameters.Length; i < count; i++)
			{
				string parameter = parameters[i];
				if (string.IsNullOrEmpty(parameter))
				{
					break;
				}
				sbyte paramType = ParameterType.Parse(parameter);
				int argumentIndex = ReadonlyRecordCollection.ReadArgumentAndGetIndex(paramType, &pCurrData, argumentCollection);
				info.Arguments.Add((paramType, argumentIndex));
			}
			return info;
		}
	}

	/// <summary>
	/// 开始添加太吾村库房记录
	/// </summary>
	/// <param name="date">经历发生的日期</param>
	/// <param name="storageType">库房类型</param>
	/// <param name="recordType">过月通知类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
	private unsafe int BeginAddingRecord(int date, TaiwuVillageStorageType storageType, short recordType)
	{
		int offset = Size;
		sbyte type = (sbyte)storageType;
		int newSize = Size + 1 + 4 + 1 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			(num + 1)[4] = (byte)type;
			*(short*)(num + 1 + 4 + 1) = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 取用物品
	/// {0}将{1}从公库中取出…
	/// </summary>
	public int AddTakeItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 0);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 存放物品
	/// {0}将{1}放入了公库中…
	/// </summary>
	public int AddStorageItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 1);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 存放资源
	/// {0}将{2}{1}放入了公库中…
	/// </summary>
	public int AddStorageResources(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 2);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 取用资源
	/// {0}将{2}{1}从公库中取出…
	/// </summary>
	public int AddTakeResources(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 3);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了私库中…
	/// </summary>
	public int AddGatherResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 4);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 迁移资源
	/// {0}将迁移时获得的{1}放入了私库中…
	/// </summary>
	public int AddMigrateResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 烹饪食物
	/// {0}使用厨仓中的{1}，烹制出了{2}…
	/// </summary>
	public int AddCookingIngredient(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 6);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 制造物品
	/// {0}使用工仓中的{1}，制造了{2}…
	/// </summary>
	public int AddVillagerMakingItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 修理物品
	/// {0}修理了工仓中的{1}…
	/// </summary>
	public int AddVillagerRepairItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 8);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 拆解物品
	/// {0}拆解了工仓中的{1}…
	/// </summary>
	public int AddVillagerDisassembleItem0(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 拆解物品
	/// {0}拆解工仓中的{1}时，意外获得了{2}…
	/// </summary>
	public int AddVillagerDisassembleItem1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 10);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 制造药品
	/// {0}使用药仓中的{1}，炼制了{2}…
	/// </summary>
	public int AddVillagerRefiningMedicine(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 11);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 解除毒素
	/// {0}使用药仓中的{1}，为{2}解除了毒素…
	/// </summary>
	public int AddVillagerDetoxify0(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 12);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 提取毒素
	/// {0}使用药仓中的{1}为{2}解除毒素时，提取出了{3}…
	/// </summary>
	public int AddVillagerDetoxify1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 13);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 物品淬毒
	/// {0}使用药仓中的{1}，为{2}进行淬毒…
	/// </summary>
	public int AddVillagerEnvenomedItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 14);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 游方行医
	/// {0}在{1}行医，获得了{2}{3}…
	/// </summary>
	public int AddVillagerCure(int date, TaiwuVillageStorageType storageType, int charId, Location location, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 15);
		AppendCharacter(charId);
		AppendLocation(location);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 叫卖货物
	/// {0}成功售出{1}，获得了{2}{3}…
	/// </summary>
	public int AddVillagerSoldItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 16);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采买货物
	/// {0}花费{1}{2}，购入了{3}…
	/// </summary>
	public int AddVillagerBuyItem(int date, TaiwuVillageStorageType storageType, int charId, int value, sbyte resourceType, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 17);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 经营建筑
	/// 从公库中取出{0}，用于经营{1}…
	/// </summary>
	public int AddOperatingBuilding(int date, TaiwuVillageStorageType storageType, sbyte itemType, short itemTemplateId, short buildingTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 18);
		AppendItem(itemType, itemTemplateId);
		AppendBuilding(buildingTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 清理记录
	/// &lt;color=#orange&gt;自上次清点库房之后……&lt;/color&gt;
	/// </summary>
	public int AddClearRecord(int date, TaiwuVillageStorageType storageType)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 19);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 物品淬毒
	/// {0}将{2}{3}{4}的毒素凝炼，为{1}进行了淬毒…
	/// </summary>
	public int AddEnvenomedItemOverload(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 20);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 提取毒素
	/// {0}使用药仓中的{1}为{2}解毒时，提取出了{3}{4}{5}…
	/// </summary>
	public int AddDetoxifyItemOverload(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, sbyte itemType2, short itemTemplateId2, sbyte itemType3, short itemTemplateId3, sbyte itemType4, short itemTemplateId4)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 21);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendItem(itemType2, itemTemplateId2);
		AppendItem(itemType3, itemTemplateId3);
		AppendItem(itemType4, itemTemplateId4);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了公库中…
	/// </summary>
	public int AddGatherResourcesToTreasury(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 22);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了货仓中…
	/// </summary>
	public int AddGatherResourcesToStockStorageGoodsShelf(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 23);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了厨仓中…
	/// </summary>
	public int AddGatherResourcesToFoodStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了药库中…
	/// </summary>
	public int AddGatherResourcesToMedicineStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 25);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了工库-制造中…
	/// </summary>
	public int AddGatherResourcesToCraftStorage(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 26);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 采集资源
	/// {0}将采集时获得的{1}放入了工库-拆解中…
	/// </summary>
	public int AddGatherResourcesToCraftStorageToDisassemble(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 27);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 资源遗失
	/// 因存储超过仓库容量，遗失了{1}{0}…
	/// </summary>
	public int AddLoseOverloadResources(int date, TaiwuVillageStorageType storageType, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 28);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 物品遗失
	/// 因存储超过仓库容量，遗失了{0}…
	/// </summary>
	public int AddLoseOverloadWarehouseItems(int date, TaiwuVillageStorageType storageType, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 29);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 精制引子
	/// {0}获得精制物品{1}…
	/// </summary>
	public int AddVillagerGetRefineItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 30);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 升级引子
	/// {0}经一番打磨雕镌，将精制物品{1}改制为了更高品质的…
	/// </summary>
	public int AddVillagerUpgradeRefineItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 31);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 银钱运营
	/// {0}与{1}筹算损益，获得了其{3}{2}…
	/// </summary>
	public int AddVillagerEarnMoney(int date, TaiwuVillageStorageType storageType, int charId, int charId1, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 32);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 物品掉落
	/// {0}将战胜外道邪魔后缴获的物品{1}置入公库…
	/// </summary>
	public int AddVillagerEnemyDropItem(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 33);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 资源掉落
	/// {0}将战胜外道邪魔后缴获的资源{2}{1}置入公库…
	/// </summary>
	public int AddVillagerEnemyDropResources(int date, TaiwuVillageStorageType storageType, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 34);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// {0}中的太吾村民经辛勤劳作，制成了{1}并将其置入公库…
	/// </summary>
	public int AddVillagerMakeHarvest(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 35);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// 托{1}的{0}订购的{2}已制成，并将其置入了太吾村公库…
	/// </summary>
	public int AddOutsiderMakeHarvest(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 36);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// {0}中的太吾村民经辛勤劳作，制成了{1}并将其置入私库…
	/// </summary>
	public int AddVillagerMakeHarvest1(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 37);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// 托{1}的{0}订购的{2}已制成，并将其置入了太吾村私库…
	/// </summary>
	public int AddOutsiderMakeHarvest1(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 38);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// {0}中的太吾村民经辛勤劳作，制成了{1}并将其置入货仓…
	/// </summary>
	public int AddVillagerMakeHarvest2(int date, TaiwuVillageStorageType storageType, short buildingTemplateId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 39);
		AppendBuilding(buildingTemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 预定产出
	/// 托{1}的{0}订购的{2}已制成，并将其置入了太吾村货仓…
	/// </summary>
	public int AddOutsiderMakeHarvest2(int date, TaiwuVillageStorageType storageType, int charId, short settlementId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 40);
		AppendCharacter(charId);
		AppendSettlement(settlementId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 升级引子
	/// {0}经一番打磨雕镌，将精制物品{1}改制为了{2}…
	/// </summary>
	public int AddVillagerUpgradeRefineItem1(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 41);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加太吾村库房记录 - 捐赠遗物
	/// 依照{0}的遗愿，将其生前拥有的{1}捐赠至太吾村公库…
	/// </summary>
	public int AddVillagerDonateLegacy(int date, TaiwuVillageStorageType storageType, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, storageType, 42);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
