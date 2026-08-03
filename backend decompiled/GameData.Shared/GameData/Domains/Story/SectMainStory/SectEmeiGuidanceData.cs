using GameData.Serializer;

namespace GameData.Domains.Story.SectMainStory;

/// <summary>
/// 峨眉指点数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class SectEmeiGuidanceData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharId = 0;

		public const ushort Point = 1;

		public const ushort EmeiGuidanceCombatSkillType = 2;

		public const ushort Changed = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CharId", "Point", "EmeiGuidanceCombatSkillType", "Changed" };
	}

	[SerializableGameDataField]
	public int EmeiGuidanceCombatSkillType;

	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public bool Changed;

	/// <summary>
	/// 峨眉指点档次
	/// </summary>
	[SerializableGameDataField]
	public int Point;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public SectEmeiGuidanceData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public SectEmeiGuidanceData(SectEmeiGuidanceData other)
	{
		CharId = other.CharId;
		Point = other.Point;
		EmeiGuidanceCombatSkillType = other.EmeiGuidanceCombatSkillType;
		Changed = other.Changed;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(SectEmeiGuidanceData other)
	{
		CharId = other.CharId;
		Point = other.Point;
		EmeiGuidanceCombatSkillType = other.EmeiGuidanceCombatSkillType;
		Changed = other.Changed;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 15;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = CharId;
		byte* num2 = num + 4;
		*(int*)num2 = Point;
		byte* num3 = num2 + 4;
		*(int*)num3 = EmeiGuidanceCombatSkillType;
		byte* num4 = num3 + 4;
		*num4 = (Changed ? ((byte)1) : ((byte)0));
		int totalSize = (int)(num4 + 1 - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CharId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			Point = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			EmeiGuidanceCombatSkillType = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			Changed = *pCurrData != 0;
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
