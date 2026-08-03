using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

/// <summary>
/// 功法突破快照
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CombatSkillBreakSnapshot : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort BreakPlate = 0;

		public const ushort LastClearTime = 1;

		public const ushort LastForceBreakoutStepsCount = 2;

		public const ushort LuohanId = 3;

		public const ushort LuohanState = 4;

		public const ushort DefaultState = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "BreakPlate", "LastClearTime", "LastForceBreakoutStepsCount", "LuohanId", "LuohanState", "DefaultState" };
	}

	/// <summary>
	/// 突破盘
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public SkillBreakPlate BreakPlate;

	/// <summary>
	/// 上次重修时间
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int LastClearTime;

	/// <summary>
	/// 上次强行突破次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public int LastForceBreakoutStepsCount;

	/// <summary>
	/// 佛像突破
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte LuohanId = -1;

	/// <summary>
	/// 佛像突破书页激活状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 4)]
	public ushort LuohanState;

	/// <summary>
	/// 未突破前激活状态
	/// </summary>
	[SerializableGameDataField(FieldIndex = 5)]
	public ushort DefaultState;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CombatSkillBreakSnapshot()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CombatSkillBreakSnapshot(CombatSkillBreakSnapshot other)
	{
		BreakPlate = new SkillBreakPlate(other.BreakPlate);
		LastClearTime = other.LastClearTime;
		LastForceBreakoutStepsCount = other.LastForceBreakoutStepsCount;
		LuohanId = other.LuohanId;
		LuohanState = other.LuohanState;
		DefaultState = other.DefaultState;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CombatSkillBreakSnapshot other)
	{
		BreakPlate = new SkillBreakPlate(other.BreakPlate);
		LastClearTime = other.LastClearTime;
		LastForceBreakoutStepsCount = other.LastForceBreakoutStepsCount;
		LuohanId = other.LuohanId;
		LuohanState = other.LuohanState;
		DefaultState = other.DefaultState;
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
		totalSize = ((BreakPlate == null) ? (totalSize + 2) : (totalSize + (2 + BreakPlate.GetSerializedSize())));
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
		*(short*)pCurrData = 6;
		pCurrData += 2;
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
		*(int*)pCurrData = LastClearTime;
		pCurrData += 4;
		*(int*)pCurrData = LastForceBreakoutStepsCount;
		pCurrData += 4;
		*pCurrData = (byte)LuohanId;
		pCurrData++;
		*(ushort*)pCurrData = LuohanState;
		pCurrData += 2;
		*(ushort*)pCurrData = DefaultState;
		pCurrData += 2;
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
		if (num > 1)
		{
			LastClearTime = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			LastForceBreakoutStepsCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			LuohanId = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 4)
		{
			LuohanState = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		if (num > 5)
		{
			DefaultState = *(ushort*)pCurrData;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
