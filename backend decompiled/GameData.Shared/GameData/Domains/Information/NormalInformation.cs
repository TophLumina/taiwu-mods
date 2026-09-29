using System;
using GameData.Serializer;

namespace GameData.Domains.Information;

public struct NormalInformation : ISerializableGameData
{
	[SerializableGameDataField]
	private short _templateId;

	[SerializableGameDataField]
	private sbyte _level;

	public const sbyte LevelMin = 0;

	public const sbyte LevelMax = 8;

	public short TemplateId => _templateId;

	public sbyte Level => _level;

	public bool IsValid()
	{
		if (TemplateId >= 0)
		{
			return Level >= 0;
		}
		return false;
	}

	public NormalInformation(short templateId, sbyte level)
	{
		_templateId = templateId;
		_level = level;
	}

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

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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
