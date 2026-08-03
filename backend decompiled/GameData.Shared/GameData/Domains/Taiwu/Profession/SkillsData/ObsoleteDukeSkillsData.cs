using System;
using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 王公相关数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteDukeSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 未被授予的角色ID标记
	/// </summary>
	public const int NobodyCharacterId = -1;

	/// <summary>
	/// 当前所有官位称号的拥有者ID
	/// (templateId - templateOffset) -&gt; CharacterId
	/// </summary>
	[SerializableGameDataField]
	private int[] _dukeTitleOwners;

	/// <summary>
	/// 官位称号模板ID偏移量，用于计算数组下标，不存档
	/// </summary>
	private static short DukeTitleTemplateOffset => 37;

	/// <inheritdoc />
	public void Initialize()
	{
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
		}
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
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
	/// 默认构造，缓存模板偏移量
	/// </summary>
	public ObsoleteDukeSkillsData()
	{
		_dukeTitleOwners = new int[6];
		for (int i = 0; i < _dukeTitleOwners.Length; i++)
		{
			_dukeTitleOwners[i] = -1;
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
		int totalSize = 0;
		totalSize = ((_dukeTitleOwners == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _dukeTitleOwners.Length)));
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
