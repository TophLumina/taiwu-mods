using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

/// <summary>
/// 一个人在什么地方，是不是绑架在那里，或者是不是奇遇中等位置信息
/// </summary>
[AutoGenerateSerializableGameData(NotRestrictCollectionSerializedSize = true, NotForArchive = true, NoCopyConstructors = true)]
public class CharacterLocationDisplayData : ISerializableGameData
{
	/// <summary>
	/// 对应<see cref="F:GameData.Domains.Character.Display.CharacterLocationDisplayData.DisplayType" />
	/// </summary>
	public enum EDisplayType
	{
		Normal,
		Kidnapped,
		InAdventure,
		Buried
	}

	/// <summary>
	/// 角色 ID
	/// </summary>
	[SerializableGameDataField]
	public int CharacterId;

	/// <summary>
	/// 综合显示状态。0: 正常位于某处；1：被绑架在某处；2：在奇遇中；3：埋藏在某处
	/// </summary>
	[SerializableGameDataField]
	public sbyte DisplayType;

	/// <summary>
	/// 当前位置，如果他被绑架，这里给到绑架者的位置
	/// </summary>
	[SerializableGameDataField]
	public Location Location;

	/// <summary>
	/// 用于显示的地块名字信息
	/// </summary>
	[SerializableGameDataField]
	public FullBlockName FullBlockName;

	/// <summary>
	/// Location对应的地块信息
	/// </summary>
	[SerializableGameDataField]
	public MapBlockData BlockData;

	/// <summary>
	/// Location对应的地块信息
	/// </summary>
	[SerializableGameDataField]
	public MapBlockData RootBlockData;

	/// <summary>
	/// 当前在奇遇中，<see cref="F:GameData.Adventure.AdventureDataHelper.Invalid" /> 的id表示不在
	/// </summary>
	[SerializableGameDataField]
	public int AdventureCoreId;

	/// <summary>
	/// 如果是被人关押，那么关押者的信息
	/// </summary>
	[SerializableGameDataField]
	public CharacterDisplayData Kidnapper;

	/// <summary>
	/// 是否在石屋中
	/// </summary>
	[SerializableGameDataField]
	public bool IsCapturedInStoneRoom;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 10;
		totalSize += Location.GetSerializedSize();
		totalSize += FullBlockName.GetSerializedSize();
		totalSize = ((BlockData == null) ? (totalSize + 2) : (totalSize + (2 + BlockData.GetSerializedSize())));
		totalSize = ((RootBlockData == null) ? (totalSize + 2) : (totalSize + (2 + RootBlockData.GetSerializedSize())));
		totalSize = ((Kidnapper == null) ? (totalSize + 2) : (totalSize + (2 + Kidnapper.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*pCurrData = (byte)DisplayType;
		pCurrData++;
		pCurrData += Location.Serialize(pCurrData);
		int fieldSize = FullBlockName.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		if (BlockData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize2 = BlockData.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (RootBlockData != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = RootBlockData.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = AdventureCoreId;
		pCurrData += 4;
		if (Kidnapper != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize4 = Kidnapper.Serialize(pCurrData);
			pCurrData += fieldSize4;
			Tester.Assert(fieldSize4 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize4;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (IsCapturedInStoneRoom ? ((byte)1) : ((byte)0));
		pCurrData++;
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
		CharacterId = *(int*)pCurrData;
		pCurrData += 4;
		DisplayType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Location.Deserialize(pCurrData);
		pCurrData += FullBlockName.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			BlockData = new MapBlockData();
			pCurrData += BlockData.Deserialize(pCurrData);
		}
		else
		{
			BlockData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			RootBlockData = new MapBlockData();
			pCurrData += RootBlockData.Deserialize(pCurrData);
		}
		else
		{
			RootBlockData = null;
		}
		AdventureCoreId = *(int*)pCurrData;
		pCurrData += 4;
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			Kidnapper = new CharacterDisplayData();
			pCurrData += Kidnapper.Deserialize(pCurrData);
		}
		else
		{
			Kidnapper = null;
		}
		IsCapturedInStoneRoom = *pCurrData != 0;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
