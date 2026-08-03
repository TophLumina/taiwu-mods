using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC;

/// <summary>
/// 一个dlc扩展包的信息
/// </summary>
public class DlcInfo : ISerializableGameData, IEquatable<DlcInfo>
{
	/// <summary>
	/// dlc id
	/// </summary>
	[SerializableGameDataField]
	public DlcId DlcId;

	/// <summary>
	/// 是否安装
	/// </summary>
	[SerializableGameDataField]
	public bool IsInstalled;

	/// <summary>
	/// 事件路径
	/// </summary>
	[SerializableGameDataField]
	public string EventDirectory;

	public DlcInfo(ulong appId, ulong version, bool isInstalled, string eventDirectory)
	{
		DlcId = new DlcId(appId, version);
		IsInstalled = isInstalled;
		EventDirectory = eventDirectory;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public bool Equals(DlcInfo other)
	{
		return DlcId.Equals(other?.DlcId);
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public override int GetHashCode()
	{
		return DlcId.GetHashCode();
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public string GetVersionString()
	{
		var (major, minor, build, revision) = BitOperation.UnpackVersion(DlcId.Version);
		return new Version(major, minor, build, revision).ToString();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public DlcInfo()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public DlcInfo(DlcInfo other)
	{
		DlcId = other.DlcId;
		IsInstalled = other.IsInstalled;
		EventDirectory = other.EventDirectory;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(DlcInfo other)
	{
		DlcId = other.DlcId;
		IsInstalled = other.IsInstalled;
		EventDirectory = other.EventDirectory;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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
