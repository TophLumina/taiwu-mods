using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Global;

[SerializableGameData(NoCopyConstructors = true)]
public class SharedGlobalSettings : ISerializableGameData
{
	[SerializableGameDataField]
	public string Language;

	[SerializableGameDataField]
	public bool AutoTriggerMapNormalPickup;

	[SerializableGameDataField]
	public MapPickupAutoTriggerSetting NormalMapPickupAutoTriggerSetting;

	[SerializableGameDataField]
	public int AutoWipeOut;

	[SerializableGameDataField]
	public bool AvoidHereticAttackBlocks;

	[SerializableGameDataField]
	public bool AvoidInfectedCharacterBlocks;

	[SerializableGameDataField]
	public bool PreferUnlockedTravelRoute;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((Language == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Language.Length)));
		totalSize = ((NormalMapPickupAutoTriggerSetting == null) ? (totalSize + 2) : (totalSize + (2 + NormalMapPickupAutoTriggerSetting.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Language != null)
		{
			int elementsCount = Language.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Language)
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
		*pCurrData = (AutoTriggerMapNormalPickup ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (NormalMapPickupAutoTriggerSetting != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = NormalMapPickupAutoTriggerSetting.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AutoWipeOut;
		pCurrData += 4;
		*pCurrData = (AvoidHereticAttackBlocks ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (AvoidInfectedCharacterBlocks ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (PreferUnlockedTravelRoute ? ((byte)1) : ((byte)0));
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			Language = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Language = null;
		}
		AutoTriggerMapNormalPickup = *pCurrData != 0;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (NormalMapPickupAutoTriggerSetting == null)
			{
				NormalMapPickupAutoTriggerSetting = new MapPickupAutoTriggerSetting();
			}
			pCurrData += NormalMapPickupAutoTriggerSetting.Deserialize(pCurrData);
		}
		else
		{
			NormalMapPickupAutoTriggerSetting = null;
		}
		AutoWipeOut = *(int*)pCurrData;
		pCurrData += 4;
		AvoidHereticAttackBlocks = *pCurrData != 0;
		pCurrData++;
		AvoidInfectedCharacterBlocks = *pCurrData != 0;
		pCurrData++;
		PreferUnlockedTravelRoute = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool IsTypeAutoWipeOutOn(int index)
	{
		return (AutoWipeOut & (1 << index)) != 0;
	}

	public bool IsTypeAutoWipeOutOn(WipeOutType type)
	{
		return IsTypeAutoWipeOutOn((int)type);
	}
}
