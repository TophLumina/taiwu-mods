using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Information;

public class SecretInformationBroadcastTipsData : ISerializableGameData
{
	[SerializableGameDataField]
	public int MetaDataId;

	public SecretInformationDisplayData DisplayData;

	public static SecretInformationDisplayPackage DisplayPackage;

	public static Dictionary<int, NameRelatedData> NameRelatedDataMap;

	[SerializableGameDataField]
	public byte BroadcastType;

	[SerializableGameDataField]
	public List<int> FameActionsOfMain;

	[SerializableGameDataField]
	public List<int> FameActionsOfTarget1;

	[SerializableGameDataField]
	public List<int> FameActionsOfTarget2;

	[SerializableGameDataField]
	public List<int> HappinessUpCharacters;

	[SerializableGameDataField]
	public List<int> HappinessDownCharacters;

	[SerializableGameDataField]
	public List<int> FavorToMainUpCharacters;

	[SerializableGameDataField]
	public List<int> FavorToMainDownCharacters;

	[SerializableGameDataField]
	public List<int> FavorToTarget1UpCharacters;

	[SerializableGameDataField]
	public List<int> FavorToTarget1DownCharacters;

	[SerializableGameDataField]
	public List<int> FavorToTarget2UpCharacters;

	[SerializableGameDataField]
	public List<int> FavorToTarget2DownCharacters;

	public SecretInformationBroadcastTipsData()
	{
	}

	public SecretInformationBroadcastTipsData(SecretInformationBroadcastTipsData other)
	{
		MetaDataId = other.MetaDataId;
		BroadcastType = other.BroadcastType;
		FameActionsOfMain = ((other.FameActionsOfMain == null) ? null : new List<int>(other.FameActionsOfMain));
		FameActionsOfTarget1 = ((other.FameActionsOfTarget1 == null) ? null : new List<int>(other.FameActionsOfTarget1));
		FameActionsOfTarget2 = ((other.FameActionsOfTarget2 == null) ? null : new List<int>(other.FameActionsOfTarget2));
		HappinessUpCharacters = ((other.HappinessUpCharacters == null) ? null : new List<int>(other.HappinessUpCharacters));
		HappinessDownCharacters = ((other.HappinessDownCharacters == null) ? null : new List<int>(other.HappinessDownCharacters));
		FavorToMainUpCharacters = ((other.FavorToMainUpCharacters == null) ? null : new List<int>(other.FavorToMainUpCharacters));
		FavorToMainDownCharacters = ((other.FavorToMainDownCharacters == null) ? null : new List<int>(other.FavorToMainDownCharacters));
		FavorToTarget1UpCharacters = ((other.FavorToTarget1UpCharacters == null) ? null : new List<int>(other.FavorToTarget1UpCharacters));
		FavorToTarget1DownCharacters = ((other.FavorToTarget1DownCharacters == null) ? null : new List<int>(other.FavorToTarget1DownCharacters));
		FavorToTarget2UpCharacters = ((other.FavorToTarget2UpCharacters == null) ? null : new List<int>(other.FavorToTarget2UpCharacters));
		FavorToTarget2DownCharacters = ((other.FavorToTarget2DownCharacters == null) ? null : new List<int>(other.FavorToTarget2DownCharacters));
	}

