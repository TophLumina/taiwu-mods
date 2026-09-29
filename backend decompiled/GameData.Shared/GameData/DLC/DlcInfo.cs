using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC;

public class DlcInfo : ISerializableGameData, IEquatable<DlcInfo>
{
	[SerializableGameDataField]
	public DlcId DlcId;

	[SerializableGameDataField]
	public bool IsInstalled;

	[SerializableGameDataField]
	public string EventDirectory;

	public DlcInfo(ulong appId, ulong version, bool isInstalled, string eventDirectory)
	{
		DlcId = new DlcId(appId, version);
		IsInstalled = isInstalled;
		EventDirectory = eventDirectory;
	}

	public bool Equals(DlcInfo other)
	{
		return DlcId.Equals(other?.DlcId);
	}

	public override int GetHashCode()
	{
		return DlcId.GetHashCode();
	}

	public string GetVersionString()
	{
		var (major, minor, build, revision) = BitOperation.UnpackVersion(DlcId.Version);
		return new Version(major, minor, build, revision).ToString();
	}

	public DlcInfo()
	{
	}

	public DlcInfo(DlcInfo other)
	{
		DlcId = other.DlcId;
		IsInstalled = other.IsInstalled;
		EventDirectory = other.EventDirectory;
	}

	public void Assign(DlcInfo other)
	{
		DlcId = other.DlcId;
		IsInstalled = other.IsInstalled;
		EventDirectory = other.EventDirectory;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 17;
		totalSize = ((EventDirectory == null) ? (totalSize + 2) : (totalSize + (2 + 2 * EventDirectory.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += DlcId.Serialize(pCurrData);
		*pCurrData = (IsInstalled ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (EventDirectory != null)
		{
			int elementsCount = EventDirectory.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = EventDirectory)
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
		pCurrData += DlcId.Deserialize(pCurrData);
		IsInstalled = *pCurrData != 0;
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			int fieldSize = 2 * elementsCount;
			EventDirectory = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			EventDirectory = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
