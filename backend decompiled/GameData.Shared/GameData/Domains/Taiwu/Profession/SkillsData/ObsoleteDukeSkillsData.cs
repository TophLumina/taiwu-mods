using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteDukeSkillsData : IProfessionSkillsData, ISerializableGameData
{
	public const int NobodyCharacterId = -1;

	[SerializableGameDataField]
	private int[] _dukeTitleOwners;

	private static short DukeTitleTemplateOffset => 37;

	public void Initialize()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
		}
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public bool TitleHasOwner(short templateId)
	{
		return GetOwnerOfTitle(templateId) != -1;
	}

	public bool CharacterHasTitle(int charId)
	{
		return GetTitleFromOwner(charId) != -1;
	}

	public short GetTitleFromOwner(int charId)
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] == charId)
			{
				return (short)(i + DukeTitleTemplateOffset);
			}
		}
		return -1;
	}

	public int GetOwnerOfTitle(short templateId)
	{
		return _dukeTitleOwners[templateId - DukeTitleTemplateOffset];
	}

	public IEnumerable<(int CharacterId, short TemplateId)> GetAllOwners()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] != -1)
			{
				yield return (CharacterId: _dukeTitleOwners[i], TemplateId: (short)(DukeTitleTemplateOffset + i));
			}
		}
	}

	public IEnumerable<short> GetAllTitles()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			yield return (short)(i + DukeTitleTemplateOffset);
		}
	}

	public ObsoleteDukeSkillsData()
	{
		_dukeTitleOwners = new int[6];
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((_dukeTitleOwners == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _dukeTitleOwners.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_dukeTitleOwners != null)
		{
			int elementsCount = _dukeTitleOwners.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _dukeTitleOwners[i];
			}
			pCurrData += 4 * elementsCount;
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
			if (_dukeTitleOwners == null || _dukeTitleOwners.Length != elementsCount)
			{
				_dukeTitleOwners = new int[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_dukeTitleOwners[i] = ((int*)pCurrData)[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_dukeTitleOwners = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
