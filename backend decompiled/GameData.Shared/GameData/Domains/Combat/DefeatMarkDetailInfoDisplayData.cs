using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Combat;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class DefeatMarkDetailInfoDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int PoisonTriggerProgress;

	[SerializableGameDataField]
	public int StateBuffPower;

	[SerializableGameDataField]
	public short[] WugTemplateIds;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize = ((WugTemplateIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * WugTemplateIds.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = PoisonTriggerProgress;
		pCurrData += 4;
		*(int*)pCurrData = StateBuffPower;
		pCurrData += 4;
		if (WugTemplateIds != null)
		{
			int elementsCount = WugTemplateIds.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = WugTemplateIds[i];
				pCurrData += 2;
			}
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

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		PoisonTriggerProgress = *(int*)pCurrData;
		pCurrData += 4;
		StateBuffPower = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (WugTemplateIds == null || WugTemplateIds.Length != elementsCount)
			{
				WugTemplateIds = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				WugTemplateIds[i] = *(short*)pCurrData;
				pCurrData += 2;
			}
		}
		else
		{
			WugTemplateIds = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
