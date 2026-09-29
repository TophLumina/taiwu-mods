using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class DukeSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort DukeTitleOwners = 0;

		public const ushort DukeLuckPoints = 1;

		public const ushort DukeCricketGiven = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "DukeTitleOwners", "DukeLuckPoints", "DukeCricketGiven" };
	}

	public const int NobodyCharacterId = -1;

	public const int TitleCount = 6;

	[SerializableGameDataField]
	private int[] _dukeTitleOwners;

	[SerializableGameDataField]
	private int[] _dukeLuckPoints;

	[SerializableGameDataField]
	private bool[] _dukeCricketGiven;

	private static short DukeTitleTemplateOffset => 37;

	public DukeSkillsData()
	{
		_dukeTitleOwners = new int[6];
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
		}
		_dukeLuckPoints = new int[6];
		for (int j = 0; j < _dukeLuckPoints.Length; j++)
		{
			_dukeLuckPoints[j] = 0;
		}
		_dukeCricketGiven = new bool[6];
	}

	public void Initialize()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
			_dukeLuckPoints[i] = 0;
			_dukeCricketGiven[i] = false;
		}
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (!(sourceData is ObsoleteDukeSkillsData skillsData))
		{
			return;
		}
		foreach (var (charId, templateId) in skillsData.GetAllOwners())
		{
			_dukeTitleOwners[templateId - DukeTitleTemplateOffset] = charId;
		}
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

	public int GetDukeLuckPointByTitle(short title)
	{
		return _dukeLuckPoints[title - DukeTitleTemplateOffset];
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

	public IEnumerable<short> GetNotGivenCricketTitles(Predicate<int> predicate)
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] != -1 && !_dukeCricketGiven[i] && predicate(_dukeTitleOwners[i]))
			{
				yield return (short)(i + DukeTitleTemplateOffset);
			}
		}
	}

	public int GetNotGiveCricketCharId(Predicate<int> predicate)
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] != -1 && !_dukeCricketGiven[i] && predicate(_dukeTitleOwners[i]))
			{
				return _dukeTitleOwners[i];
			}
		}
		return -1;
	}

	public void OfflineAssignTitleToCharacter(IRandomSource random, short templateId, int charId)
	{
		_dukeTitleOwners[templateId - DukeTitleTemplateOffset] = charId;
		_dukeLuckPoints[templateId - DukeTitleTemplateOffset] = random.Next(51);
	}

	public void OfflineRemoveTitleFromAnybody(short templateId)
	{
		OfflineRemoveTitle(templateId - DukeTitleTemplateOffset);
	}

	public short OfflineRemoveTitleFromCharacter(int charId)
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] == charId)
			{
				OfflineRemoveTitle(i);
				return (short)(i + DukeTitleTemplateOffset);
			}
		}
		return -1;
	}

	public void OfflineClearAllTitles()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			OfflineRemoveTitle(i);
		}
	}

	private void OfflineRemoveTitle(int i)
	{
		_dukeTitleOwners[i] = -1;
		_dukeLuckPoints[i] = 0;
	}

	public void OfflineSetDukeLuckPointByTitle(short title, int value)
	{
		_dukeLuckPoints[title - DukeTitleTemplateOffset] = value;
	}

	public void ResetAllCricketGivenData()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeCricketGiven[i] = false;
		}
	}

	public void SetCharacterCricketGivenData(int charId, bool isGiven)
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			if (_dukeTitleOwners[i] == charId && !_dukeCricketGiven[i])
			{
				_dukeCricketGiven[i] = isGiven;
			}
		}
	}

	public DukeSkillsData(DukeSkillsData other)
	{
		int[] item = other._dukeTitleOwners;
		int elementsCount = item.Length;
		_dukeTitleOwners = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_dukeTitleOwners[i] = item[i];
		}
		int[] item2 = other._dukeLuckPoints;
		int elementsCount2 = item2.Length;
		_dukeLuckPoints = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			_dukeLuckPoints[j] = item2[j];
		}
		bool[] item3 = other._dukeCricketGiven;
		int elementsCount3 = item3.Length;
		_dukeCricketGiven = new bool[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			_dukeCricketGiven[k] = item3[k];
		}
	}

	public void Assign(DukeSkillsData other)
	{
		int[] item = other._dukeTitleOwners;
		int elementsCount = item.Length;
		_dukeTitleOwners = new int[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			_dukeTitleOwners[i] = item[i];
		}
		int[] item2 = other._dukeLuckPoints;
		int elementsCount2 = item2.Length;
		_dukeLuckPoints = new int[elementsCount2];
		for (int j = 0; j < elementsCount2; j++)
		{
			_dukeLuckPoints[j] = item2[j];
		}
		bool[] item3 = other._dukeCricketGiven;
		int elementsCount3 = item3.Length;
		_dukeCricketGiven = new bool[elementsCount3];
		for (int k = 0; k < elementsCount3; k++)
		{
			_dukeCricketGiven[k] = item3[k];
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((_dukeTitleOwners == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _dukeTitleOwners.Length)));
		totalSize = ((_dukeLuckPoints == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _dukeLuckPoints.Length)));
		totalSize = ((_dukeCricketGiven == null) ? (totalSize + 2) : (totalSize + (2 + _dukeCricketGiven.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
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
		if (_dukeLuckPoints != null)
		{
			int elementsCount2 = _dukeLuckPoints.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((int*)pCurrData)[j] = _dukeLuckPoints[j];
			}
			pCurrData += 4 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (_dukeCricketGiven != null)
		{
			int elementsCount3 = _dukeCricketGiven.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				pCurrData[k] = (_dukeCricketGiven[k] ? ((byte)1) : ((byte)0));
			}
			pCurrData += elementsCount3;
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
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
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
		}
		if (fieldCount > 1)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				if (_dukeLuckPoints == null || _dukeLuckPoints.Length != elementsCount2)
				{
					_dukeLuckPoints = new int[elementsCount2];
				}
				for (int j = 0; j < elementsCount2; j++)
				{
					_dukeLuckPoints[j] = ((int*)pCurrData)[j];
				}
				pCurrData += 4 * elementsCount2;
			}
			else
			{
				_dukeLuckPoints = null;
			}
		}
		if (fieldCount > 2)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				if (_dukeCricketGiven == null || _dukeCricketGiven.Length != elementsCount3)
				{
					_dukeCricketGiven = new bool[elementsCount3];
				}
				for (int k = 0; k < elementsCount3; k++)
				{
					_dukeCricketGiven[k] = pCurrData[k] != 0;
				}
				pCurrData += (int)elementsCount3;
			}
			else
			{
				_dukeCricketGiven = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
