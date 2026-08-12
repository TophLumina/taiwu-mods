using System.Text;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 轻量级人头数据，仅用于显示人头+姓名
/// </summary>
[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public struct NameStringAndAvatar : ISerializableGameData
{
	/// <summary>
	/// 肖像数据，可能为空
	/// 为空时应显示死人
	/// </summary>
	[SerializableGameDataField]
	public AvatarRelatedData Avatar;

	/// <summary>
	/// 姓名数据
	/// </summary>
	[SerializableGameDataField]
	public string Name;

	/// <summary>
	/// 人物Id
	/// </summary>
	[SerializableGameDataField]
	public int CharId;

	/// <summary>
	/// 人物模板获取
	/// </summary>
	[SerializableGameDataField]
	public short CharTemplateId;

	/// <summary>
	/// 此处约定avatar为null时数据无效
	/// </summary>
	public bool IsValid => Avatar != null;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		totalSize = ((Name == null) ? (totalSize + 2) : (totalSize + (2 + 2 * Name.Length)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Avatar != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Name != null)
		{
			int stringCount = Name.Length;
			Tester.Assert(stringCount <= 65535);
			*(ushort*)pCurrData = (ushort)stringCount;
			pCurrData += 2;
			fixed (char* pChar = Name)
			{
				for (int stringIndex = 0; stringIndex < stringCount; stringIndex++)
				{
					((short*)pCurrData)[stringIndex] = (short)pChar[stringIndex];
				}
			}
			pCurrData += 2 * stringCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(short*)pCurrData = CharTemplateId;
		pCurrData += 2;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Avatar = new AvatarRelatedData();
			pCurrData += Avatar.Deserialize(pCurrData);
		}
		else
		{
			Avatar = null;
		}
		ushort stringCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (stringCount > 0)
		{
			int fieldSize = 2 * stringCount;
			Name = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			Name = null;
		}
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		CharTemplateId = *(short*)pCurrData;
		pCurrData += 2;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
