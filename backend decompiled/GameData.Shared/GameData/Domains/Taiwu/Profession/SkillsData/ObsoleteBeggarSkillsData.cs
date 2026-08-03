using System;
using System.Text;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 乞丐相关数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteBeggarSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 正在寻找的角色姓名
	/// </summary>
	[SerializableGameDataField]
	public string LookingForCharName;

	/// <summary>
	/// 已经被找到过的角色ID集合
	/// </summary>
	[SerializableGameDataField]
	public CharacterSet AlreadyFoundCharacters;

	/// <summary>
	/// 找到更多活着的角色
	/// </summary>
	public bool FoundMoreAlive;

	/// <summary>
	/// 找到更多死亡的角色
	/// </summary>
	public bool FoundMoreDead;

	/// <inheritdoc />
	public void Initialize()
	{
		ClearData();
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	/// <summary>
	/// 清除数据
	/// </summary>
	public void ClearData()
	{
		LookingForCharName = null;
		AlreadyFoundCharacters.Clear();
		FoundMoreDead = false;
		FoundMoreAlive = false;
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
		totalSize = ((LookingForCharName == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LookingForCharName.Length)));
		totalSize += AlreadyFoundCharacters.GetSerializedSize();
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
		if (LookingForCharName != null)
		{
			int elementsCount = LookingForCharName.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			fixed (char* pChar = LookingForCharName)
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
		int fieldSize = AlreadyFoundCharacters.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
			int fieldSize = 2 * elementsCount;
			LookingForCharName = Encoding.Unicode.GetString(pCurrData, fieldSize);
			pCurrData += fieldSize;
		}
		else
		{
			LookingForCharName = null;
		}
		pCurrData += AlreadyFoundCharacters.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
