using GameData.Serializer;

namespace GameData.DLC.SmarterChicken;

[SerializableGameData(IsExtensible = true)]
public class SmarterChickenData : IPolymorphRuntime, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort MaleCharacterId = 0;

		public const ushort FemaleCharacterId = 1;

		public const ushort State = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "MaleCharacterId", "FemaleCharacterId", "State" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int MaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 1)]
	public int FemaleCharacterId = -1;

	[SerializableGameDataField(FieldIndex = 2)]
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

	public SmarterChickenData()
	{
	}

	public SmarterChickenData(SmarterChickenData other)
	{
		MaleCharacterId = other.MaleCharacterId;
		FemaleCharacterId = other.FemaleCharacterId;
		_state = other._state;
	}

	public void Assign(SmarterChickenData other)
	{
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
		int totalSize = 11;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 3;
		byte* num = pData + 2;
		*(int*)num = MaleCharacterId;
		byte* num2 = num + 4;
		*(int*)num2 = FemaleCharacterId;
		byte* num3 = num2 + 4;
		*num3 = (byte)_state;
		int totalSize = (int)(num3 + 1 - pData);
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
			MaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			FemaleCharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 2)
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
