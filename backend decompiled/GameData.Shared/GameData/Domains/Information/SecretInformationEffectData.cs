using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Information;

/// <summary>
/// 秘闻公开效果数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SecretInformationEffectData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 类型，-1代表来源者，其余参见<see cref="T:Config.SecretInformationAppliedRelation" />, 行为人为主要，其余都为次要
	/// </summary>
	[SerializableGameDataField]
	public short Type;

	[SerializableGameDataField]
	public int HappinessDelta;

	[SerializableGameDataField]
	public int FavorDelta;

	[SerializableGameDataField]
	public int FavorCount;

	[SerializableGameDataField]
	public bool HasEnemy;

	[SerializableGameDataField]
	public List<short> Fame = new List<short>();

	[SerializableGameDataField]
	public List<ShortPair> Punish = new List<ShortPair>();

	public SecretInformationEffectData(int charId, short type)
	{
		CharId = charId;
		Type = type;
	}

	public SecretInformationEffectData()
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 19;
		totalSize = ((Fame == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Fame.Count)));
		if (Punish != null)
		{
			totalSize += 2;
			for (int i = 0; i < Punish.Count; i++)
			{
				totalSize += Punish[i].GetSerializedSize();
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
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(short*)pCurrData = Type;
		pCurrData += 2;
		*(int*)pCurrData = HappinessDelta;
		pCurrData += 4;
		*(int*)pCurrData = FavorDelta;
		pCurrData += 4;
		*(int*)pCurrData = FavorCount;
		pCurrData += 4;
		*pCurrData = (HasEnemy ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (Fame != null)
		{
			int elementsCount = Fame.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = Fame[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Punish != null)
		{
			int elementsCount2 = Punish.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				int fieldSize = Punish[j].Serialize(pCurrData);
				pCurrData += fieldSize;
				Tester.Assert(fieldSize <= 65535);
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		Type = *(short*)pCurrData;
		pCurrData += 2;
		HappinessDelta = *(int*)pCurrData;
		pCurrData += 4;
		FavorDelta = *(int*)pCurrData;
		pCurrData += 4;
		FavorCount = *(int*)pCurrData;
		pCurrData += 4;
		HasEnemy = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Fame == null)
			{
				Fame = new List<short>();
			}
			else
			{
				Fame.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				Fame.Add(element);
			}
		}
		else
		{
			Fame?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (Punish == null)
			{
				Punish = new List<ShortPair>();
			}
			else
			{
				Punish.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ShortPair element2 = default(ShortPair);
				pCurrData += element2.Deserialize(pCurrData);
				Punish.Add(element2);
			}
		}
		else
		{
			Punish?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
