using System.Collections.Generic;
using Config;
using GameData.Domains.LifeRecord.GeneralRecord;
using GameData.Utilities;

namespace GameData.Domains.Building.SamsaraPlatformRecord;

/// <summary>
/// 轮回台记录集合
/// </summary>
/// <summary>
/// 轮回台记录的集合
/// </summary>
public class SamsaraPlatformRecordCollection : WriteableRecordCollection
{
	/// <summary>
	/// 获取所有轮回台的渲染信息
	/// </summary>
	/// <param name="renderInfos">调用者保证传入时此集合为空</param>
	/// <param name="argumentCollection">传入时可以不为空</param>
	public void GetRenderInfos(List<SamsaraPlatformRecordRenderInfo> renderInfos, ArgumentCollection argumentCollection)
	{
		int index = -1;
		int offset = -1;
		while (Next(ref index, ref offset))
		{
			SamsaraPlatformRecordRenderInfo renderInfo = GetRenderInfo(offset, argumentCollection);
			if (renderInfo != null)
			{
				renderInfos.Add(renderInfo);
			}
		}
	}

	/// <summary>
	/// 获取指定位置上的记录类型（即轮回台模板ID）
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
	/// 获取指定索引的轮回台记录的渲染信息
	/// </summary>
	/// <param name="offset"></param>
	/// <param name="argumentCollection">实参集合</param>
	/// <returns></returns>
	public new unsafe SamsaraPlatformRecordRenderInfo GetRenderInfo(int offset, ArgumentCollection argumentCollection)
	{
		fixed (byte* pRawData = RawData)
		{
			byte* pCurrData = pRawData + offset;
			pCurrData++;
			int date = *(int*)pCurrData;
			pCurrData += 4;
			short recordType = *(short*)pCurrData;
			pCurrData += 2;
			SamsaraPlatformRecordItem config = Config.SamsaraPlatformRecord.Instance[recordType];
			if (config == null)
			{
				AdaptableLog.Warning($"Unable to render monthly notification with template id {recordType}");
				return null;
			}
			string[] parameters = config.Parameters;
			SamsaraPlatformRecordRenderInfo info = new SamsaraPlatformRecordRenderInfo(recordType, config.Desc, date);
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
	/// 开始添加轮回台记录
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
	/// 添加轮回台记录 - 轮回成功
	/// {0}通过{1}轮回至{2}，成为了此处{3}{4}的子女…
	/// </summary>
	public int AddSamsaraSuccess(int date, int charId, sbyte destinyType, short settlementId, sbyte orgTemplateId, sbyte orgGrade, bool orgPrincipal, sbyte gender, int charId1)
	{
		int beginOffset = BeginAddingRecord(date, 0);
		AppendCharacter(charId);
		AppendDestinyType(destinyType);
		AppendSettlement(settlementId);
		AppendOrgGrade(orgTemplateId, orgGrade, orgPrincipal, gender);
		AppendCharacter(charId1);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}

	/// <summary>
	/// 添加轮回台记录 - 轮回失败
	/// {0}本应通过{1}投胎转世，却不知何故再三受阻，未能入得轮回……
	/// </summary>
	public int AddSamsaraFailed(int date, int charId, sbyte destinyType)
	{
		int beginOffset = BeginAddingRecord(date, 1);
		AppendCharacter(charId);
		AppendDestinyType(destinyType);
		EndAddingRecord(beginOffset);
		return beginOffset;
	}
}
