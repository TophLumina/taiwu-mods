using System.Collections.Generic;
using Config;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.LifeRecord;

/// <summary>
/// 最小的经历传输单位，需要与<see cref="T:GameData.Domains.LifeRecord.TransferableArgumentCollection" />一并传送
/// GameData.Domains.LifeRecord.TransferableRecord
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class TransferableRecord : ISerializableGameData
{
	/// <summary>
	/// 记录类型 (即记录配置表中的模板 ID)
	/// RecordType可能为-1(生成的姓名信息), -2(日期), -3(分割线)
	/// <see cref="T:GameData.Domains.LifeRecord.TransferableRecordType" />.
	/// </summary>
	[SerializableGameDataField]
	public int Date;

	/// <summary>
	/// 记录类型 (即记录配置表中的模板 ID)
	/// RecordType可能为-1(生成的姓名信息), -2(日期), -3(分割线)
	/// <see cref="T:GameData.Domains.LifeRecord.TransferableRecordType" />.
	/// </summary>
	[SerializableGameDataField]
	public short RecordType;

	/// <summary>
	/// 实参集合.
	/// paramType: 参数类型. <see cref="T:GameData.Domains.LifeRecord.GeneralRecord.ParameterType" />.
	/// index: 该参数在同类参数列表中的索引.
	///
	/// 对LifeRecordDate，Arguments只有一项，sbyte为-1，且int值为Date
	/// 对SeparateLine，Arguments为空
	/// </summary>
	[SerializableGameDataField]
	public List<(sbyte, int)> Arguments;

	public TransferableRecord()
		: this(0, 0)
	{
	}

	public TransferableRecord(int date = 0, short recordType = 0)
	{
		Date = date;
		RecordType = recordType;
		Arguments = new List<(sbyte, int)>();
	}

	/// <summary>
	/// 计算分数（可以直接计算得分，不必理会其分数格式是否为计算）
	/// 其计算逻辑应保证与<see cref="T:GameData.Domains.LifeRecord.ReadonlyLifeRecords" />中的计算逻辑一致
	/// </summary>
	/// <param name="argumentCollection"></param>
	/// <returns></returns>
	public int GetCalculatedLifeRecordScore(TransferableArgumentCollection argumentCollection)
	{
		switch (RecordType)
		{
		case 16:
			var (itemType2, templateId2) = argumentCollection.Items[Arguments[1].Item2];
			return 50 + (ItemTemplateHelper.GetGrade(itemType2, templateId2) + 1) * 3;
		case 17:
			var (itemType, templateId) = argumentCollection.Items[Arguments[1].Item2];
			return 50 - (ItemTemplateHelper.GetGrade(itemType, templateId) + 1) * 3;
		case 18:
		{
			int templateId3 = Arguments[1].Item2;
			return 50 + (Config.CombatSkill.Instance[templateId3].Grade + 1) * 3;
		}
		case 19:
		{
			int templateId7 = Arguments[1].Item2;
			return 50 - (Config.CombatSkill.Instance[templateId7].Grade + 1) * 3;
		}
		case 20:
		{
			int templateId6 = Arguments[1].Item2;
			return 50 + (Config.CombatSkill.Instance[templateId6].Grade + 1) * 3;
		}
		case 21:
		{
			int templateId5 = Arguments[1].Item2;
			return 50 + (LifeSkill.Instance[templateId5].Grade + 1) * 3;
		}
		case 81:
		case 83:
			var (itemType3, templateId4) = argumentCollection.Items[Arguments[1].Item2];
			return 50 + (ItemTemplateHelper.GetGrade(itemType3, templateId4) + 1) * 3;
		default:
		{
			LifeRecordItem lifeRecordItem = Config.LifeRecord.Instance[RecordType];
			if (lifeRecordItem != null)
			{
				short score = lifeRecordItem.Score;
				if (score != -1)
				{
					return score;
				}
			}
			return 50;
		}
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Arguments == null) ? (totalSize + 2) : (totalSize + (2 + 5 * Arguments.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Date;
		pCurrData += 4;
		*(short*)pCurrData = RecordType;
		pCurrData += 2;
		if (Arguments != null)
		{
			int elementsCount = Arguments.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*pCurrData = (byte)Arguments[i].Item1;
				pCurrData++;
				*(int*)pCurrData = Arguments[i].Item2;
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
		Date = *(int*)pCurrData;
		pCurrData += 4;
		RecordType = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Arguments == null)
			{
				Arguments = new List<(sbyte, int)>();
			}
			else
			{
				Arguments.Clear();
			}
			(sbyte, int) element = default((sbyte, int));
			for (int i = 0; i < elementsCount; i++)
			{
				element.Item1 = (sbyte)(*pCurrData);
				pCurrData++;
				element.Item2 = *(int*)pCurrData;
				pCurrData += 4;
				Arguments.Add(element);
			}
		}
		else
		{
			Arguments?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
