using System.Text;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Adventure;

[AutoGenerateSerializableGameData(AllowFixedSize = false, NotForArchive = true)]
public class AdventureNameAndDurationDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public string Name;

	[SerializableGameDataField]
	public uint Duration;

	public AdventureNameAndDurationDisplayData(string name, uint duration)
	{
		Name = name;
		Duration = duration;
	}

	public AdventureNameAndDurationDisplayData()
	{
	}

	public AdventureNameAndDurationDisplayData(AdventureNameAndDurationDisplayData other)
	{
		Name = other.Name;
		Duration = other.Duration;
	}

	public void Assign(AdventureNameAndDurationDisplayData other)
	{
		Name = other.Name;
		Duration = other.Duration;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
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
		*(uint*)pCurrData = Duration;
		pCurrData += 4;
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
		Duration = *(uint*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
