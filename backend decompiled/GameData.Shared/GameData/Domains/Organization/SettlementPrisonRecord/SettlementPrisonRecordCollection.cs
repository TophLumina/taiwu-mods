using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Organization.SettlementPrisonRecord;

/// <summary>
/// 监牢记录集合
/// </summary>
/// <summary>
/// 定居点监牢记录的集合 - 添加监牢记录
/// </summary>
public class SettlementPrisonRecordCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有监牢的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<SettlementPrisonRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SettlementPrisonRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即监牢模板ID）
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
	/// 获取指定索引的监牢记录的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe SettlementPrisonRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
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
			SettlementPrisonRecordItem config = Config.SettlementPrisonRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SettlementPrisonRecordRenderInfo info = new SettlementPrisonRecordRenderInfo(recordType, config.Desc, date, settlementId);
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
	/// 开始添加监牢记录
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
	/// 添加定居点监牢记录 - 擅闯监牢
	/// {0}未经同意，擅闯监牢…
	/// </summary>
	public int AddIntrudePrison(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 0);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 擅闯收监
	/// {0}擅闯监牢，收监了{1}…
	/// </summary>
	public int AddIntrudePrisonAndSentToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 1);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 擅闯劫狱
	/// {0}擅闯监牢，劫走了{1}…
	/// </summary>
	public int AddIntrudePrisonAndPrisonRobbery(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 2);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 收监囚犯
	/// {0}经过同意，收监了{1}…
	/// </summary>
	public int AddSendingToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 3);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 劫走囚犯
	/// {0}进入监牢，劫走了{1}…
	/// </summary>
	public int AddPrisonRobbery(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 4);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 请求释放
	/// 因{0}向门派求情，{1}被提前释放…
	/// </summary>
	public int AddPrisonBail(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 5);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 自首关押
	/// {0}犯下{1}罪行后投案自首，被关入监牢…
	/// </summary>
	public int AddImprisonedVoluntarily(int date, short settlementId, int charId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 6);
		AppendCharacter(charId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 抓捕关押
	/// {0}犯下{1}罪行后，被抓捕入狱…
	/// </summary>
	public int AddImprisonedByArrested(int date, short settlementId, int charId, short punishmentType)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 7);
		AppendCharacter(charId);
		AppendPunishmentType(punishmentType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 刑满释放
	/// {0}刑满释放，就此离开监牢…
	/// </summary>
	public int AddBeReleasedUponCompletionOfASentence(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 8);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 囚犯越狱
	/// {0}设法逃离了监牢…
	/// </summary>
	public int AddPrisonBreak(int date, short settlementId, int charId)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 9);
		AppendCharacter(charId);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 送监人物
	/// {0}被{1}送入了监牢…
	/// </summary>
	public int AddSentToPrisonTaiwu(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 10);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加定居点监牢记录 - 有教无类
	/// {0}因{1}的名望得到特赦…
	/// </summary>
	public int AddPrisonerBeReleaseByAristocrat(int date, short settlementId, int charId, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, settlementId, 11);
		AppendCharacter(charId);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
