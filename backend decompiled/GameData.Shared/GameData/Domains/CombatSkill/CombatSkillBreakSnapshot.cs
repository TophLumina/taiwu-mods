using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.CombatSkill;

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

	[SerializableGameDataField(FieldIndex = 0)]
	public SkillBreakPlate BreakPlate;

	[SerializableGameDataField(FieldIndex = 1)]
	public int LastClearTime;

	[SerializableGameDataField(FieldIndex = 2)]
	public int LastForceBreakoutStepsCount;

	[SerializableGameDataField(FieldIndex = 3)]
	public sbyte LuohanId = -1;

	[SerializableGameDataField(FieldIndex = 4)]
	public ushort LuohanState;

	[SerializableGameDataField(FieldIndex = 5)]
	public ushort DefaultState;

	public CombatSkillBreakSnapshot()
	{
	}

	public CombatSkillBreakSnapshot(CombatSkillBreakSnapshot other)
	{
		BreakPlate = new SkillBreakPlate(other.BreakPlate);
		LastClearTime = other.LastClearTime;
		LastForceBreakoutStepsCount = other.LastForceBreakoutStepsCount;
		LuohanId = other.LuohanId;
		LuohanState = other.LuohanState;
		DefaultState = other.DefaultState;
	}

	public void Assign(CombatSkillBreakSnapshot other)
	{
		BreakPlate = new SkillBreakPlate(other.BreakPlate);
		LastClearTime = other.LastClearTime;
		LastForceBreakoutStepsCount = other.LastForceBreakoutStepsCount;
		LuohanId = other.LuohanId;
		LuohanState = other.LuohanState;
		DefaultState = other.DefaultState;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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
