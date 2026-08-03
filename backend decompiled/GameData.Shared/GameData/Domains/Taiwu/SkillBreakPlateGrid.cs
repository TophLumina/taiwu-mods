using Config;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 突破盘格子
/// </summary>
[AutoGenerateSerializableGameData(IsExtensible = true)]
public class SkillBreakPlateGrid : ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort SuccessRateFix = 1;

		public const ushort InternalState = 2;

		public const ushort AddMaxPower = 3;

		public const ushort RecordedSuccessRate = 4;

		public const ushort RecordedStepIsGoneMad = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "TemplateId", "SuccessRateFix", "InternalState", "AddMaxPower", "RecordedSuccessRate", "RecordedStepIsGoneMad" };
	}

	/// <summary>
	/// 模板ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public sbyte TemplateId;

	/// <summary>
	/// 成功率修正
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte SuccessRateFix;

	/// <summary>
	/// 状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	private sbyte _internalState;

	/// <summary>
	/// 分布的加成威力值
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public int AddMaxPower;

	/// <summary>
	/// 被选中时的成功率
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public short RecordedSuccessRate;

	/// <summary>
	/// 被选中时是否处于走火入魔状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public bool RecordedStepIsGoneMad;

	/// <summary>
	/// 模板数据
	/// </summary>
	public SkillBreakGridTypeItem Template => SkillBreakGridType.Instance[TemplateId];

	/// <summary>
	/// 格子状态
	/// </summary>
	public ESkillBreakGridState State
	{
		get
		{
			return (ESkillBreakGridState)_internalState;
		}
		set
		{
			_internalState = (sbyte)value;
		}
	}

	/// <summary>
	/// 构造方法
	/// </summary>
	/// <param name="templateId"></param>
	/// <param name="successRateFix"></param>
	/// <param name="state"></param>
	public SkillBreakPlateGrid(sbyte templateId, sbyte successRateFix, ESkillBreakGridState state)
	{
		TemplateId = templateId;
		SuccessRateFix = successRateFix;
		_internalState = (sbyte)state;
		AddMaxPower = 0;
		RecordedSuccessRate = -1;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SkillBreakPlateGrid()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SkillBreakPlateGrid(SkillBreakPlateGrid other)
	{
		TemplateId = other.TemplateId;
		SuccessRateFix = other.SuccessRateFix;
		_internalState = other._internalState;
		AddMaxPower = other.AddMaxPower;
		RecordedSuccessRate = other.RecordedSuccessRate;
		RecordedStepIsGoneMad = other.RecordedStepIsGoneMad;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SkillBreakPlateGrid other)
	{
		TemplateId = other.TemplateId;
		SuccessRateFix = other.SuccessRateFix;
		_internalState = other._internalState;
		AddMaxPower = other.AddMaxPower;
		RecordedSuccessRate = other.RecordedSuccessRate;
		RecordedStepIsGoneMad = other.RecordedStepIsGoneMad;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 6;
		byte* num = pData + 2;
		*num = (byte)TemplateId;
		byte* num2 = num + 1;
		*num2 = (byte)SuccessRateFix;
		byte* num3 = num2 + 1;
		*num3 = (byte)_internalState;
		byte* num4 = num3 + 1;
		*(int*)num4 = AddMaxPower;
		byte* num5 = num4 + 4;
		*(short*)num5 = RecordedSuccessRate;
		byte* num6 = num5 + 2;
		*num6 = (RecordedStepIsGoneMad ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num6 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			TemplateId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			SuccessRateFix = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			_internalState = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			AddMaxPower = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 4)
		{
			RecordedSuccessRate = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			RecordedStepIsGoneMad = *pCurrData != 0;
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
