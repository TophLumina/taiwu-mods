using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

/// <summary>
/// 人物任务(目标集合)相关数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CharacterMissionDisplayData : ISerializableGameData
{
	/// <summary>
	/// 任务模板ID <see cref="F:Config.CharacterMissionItem.TemplateId" />
	/// </summary>
	[SerializableGameDataField]
	public int MissionTemplateId = -1;

	/// <summary>
	/// 完成时间
	/// </summary>
	[SerializableGameDataField]
	public int EndDate = int.MinValue;

	/// <summary>
	/// 剩余时间 根据 currDate、CharacterMissionData.EndDate和配置表里的KeepDuration
	/// </summary>
	[SerializableGameDataField]
	public int RemainMonth = int.MinValue;

	/// <summary>
	/// 剩余保留时间 根据 currDate和CharacterGoalData.CreateDate和配置表里的Duration
	/// </summary>
	[SerializableGameDataField]
	public int RemainLingeringMonth = int.MinValue;

	/// <summary>
	/// 目标列表.
	/// 只包含需要寻路的目标，任务开始时目标已完成的情况无需添加数据
	/// </summary>
	[SerializableGameDataField]
	public List<CharacterGoalDisplayData> Goals = new List<CharacterGoalDisplayData>();

	/// <summary>
	/// 任务已完成
	/// </summary>
	[SerializableGameDataField]
	public bool IsComplete;

	/// <summary>
	/// 是否已超时
	/// </summary>
	[SerializableGameDataField]
	public bool IsTimeout;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CharacterMissionDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CharacterMissionDisplayData(CharacterMissionDisplayData other)
	{
		MissionTemplateId = other.MissionTemplateId;
		EndDate = other.EndDate;
		RemainMonth = other.RemainMonth;
		RemainLingeringMonth = other.RemainLingeringMonth;
		if (other.Goals != null)
		{
			List<CharacterGoalDisplayData> item = other.Goals;
			int elementsCount = item.Count;
			Goals = new List<CharacterGoalDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Goals.Add(new CharacterGoalDisplayData(item[i]));
			}
		}
		else
		{
			Goals = null;
		}
		IsComplete = other.IsComplete;
		IsTimeout = other.IsTimeout;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CharacterMissionDisplayData other)
	{
		MissionTemplateId = other.MissionTemplateId;
		EndDate = other.EndDate;
		RemainMonth = other.RemainMonth;
		RemainLingeringMonth = other.RemainLingeringMonth;
		if (other.Goals != null)
		{
			List<CharacterGoalDisplayData> item = other.Goals;
			int elementsCount = item.Count;
			Goals = new List<CharacterGoalDisplayData>(elementsCount);
			for (int i = 0; i < elementsCount; i++)
			{
				Goals.Add(new CharacterGoalDisplayData(item[i]));
			}
		}
		else
		{
			Goals = null;
		}
		IsComplete = other.IsComplete;
		IsTimeout = other.IsTimeout;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		if (Goals != null)
		{
			totalSize += 2;
			int elementsCount = Goals.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalDisplayData element = Goals[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		*(int*)pCurrData = MissionTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = EndDate;
		pCurrData += 4;
		*(int*)pCurrData = RemainMonth;
		pCurrData += 4;
		*(int*)pCurrData = RemainLingeringMonth;
		pCurrData += 4;
		if (Goals != null)
		{
			int elementsCount = Goals.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				CharacterGoalDisplayData element = Goals[i];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
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
		*pCurrData = (IsComplete ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (IsTimeout ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		MissionTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		EndDate = *(int*)pCurrData;
		pCurrData += 4;
		RemainMonth = *(int*)pCurrData;
		pCurrData += 4;
		RemainLingeringMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Goals == null)
			{
				Goals = new List<CharacterGoalDisplayData>(elementsCount);
			}
			else
			{
				Goals.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CharacterGoalDisplayData element = new CharacterGoalDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					Goals.Add(element);
				}
				else
				{
					Goals.Add(null);
				}
			}
		}
		else
		{
			Goals?.Clear();
		}
		IsComplete = *pCurrData != 0;
		pCurrData++;
		IsTimeout = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
