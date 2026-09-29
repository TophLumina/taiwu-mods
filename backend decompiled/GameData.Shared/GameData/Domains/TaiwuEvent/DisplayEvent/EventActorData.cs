using System;
using System.Text;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[Serializable]
public class EventActorData : ISerializableGameData
{
	[SerializableGameDataField]
	public short TemplateId;

	public FullName FullName;

	[SerializableGameDataField]
	public string DisplayName;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public byte Age;

	[SerializableGameDataField]
	public AvatarData AvatarData;

	[SerializableGameDataField]
	public short ClothDisplayId;

	public EventActorData(short templateId)
	{
		TemplateId = templateId;
		AvatarData = new AvatarData();
	}

	public EventActorData(CharacterDisplayData displayData, string displayName)
	{
		TemplateId = displayData.TemplateId;
		FullName = displayData.FullName;
		DisplayName = displayName;
		Gender = displayData.Gender;
		Age = (byte)Math.Clamp((ushort)displayData.PhysiologicalAge, (ushort)0, (ushort)255);
		AvatarData = displayData.AvatarRelatedData.AvatarData;
		ClothDisplayId = displayData.AvatarRelatedData.ClothingDisplayId;
	}

	public EventActorData()
	{
	}

	public EventActorData(EventActorData other)
	{
		TemplateId = other.TemplateId;
		DisplayName = other.DisplayName;
		Gender = other.Gender;
		Age = other.Age;
		AvatarData = new AvatarData(other.AvatarData);
		ClothDisplayId = other.ClothDisplayId;
	}

	public void Assign(EventActorData other)
	{
		TemplateId = other.TemplateId;
		DisplayName = other.DisplayName;
		Gender = other.Gender;
		Age = other.Age;
		AvatarData = new AvatarData(other.AvatarData);
		ClothDisplayId = other.ClothDisplayId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((DisplayName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * DisplayName.Length)));
		totalSize = ((AvatarData == null) ? (totalSize + 2) : (totalSize + (2 + AvatarData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = TemplateId;
		pCurrData += 2;
		if (DisplayName != null)
		{
			int elementsCount = DisplayName.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = DisplayName)
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
		*pCurrData = (byte)Gender;
		pCurrData++;
		*pCurrData = Age;
		pCurrData++;
		if (AvatarData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = AvatarData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(short*)pCurrData = ClothDisplayId;
		pCurrData += 2;
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
		TemplateId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			DisplayName = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			DisplayName = null;
		}
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		Age = *pCurrData;
		pCurrData++;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (AvatarData == null)
			{
				AvatarData = new AvatarData();
			}
			pCurrData += AvatarData.Deserialize(pCurrData);
		}
		else
		{
			AvatarData = null;
		}
		ClothDisplayId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
