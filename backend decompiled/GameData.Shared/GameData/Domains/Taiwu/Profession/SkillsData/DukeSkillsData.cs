using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 王公相关数据
/// </summary>
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

	/// <summary>
	/// 未被授予的角色ID标记
	/// </summary>
	public const int NobodyCharacterId = -1;

	/// <summary>
	/// 官职称号数量
	/// </summary>
	public const int TitleCount = 6;

	/// <summary>
	/// 当前所有官位称号的拥有者ID
	/// (templateId - templateOffset) -&gt; CharacterId
	/// </summary>
	[SerializableGameDataField]
	private int[] _dukeTitleOwners;

	/// <summary>
	/// 当前所有官位称号的促织缘
	/// (templateId - templateOffset) -&gt; 促织缘
	/// </summary>
	[SerializableGameDataField]
	private int[] _dukeLuckPoints;

	/// <summary>
	/// 当前所有官位是否已进贡促织给太吾
	/// </summary>
	[SerializableGameDataField]
	private bool[] _dukeCricketGiven;

	/// <summary>
	/// 官位称号模板ID偏移量，用于计算数组下标，不存档
	/// </summary>
	private static short DukeTitleTemplateOffset => 37;

	/// <summary>
	/// 默认构造
	/// </summary>
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

	/// <inheritdoc />
	public void Initialize()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
			_dukeLuckPoints[i] = 0;
			_dukeCricketGiven[i] = false;
		}
	}

	/// <inheritdoc />
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

	/// <summary>
	/// 检查某个称号是否已被授予
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public bool TitleHasOwner(short templateId)
	{
		return GetOwnerOfTitle(templateId) != -1;
	}

	/// <summary>
	/// 检查某个角色是否拥有称号
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public bool CharacterHasTitle(int charId)
	{
		return GetTitleFromOwner(charId) != -1;
	}

	/// <summary>
	/// 根据拥有者获取称号，未授予返回-1
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取某个称号的拥有者ID
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public int GetOwnerOfTitle(short templateId)
	{
		return _dukeTitleOwners[templateId - DukeTitleTemplateOffset];
	}

	/// <summary>
	/// 获取促织缘
	/// </summary>
	public int GetDukeLuckPointByTitle(short title)
	{
		return _dukeLuckPoints[title - DukeTitleTemplateOffset];
	}

	/// <summary>
	/// 获取所有已授予官职称号的角色ID
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取所有可授予的官职称号模板ID
	/// </summary>
	/// <returns></returns>
	public IEnumerable<short> GetAllTitles()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			yield return (short)(i + DukeTitleTemplateOffset);
		}
	}

	/// <summary>
	/// 获取还没有进贡促织的官职称号模板ID
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获得一个未进贡促织的角色ID
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 向某个角色授予称号
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	/// <param name="random"></param>
	/// <param name="templateId"></param>
	/// <param name="charId"></param>
	public void OfflineAssignTitleToCharacter(IRandomSource random, short templateId, int charId)
	{
		_dukeTitleOwners[templateId - DukeTitleTemplateOffset] = charId;
		_dukeLuckPoints[templateId - DukeTitleTemplateOffset] = random.Next(51);
	}

	/// <summary>
	/// 撤销某个称号的授予状态
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	/// <param name="templateId"></param>
	public void OfflineRemoveTitleFromAnybody(short templateId)
	{
		OfflineRemoveTitle(templateId - DukeTitleTemplateOffset);
	}

	/// <summary>
	/// 撤销对某个角色授予的称号，返回 -1 表示该角色不存在称号
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>已撤销称号</returns>
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

	/// <summary>
	/// 清除所有称号的授予状态
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	public void OfflineClearAllTitles()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			OfflineRemoveTitle(i);
		}
	}

	/// <summary>
	/// 清除指定官职的授予状态
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	/// <param name="i"></param>
	private void OfflineRemoveTitle(int i)
	{
		_dukeTitleOwners[i] = -1;
		_dukeLuckPoints[i] = 0;
	}

	/// <summary>
	/// 设置促织缘
	/// </summary>
	public void OfflineSetDukeLuckPointByTitle(short title, int value)
	{
		_dukeLuckPoints[title - DukeTitleTemplateOffset] = value;
	}

	/// <summary>
	/// 重置所有官职的进贡促织状态
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
	public void ResetAllCricketGivenData()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeCricketGiven[i] = false;
		}
	}

	/// <summary>
	/// 设置一个角色的促织进贡状态
	/// 需要调用<see cref="!:GameData.Domains.Extra.ExtraDomain.SetProfessionData" />方法应用修改
	/// </summary>
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

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
