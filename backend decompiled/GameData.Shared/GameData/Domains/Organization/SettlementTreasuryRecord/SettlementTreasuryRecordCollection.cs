using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Organization.SettlementTreasuryRecord;

/// <summary>
/// 库房记录集合
/// </summary>
/// <summary>
/// 定居点库房记录的集合 - 添加库房记录
/// </summary>
public class SettlementTreasuryRecordCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有库房的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<SettlementTreasuryRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SettlementTreasuryRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即库房模板ID）
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
	/// 获取指定索引的库房记录的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe SettlementTreasuryRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short settlementId = *(short*)pCurrData;
			pCurrData += 2;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			SettlementTreasuryRecordItem config = Config.SettlementTreasuryRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SettlementTreasuryRecordRenderInfo info = new SettlementTreasuryRecordRenderInfo(recordType, config.Desc, date, settlementId);
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
	/// 开始添加库房记录
	/// </summary>
	/// <param name="date">经历发生的日期</param>
	/// <param name="settlementId">定居点ID</param>
	/// <param name="recordType">过月通知类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
	private unsafe int BeginAddingRecord(int date, short settlementId, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = settlementId;
			((short*)(num + 1 + 4))[1] = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 库房进货
	/// 清点库存后，库房补充了一批资源…
	/// </summary>
	public int AddSupplementResource(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 0);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 库房进货
	/// 清点库存后，库房补充了一批物品…
	/// </summary>
	public int AddSupplementItem(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 存放资源
	/// {0}赠予了{2}{1}，获得了{3}贡献…
	/// </summary>
	public int AddStorageResource(int date, short settlementId, int charId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 2);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 存放物品
	/// {0}赠予了{1}，获得了{2}贡献…
	/// </summary>
	public int AddStorageItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 3);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 取用资源
	/// {0}取用了{2}{1}，消耗了{3}贡献…
	/// </summary>
	public int AddTakeOutResource(int date, short settlementId, int charId, sbyte resourceType, int value, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 4);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 取用物品
	/// {0}取用了{1}，消耗了{2}贡献…
	/// </summary>
	public int AddTakeOutItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 5);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 存放资源
	/// {0}赠予了{2}{1}…
	/// </summary>
	public int AddTaiwuStorageResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 6);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 存放物品
	/// {0}赠予了{1}…
	/// </summary>
	public int AddTaiwuStorageItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 7);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 取用资源
	/// {0}取用了{2}{1}…
	/// </summary>
	public int AddTaiwuTakeOutResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 8);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 取用物品
	/// {0}取用了{1}…
	/// </summary>
	public int AddTaiwuTakeOutItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 9);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 赠予库房
	/// {0}将私人之物赠予库房…
	/// </summary>
	public int AddDonateSectTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 10);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 赠予库房
	/// {0}将私人之物赠予库房…
	/// </summary>
	public int AddDonateTownTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 11);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 擅闯库房
	/// {0}未经同意，擅闯库房…
	/// </summary>
	public int AddIntrudeSectTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 12);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 擅闯库房
	/// {0}未经同意，擅闯库房…
	/// </summary>
	public int AddIntrudeTownTreasury(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 13);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 掠夺库房
	/// {0}掠夺了库房…
	/// </summary>
	public int AddPlunderSectTreasurySuccess(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 14);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 掠夺库房
	/// {0}掠夺了库房…
	/// </summary>
	public int AddPlunderTownTreasurySuccess(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 15);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 掠夺库房
	/// {0}掠夺库房失败狼狈逃走…
	/// </summary>
	public int AddPlunderSectTreasuryFail(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 16);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 掠夺库房
	/// {0}掠夺库房失败狼狈逃走…
	/// </summary>
	public int AddPlunderTownTreasuryFail(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 17);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 门派处罚
	/// 因{0}受到处罚，没收了其些{2}{1}…
	/// </summary>
	public int AddConfiscateResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 18);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 门派处罚
	/// 因{0}受到处罚，没收了其些{1}…
	/// </summary>
	public int AddConfiscateItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 19);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 分发物品
	/// 库房物品丰富，分发了{1}给{0}…
	/// </summary>
	public int AddDistributeItem(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 20);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 清理记录
	/// &lt;color=#orange&gt;自上次清点库房之后……&lt;/color&gt;
	/// </summary>
	public int AddClearRecord(int date, short settlementId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 21);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 分发资源
	/// 库房资源丰富，分发了{2}{1}给{0}…
	/// </summary>
	public int AddDistributeResource(int date, short settlementId, int charId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 22);
		AppendCharacter(charId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 伏龙劫掠
	/// 伏龙狂徒劫掠路人归来，将{1}{0}与{3}{2}收入库房之中…
	/// </summary>
	public int AddSectStoryFulongLooting(int date, short settlementId, sbyte resourceType, int value, sbyte resourceType1, int value1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 23);
		AppendResource(resourceType);
		AppendInteger(value);
		AppendResource(resourceType1);
		AppendInteger(value1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点库房记录 - 捐赠遗物
	/// 依照{0}的遗愿，将其生前拥有的{1}捐赠至库房…
	/// </summary>
	public int AddDonateLegacy(int date, short settlementId, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 24);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
