using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Character;

[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct FullName : ISerializableGameData, IEquatable<FullName>
{
	[FieldOffset(8)]
	public sbyte Type;

	[FieldOffset(0)]
	public int CustomSurnameId;

	[FieldOffset(4)]
	public int CustomGivenNameId;

	[FieldOffset(0)]
	public short SurnameId;

	[FieldOffset(4)]
	public short GivenNameGroupId;

	[FieldOffset(6)]
	public short GivenNameSuffixId;

	[FieldOffset(9)]
	public sbyte GivenNameType;

	[FieldOffset(0)]
	public short ZangPrefixId;

	[FieldOffset(2)]
	public short ZangSuffixId;

	public FullName(int customSurnameId, int customGivenNameId, short surnameId, short givenNameGroupId, short givenNameSuffixId, sbyte givenNameType)
	{
		Type = 1;
		if (customSurnameId >= 0)
		{
			Type |= 4;
			SurnameId = 0;
			ZangPrefixId = 0;
			ZangSuffixId = 0;
			CustomSurnameId = customSurnameId;
		}
		else
		{
			CustomSurnameId = 0;
			ZangPrefixId = 0;
			ZangSuffixId = 0;
			SurnameId = surnameId;
		}
		if (customGivenNameId >= 0)
		{
			Type |= 8;
			GivenNameGroupId = 0;
			GivenNameSuffixId = 0;
			CustomGivenNameId = customGivenNameId;
			GivenNameType = 0;
		}
		else
		{
			CustomGivenNameId = 0;
			GivenNameGroupId = givenNameGroupId;
			GivenNameSuffixId = givenNameSuffixId;
			GivenNameType = givenNameType;
		}
	}

	public FullName(int customNameId, short zangPrefixId, short zangSuffixId)
	{
		Type = 2;
		if (customNameId >= 0)
		{
			Type |= 8;
			CustomSurnameId = 0;
			SurnameId = 0;
			ZangPrefixId = 0;
			ZangSuffixId = 0;
			GivenNameGroupId = 0;
			GivenNameSuffixId = 0;
			CustomGivenNameId = customNameId;
			GivenNameType = 0;
		}
		else
		{
			CustomSurnameId = 0;
			SurnameId = 0;
			ZangPrefixId = zangPrefixId;
			ZangSuffixId = zangSuffixId;
			GivenNameGroupId = 0;
			GivenNameSuffixId = 0;
			CustomGivenNameId = 0;
			GivenNameType = 0;
		}
	}

	public void InheritSurname(FullName otherName)
	{
		if ((otherName.Type | 4) == otherName.Type)
		{
			Type |= 4;
			Type |= 1;
			Type &= -3;
			ZangPrefixId = 0;
			ZangSuffixId = 0;
			CustomSurnameId = otherName.CustomSurnameId;
		}
		else if ((otherName.Type | 1) == otherName.Type)
		{
			Type |= 1;
			Type &= -5;
			Type &= -3;
			CustomSurnameId = 0;
			ZangPrefixId = 0;
			ZangSuffixId = 0;
			SurnameId = otherName.SurnameId;
		}
	}

	public void SetCustomGivenName(int customGivenNameId)
	{
		if ((Type | 1) == Type)
		{
			Type |= 8;
			GivenNameGroupId = 0;
			GivenNameSuffixId = 0;
			CustomGivenNameId = customGivenNameId;
			GivenNameType = 0;
			return;
		}
		Type |= 2;
		Type |= 8;
		CustomSurnameId = 0;
		SurnameId = 0;
		ZangPrefixId = 0;
		ZangSuffixId = 0;
		GivenNameGroupId = 0;
		GivenNameSuffixId = 0;
		CustomGivenNameId = customGivenNameId;
		GivenNameType = 0;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 10;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = CustomSurnameId;
		((int*)pData)[1] = CustomGivenNameId;
		pData[8] = (byte)Type;
		pData[9] = (byte)GivenNameType;
		return 10;
	}

	public unsafe int Deserialize(byte* pData)
	{
		CustomSurnameId = *(int*)pData;
		CustomGivenNameId = ((int*)pData)[1];
		Type = (sbyte)pData[8];
		GivenNameType = (sbyte)pData[9];
		return 10;
	}

	public (string, string) GetName(sbyte gender, IReadOnlyDictionary<int, string> customTexts)
	{
		if ((Type & 0x10) != 0)
		{
			return (null, (gender == 0) ? ExtraNameText.DefValue.NoNameInfantFemale.Content : ExtraNameText.DefValue.NoNameInfantMale.Content);
		}
		if ((Type & 1) != 0)
		{
			string surname = (((Type & 4) != 0) ? customTexts.GetValueOrDefault(CustomSurnameId) : LocalSurnames.Instance.SurnameCore[SurnameId].Surname);
			string givenName;
			if ((Type & 8) == 0)
			{
				HanNameItem nameGroup = LocalNames.Instance.AllNamesCore[GivenNameGroupId];
				givenName = GivenNameType switch
				{
					0 => GetSuffixName(nameGroup, GivenNameSuffixId, gender, unattached: true), 
					1 => nameGroup.MiddleChar + GetSuffixName(nameGroup, GivenNameSuffixId, gender, unattached: true), 
					2 => nameGroup.MiddleChar + GetSuffixName(nameGroup, GivenNameSuffixId, gender, unattached: false), 
					_ => null, 
				};
			}
			else
			{
				givenName = customTexts[CustomGivenNameId];
			}
			return (surname, givenName);
		}
		if ((Type & 2) != 0)
		{
			if ((Type & 8) == 0)
			{
				ZangNameItem[] names = LocalZangNames.Instance.ZangNameCore;
				string firstName = names[ZangPrefixId].Name;
				if (ZangSuffixId >= 0)
				{
					return (null, firstName + names[ZangSuffixId].Name);
				}
				return (null, firstName);
			}
			return (null, customTexts.GetValueOrDefault(CustomGivenNameId));
		}
		return (null, null);
	}

	public short GetSurnameId()
	{
		if ((Type & 1) != 0 && (Type & 4) == 0)
		{
			return SurnameId;
		}
		return -1;
	}

	public int GetCustomSurnameId()
	{
		if ((Type & 1) != 0 && (Type & 4) != 0)
		{
			return CustomSurnameId;
		}
		return -1;
	}

	public bool Equals(FullName other)
	{
		if (CustomSurnameId == other.CustomSurnameId && CustomGivenNameId == other.CustomGivenNameId && Type == other.Type)
		{
			return GivenNameType == other.GivenNameType;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is FullName other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((CustomSurnameId * 397) ^ CustomGivenNameId) * 397) ^ Type.GetHashCode()) * 397) ^ GivenNameType.GetHashCode();
	}

	private static string GetSuffixName(HanNameItem group, short suffixId, sbyte gender, bool unattached)
	{
		string[] genderNames;
		string[] genderlessNames;
		if (unattached)
		{
			genderNames = ((gender == 1) ? group.ApartMan : group.ApartWoman);
			genderlessNames = group.ApartNeutral;
			if (suffixId >= genderNames.Length + genderlessNames.Length)
			{
				genderNames = ((gender == 0) ? group.ApartMan : group.ApartWoman);
			}
		}
		else
		{
			genderNames = ((gender == 1) ? group.SerialMan : group.SerialWoman);
			genderlessNames = group.SerialNeutral;
			if (suffixId >= genderNames.Length + genderlessNames.Length)
			{
				genderNames = ((gender == 0) ? group.SerialMan : group.SerialWoman);
			}
		}
		int genderNamesCount = genderNames.Length;
		if (suffixId >= genderNamesCount)
		{
			return genderlessNames[suffixId - genderNamesCount];
		}
		return genderNames[suffixId];
	}
}
