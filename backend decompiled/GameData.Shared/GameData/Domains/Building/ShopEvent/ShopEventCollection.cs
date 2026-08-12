using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Building.ShopEvent;

/// <summary>
/// 经营事件记录集合
/// </summary>
/// <summary>
/// 经营事件的集合 - 添加经营事件
/// </summary>
public class ShopEventCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有经营事件的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<ShopEventRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			ShopEventRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即经营事件模板ID）
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
	/// 获取指定索引的旅行事件的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe ShopEventRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			ShopEventItem config = Config.ShopEvent.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			ShopEventRenderInfo info = new ShopEventRenderInfo(recordType, config.Desc, date);
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
	/// 开始添加过月通知
	/// </summary>
	/// <param name="date">经历发生的日期</param>
	/// <param name="recordType">过月通知类型</param>
	/// <returns>当前过月通知的起始偏移</returns>
	private unsafe int BeginAddingRecord(int date, short recordType)
	{
		int offset = Size;
		int newSize = Size + 1 + 4 + 2;
		EnsureCapacity(newSize);
		Size = newSize;
		fixed (byte* pRawData = RawData)
		{
			byte* num = pRawData + offset;
			*(int*)(num + 1) = date;
			((short*)(num + 1))[2] = recordType;
		}
		return offset;
	}

	/// <summary>
	/// 添加经营事件 - 堤堰成功
	/// 顺利地进行了捕捞工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess0(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 矿井成功
	/// 顺利地进行了采炼工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess1(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 树农成功
	/// 顺利地进行了采伐工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess2(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 2);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 石碑成功
	/// 顺利地进行了整修工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 3);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药农成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 4);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 泥渠成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 5);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 花农成功
	/// 顺利地进行了采集工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess6(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 6);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 宝井成功
	/// 顺利地进行了挖掘工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess7(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 7);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 筒车成功
	/// 顺利地进行了采集工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess8(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 8);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 牧场成功
	/// 顺利地进行了猎捕工作，收获了{0}…
	/// </summary>
	public int AddCollectResourceSuccess9(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 9);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 琉璃索成功
	/// 顺利地进行了提炼工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess0(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 10);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 火爆堆成功
	/// 顺利地进行了采炼工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess1(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 11);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 护林墙成功
	/// 顺利地进行了采伐工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess2(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 12);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 悬空栈成功
	/// 顺利地进行了采伐工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 13);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 引涧渠成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 14);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 饵食牢成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 15);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 云篷成功
	/// 顺利地进行了采集工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess6(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 16);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 福人居成功
	/// 顺利地进行了采集工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess7(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 17);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 秘陵成功
	/// 顺利地进行了挖掘工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess8(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 18);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 冰夷像成功
	/// 顺利地进行了挖掘工作，收获了{0}…
	/// </summary>
	public int AddCollectBetterResourceSuccess9(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 19);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 堤堰失败
	/// 捕捞工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 20);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 矿井失败
	/// 采炼工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 21);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 树农失败
	/// 采伐工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 22);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 石碑失败
	/// 整修工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 23);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药农失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 24);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 泥渠失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 25);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 花农失败
	/// 采集工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 26);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 宝井失败
	/// 挖掘工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 27);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 筒车失败
	/// 采集工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail8(int date)
	{
		int beginOffset = BeginAddingRecord(date, 28);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 牧场失败
	/// 猎捕工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectResourceFail9(int date)
	{
		int beginOffset = BeginAddingRecord(date, 29);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 琉璃索失败
	/// 提炼工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 30);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 火爆堆失败
	/// 采炼工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 31);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 护林墙失败
	/// 采伐工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 32);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 悬空栈失败
	/// 采伐工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 33);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 引涧渠失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 34);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 饵食牢失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 35);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 云篷失败
	/// 采集工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 36);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 福人居失败
	/// 采集工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 37);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 秘陵失败
	/// 挖掘工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail8(int date)
	{
		int beginOffset = BeginAddingRecord(date, 38);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 冰夷像失败
	/// 挖掘工作发生了失误，以致一无所获…
	/// </summary>
	public int AddCollectBetterResourceFail9(int date)
	{
		int beginOffset = BeginAddingRecord(date, 39);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 镖局成功
	/// 顺利地完成了保镖工作，收获了{1}银钱…
	/// </summary>
	public int AddManageCombatSkillBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 40);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 炼神峰成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageCombatSkillBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 41);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 知客亭成功
	/// 顺利地完成了接引工作，收获了{1}威望…
	/// </summary>
	public int AddManageCombatSkillBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 42);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 镖局失败
	/// 保镖工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCombatSkillBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 43);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 炼神峰失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageCombatSkillBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 44);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 知客亭失败
	/// 接引工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCombatSkillBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 45);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 乐坊成功
	/// 顺利地完成了演奏工作，收获了{1}银钱…
	/// </summary>
	public int AddManageMusicBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 46);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 知音阁成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageMusicBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 47);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百戏园成功
	/// 顺利地完成了作曲工作，收获了{1}威望…
	/// </summary>
	public int AddManageMusicBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 48);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 乐坊失败
	/// 演奏工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMusicBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 49);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 知音阁失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageMusicBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 50);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百戏园失败
	/// 作曲工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMusicBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 51);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 棋馆成功
	/// 顺利地完成了接引工作，收获了{1}银钱…
	/// </summary>
	public int AddManageChessBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 52);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 斗弈台成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageChessBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 53);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 石谱园成功
	/// 顺利地完成了讲学工作，收获了{1}威望…
	/// </summary>
	public int AddManageChessBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 54);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 棋馆失败
	/// 接引工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageChessBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 55);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 斗弈台失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageChessBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 56);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 石谱园失败
	/// 讲学工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageChessBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 57);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 书铺成功
	/// 顺利地完成了售卖工作，收获了{1}银钱…
	/// </summary>
	public int AddManagePoemBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 58);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 书院成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManagePoemBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 59);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 翰苑成功
	/// 顺利地完成了讲学工作，收获了{1}威望…
	/// </summary>
	public int AddManagePoemBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 60);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 书铺失败
	/// 售卖工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManagePoemBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 61);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 书院失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManagePoemBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 62);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 翰苑失败
	/// 讲学工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManagePoemBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 63);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 画铺成功
	/// 顺利地完成了售卖工作，收获了{1}银钱…
	/// </summary>
	public int AddManagePaintingBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 64);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 丹青馆成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManagePaintingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 65);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 流光园成功
	/// 顺利地完成了接引工作，收获了{1}威望…
	/// </summary>
	public int AddManagePaintingBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 66);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 画铺失败
	/// 售卖工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManagePaintingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 67);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 丹青馆失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManagePaintingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 68);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 流光园失败
	/// 接引工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManagePaintingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 69);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 占卜馆成功
	/// 顺利地完成了占卜工作，收获了{1}银钱…
	/// </summary>
	public int AddManageMathBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 70);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 方士馆成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageMathBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 71);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 祭天高台成功
	/// 顺利地完成了祭祀工作，收获了{1}威望…
	/// </summary>
	public int AddManageMathBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 72);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 占卜馆失败
	/// 占卜工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMathBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 73);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 方士馆失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageMathBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 74);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 祭天高台失败
	/// 祭祀工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMathBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 75);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 茶馆成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 76);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 酒肆成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess1(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 77);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 闻香苑成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 78);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 四海府成功
	/// 以{0}为奖励，顺利地举办了盛会，收获了{2}威望…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess3(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 79);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 茶园成功
	/// 顺利地进行了茶叶品鉴，收获了{0}…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 80);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 蒸酒坊成功
	/// 顺利地进行了美酒品鉴，收获了{0}…
	/// </summary>
	public int AddManageAppraisalBuildingSuccess5(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 81);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 茶馆失败
	/// 售卖茶叶时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageAppraisalBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 82);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 酒肆失败
	/// 售卖美酒时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageAppraisalBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 83);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 闻香苑失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageAppraisalBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 84);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 四海府失败
	/// 举办盛会时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageAppraisalBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 85);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 茶园失败
	/// 茶叶品鉴发生了失误，以致一无所获…
	/// </summary>
	public int AddManageAppraisalBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 86);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 蒸酒坊失败
	/// 美酒品鉴发生了失误，以致一无所获…
	/// </summary>
	public int AddManageAppraisalBuildingFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 87);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 铁匠铺成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageForgingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 88);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 锻冶坊成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageForgingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 89);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 金铺成功
	/// 以{0}为奖励，顺利地举办了盛会，收获了{2}威望…
	/// </summary>
	public int AddManageForgingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 90);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 淘洗池成功
	/// 顺利地进行了淘洗工作，收获了{0}…
	/// </summary>
	public int AddManageForgingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 91);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 精炼室成功
	/// 顺利地进行了精炼工作，收获了{0}…
	/// </summary>
	public int AddManageForgingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 92);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 铁匠铺失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageForgingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 93);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 锻冶坊失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageForgingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 94);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 金铺失败
	/// 举办盛会时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageForgingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 95);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 淘洗池失败
	/// 淘洗工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageForgingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 96);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 精炼室失败
	/// 精炼工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageForgingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 97);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 木工铺成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageWoodworkingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 98);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 制木坊成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageWoodworkingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 99);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 营造坊成功
	/// 以{0}为奖励，顺利地举办了盛会，收获了{2}威望…
	/// </summary>
	public int AddManageWoodworkingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 100);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 伐木场成功
	/// 顺利地进行了伐木工作，收获了{0}…
	/// </summary>
	public int AddManageWoodworkingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 101);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 林场成功
	/// 顺利地进行了栽培工作，收获了{0}…
	/// </summary>
	public int AddManageWoodworkingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 102);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 木工铺失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWoodworkingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 103);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 制木坊失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageWoodworkingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 104);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 营造坊失败
	/// 举办盛会时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWoodworkingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 105);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 伐木场失败
	/// 伐木工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWoodworkingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 106);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 林场失败
	/// 栽培工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWoodworkingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 107);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 熟药铺成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageMedicineBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 108);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药师馆成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageMedicineBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 109);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 病坊成功
	/// 以{0}救治流民，收获了{2}威望…
	/// </summary>
	public int AddManageMedicineBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 110);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药圃成功
	/// 顺利地进行了种植工作，收获了{0}…
	/// </summary>
	public int AddManageMedicineBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 111);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 养药室成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddManageMedicineBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 112);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 熟药铺失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMedicineBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 113);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药师馆失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageMedicineBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 114);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 病坊失败
	/// 救治流民时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMedicineBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 115);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 药圃失败
	/// 种植工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMedicineBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 116);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 养药室失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageMedicineBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 117);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 毒市成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageToxicologyBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 118);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 暗牢成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageToxicologyBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 119);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 密医成功
	/// 以{0}救治流民，收获了{2}威望…
	/// </summary>
	public int AddManageToxicologyBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 120);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 炼瘴池成功
	/// 顺利地进行了炼毒工作，收获了{0}…
	/// </summary>
	public int AddManageToxicologyBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 121);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 废人窟成功
	/// 顺利地进行了养毒工作，收获了{0}…
	/// </summary>
	public int AddManageToxicologyBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 122);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 毒市失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageToxicologyBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 123);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 暗牢失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageToxicologyBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 124);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 密医失败
	/// 救治流民时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageToxicologyBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 125);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 炼瘴池失败
	/// 炼毒工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageToxicologyBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 126);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 废人窟失败
	/// 养毒工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageToxicologyBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 127);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 布庄成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageWeavingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 128);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 织造坊成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageWeavingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 129);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 锦绣阁成功
	/// 以{0}为媒，替人牵线搭桥，收获了{2}威望…
	/// </summary>
	public int AddManageWeavingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 130);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百花瀑成功
	/// 顺利地进行了洗涤工作，收获了{0}…
	/// </summary>
	public int AddManageWeavingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 131);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 奇珍园成功
	/// 顺利地进行了饲育工作，收获了{0}…
	/// </summary>
	public int AddManageWeavingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 132);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 布庄失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWeavingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 133);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 织造坊失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageWeavingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 134);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 锦绣阁失败
	/// 牵线做媒时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWeavingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 135);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百花瀑失败
	/// 洗涤工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWeavingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 136);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 奇珍园失败
	/// 精炼工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageWeavingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 137);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 珠宝铺成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageJadeBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 138);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 毛石坊成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageJadeBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 139);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 琳琅阁成功
	/// 以{0}为奖励，顺利地举办了盛会，收获了{2}威望…
	/// </summary>
	public int AddManageJadeBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 140);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 浣宝池成功
	/// 顺利地进行了浣宝工作，收获了{0}…
	/// </summary>
	public int AddManageJadeBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 141);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 金刚解玉台成功
	/// 顺利地进行了解石工作，收获了{0}…
	/// </summary>
	public int AddManageJadeBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 142);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 珠宝铺失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageJadeBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 143);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 毛石坊失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageJadeBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 144);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 琳琅阁失败
	/// 举办盛会时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageJadeBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 145);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 浣宝池失败
	/// 浣宝工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageJadeBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 146);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 金刚解玉台失败
	/// 解玉工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageJadeBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 147);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 法事道场成功
	/// 顺利地完成了法事工作，收获了{1}银钱…
	/// </summary>
	public int AddManageTaoismBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 148);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 道观成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageTaoismBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 149);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 三清殿成功
	/// 顺利地完成了接引工作，收获了{1}威望…
	/// </summary>
	public int AddManageTaoismBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 150);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 法事道场失败
	/// 法事工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageTaoismBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 151);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 道观失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageTaoismBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 152);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 三清殿失败
	/// 接引工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageTaoismBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 153);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 寺院成功
	/// 顺利地完成了化缘工作，收获了{1}银钱…
	/// </summary>
	public int AddManageBuddhismBuildingSuccess0(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 154);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 佛塔成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageBuddhismBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 155);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 法堂成功
	/// 顺利地完成了讲经工作，收获了{1}威望…
	/// </summary>
	public int AddManageBuddhismBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 156);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 寺院失败
	/// 化缘工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageBuddhismBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 157);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 佛塔失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageBuddhismBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 158);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 法堂失败
	/// 讲经工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageBuddhismBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 159);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 酒楼成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageCookingBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 160);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百家宴成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageCookingBuildingSuccess1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 161);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 争妍阁成功
	/// 以{0}为奖励，顺利地举办了盛会，收获了{2}威望…
	/// </summary>
	public int AddManageCookingBuildingSuccess2(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 162);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 四季园成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddManageCookingBuildingSuccess3(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 163);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 天成乡成功
	/// 顺利地进行了培育工作，收获了{0}…
	/// </summary>
	public int AddManageCookingBuildingSuccess4(int date, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 164);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 酒楼失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCookingBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 165);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 百家宴失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageCookingBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 166);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 争妍阁失败
	/// 举办盛会时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCookingBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 167);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 四季园失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCookingBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 168);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 天成乡失败
	/// 培育工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageCookingBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 169);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 市集成功
	/// 顺利地售出了{0}，收获了{2}银钱…
	/// </summary>
	public int AddManageEclecticBuildingSuccess0(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 170);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 赌坊成功
	/// 顺利地完成了博彩工作，收获了{1}银钱…
	/// </summary>
	public int AddManageEclecticBuildingSuccess1(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 171);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 青楼成功
	/// 顺利地完成了经营工作，收获了{1}银钱…
	/// </summary>
	public int AddManageEclecticBuildingSuccess2(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 172);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 花舫成功
	/// 一位流民魅力出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageEclecticBuildingSuccess3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 173);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 勾栏瓦舍成功
	/// 一位流民资质出众，通过了选拔，可被招揽至太吾村…
	/// </summary>
	public int AddManageEclecticBuildingSuccess4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 174);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 游园成功
	/// 顺利地完成了接引工作，收获了{1}威望…
	/// </summary>
	public int AddManageEclecticBuildingSuccess5(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 175);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 当铺成功
	/// 收到当品{0}，可花费{2}银钱将其收入囊中…
	/// </summary>
	public int AddManageEclecticBuildingSuccess6(int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 176);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 贤士馆成功
	/// 得到一位流民的投奔，可花费{1}威望将其招揽至太吾村…
	/// </summary>
	public int AddManageEclecticBuildingSuccess7(int date, sbyte resourceType, int value)
	{
		int beginOffset = BeginAddingRecord(date, 177);
		AppendResource(resourceType);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 市集失败
	/// 售卖时发生了失误，以致一无所获…
	/// </summary>
	public int AddManageEclecticBuildingFail0(int date)
	{
		int beginOffset = BeginAddingRecord(date, 178);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 赌坊失败
	/// 博彩工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageEclecticBuildingFail1(int date)
	{
		int beginOffset = BeginAddingRecord(date, 179);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 青楼失败
	/// 经营工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageEclecticBuildingFail2(int date)
	{
		int beginOffset = BeginAddingRecord(date, 180);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 花舫失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageEclecticBuildingFail3(int date)
	{
		int beginOffset = BeginAddingRecord(date, 181);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 勾栏瓦舍失败
	/// 未能发现可招揽至太吾村的人才…
	/// </summary>
	public int AddManageEclecticBuildingFail4(int date)
	{
		int beginOffset = BeginAddingRecord(date, 182);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 游园失败
	/// 接引工作发生了失误，以致一无所获…
	/// </summary>
	public int AddManageEclecticBuildingFail5(int date)
	{
		int beginOffset = BeginAddingRecord(date, 183);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 当铺失败
	/// 未能接收到当品…
	/// </summary>
	public int AddManageEclecticBuildingFail6(int date)
	{
		int beginOffset = BeginAddingRecord(date, 184);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 贤士馆失败
	/// 未能招揽到流民…
	/// </summary>
	public int AddManageEclecticBuildingFail7(int date)
	{
		int beginOffset = BeginAddingRecord(date, 185);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 成功学得技艺
	/// {0}在工作时，领悟到{1}之妙法…
	/// </summary>
	public int AddLearnLifeSkillSuccess(int date, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 186);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 成功学得功法
	/// {0}在工作时，掌握了{1}的法门…
	/// </summary>
	public int AddLearnCombatSkillSuccess(int date, int charId, sbyte itemType, short itemTemplateId)
	{
		int beginOffset = BeginAddingRecord(date, 187);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 未学得技艺但加了资质
	/// {0}在工作时若有所悟，然须臾已失，仅使{1}资质略长…
	/// </summary>
	public int AddLearnLifeSkillFail(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 188);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 未学得功法但加了资质
	/// {0}在工作时恍若得道，然转瞬即逝，仅使{1}资质略长…
	/// </summary>
	public int AddLearnCombatSkillFail(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 189);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 因经营技艺资质提升
	/// {0}在工作时心念微动，似有所触，{1}资质得到了增长…
	/// </summary>
	public int AddManageLifeSkillAbilityUp(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 190);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 因经营功法资质提升
	/// {0}在工作时心念微动，似有所触，{1}资质得到了增长…
	/// </summary>
	public int AddManageCombatSkillAbilityUp(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 191);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 保底资质加成-技艺
	/// {0}研习时经刻苦钻研，{1}资质得到了增长…
	/// </summary>
	public int AddBaseDevelopLifeSkill(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 192);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 保底资质加成-武学
	/// {0}研习时经刻苦钻研，{1}资质得到了增长…
	/// </summary>
	public int AddBaseDevelopCombatSkill(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 193);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 七元影响资质加成-技艺
	/// {0}在研习时因赋性相合，{1}资质得到了增长…
	/// </summary>
	public int AddPersonalityDevelopLifeSkill(int date, int charId, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 194);
		AppendCharacter(charId);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 七元影响资质加成-武学
	/// {0}在研习时因赋性相合，{1}资质得到了增长…
	/// </summary>
	public int AddPersonalityDevelopCombatSkill(int date, int charId, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 195);
		AppendCharacter(charId);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 领袖指导资质加成-技艺
	/// {0}受到{1}监督教导，受益匪浅，{2}资质得到了增长…
	/// </summary>
	public int AddLeaderDevelopLifeSkill(int date, int charId, int charId1, sbyte lifeSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 196);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendLifeSkillType(lifeSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 领袖指导资质加成-武学
	/// {0}受到{1}监督教导，受益匪浅，{2}资质得到了增长…
	/// </summary>
	public int AddLeaderDevelopCombatSkill(int date, int charId, int charId1, sbyte combatSkillType)
	{
		int beginOffset = BeginAddingRecord(date, 197);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		AppendCombatSkillType(combatSkillType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 研习学得技艺
	/// {0}在研习时，领悟到{1}的第{2}篇…
	/// </summary>
	public int AddLearnLifeSkill(int date, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 198);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 研习学得功法
	/// {0}在研习时，掌握了{1}的第{2}篇…
	/// </summary>
	public int AddLearnCombatSkill(int date, int charId, sbyte itemType, short itemTemplateId, int value)
	{
		int beginOffset = BeginAddingRecord(date, 199);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendInteger(value);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 经营完成获得报酬
	/// {0}因完成经营，获得报酬{1}{2}…
	/// </summary>
	public int AddSalaryReceived(int date, int charId, int value, sbyte resourceType)
	{
		int beginOffset = BeginAddingRecord(date, 200);
		AppendCharacter(charId);
		AppendInteger(value);
		AppendResource(resourceType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 低心情村民服用了物品
	/// {0}终日郁郁寡欢，在享用{1}后喜上眉梢，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_1(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 201);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 低心情村民服用了喜爱的物品
	/// {0}终日郁郁寡欢，在享用喜爱的{1}后心花怒发，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_2(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 202);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 低心情村民在宴席上服用了物品
	/// {0}终日郁郁寡欢，在{3}中享用{1}后喜笑颜开，自觉略有所得，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_3(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 203);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 低心情村民在宴席上服用了喜爱的物品
	/// {0}终日郁郁寡欢，在{3}中享用喜爱的{1}后欢欣雀跃，一时收获颇丰，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_4(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 204);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 村民服用了物品
	/// {0}在享用{1}后怡然自得，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_5(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 205);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 村民服用了喜爱的物品
	/// {0}在享用喜爱的{1}后满面春风，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_6(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1)
	{
		int beginOffset = BeginAddingRecord(date, 206);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 村民在宴席上服用了物品
	/// {0}在{3}中享用{1}后心满意足，自觉略有所得，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_7(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 207);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 村民在宴席上服用了喜爱的物品
	/// {0}在{3}中享用喜爱的{1}后兴高采烈，一时收获颇丰，留下{2}以表谢意…
	/// </summary>
	public int AddBanquet_8(int date, int charId, sbyte itemType, short itemTemplateId, sbyte itemType1, short itemTemplateId1, short Feast)
	{
		int beginOffset = BeginAddingRecord(date, 208);
		AppendCharacter(charId);
		AppendItem(itemType, itemTemplateId);
		AppendItem(itemType1, itemTemplateId1);
		AppendFeast(Feast);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 宴堂没有可食用物品
	/// {0}未在宴堂寻得可用佳肴，对此心存怨念，心情与好感皆下降…
	/// </summary>
	public int AddBanquet_9(int date, int charId)
	{
		int beginOffset = BeginAddingRecord(date, 209);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营事件 - 村民已经吃不下
	/// {0}入宴堂时已满腹佳肴，对席中珍馐无动于衷，心情与好感未变…
	/// </summary>
	public int AddBanquet_10(int date, int charId)
	{
		int beginOffset = BeginAddingRecord(date, 210);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营获得道具成功记录
	/// </summary>
	public int AddCollectItemSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte itemType, short itemTemplateId)
	{
		if (shopEventCfg.Parameters[0] != "Item" || !string.IsNullOrEmpty(shopEventCfg.Parameters[1]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard collect item success record: {shopEventCfg.Desc}", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendItem(itemType, itemTemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营招募成功记录
	/// </summary>
	public int AddRecruitSuccessRecord(ShopEventItem shopEventCfg, int date)
	{
		Tester.Assert(string.IsNullOrEmpty(shopEventCfg.Parameters[0]));
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加花费资源经营招募成功记录
	/// </summary>
	public int AddRecruitWithCostSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte resourceType, int amount)
	{
		if (shopEventCfg.Parameters[0] != "Resource" || shopEventCfg.Parameters[1] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[2]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard recruit people success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendResource(resourceType);
		AppendInteger(amount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营收获资源成功记录
	/// </summary>
	public int AddCollectResourceSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte resourceType, int resourceAmount)
	{
		if (shopEventCfg.Parameters[0] != "Resource" || shopEventCfg.Parameters[1] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[2]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard collect resource success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendResource(resourceType);
		AppendInteger(resourceAmount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营出售道具成功记录
	/// </summary>
	public int AddSellItemSuccessRecord(ShopEventItem shopEventCfg, int date, sbyte itemType, short itemTemplateId, sbyte resourceType, int amount)
	{
		if (shopEventCfg.Parameters[0] != "Item" || shopEventCfg.Parameters[1] != "Resource" || shopEventCfg.Parameters[2] != "Integer" || !string.IsNullOrEmpty(shopEventCfg.Parameters[3]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard sell item success record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		AppendItem(itemType, itemTemplateId);
		AppendResource(resourceType);
		AppendInteger(amount);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加经营失败记录
	/// </summary>
	public int AddFailureRecord(ShopEventItem shopEventCfg, int date)
	{
		if (!string.IsNullOrEmpty(shopEventCfg.Parameters[0]))
		{
			AdaptableLog.Warning($"shop event {shopEventCfg.TemplateId} is not a standard failure record: {shopEventCfg.Desc} ", appendWarningMessage: true);
			return -1;
		}
		int beginOffset = BeginAddingRecord(date, shopEventCfg.TemplateId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加宴席服食的记录
	/// </summary>
	/// <param name="charId">宴席中的角色</param>
	/// <param name="happiness">宴席中的角色心情</param>
	/// <param name="dish"></param>
	/// <param name="gift"></param>
	/// <param name="feastType"></param>
	/// <param name="loveItem"></param>
	/// <returns></returns>
	public int AddFeastRecord(int charId, sbyte happiness, ItemKey dish, ItemKey gift, short feastType, bool loveItem)
	{
		int date = ExternalDataBridge.Context.CurrDate;
		short defKey = (short)((happiness <= GlobalConfig.Instance.FeastLowHappiness) ? ((feastType != 0) ? ((!loveItem) ? 203 : 204) : ((!loveItem) ? 201 : 202)) : ((feastType != 0) ? ((!loveItem) ? 207 : 208) : ((!loveItem) ? 205 : 206)));
		int beginOffset = BeginAddingRecord(date, defKey);
		AppendCharacter(charId);
		AppendItem(dish.ItemType, dish.TemplateId);
		AppendItem(gift.ItemType, gift.TemplateId);
		if (feastType != 0)
		{
			AppendFeast(feastType);
		}
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
