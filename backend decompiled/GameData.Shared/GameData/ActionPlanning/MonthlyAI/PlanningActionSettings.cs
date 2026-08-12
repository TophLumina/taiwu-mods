using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.MonthlyAI;

[AutoGenerateSerializableGameData]
public class PlanningActionSettings : ISerializableGameData
{
	[SerializableGameDataField(FieldIndex = 0)]
	public bool Disabled;

	[SerializableGameDataField(FieldIndex = 1)]
	public int WeightAdjust;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public PlanningActionSettings()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public PlanningActionSettings(PlanningActionSettings other)
	{
		Disabled = other.Disabled;
		WeightAdjust = other.WeightAdjust;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(PlanningActionSettings other)
	{
		Disabled = other.Disabled;
		WeightAdjust = other.WeightAdjust;
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
		*(int*)num = WeightAdjust;
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
		WeightAdjust = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
