using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Building;

[AutoGenerateSerializableGameData(NotForArchive = true)]
public struct MakeResult : ISerializableGameData
{
	[SerializableGameDataField]
	private int _targetStageIndex;

	[SerializableGameDataField]
	public MakeResultStage[] MakeResultItemArray;

	[SerializableGameDataField]
	public short UpgradeBuildingNameTemplate;

	[SerializableGameDataField]
	public bool UpgradeBuildingCanUse;

	public MakeResultStage TargetResultStage => MakeResultItemArray?.GetOrDefault(_targetStageIndex) ?? default(MakeResultStage);

	public int TargetStageIndex => _targetStageIndex;

	public MakeResult(int targetStageIndex, MakeResultStage[] makeResultItemArray, short upgradeBuildingNameTemplate, bool upgradeBuildingCanUse)
	{
		_targetStageIndex = targetStageIndex;
		MakeResultItemArray = makeResultItemArray;
		UpgradeBuildingNameTemplate = upgradeBuildingNameTemplate;
		UpgradeBuildingCanUse = upgradeBuildingCanUse;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		if (MakeResultItemArray != null)
		{
			totalSize += 2;
			for (int i = 0; i < MakeResultItemArray.Length; i++)
			{
				totalSize += MakeResultItemArray[i].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = _targetStageIndex;
		pCurrData += 4;
		if (MakeResultItemArray != null)
		{
			int elementsCount = MakeResultItemArray.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize = MakeResultItemArray[i].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = UpgradeBuildingNameTemplate;
		pCurrData += 2;
		*pCurrData = (UpgradeBuildingCanUse ? ((byte)1) : ((byte)0));
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
		_targetStageIndex = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (MakeResultItemArray == null || MakeResultItemArray.Length != elementsCount)
			{
				MakeResultItemArray = new MakeResultStage[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				MakeResultItemArray[i] = default(MakeResultStage);
				pCurrData += MakeResultItemArray[i].Deserialize(pCurrData);
			}
		}
		else
		{
			MakeResultItemArray = null;
		}
		UpgradeBuildingNameTemplate = *(short*)pCurrData;
		pCurrData += 2;
		UpgradeBuildingCanUse = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
