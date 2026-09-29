using System.Collections.Generic;
using System.Text;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Global;
using GameData.Domains.Global.Inscription;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Creation;

[SerializableGameData(NotForArchive = true)]
public class ProtagonistCreationInfo : ISerializableGameData
{
	[SerializableGameDataField]
	public string Surname;

	[SerializableGameDataField]
	public string GivenName;

	[SerializableGameDataField]
	public short Morality;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public short Age;

	[SerializableGameDataField]
	public sbyte BirthMonth;

	[SerializableGameDataField]
	public AvatarData Avatar;

	[SerializableGameDataField]
	public short ClothingTemplateId;

	[SerializableGameDataField]
	public List<short> ProtagonistFeatureIds;

	[SerializableGameDataField]
	public Dictionary<short, DataList<TemplateKey>> ProtagonistCustomItems;

	[SerializableGameDataField]
	public ChallengeModeInfo ChallengeModeInfo = new ChallengeModeInfo();

	[SerializableGameDataField]
	public sbyte TaiwuVillageStateTemplateId;

	[SerializableGameDataField]
	public InscribedCharacter InscribedChar;

	[SerializableGameDataField]
	public CustomProtagonistPresetItem CustomPreset;

	public ProtagonistCreationInfo()
	{
	}

	public ProtagonistCreationInfo(ProtagonistCreationInfo other)
	{
		Surname = other.Surname;
		GivenName = other.GivenName;
		Morality = other.Morality;
		Gender = other.Gender;
		Age = other.Age;
		BirthMonth = other.BirthMonth;
		Avatar = new AvatarData(other.Avatar);
		ClothingTemplateId = other.ClothingTemplateId;
		ProtagonistFeatureIds = ((other.ProtagonistFeatureIds == null) ? null : new List<short>(other.ProtagonistFeatureIds));
		if (other.ProtagonistCustomItems != null)
		{
			Dictionary<short, DataList<TemplateKey>> protagonistCustomItems = other.ProtagonistCustomItems;
			int elementsCount = protagonistCustomItems.Count;
			ProtagonistCustomItems = new Dictionary<short, DataList<TemplateKey>>(elementsCount);
			foreach (KeyValuePair<short, DataList<TemplateKey>> pair in protagonistCustomItems)
			{
				ProtagonistCustomItems.Add(pair.Key, new DataList<TemplateKey>(pair.Value));
			}
		}
		else
		{
			ProtagonistCustomItems = null;
		}
		ChallengeModeInfo = new ChallengeModeInfo(other.ChallengeModeInfo);
		TaiwuVillageStateTemplateId = other.TaiwuVillageStateTemplateId;
		InscribedChar = new InscribedCharacter(other.InscribedChar);
		CustomPreset = new CustomProtagonistPresetItem(other.CustomPreset);
	}

	public void Assign(ProtagonistCreationInfo other)
	{
		Surname = other.Surname;
		GivenName = other.GivenName;
		Morality = other.Morality;
		Gender = other.Gender;
		Age = other.Age;
		BirthMonth = other.BirthMonth;
		Avatar = new AvatarData(other.Avatar);
		ClothingTemplateId = other.ClothingTemplateId;
		ProtagonistFeatureIds = ((other.ProtagonistFeatureIds == null) ? null : new List<short>(other.ProtagonistFeatureIds));
		if (other.ProtagonistCustomItems != null)
		{
			Dictionary<short, DataList<TemplateKey>> protagonistCustomItems = other.ProtagonistCustomItems;
			int elementsCount = protagonistCustomItems.Count;
			ProtagonistCustomItems = new Dictionary<short, DataList<TemplateKey>>(elementsCount);
			foreach (KeyValuePair<short, DataList<TemplateKey>> pair in protagonistCustomItems)
			{
				ProtagonistCustomItems.Add(pair.Key, new DataList<TemplateKey>(pair.Value));
			}
		}
		else
		{
			ProtagonistCustomItems = null;
		}
		ChallengeModeInfo = new ChallengeModeInfo(other.ChallengeModeInfo);
		TaiwuVillageStateTemplateId = other.TaiwuVillageStateTemplateId;
		InscribedChar = new InscribedCharacter(other.InscribedChar);
		CustomPreset = new CustomProtagonistPresetItem(other.CustomPreset);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 11;
		totalSize = ((Surname == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Surname.Length)));
		totalSize = ((GivenName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GivenName.Length)));
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		totalSize = ((ProtagonistFeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ProtagonistFeatureIds.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(ProtagonistCustomItems);
		totalSize = ((InscribedChar == null) ? (totalSize + 2) : (totalSize + (2 + InscribedChar.GetSerializedSize())));
		totalSize = ((CustomPreset == null) ? (totalSize + 2) : (totalSize + (2 + CustomPreset.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Surname != null)
		{
			int elementsCount = Surname.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = Surname)
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
		if (GivenName != null)
		{
			int elementsCount2 = GivenName.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = GivenName)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = Morality;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*(short*)pCurrData = Age;
		pCurrData += 2;
		*pCurrData = (byte)BirthMonth;
		pCurrData++;
		if (Avatar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = ClothingTemplateId;
		pCurrData += 2;
		if (ProtagonistFeatureIds != null)
		{
			int elementsCount3 = ProtagonistFeatureIds.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = ProtagonistFeatureIds[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref ProtagonistCustomItems);
		pCurrData += ChallengeModeInfo.Serialize(pCurrData);
		*pCurrData = (byte)TaiwuVillageStateTemplateId;
		pCurrData++;
		if (InscribedChar != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = InscribedChar.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CustomPreset != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = CustomPreset.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			Surname = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Surname = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			int fieldSize2 = 2 * elementsCount2;
			GivenName = Encoding.Unicode.GetString(pCurrData, fieldSize2);
			pCurrData += fieldSize2;
		}
		else
		{
			GivenName = null;
		}
		Morality = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		Age = *(short*)pCurrData;
		pCurrData += 2;
		BirthMonth = (sbyte)(*pCurrData);
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (Avatar == null)
			{
				Avatar = new AvatarData();
			}
			pCurrData += Avatar.Deserialize(pCurrData);
		}
		else
		{
			Avatar = null;
		}
		ClothingTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ProtagonistFeatureIds == null)
			{
				ProtagonistFeatureIds = new List<short>(elementsCount3);
			}
			else
			{
				ProtagonistFeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount3; i++)
			{
				ProtagonistFeatureIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			ProtagonistFeatureIds?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref ProtagonistCustomItems);
		if (ChallengeModeInfo == null)
		{
			ChallengeModeInfo = new ChallengeModeInfo();
		}
		pCurrData += ChallengeModeInfo.Deserialize(pCurrData);
		TaiwuVillageStateTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			if (InscribedChar == null)
			{
				InscribedChar = new InscribedCharacter();
			}
			pCurrData += InscribedChar.Deserialize(pCurrData);
		}
		else
		{
			InscribedChar = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			if (CustomPreset == null)
			{
				CustomPreset = new CustomProtagonistPresetItem();
			}
			pCurrData += CustomPreset.Deserialize(pCurrData);
		}
		else
		{
			CustomPreset = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
