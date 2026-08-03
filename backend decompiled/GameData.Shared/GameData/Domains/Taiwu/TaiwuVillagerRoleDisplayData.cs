using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Domains.Map;
using GameData.Domains.Taiwu.Display;
using GameData.Domains.World;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuVillagerRoleDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<VillagerRoleManageDisplayData> VillagerRoleManageDisplayData;

	[SerializableGameDataField]
	public List<bool> VillagerRoleExtraEffectUnlockState;

	[SerializableGameDataField]
	public Dictionary<int, VillagerRoleCharacterDisplayData> Villagers;

	[SerializableGameDataField]
	public Dictionary<Location, CharacterLocationDisplayData> LocationData;

	[SerializableGameDataField]
	public List<DispatchSwordTombDisplayData> SwordTombList;

	[SerializableGameDataField]
	public Dictionary<short, BigEventRecord> BigEvents;

	[SerializableGameDataField]
	public AreaDisplayData[] AreaDisplayData;

	/// <summary>
	/// 村民昵称列表，可能为空（为空则需要前端处理成默认村民名称）
	/// index与Config.VillagerRole.DefKey对应
	/// </summary>
	[SerializableGameDataField]
	public string[] VillagerRoleNpcNickNames;

	[SerializableGameDataField]
	public CharacterSet Teammates;

	public List<(CharacterLocationDisplayData location, VillagerRoleCharacterDisplayData charData)> OrderedLocations => (from location in LocationData?.Values
		select (location: location, Villagers?.Values.FirstOrDefault(delegate(VillagerRoleCharacterDisplayData x)
		{
			sbyte? b = x.VillagerWorkData?.WorkType;
			bool flag;
			if (b.HasValue)
			{
				sbyte valueOrDefault = b.GetValueOrDefault();
				if ((uint)(valueOrDefault - 12) <= 1u)
				{
					flag = true;
					goto IL_003e;
				}
			}
			flag = false;
			goto IL_003e;
			IL_003e:
			if (flag && x.VillagerWorkData.AreaId == location.Location.AreaId)
			{
				return x.VillagerWorkData.BlockId == location.Location.BlockId;
			}
			return false;
		})) into location
		orderby (ulong)(((location.Item2 == null) ? 4294967296L : 0) | (uint)((ushort)(location.location.Location.AreaId << 16) | (ushort)location.location.Location.BlockId))
		select location).ToList() ?? new List<(CharacterLocationDisplayData, VillagerRoleCharacterDisplayData)>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (VillagerRoleManageDisplayData != null)
		{
			totalSize += 2;
			for (int i = 0; i < VillagerRoleManageDisplayData.Count; i++)
			{
				totalSize = ((VillagerRoleManageDisplayData[i] == null) ? (totalSize + 2) : (totalSize + (2 + VillagerRoleManageDisplayData[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((VillagerRoleExtraEffectUnlockState == null) ? (totalSize + 2) : (totalSize + (2 + VillagerRoleExtraEffectUnlockState.Count)));
		totalSize += 4;
		if (Villagers != null)
		{
			foreach (KeyValuePair<int, VillagerRoleCharacterDisplayData> pair in Villagers)
			{
				totalSize += 4;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize += 4;
		if (LocationData != null)
		{
			foreach (KeyValuePair<Location, CharacterLocationDisplayData> pair2 in LocationData)
			{
				totalSize += pair2.Key.GetSerializedSize();
				totalSize += pair2.Value.GetSerializedSize();
			}
		}
		if (SwordTombList != null)
		{
			totalSize += 2;
			for (int j = 0; j < SwordTombList.Count; j++)
			{
				totalSize = ((SwordTombList[j] == null) ? (totalSize + 2) : (totalSize + (2 + SwordTombList[j].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += 4;
		if (BigEvents != null)
		{
			foreach (KeyValuePair<short, BigEventRecord> pair3 in BigEvents)
			{
				totalSize += 2;
				totalSize += pair3.Value.GetSerializedSize();
			}
		}
		if (AreaDisplayData != null)
		{
			totalSize += 2;
			for (int k = 0; k < AreaDisplayData.Length; k++)
			{
				totalSize += AreaDisplayData[k].GetSerializedSize();
			}
		}
		else
		{
			totalSize += 2;
		}
		if (VillagerRoleNpcNickNames != null)
		{
			totalSize += 2;
			for (int l = 0; l < VillagerRoleNpcNickNames.Length; l++)
			{
				totalSize = ((VillagerRoleNpcNickNames[l] == null) ? (totalSize + 2) : (totalSize + (2 + 2 * VillagerRoleNpcNickNames[l].Length)));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize += Teammates.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (VillagerRoleManageDisplayData != null)
		{
			int elementsCount = VillagerRoleManageDisplayData.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (VillagerRoleManageDisplayData[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = VillagerRoleManageDisplayData[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VillagerRoleExtraEffectUnlockState != null)
		{
			int elementsCount2 = VillagerRoleExtraEffectUnlockState.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (VillagerRoleExtraEffectUnlockState[j] ? ((byte)1) : ((byte)0));
				pCurrData++;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (Villagers != null)
		{
			*(int*)pCurrData = Villagers.Count;
			pCurrData += 4;
			foreach (KeyValuePair<int, VillagerRoleCharacterDisplayData> pair in Villagers)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (LocationData != null)
		{
			*(int*)pCurrData = LocationData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<Location, CharacterLocationDisplayData> pair2 in LocationData)
			{
				pCurrData += pair2.Key.Serialize(pCurrData);
				pCurrData += pair2.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (SwordTombList != null)
		{
			int elementsCount3 = SwordTombList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				if (SwordTombList[k] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = SwordTombList[k].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (BigEvents != null)
		{
			*(int*)pCurrData = BigEvents.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, BigEventRecord> pair3 in BigEvents)
			{
				*(short*)pCurrData = pair3.Key;
				pCurrData += 2;
				pCurrData += pair3.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		if (AreaDisplayData != null)
		{
			int elementsCount4 = AreaDisplayData.Length;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				int fieldSize3 = AreaDisplayData[l].Serialize(pCurrData);
				pCurrData += fieldSize3;
				Tester.Assert(fieldSize3 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (VillagerRoleNpcNickNames != null)
		{
			int elementsCount5 = VillagerRoleNpcNickNames.Length;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				if (VillagerRoleNpcNickNames[m] != null)
				{
					int stringCount = VillagerRoleNpcNickNames[m].Length;
					Tester.Assert(stringCount <= 65535);
					*(ushort*)pCurrData = (ushort)stringCount;
					pCurrData += 2;
					fixed (char* pChar = VillagerRoleNpcNickNames[m])
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
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize4 = Teammates.Serialize(pCurrData);
		pCurrData += fieldSize4;
		Tester.Assert(fieldSize4 <= 65535);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (VillagerRoleManageDisplayData == null)
			{
				VillagerRoleManageDisplayData = new List<VillagerRoleManageDisplayData>();
			}
			else
			{
				VillagerRoleManageDisplayData.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				VillagerRoleManageDisplayData element;
				if (num > 0)
				{
					element = new VillagerRoleManageDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				VillagerRoleManageDisplayData.Add(element);
			}
		}
		else
		{
			VillagerRoleManageDisplayData?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (VillagerRoleExtraEffectUnlockState == null)
			{
				VillagerRoleExtraEffectUnlockState = new List<bool>();
			}
			else
			{
				VillagerRoleExtraEffectUnlockState.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				bool element2 = *pCurrData != 0;
				pCurrData++;
				VillagerRoleExtraEffectUnlockState.Add(element2);
			}
		}
		else
		{
			VillagerRoleExtraEffectUnlockState?.Clear();
		}
		int VillagersElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (VillagersElementsCount > 0)
		{
			if (Villagers == null)
			{
				Villagers = new Dictionary<int, VillagerRoleCharacterDisplayData>();
			}
			else
			{
				Villagers.Clear();
			}
			for (int k = 0; k < VillagersElementsCount; k++)
			{
				int key = *(int*)pCurrData;
				pCurrData += 4;
				VillagerRoleCharacterDisplayData value = new VillagerRoleCharacterDisplayData();
				pCurrData += value.Deserialize(pCurrData);
				Villagers.Add(key, value);
			}
		}
		else
		{
			Villagers?.Clear();
		}
		int LocationDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (LocationDataElementsCount > 0)
		{
			if (LocationData == null)
			{
				LocationData = new Dictionary<Location, CharacterLocationDisplayData>();
			}
			else
			{
				LocationData.Clear();
			}
			for (int l = 0; l < LocationDataElementsCount; l++)
			{
				Location key2 = default(Location);
				pCurrData += key2.Deserialize(pCurrData);
				CharacterLocationDisplayData value2 = new CharacterLocationDisplayData();
				pCurrData += value2.Deserialize(pCurrData);
				LocationData.Add(key2, value2);
			}
		}
		else
		{
			LocationData?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (SwordTombList == null)
			{
				SwordTombList = new List<DispatchSwordTombDisplayData>();
			}
			else
			{
				SwordTombList.Clear();
			}
			for (int m = 0; m < elementsCount3; m++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				DispatchSwordTombDisplayData element3;
				if (num2 > 0)
				{
					element3 = new DispatchSwordTombDisplayData();
					pCurrData += element3.Deserialize(pCurrData);
				}
				else
				{
					element3 = null;
				}
				SwordTombList.Add(element3);
			}
		}
		else
		{
			SwordTombList?.Clear();
		}
		int BigEventsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (BigEventsElementsCount > 0)
		{
			if (BigEvents == null)
			{
				BigEvents = new Dictionary<short, BigEventRecord>();
			}
			else
			{
				BigEvents.Clear();
			}
			for (int n = 0; n < BigEventsElementsCount; n++)
			{
				short key3 = *(short*)pCurrData;
				pCurrData += 2;
				BigEventRecord value3 = new BigEventRecord();
				pCurrData += value3.Deserialize(pCurrData);
				BigEvents.Add(key3, value3);
			}
		}
		else
		{
			BigEvents?.Clear();
		}
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (AreaDisplayData == null || AreaDisplayData.Length != elementsCount4)
			{
				AreaDisplayData = new AreaDisplayData[elementsCount4];
			}
			for (int num3 = 0; num3 < elementsCount4; num3++)
			{
				AreaDisplayData[num3] = default(AreaDisplayData);
				pCurrData += AreaDisplayData[num3].Deserialize(pCurrData);
			}
		}
		else
		{
			AreaDisplayData = null;
		}
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (VillagerRoleNpcNickNames == null || VillagerRoleNpcNickNames.Length != elementsCount5)
			{
				VillagerRoleNpcNickNames = new string[elementsCount5];
			}
			for (int num4 = 0; num4 < elementsCount5; num4++)
			{
				ushort stringCount = *(ushort*)pCurrData;
				pCurrData += 2;
				if (stringCount > 0)
				{
					int fieldSize = 2 * stringCount;
					VillagerRoleNpcNickNames[num4] = Encoding.Unicode.GetString(pCurrData, fieldSize);
					pCurrData += fieldSize;
				}
				else
				{
					VillagerRoleNpcNickNames[num4] = null;
				}
			}
		}
		else
		{
			VillagerRoleNpcNickNames = null;
		}
		pCurrData += Teammates.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
