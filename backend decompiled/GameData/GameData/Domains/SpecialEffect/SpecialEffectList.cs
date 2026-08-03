using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect;

[SerializableGameData(NotForDisplayModule = true)]
public class SpecialEffectList : ISerializableGameData
{
	public List<SpecialEffectBase> EffectList;

	public SpecialEffectList()
	{
		EffectList = new List<SpecialEffectBase>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 2;
		if (EffectList != null)
		{
			for (int i = 0; i < EffectList.Count; i++)
			{
				totalSize += 4;
				totalSize += EffectList[i].GetSerializedSize();
			}
		}
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (EffectList != null)
		{
			int elementsCount = EffectList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				SpecialEffectBase effect = EffectList[i];
				*(int*)pCurrData = effect.Type;
				pCurrData += 4;
				pCurrData += EffectList[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (EffectList == null)
			{
				EffectList = new List<SpecialEffectBase>();
			}
			EffectList.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				int type = *(int*)pCurrData;
				pCurrData += 4;
				SpecialEffectBase effect = SpecialEffectType.CreateEffectObj(type);
				pCurrData += effect.Deserialize(pCurrData);
				EffectList.Add(effect);
			}
			pCurrData += (int)elementsCount;
		}
		else
		{
			EffectList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
