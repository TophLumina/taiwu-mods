using GameData.Serializer;

namespace GameData.DLC.CricketPolymorph;

[SerializableGameData(IsExtensible = true)]
public class CricketPolymorphData : IPolymorphRuntime, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CricketItemId = 0;

		public const ushort MaleCharacterId = 1;

		public const ushort FemaleCharacterId = 2;

		public const ushort State = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CricketItemId", "MaleCharacterId", "FemaleCharacterId", "State" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int CricketItemId = -1;

	[SerializableGameDataField(FieldIndex = 1)]
	public int MaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 2)]
	public int FemaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 3)]
	private EPolymorphState _state;

	public bool Alive => this.IsAlive();

	public int CurrentCharacterId => this.GetCurrentCharacterId();

	int IPolymorphRuntime.MaleCharacterId => MaleCharacterId;

	int IPolymorphRuntime.FemaleCharacterId => FemaleCharacterId;

	EPolymorphState IPolymorphRuntime.State
	{
		get
		{
			return _state;
		}
		set
		{
			_state = value;
		}
	}

	public CricketPolymorphData()
	{
	}

	public CricketPolymorphData(CricketPolymorphData other)
	{
		CricketItemId = other.CricketItemId;
		MaleCharacterId = other.MaleCharacterId;
		FemaleCharacterId = other.FemaleCharacterId;
		_state = other._state;
	}

	public void Assign(CricketPolymorphData other)
	{
		CricketItemId = other.CricketItemId;
		MaleCharacterId = other.MaleCharacterId;
		FemaleCharacterId = other.FemaleCharacterId;
		_state = other._state;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 15;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = CricketItemId;
		byte* num2 = num + 4;
		*(int*)num2 = MaleCharacterId;
		byte* num3 = num2 + 4;
		*(int*)num3 = FemaleCharacterId;
		byte* num4 = num3 + 4;
		*num4 = (byte)_state;
		int totalSize = (int)(num4 + 1 - pData);
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
			CricketItemId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			MaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
		{
			FemaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 3)
		{
			_state = (EPolymorphState)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
