using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true, NotRestrictCollectionSerializedSize = true)]
public class TaiwuFollowingDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CharacterDisplayData Display = new CharacterDisplayData();

	[SerializableGameDataField]
	public CharacterLocationDisplayData Location = new CharacterLocationDisplayData();

	[SerializableGameDataField]
	public CharacterInjuryDisplayData Injury = new CharacterInjuryDisplayData();

	/// <summary>
	/// 获取无效位置的显示数据
	/// </summary>
	public static CharacterLocationDisplayData InvalidLocation => new CharacterLocationDisplayData
	{
		CharacterId = -1,
		IsCapturedInStoneRoom = false,
		DisplayType = -1,
		Location = GameData.Domains.Map.Location.Invalid,
		FullBlockName = new FullBlockName
		{
			areaTemplateId = -1,
			stateTemplateId = -1,
			BelongBlockData = null,
			BlockData = null
		},
		AdventureCoreId = 0
	};

	public TaiwuFollowingDisplayData()
	{
	}

	public TaiwuFollowingDisplayData(CharacterDisplayData display, CharacterLocationDisplayData location, CharacterInjuryDisplayData injury)
	{
		Display = display;
		Location = location;
		Injury = injury;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((Display == null) ? (totalSize + 2) : (totalSize + (2 + Display.GetSerializedSize())));
		totalSize = ((Location == null) ? (totalSize + 2) : (totalSize + (2 + Location.GetSerializedSize())));
		totalSize = ((Injury == null) ? (totalSize + 2) : (totalSize + (2 + Injury.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Display != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = Display.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Location != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = Location.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Injury != null)
		{
			byte* intPtr3 = pCurrData;
			pCurrData += 2;
			int fieldSize3 = Injury.Serialize(pCurrData);
			pCurrData += fieldSize3;
			Tester.Assert(fieldSize3 <= 65535);
			*(ushort*)intPtr3 = (ushort)fieldSize3;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			Display = new CharacterDisplayData();
			pCurrData += Display.Deserialize(pCurrData);
		}
		else
		{
			Display = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			Location = new CharacterLocationDisplayData();
			pCurrData += Location.Deserialize(pCurrData);
		}
		else
		{
			Location = null;
		}
		ushort num3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num3 > 0)
		{
			Injury = new CharacterInjuryDisplayData();
			pCurrData += Injury.Deserialize(pCurrData);
		}
		else
		{
			Injury = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
