using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 梦回合并发生冲突的功法数据
/// </summary>
[SerializableGameData(IsExtensible = true, NoCopyConstructors = true)]
public class ConflictCombatSkill : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TemplateId = 0;

		public const ushort BreakStepCount = 1;

		public const ushort ForcedBreakStepCount = 2;

		public const ushort BreakPlate = 3;

		public const ushort BreakPreset = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "TemplateId", "BreakStepCount", "ForcedBreakStepCount", "BreakPlate", "BreakPreset" };
	}

	/// <summary>
	/// 模板ID
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public short TemplateId;

	/// <summary>
	/// 突破使用步数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public sbyte BreakStepCount;

	/// <summary>
	/// 强行突破的步数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public sbyte ForcedBreakStepCount;

	/// <summary>
	/// 突破盘
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public SkillBreakPlate BreakPlate;

	/// <summary>
	/// 突破预设
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public CombatSkillBreakPreset BreakPreset;

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((BreakPlate == null) ? (totalSize + 2) : (totalSize + (2 + BreakPlate.GetSerializedSize())));
		totalSize = ((BreakPreset == null) ? (totalSize + 2) : (totalSize + (2 + BreakPreset.GetSerializedSize())));
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
		*(short*)pCurrData = 5;
		pCurrData += 2;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		*pCurrData = (byte)BreakStepCount;
		pCurrData++;
		*pCurrData = (byte)ForcedBreakStepCount;
		pCurrData++;
		if (BreakPlate != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = BreakPlate.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BreakPreset != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = BreakPreset.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			TemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (num > 1)
		{
			BreakStepCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 2)
		{
			ForcedBreakStepCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			ushort num2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num2 > 0)
			{
				if (BreakPlate == null)
				{
					BreakPlate = new SkillBreakPlate();
				}
				pCurrData += BreakPlate.Deserialize(pCurrData);
			}
			else
			{
				BreakPlate = null;
			}
		}
		if (num > 4)
		{
			ushort num3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (num3 > 0)
			{
				if (BreakPreset == null)
				{
					BreakPreset = new CombatSkillBreakPreset();
				}
				pCurrData += BreakPreset.Deserialize(pCurrData);
			}
			else
			{
				BreakPreset = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
