using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 关系界面用角色显示数据
/// </summary>
[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class CharacterDisplayDataForRelations : ISerializableGameData
{
	/// <summary>
	/// 主体数据
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayDataForGeneralScrollList Main;

	/// <summary>
	/// 生死状态
	/// <see cref="T:GameData.Domains.Character.LifeState" />
	/// </summary>
	[SerializableGameDataField]
	public sbyte LifeState;

	/// <summary>
	/// 所在地
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 关系类型
	/// </summary>
	[SerializableGameDataField]
	public ushort RelationType;

	/// <summary>
	/// 死亡日期
	/// </summary>
	[SerializableGameDataField]
	public int DeathDate;

	public int CharacterId => Main?.CharacterId ?? (-1);

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CharacterDisplayDataForRelations()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CharacterDisplayDataForRelations(CharacterDisplayDataForRelations other)
	{
		Main = new CharacterDisplayDataForGeneralScrollList(other.Main);
		LifeState = other.LifeState;
		Location = other.Location;
		RelationType = other.RelationType;
		DeathDate = other.DeathDate;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CharacterDisplayDataForRelations other)
	{
		Main = new CharacterDisplayDataForGeneralScrollList(other.Main);
		LifeState = other.LifeState;
		Location = other.Location;
		RelationType = other.RelationType;
		DeathDate = other.DeathDate;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((Main == null) ? (totalSize + 2) : (totalSize + (2 + Main.GetSerializedSize())));
		totalSize += Location.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Main != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Main.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)LifeState;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		*(ushort*)pCurrData = RelationType;
		pCurrData += 2;
		*(int*)pCurrData = DeathDate;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Main = new CharacterDisplayDataForGeneralScrollList();
			pCurrData += Main.Deserialize(pCurrData);
		}
		else
		{
			Main = null;
		}
		LifeState = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		RelationType = *(ushort*)pCurrData;
		pCurrData += 2;
		DeathDate = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
