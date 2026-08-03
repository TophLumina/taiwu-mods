using System.Text;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 旅人仙府数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class TravelerPalaceData : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CustomName = 0;

		public const ushort Location = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "CustomName", "Location" };
	}

	/// <summary>
	/// 自定义名称
	/// </summary>
	[SerializableGameDataField]
	public string CustomName;

	/// <summary>
	/// 位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TravelerPalaceData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TravelerPalaceData(TravelerPalaceData other)
	{
		CustomName = other.CustomName;
		Location = other.Location;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TravelerPalaceData other)
	{
		CustomName = other.CustomName;
		Location = other.Location;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((CustomName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CustomName.Length)));
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
		*(short*)pCurrData = 2;
		pCurrData += 2;
		if (CustomName != null)
		{
			int elementsCount = CustomName.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = CustomName)
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
		pCurrData += Location.Serialize(pCurrData);
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
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				int fieldSize = 2 * elementsCount;
				CustomName = Encoding.Unicode.GetString(pCurrData, fieldSize);
				pCurrData += fieldSize;
			}
			else
			{
				CustomName = null;
			}
		}
		if (num > 1)
		{
			pCurrData += Location.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
