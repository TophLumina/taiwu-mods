using System.Collections.Generic;
using GameData.Adventure;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(IsExtensible = true)]
public class AdventureTaiwu : ISerializableGameData, IAdventureParticipant, IAdventureParameterProvider
{
	private static class FieldIds
	{
		public const ushort AdventureId = 0;

		public const ushort InternalIndex = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "AdventureId", "InternalIndex" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int AdventureId;

	[SerializableGameDataField(FieldIndex = 1)]
	private AdventureBlockIndex _internalIndex;

	public bool InAdventure => AdventureId >= 1;

	public bool NotInAdventure => !InAdventure;

	public AdventureRuntime Adventure => ExternalDataBridge.Context.GetAdventure(AdventureId);

	public AdventureBlockIndex Index => _internalIndex;

	IReadOnlyList<AdventureParameterData> IAdventureParameterProvider.Parameters => Adventure.Core.Parameters;

	public AdventureTaiwu(int adventureId, AdventureBlockIndex index)
	{
		AdventureId = adventureId;
		_internalIndex = index;
	}

	public void ResetAdventureId()
	{
		AdventureId = 0;
		SetCurrentIndex(default(AdventureBlockIndex));
	}

	public void SetCurrentIndex(AdventureBlockIndex index)
	{
		_internalIndex = index;
	}

	AdventureParameterValue? IAdventureParameterProvider.GetParameterOrNull(AdventureParameterKey key)
	{
		return Adventure.GetParameterOrNull(key);
	}

	void IAdventureParameterProvider.SetParameter(AdventureParameterKey key, AdventureParameterValue value)
	{
		Adventure.SetParameter(key, value);
	}

	void IAdventureParameterProvider.RemoveParameter(AdventureParameterKey key)
	{
		Adventure.RemoveParameter(key);
	}

	public AdventureTaiwu()
	{
	}

	public AdventureTaiwu(AdventureTaiwu other)
	{
		AdventureId = other.AdventureId;
		_internalIndex = other._internalIndex;
	}

	public void Assign(AdventureTaiwu other)
	{
		AdventureId = other.AdventureId;
		_internalIndex = other._internalIndex;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += ((AdventureBlockIndexForSerialize)_internalIndex).GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 2;
		pCurrData += 2;
		*(int*)pCurrData = AdventureId;
		pCurrData += 4;
		int fieldSize = ((AdventureBlockIndexForSerialize)_internalIndex).Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
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
			AdventureId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			AdventureBlockIndexForSerialize field = _internalIndex;
			pCurrData += field.Deserialize(pCurrData);
			_internalIndex = field;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
