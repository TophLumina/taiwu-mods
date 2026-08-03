using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.MonthlyAI;

[AutoGenerateSerializableGameData]
public class PlanningGoalSettings : ISerializableGameData
{
	[SerializableGameDataField(FieldIndex = 0)]
	public bool Disabled;

	[SerializableGameDataField(FieldIndex = 1)]
	public int PriorityAdjust;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public PlanningGoalSettings()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public PlanningGoalSettings(PlanningGoalSettings other)
	{
		Disabled = other.Disabled;
		PriorityAdjust = other.PriorityAdjust;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(PlanningGoalSettings other)
	{
		Disabled = other.Disabled;
		PriorityAdjust = other.PriorityAdjust;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*pData = (Disabled ? ((byte)1) : ((byte)0));
		byte* num = pData + 1;
		*(int*)num = PriorityAdjust;
		int totalSize = (int)(num + 4 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		Disabled = *pCurrData != 0;
		pCurrData++;
		PriorityAdjust = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
