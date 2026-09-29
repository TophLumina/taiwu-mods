using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.DLC.TameLoong;

[AutoGenerateSerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public struct TameLoongData : ISerializableGameData, IPolymorphRuntime
{
	public static class FieldIds
	{
		public const ushort FemaleCharacterId = 0;

		public const ushort MaleCharacterId = 1;

		public const ushort ItemKey = 2;

		public const ushort State = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "FemaleCharacterId", "MaleCharacterId", "ItemKey", "State" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int FemaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 1)]
	public int MaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 2)]
	public ItemKey ItemKey = ItemKey.Invalid;

	[SerializableGameDataField(FieldIndex = 3)]
	public EPolymorphState State = EPolymorphState.None;

	public bool IsAlive => (State & EPolymorphState.Alive) != 0;

	public int CharacterId
	{
		get
		{
			if (!IsAlive)
			{
				return -1;
			}
			if ((State & EPolymorphState.Male) != EPolymorphState.Male)
			{
				return FemaleCharacterId;
			}
			return MaleCharacterId;
		}
	}

	public IEnumerable<int> CharacterIds
	{
		get
		{
			if (MaleCharacterId != -1)
			{
				yield return MaleCharacterId;
			}
			if (FemaleCharacterId != -1)
			{
				yield return FemaleCharacterId;
			}
		}
	}

	int IPolymorphRuntime.MaleCharacterId => MaleCharacterId;

	int IPolymorphRuntime.FemaleCharacterId => FemaleCharacterId;

	EPolymorphState IPolymorphRuntime.State
	{
		get
		{
			return State;
		}
		set
		{
			State = value;
		}
	}

	public TameLoongData()
	{
	}

	public override string ToString()
	{
		return $"TameLoongData(charIds = ({FemaleCharacterId}, {MaleCharacterId}), key = {ItemKey} state = {State})";
	}

	public static short GetEnemyTemplateIdByCharacterTemplateId(short characterTemplateId)
	{
		switch (characterTemplateId)
		{
		case 1316:
		case 1317:
			return 246;
		case 1318:
		case 1319:
			return 247;
		case 1320:
		case 1321:
			return 248;
		case 1322:
		case 1323:
			return 249;
		case 1324:
		case 1325:
			return 250;
		default:
			return -1;
		}
	}

	public static short GetCharacterTemplateId(short enemyTemplateId, sbyte gender)
	{
		switch (enemyTemplateId)
		{
		case 246:
			switch (gender)
			{
			case 1:
				return 1316;
			case 0:
				return 1317;
			}
			break;
		case 247:
			switch (gender)
			{
			case 1:
				return 1318;
			case 0:
				return 1319;
			}
			break;
		case 248:
			switch (gender)
			{
			case 1:
				return 1320;
			case 0:
				return 1321;
			}
			break;
		case 249:
			switch (gender)
			{
			case 1:
				return 1322;
			case 0:
				return 1323;
			}
			break;
		case 250:
			switch (gender)
			{
			case 1:
				return 1324;
			case 0:
				return 1325;
			}
			break;
		}
		return -1;
	}

	public static short GetEnemyTemplateId(ItemKey key)
	{
		if (key.ItemType != 4)
		{
			return -1;
		}
		return GetEnemyTemplateIdByCarrierTemplateId(key.TemplateId);
	}

	public static short GetEnemyTemplateIdByCarrierTemplateId(short carrierTemplateId)
	{
		return carrierTemplateId switch
		{
			86 => 246, 
			87 => 247, 
			88 => 248, 
			89 => 249, 
			90 => 250, 
			_ => -1, 
		};
	}

	public static short GetCarrierTemplateIdByEnemyTemplateId(short enemyTemplateId)
	{
		return enemyTemplateId switch
		{
			246 => 86, 
			247 => 87, 
			248 => 88, 
			249 => 89, 
			250 => 90, 
			_ => -1, 
		};
	}

	public static short GetFleeAnimalId(short enemyTemplateId)
	{
		return enemyTemplateId switch
		{
			246 => 1343, 
			247 => 1344, 
			248 => 1345, 
			249 => 1346, 
			250 => 1347, 
			_ => enemyTemplateId, 
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		*(int*)pCurrData = FemaleCharacterId;
		pCurrData += 4;
		*(int*)pCurrData = MaleCharacterId;
		pCurrData += 4;
		pCurrData += ItemKey.Serialize(pCurrData);
		*pCurrData = (byte)State;
		pCurrData++;
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
			FemaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			MaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			pCurrData += ItemKey.Deserialize(pCurrData);
		}
		if (num > 3)
		{
			State = (EPolymorphState)(*pCurrData);
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
