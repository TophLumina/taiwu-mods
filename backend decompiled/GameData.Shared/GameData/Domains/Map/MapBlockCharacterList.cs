using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Merchant;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class MapBlockCharacterList : ISerializableGameData
{
	[SerializableGameDataField]
	public List<CharacterDisplayData> SpecialCharacters;

	[SerializableGameDataField]
	public List<CharacterDisplayData> NormalCharacters;

	[SerializableGameDataField]
	public List<CharacterDisplayData> InfectedCharacters;

	[SerializableGameDataField]
	public List<CharacterDisplayData> EnemyCharacters;

	[SerializableGameDataField]
	public List<MapTemplateEnemyInfo> RandomEnemies;

	[SerializableGameDataField]
	public List<Animal> Animals;

	[SerializableGameDataField]
	public List<CaravanDisplayData> Caravans;

	[SerializableGameDataField]
	public List<GraveDisplayData> Graves;

	[SerializableGameDataField]
	public Dictionary<int, bool> HasGuardInfo;

	[SerializableGameDataField]
	public CharacterSet InteractedCharSet;

	public CharacterDisplayData FindChar(int charId)
	{
		IEnumerable<CharacterDisplayData> specialCharacters = SpecialCharacters;
		IEnumerable<CharacterDisplayData> first = specialCharacters ?? Enumerable.Empty<CharacterDisplayData>();
		specialCharacters = NormalCharacters;
		IEnumerable<CharacterDisplayData> first2 = specialCharacters ?? Enumerable.Empty<CharacterDisplayData>();
		specialCharacters = InfectedCharacters;
		IEnumerable<CharacterDisplayData> first3 = specialCharacters ?? Enumerable.Empty<CharacterDisplayData>();
		specialCharacters = EnemyCharacters;
		return first.Concat(first2.Concat(first3.Concat(specialCharacters ?? Enumerable.Empty<CharacterDisplayData>()))).FirstOrDefault((CharacterDisplayData x) => x != null && x.CharacterId == charId);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (SpecialCharacters != null)
		{
			totalSize += 2;
			for (int i = 0; i < SpecialCharacters.Count; i++)
			{
				totalSize = ((SpecialCharacters[i] == null) ? (totalSize + 2) : (totalSize + (2 + SpecialCharacters[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (NormalCharacters != null)
		{
			totalSize += 2;
			for (int j = 0; j < NormalCharacters.Count; j++)
			{
				totalSize = ((NormalCharacters[j] == null) ? (totalSize + 2) : (totalSize + (2 + NormalCharacters[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (InfectedCharacters != null)
		{
			totalSize += 2;
			for (int k = 0; k < InfectedCharacters.Count; k++)
			{
				totalSize = ((InfectedCharacters[k] == null) ? (totalSize + 2) : (totalSize + (2 + InfectedCharacters[k].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (EnemyCharacters != null)
		{
			totalSize += 2;
			for (int l = 0; l < EnemyCharacters.Count; l++)
			{
				totalSize = ((EnemyCharacters[l] == null) ? (totalSize + 2) : (totalSize + (2 + EnemyCharacters[l].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((RandomEnemies == null) ? (totalSize + 2) : (totalSize + (2 + 8 * RandomEnemies.Count)));
		if (Animals != null)
		{
			totalSize += 2;
			for (int m = 0; m < Animals.Count; m++)
			{
				totalSize = ((Animals[m] == null) ? (totalSize + 2) : (totalSize + (2 + Animals[m].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (Caravans != null)
		{
			totalSize += 2;
			for (int n = 0; n < Caravans.Count; n++)
			{
				totalSize = ((Caravans[n] == null) ? (totalSize + 2) : (totalSize + (2 + Caravans[n].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((Graves == null) ? (totalSize + 2) : (totalSize + (2 + 52 * Graves.Count)));
		totalSize += 4;
		if (HasGuardInfo != null)
		{
			foreach (KeyValuePair<int, bool> item in HasGuardInfo)
			{
				_ = item;
				totalSize += 4;
				totalSize++;
			}
		}
		totalSize += InteractedCharSet.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (SpecialCharacters != null)
		{
			int elementsCount = SpecialCharacters.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (SpecialCharacters[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = SpecialCharacters[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (NormalCharacters != null)
		{
			int elementsCount2 = NormalCharacters.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (NormalCharacters[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = NormalCharacters[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (InfectedCharacters != null)
		{
			int elementsCount3 = InfectedCharacters.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (InfectedCharacters[k] != null)
				{
					byte* intPtr3 = pCurrData;
					pCurrData += 2;
					int fieldSize3 = InfectedCharacters[k].Serialize(pCurrData);
					pCurrData += fieldSize3;
					Tester.Assert(fieldSize3 <= 65535);
					*(ushort*)intPtr3 = (ushort)fieldSize3;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (EnemyCharacters != null)
		{
			int elementsCount4 = EnemyCharacters.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				if (EnemyCharacters[l] != null)
				{
					byte* intPtr4 = pCurrData;
					pCurrData += 2;
					int fieldSize4 = EnemyCharacters[l].Serialize(pCurrData);
					pCurrData += fieldSize4;
					Tester.Assert(fieldSize4 <= 65535);
					*(ushort*)intPtr4 = (ushort)fieldSize4;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RandomEnemies != null)
		{
			int elementsCount5 = RandomEnemies.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += RandomEnemies[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Animals != null)
		{
			int elementsCount6 = Animals.Count;
			Tester.Assert(elementsCount6 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount6;
			pCurrData += 2;
			for (int n = 0; n < elementsCount6; n++)
			{
				if (Animals[n] != null)
				{
					byte* intPtr5 = pCurrData;
					pCurrData += 2;
					int fieldSize5 = Animals[n].Serialize(pCurrData);
					pCurrData += fieldSize5;
					Tester.Assert(fieldSize5 <= 65535);
					*(ushort*)intPtr5 = (ushort)fieldSize5;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Caravans != null)
		{
			int elementsCount7 = Caravans.Count;
			Tester.Assert(elementsCount7 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount7;
			pCurrData += 2;
			for (int num = 0; num < elementsCount7; num++)
			{
				if (Caravans[num] != null)
				{
					byte* intPtr6 = pCurrData;
					pCurrData += 2;
					int fieldSize6 = Caravans[num].Serialize(pCurrData);
					pCurrData += fieldSize6;
					Tester.Assert(fieldSize6 <= 65535);
					*(ushort*)intPtr6 = (ushort)fieldSize6;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Graves != null)
		{
			int elementsCount8 = Graves.Count;
			Tester.Assert(elementsCount8 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount8;
			pCurrData += 2;
			for (int num2 = 0; num2 < elementsCount8; num2++)
			{
				pCurrData += Graves[num2].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (HasGuardInfo != null)
		{
			*(int*)pCurrData = HasGuardInfo.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, bool> pair in HasGuardInfo)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*pCurrData = (pair.Value ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		int fieldSize7 = InteractedCharSet.Serialize(pCurrData);
		pCurrData += fieldSize7;
		Tester.Assert(fieldSize7 <= 65535);
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
			if (SpecialCharacters == null)
			{
				SpecialCharacters = new List<CharacterDisplayData>();
			}
			else
			{
				SpecialCharacters.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element;
				if (num > 0)
				{
					element = new CharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				SpecialCharacters.Add(element);
			}
		}
		else
		{
			SpecialCharacters?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (NormalCharacters == null)
			{
				NormalCharacters = new List<CharacterDisplayData>();
			}
			else
			{
				NormalCharacters.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element2;
				if (num2 > 0)
				{
					element2 = new CharacterDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				NormalCharacters.Add(element2);
			}
		}
		else
		{
			NormalCharacters?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (InfectedCharacters == null)
			{
				InfectedCharacters = new List<CharacterDisplayData>();
			}
			else
			{
				InfectedCharacters.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ushort num3 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element3;
				if (num3 > 0)
				{
					element3 = new CharacterDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				InfectedCharacters.Add(element3);
			}
		}
		else
		{
			InfectedCharacters?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (EnemyCharacters == null)
			{
				EnemyCharacters = new List<CharacterDisplayData>();
			}
			else
			{
				EnemyCharacters.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num4 = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element4;
				if (num4 > 0)
				{
					element4 = new CharacterDisplayData();
					pCurrData += element4.Deserialize(pCurrData);
				}
				else
				{
					element4 = null;
				}
				EnemyCharacters.Add(element4);
			}
		}
		else
		{
			EnemyCharacters?.Clear();
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (RandomEnemies == null)
			{
				RandomEnemies = new List<MapTemplateEnemyInfo>();
			}
			else
			{
				RandomEnemies.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				MapTemplateEnemyInfo element5 = default(MapTemplateEnemyInfo);
				pCurrData += element5.Deserialize(pCurrData);
				RandomEnemies.Add(element5);
			}
		}
		else
		{
			RandomEnemies?.Clear();
		}
		ushort elementsCount6 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount6 > 0)
		{
			if (Animals == null)
			{
				Animals = new List<Animal>();
			}
			else
			{
				Animals.Clear();
			}
			for (int n = 0; n < elementsCount6; n++)
			{
				ushort num5 = *(ushort*)pCurrData;
				pCurrData += 2;
				Animal element6;
				if (num5 > 0)
				{
					element6 = new Animal();
					pCurrData += element6.Deserialize(pCurrData);
				}
				else
				{
					element6 = null;
				}
				Animals.Add(element6);
			}
		}
		else
		{
			Animals?.Clear();
		}
		ushort elementsCount7 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount7 > 0)
		{
			if (Caravans == null)
			{
				Caravans = new List<CaravanDisplayData>();
			}
			else
			{
				Caravans.Clear();
			}
			for (int num6 = 0; num6 < elementsCount7; num6++)
			{
				ushort num7 = *(ushort*)pCurrData;
				pCurrData += 2;
				CaravanDisplayData element7;
				if (num7 > 0)
				{
					element7 = new CaravanDisplayData();
					pCurrData += element7.Deserialize(pCurrData);
				}
				else
				{
					element7 = null;
				}
				Caravans.Add(element7);
			}
		}
		else
		{
			Caravans?.Clear();
		}
		ushort elementsCount8 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount8 > 0)
		{
			if (Graves == null)
			{
				Graves = new List<GraveDisplayData>();
			}
			else
			{
				Graves.Clear();
			}
			for (int num8 = 0; num8 < elementsCount8; num8++)
			{
				GraveDisplayData element8 = new GraveDisplayData();
				pCurrData += element8.Deserialize(pCurrData);
				Graves.Add(element8);
			}
		}
		else
		{
			Graves?.Clear();
		}
		int HasGuardInfoElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (HasGuardInfoElementsCount > 0)
		{
			if (HasGuardInfo == null)
			{
				HasGuardInfo = new Dictionary<int, bool>();
			}
			else
			{
				HasGuardInfo.Clear();
			}
			for (int num9 = 0; num9 < HasGuardInfoElementsCount; num9++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				bool value = *pCurrData != 0;
				pCurrData++;
				HasGuardInfo.Add(key, value);
			}
		}
		else
		{
			HasGuardInfo?.Clear();
		}
		pCurrData += InteractedCharSet.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
