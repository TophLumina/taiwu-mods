using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

public class SecretInformationBroadcastTipsExtraData : ISerializableGameData
{
	[SerializableGameDataField]
	public int MetaDataId;

	[SerializableGameDataField]
	public List<int> StartEnemyRelationCharactersToActor;

	[SerializableGameDataField]
	public List<int> StartEnemyRelationCharactersToReactor;

	[SerializableGameDataField]
	public List<int> StartEnemyRelationCharactersToSecactor;

	[SerializableGameDataField]
	public List<int> StartEnemyRelationCharactersToSource;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize = ((StartEnemyRelationCharactersToActor == null) ? (totalSize + 2) : (totalSize + (2 + 4 * StartEnemyRelationCharactersToActor.Count)));
		totalSize = ((StartEnemyRelationCharactersToReactor == null) ? (totalSize + 2) : (totalSize + (2 + 4 * StartEnemyRelationCharactersToReactor.Count)));
		totalSize = ((StartEnemyRelationCharactersToSecactor == null) ? (totalSize + 2) : (totalSize + (2 + 4 * StartEnemyRelationCharactersToSecactor.Count)));
		totalSize = ((StartEnemyRelationCharactersToSource == null) ? (totalSize + 2) : (totalSize + (2 + 4 * StartEnemyRelationCharactersToSource.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = MetaDataId;
		pCurrData += 4;
		if (StartEnemyRelationCharactersToActor != null)
		{
			int elementsCount = StartEnemyRelationCharactersToActor.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = StartEnemyRelationCharactersToActor[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (StartEnemyRelationCharactersToReactor != null)
		{
			int elementsCount2 = StartEnemyRelationCharactersToReactor.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = StartEnemyRelationCharactersToReactor[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (StartEnemyRelationCharactersToSecactor != null)
		{
			int elementsCount3 = StartEnemyRelationCharactersToSecactor.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = StartEnemyRelationCharactersToSecactor[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (StartEnemyRelationCharactersToSource != null)
		{
			int elementsCount4 = StartEnemyRelationCharactersToSource.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((int*)pCurrData)[l] = StartEnemyRelationCharactersToSource[l];
			}
			pCurrData += 4 * elementsCount4;
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
		MetaDataId = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (StartEnemyRelationCharactersToActor == null)
			{
				StartEnemyRelationCharactersToActor = new List<int>(elementsCount);
			}
			else
			{
				StartEnemyRelationCharactersToActor.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				StartEnemyRelationCharactersToActor.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			StartEnemyRelationCharactersToActor?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (StartEnemyRelationCharactersToReactor == null)
			{
				StartEnemyRelationCharactersToReactor = new List<int>(elementsCount2);
			}
			else
			{
				StartEnemyRelationCharactersToReactor.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				StartEnemyRelationCharactersToReactor.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			StartEnemyRelationCharactersToReactor?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (StartEnemyRelationCharactersToSecactor == null)
			{
				StartEnemyRelationCharactersToSecactor = new List<int>(elementsCount3);
			}
			else
			{
				StartEnemyRelationCharactersToSecactor.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				StartEnemyRelationCharactersToSecactor.Add(((int*)pCurrData)[k]);
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			StartEnemyRelationCharactersToSecactor?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (StartEnemyRelationCharactersToSource == null)
			{
				StartEnemyRelationCharactersToSource = new List<int>(elementsCount4);
			}
			else
			{
				StartEnemyRelationCharactersToSource.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				StartEnemyRelationCharactersToSource.Add(((int*)pCurrData)[l]);
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			StartEnemyRelationCharactersToSource?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
