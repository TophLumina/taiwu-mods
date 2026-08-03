using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI;

/// <summary>
/// 角色目标数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class CharacterGoalDisplayData : ISerializableGameData
{
	/// <summary>
	/// 目标模板ID. <see cref="T:Config.PlanningGoal" />
	/// </summary>
	[SerializableGameDataField]
	public int GoalTemplateId;

	/// <summary>
	/// 创建时间
	/// </summary>
	[SerializableGameDataField]
	public int CreateDate;

	/// <summary>
	/// 优先级变化量 配置表BasePriority + PriorityDelta
	/// </summary>
	[SerializableGameDataField]
	public int Priority;

	/// <summary>
	/// 是否已完成
	/// </summary>
	[SerializableGameDataField]
	public bool Finished;

	/// <summary>
	/// 剩余时间 根据 currDate、CharacterMissionData.EndDate和配置表里的KeepDuration
	/// </summary>
	[SerializableGameDataField]
	public int RemainMonth = int.MinValue;

	/// <summary>
	/// 目标参数展示文本，由后端根据 PlanningGoal.Parameters 与 ContextArgs 格式化
	/// </summary>
	[SerializableGameDataField]
	public string ParameterContent;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CharacterGoalDisplayData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CharacterGoalDisplayData(CharacterGoalDisplayData other)
	{
		GoalTemplateId = other.GoalTemplateId;
		CreateDate = other.CreateDate;
		Priority = other.Priority;
		Finished = other.Finished;
		RemainMonth = other.RemainMonth;
		ParameterContent = other.ParameterContent;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CharacterGoalDisplayData other)
	{
		GoalTemplateId = other.GoalTemplateId;
		CreateDate = other.CreateDate;
		Priority = other.Priority;
		Finished = other.Finished;
		RemainMonth = other.RemainMonth;
		ParameterContent = other.ParameterContent;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 17;
		totalSize = ((ParameterContent == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ParameterContent.Length)));
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
		*(int*)pCurrData = GoalTemplateId;
		pCurrData += 4;
		*(int*)pCurrData = CreateDate;
		pCurrData += 4;
		*(int*)pCurrData = Priority;
		pCurrData += 4;
		*pCurrData = (Finished ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(int*)pCurrData = RemainMonth;
		pCurrData += 4;
		if (ParameterContent != null)
		{
			int elementsCount = ParameterContent.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = ParameterContent)
			{
				for (int i = 0; i < elementsCount; i++)
				{
					((short*)pCurrData)[i] = (short)pChar[i];
				}
			}
			pCurrData += 2 * elementsCount;
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		GoalTemplateId = *(int*)pCurrData;
		pCurrData += 4;
		CreateDate = *(int*)pCurrData;
		pCurrData += 4;
		Priority = *(int*)pCurrData;
		pCurrData += 4;
		Finished = *pCurrData != 0;
		pCurrData++;
		RemainMonth = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			ParameterContent = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			ParameterContent = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
