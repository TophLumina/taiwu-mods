using System;
using GameData.Serializer;

namespace GameData.Domains.Information;

/// <summary>
/// 一般见闻
/// </summary>
public struct NormalInformation : ISerializableGameData
{
	/// <summary>
	/// 见闻模板 Id
	/// </summary>
	[SerializableGameDataField]
	private short _templateId;

	/// <summary>
	/// 该见闻的等级 (0~8)
	/// </summary>
	[SerializableGameDataField]
	private sbyte _level;

	/// <summary>
	/// 最低等级
	/// </summary>
	public const sbyte LevelMin = 0;

	/// <summary>
	/// 最高等级
	/// </summary>
	public const sbyte LevelMax = 8;

	/// <summary>
	/// 模板 Id
	/// </summary>
	public short TemplateId => _templateId;

	/// <summary>
	/// 当前等级
	/// </summary>
	public sbyte Level => _level;

	/// <summary>
	/// 判断见闻对象的合法性
	/// </summary>
	/// <returns></returns>
	public bool IsValid()
	{
		if (TemplateId >= 0)
		{
			return Level >= 0;
		}
		return false;
	}

	/// <summary>
	/// 构造
	/// </summary>
	/// <param name="templateId">见闻模板 Id</param>
	/// <param name="level">等级</param>
	public NormalInformation(short templateId, sbyte level)
	{
		_templateId = templateId;
		_level = level;
	}

	/// <summary>
	/// 变更等级
	/// 会自动修正越界问题
	/// </summary>
	public void UpdateLevel(sbyte level)
	{
		_level = Math.Max(0, Math.Min(level, 8));
	}

	public bool Equals(NormalInformation other)
	{
		if (other.TemplateId == TemplateId)
		{
			return other.Level == Level;
		}
		return false;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = _templateId;
		byte* num = pData + 2;
		*num = (byte)_level;
		int totalSize = (int)(num + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_templateId = *(short*)pCurrData;
		pCurrData += 2;
		_level = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