	public void Assign(SecretInformationBroadcastTipsData other)
	{
		MetaDataId = other.MetaDataId;
		BroadcastType = other.BroadcastType;
		FameActionsOfMain = ((other.FameActionsOfMain == null) ? null : new List<int>(other.FameActionsOfMain));
		FameActionsOfTarget1 = ((other.FameActionsOfTarget1 == null) ? null : new List<int>(other.FameActionsOfTarget1));
		FameActionsOfTarget2 = ((other.FameActionsOfTarget2 == null) ? null : new List<int>(other.FameActionsOfTarget2));
		HappinessUpCharacters = ((other.HappinessUpCharacters == null) ? null : new List<int>(other.HappinessUpCharacters));
		HappinessDownCharacters = ((other.HappinessDownCharacters == null) ? null : new List<int>(other.HappinessDownCharacters));
		FavorToMainUpCharacters = ((other.FavorToMainUpCharacters == null) ? null : new List<int>(other.FavorToMainUpCharacters));
		FavorToMainDownCharacters = ((other.FavorToMainDownCharacters == null) ? null : new List<int>(other.FavorToMainDownCharacters));
		FavorToTarget1UpCharacters = ((other.FavorToTarget1UpCharacters == null) ? null : new List<int>(other.FavorToTarget1UpCharacters));
		FavorToTarget1DownCharacters = ((other.FavorToTarget1DownCharacters == null) ? null : new List<int>(other.FavorToTarget1DownCharacters));
		FavorToTarget2UpCharacters = ((other.FavorToTarget2UpCharacters == null) ? null : new List<int>(other.FavorToTarget2UpCharacters));
		FavorToTarget2DownCharacters = ((other.FavorToTarget2DownCharacters == null) ? null : new List<int>(other.FavorToTarget2DownCharacters));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 5;
		totalSize = ((FameActionsOfMain == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FameActionsOfMain.Count)));
		totalSize = ((FameActionsOfTarget1 == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FameActionsOfTarget1.Count)));
		totalSize = ((FameActionsOfTarget2 == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FameActionsOfTarget2.Count)));
		totalSize = ((HappinessUpCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * HappinessUpCharacters.Count)));
		totalSize = ((HappinessDownCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * HappinessDownCharacters.Count)));
		totalSize = ((FavorToMainUpCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToMainUpCharacters.Count)));
		totalSize = ((FavorToMainDownCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToMainDownCharacters.Count)));
		totalSize = ((FavorToTarget1UpCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToTarget1UpCharacters.Count)));
		totalSize = ((FavorToTarget1DownCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToTarget1DownCharacters.Count)));
		totalSize = ((FavorToTarget2UpCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToTarget2UpCharacters.Count)));
		totalSize = ((FavorToTarget2DownCharacters == null) ? (totalSize + 2) : (totalSize + (2 + 4 * FavorToTarget2DownCharacters.Count)));
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
		*pCurrData = BroadcastType;
		pCurrData++;
		if (FameActionsOfMain != null)
		{
			int elementsCount = FameActionsOfMain.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = FameActionsOfMain[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FameActionsOfTarget1 != null)
		{
			int elementsCount2 = FameActionsOfTarget1.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = FameActionsOfTarget1[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FameActionsOfTarget2 != null)
		{
			int elementsCount3 = FameActionsOfTarget2.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((int*)pCurrData)[k] = FameActionsOfTarget2[k];
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HappinessUpCharacters != null)
		{
			int elementsCount4 = HappinessUpCharacters.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				((int*)pCurrData)[l] = HappinessUpCharacters[l];
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HappinessDownCharacters != null)
		{
			int elementsCount5 = HappinessDownCharacters.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((int*)pCurrData)[m] = HappinessDownCharacters[m];
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToMainUpCharacters != null)
		{
			int elementsCount6 = FavorToMainUpCharacters.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				((int*)pCurrData)[n] = FavorToMainUpCharacters[n];
			}
			pCurrData += 4 * elementsCount6;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToMainDownCharacters != null)
		{
			int elementsCount7 = FavorToMainDownCharacters.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				((int*)pCurrData)[num] = FavorToMainDownCharacters[num];
			}
			pCurrData += 4 * elementsCount7;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToTarget1UpCharacters != null)
		{
			int elementsCount8 = FavorToTarget1UpCharacters.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				((int*)pCurrData)[num2] = FavorToTarget1UpCharacters[num2];
			}
			pCurrData += 4 * elementsCount8;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToTarget1DownCharacters != null)
		{
			int elementsCount9 = FavorToTarget1DownCharacters.Count;
			Tester.Assert(elementsCount9 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount9;
			pCurrData += 2;
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				((int*)pCurrData)[num3] = FavorToTarget1DownCharacters[num3];
			}
			pCurrData += 4 * elementsCount9;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToTarget2UpCharacters != null)
		{
			int elementsCount10 = FavorToTarget2UpCharacters.Count;
			Tester.Assert(elementsCount10 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount10;
			pCurrData += 2;
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				((int*)pCurrData)[num4] = FavorToTarget2UpCharacters[num4];
			}
			pCurrData += 4 * elementsCount10;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (FavorToTarget2DownCharacters != null)
		{
			int elementsCount11 = FavorToTarget2DownCharacters.Count;
			Tester.Assert(elementsCount11 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount11;
			pCurrData += 2;
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				((int*)pCurrData)[num5] = FavorToTarget2DownCharacters[num5];
			}
			pCurrData += 4 * elementsCount11;
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
		BroadcastType = *pCurrData;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FameActionsOfMain == null)
			{
				FameActionsOfMain = new List<int>(elementsCount);
			}
			else
			{
				FameActionsOfMain.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				FameActionsOfMain.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			FameActionsOfMain?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (FameActionsOfTarget1 == null)
			{
				FameActionsOfTarget1 = new List<int>(elementsCount2);
			}
			else
			{
				FameActionsOfTarget1.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				FameActionsOfTarget1.Add(((int*)pCurrData)[j]);
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			FameActionsOfTarget1?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (FameActionsOfTarget2 == null)
			{
				FameActionsOfTarget2 = new List<int>(elementsCount3);
			}
			else
			{
				FameActionsOfTarget2.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				FameActionsOfTarget2.Add(((int*)pCurrData)[k]);
			}
			pCurrData += 4 * elementsCount3;
		}
		else
		{
			FameActionsOfTarget2?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (HappinessUpCharacters == null)
			{
				HappinessUpCharacters = new List<int>(elementsCount4);
			}
			else
			{
				HappinessUpCharacters.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				HappinessUpCharacters.Add(((int*)pCurrData)[l]);
			}
			pCurrData += 4 * elementsCount4;
		}
		else
		{
			HappinessUpCharacters?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (HappinessDownCharacters == null)
			{
				HappinessDownCharacters = new List<int>(elementsCount5);
			}
			else
			{
				HappinessDownCharacters.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				HappinessDownCharacters.Add(((int*)pCurrData)[m]);
			}
			pCurrData += 4 * elementsCount5;
		}
		else
		{
			HappinessDownCharacters?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (FavorToMainUpCharacters == null)
			{
				FavorToMainUpCharacters = new List<int>(elementsCount6);
			}
			else
			{
				FavorToMainUpCharacters.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				FavorToMainUpCharacters.Add(((int*)pCurrData)[n]);
			}
			pCurrData += 4 * elementsCount6;
		}
		else
		{
			FavorToMainUpCharacters?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (FavorToMainDownCharacters == null)
			{
				FavorToMainDownCharacters = new List<int>(elementsCount7);
			}
			else
			{
				FavorToMainDownCharacters.Clear();
			}
			for (int num = 0; num < elementsCount7; num++)
			{
				FavorToMainDownCharacters.Add(((int*)pCurrData)[num]);
			}
			pCurrData += 4 * elementsCount7;
		}
		else
		{
			FavorToMainDownCharacters?.Clear();
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (FavorToTarget1UpCharacters == null)
			{
				FavorToTarget1UpCharacters = new List<int>(elementsCount8);
			}
			else
			{
				FavorToTarget1UpCharacters.Clear();
			}
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				FavorToTarget1UpCharacters.Add(((int*)pCurrData)[num2]);
			}
			pCurrData += 4 * elementsCount8;
		}
		else
		{
			FavorToTarget1UpCharacters?.Clear();
		}
		ushort elementsCount9 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount9 > 0)
		{
			if (FavorToTarget1DownCharacters == null)
			{
				FavorToTarget1DownCharacters = new List<int>(elementsCount9);
			}
			else
			{
				FavorToTarget1DownCharacters.Clear();
			}
			for (int num3 = 0; num3 < elementsCount9; num3++)
			{
				FavorToTarget1DownCharacters.Add(((int*)pCurrData)[num3]);
			}
			pCurrData += 4 * elementsCount9;
		}
		else
		{
			FavorToTarget1DownCharacters?.Clear();
		}
		ushort elementsCount10 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount10 > 0)
		{
			if (FavorToTarget2UpCharacters == null)
			{
				FavorToTarget2UpCharacters = new List<int>(elementsCount10);
			}
			else
			{
				FavorToTarget2UpCharacters.Clear();
			}
			for (int num4 = 0; num4 < elementsCount10; num4++)
			{
				FavorToTarget2UpCharacters.Add(((int*)pCurrData)[num4]);
			}
			pCurrData += 4 * elementsCount10;
		}
		else
		{
			FavorToTarget2UpCharacters?.Clear();
		}
		ushort elementsCount11 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount11 > 0)
		{
			if (FavorToTarget2DownCharacters == null)
			{
				FavorToTarget2DownCharacters = new List<int>(elementsCount11);
			}
			else
			{
				FavorToTarget2DownCharacters.Clear();
			}
			for (int num5 = 0; num5 < elementsCount11; num5++)
			{
				FavorToTarget2DownCharacters.Add(((int*)pCurrData)[num5]);
			}
			pCurrData += 4 * elementsCount11;
		}
		else
		{
			FavorToTarget2DownCharacters?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
