using System;
using System.Text;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.World;

/// <summary>
/// 游戏版本信息
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class GameVersionInfo : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort TimestampCreating = 0;

		public const ushort TimestampLastSaving = 1;

		public const ushort GameVersionCreating = 2;

		public const ushort GameVersionLastSaving = 3;

		public const ushort GameBuildDateCreating = 4;

		public const ushort GameBuildDateLastSaving = 5;

		public const ushort Count = 6;

		public static readonly string[] FieldId2FieldName = new string[6] { "TimestampCreating", "TimestampLastSaving", "GameVersionCreating", "GameVersionLastSaving", "GameBuildDateCreating", "GameBuildDateLastSaving" };
	}

	/// <summary>
	/// 创建存档时的时间戳 (UTC)
	/// </summary>
	[SerializableGameDataField]
	public long TimestampCreating;

	/// <summary>
	/// 保存存档时的时间戳 (UTC)
	/// </summary>
	[SerializableGameDataField]
	public long TimestampLastSaving;

	/// <summary>
	/// 创建存档时的游戏版本
	/// </summary>
	[SerializableGameDataField]
	public string GameVersionCreating = string.Empty;

	/// <summary>
	/// 最后一次存档时的游戏版本
	/// </summary>
	[SerializableGameDataField]
	public string GameVersionLastSaving = string.Empty;

	/// <summary>
	/// 创建存档时的游戏版本日期
	/// </summary>
	[SerializableGameDataField]
	public string GameBuildDateCreating = string.Empty;

	/// <summary>
	/// 最后一次存档时的游戏版本日期
	/// </summary>
	[SerializableGameDataField]
	public string GameBuildDateLastSaving = string.Empty;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public GameVersionInfo()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public GameVersionInfo(GameVersionInfo other)
	{
		TimestampCreating = other.TimestampCreating;
		TimestampLastSaving = other.TimestampLastSaving;
		GameVersionCreating = other.GameVersionCreating;
		GameVersionLastSaving = other.GameVersionLastSaving;
		GameBuildDateCreating = other.GameBuildDateCreating;
		GameBuildDateLastSaving = other.GameBuildDateLastSaving;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(GameVersionInfo other)
	{
		TimestampCreating = other.TimestampCreating;
		TimestampLastSaving = other.TimestampLastSaving;
		GameVersionCreating = other.GameVersionCreating;
		GameVersionLastSaving = other.GameVersionLastSaving;
		GameBuildDateCreating = other.GameBuildDateCreating;
		GameBuildDateLastSaving = other.GameBuildDateLastSaving;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 18;
		totalSize = ((GameVersionCreating == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GameVersionCreating.Length)));
		totalSize = ((GameVersionLastSaving == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GameVersionLastSaving.Length)));
		totalSize = ((GameBuildDateCreating == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GameBuildDateCreating.Length)));
		totalSize = ((GameBuildDateLastSaving == null) ? (totalSize + 2) : (totalSize + (2 + 2 * GameBuildDateLastSaving.Length)));
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
		*(short*)pCurrData = 6;
		pCurrData += 2;
		*(long*)pCurrData = TimestampCreating;
		pCurrData += 8;
		*(long*)pCurrData = TimestampLastSaving;
		pCurrData += 8;
		if (GameVersionCreating != null)
		{
			int elementsCount = GameVersionCreating.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = GameVersionCreating)
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
		if (GameVersionLastSaving != null)
		{
			int elementsCount2 = GameVersionLastSaving.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			fixed (char* pChar2 = GameVersionLastSaving)
			{
				for (int j = 0; j < elementsCount2; j++)
				{
					((short*)pCurrData)[j] = (short)pChar2[j];
				}
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GameBuildDateCreating != null)
		{
			int elementsCount3 = GameBuildDateCreating.Length;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			fixed (char* pChar3 = GameBuildDateCreating)
			{
				for (int k = 0; k < elementsCount3; k++)
				{
					((short*)pCurrData)[k] = (short)pChar3[k];
				}
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (GameBuildDateLastSaving != null)
		{
			int elementsCount4 = GameBuildDateLastSaving.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			fixed (char* pChar4 = GameBuildDateLastSaving)
			{
				for (int l = 0; l < elementsCount4; l++)
				{
					((short*)pCurrData)[l] = (short)pChar4[l];
				}
			}
			pCurrData += 2 * elementsCount4;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			TimestampCreating = *(long*)pCurrData;
			pCurrData += 8;
		}
		if (num > 1)
		{
			TimestampLastSaving = *(long*)pCurrData;
			pCurrData += 8;
		}
		if (num > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				GameVersionCreating = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				GameVersionCreating = null;
			}
		}
		if (num > 3)
		{
			ushort elementsCount2 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount2 > 0)
			{
				int fieldSize2 = 2 * elementsCount2;
				GameVersionLastSaving = Encoding.Unicode.GetString(pCurrData, fieldSize2);
				pCurrData += fieldSize2;
			}
			else
			{
				GameVersionLastSaving = null;
			}
		}
		if (num > 4)
		{
			ushort elementsCount3 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount3 > 0)
			{
				int fieldSize3 = 2 * elementsCount3;
				GameBuildDateCreating = Encoding.Unicode.GetString(pCurrData, fieldSize3);
				pCurrData += fieldSize3;
			}
			else
			{
				GameBuildDateCreating = null;
			}
		}
		if (num > 5)
		{
			ushort elementsCount4 = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount4 > 0)
			{
				int fieldSize4 = 2 * elementsCount4;
				GameBuildDateLastSaving = Encoding.Unicode.GetString(pCurrData, fieldSize4);
				pCurrData += fieldSize4;
			}
			else
			{
				GameBuildDateLastSaving = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <summary>
	/// 将字符串转为游戏版本
	/// </summary>
	public static Version ParseGameVersion(string gameVersion)
	{
		if (string.IsNullOrEmpty(gameVersion))
		{
			return null;
		}
		if (gameVersion[0] == 'V')
		{
			gameVersion = gameVersion.Substring(1);
		}
		if (Version.TryParse(gameVersion, out Version version))
		{
			if (version.Major > 1)
			{
				return null;
			}
			return version;
		}
		int versionLength = gameVersion.IndexOf('-');
		if (versionLength < 0)
		{
			return null;
		}
		if (!Version.TryParse(gameVersion.Substring(0, versionLength), out version))
		{
			return null;
		}
		if (version.Major > 1)
		{
			return null;
		}
		return version;
	}
}
