using GameData.Serializer;

namespace GameData.Domains.Character;

[SerializableGameData(IsExtensible = true, NotForDisplayModule = true)]
public class CharacterCreationMeta : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CreateDate = 0;

		public const ushort CreatingType = 1;

		public const ushort IsTemporary = 2;

		public const ushort OrgInfo = 3;

		public const ushort CreatingLocationAdventureCoreId = 4;

		public const ushort Count = 5;

		public static readonly string[] FieldId2FieldName = new string[5] { "CreateDate", "CreatingType", "IsTemporary", "OrgInfo", "CreatingLocationAdventureCoreId" };
	}

	[SerializableGameDataField]
	private int _createDate;

	[SerializableGameDataField]
	private byte _creatingType;

	[SerializableGameDataField]
	private bool _isTemporary;

	[SerializableGameDataField]
	private OrganizationInfo _orgInfo;

	[SerializableGameDataField]
	private int _creatingLocationAdventureCoreId;

	public CharacterCreationMeta(Character character)
	{
		_createDate = DomainManager.World.GetCurrDate();
		_creatingType = character.GetCreatingType();
		int charId = character.GetId();
		_isTemporary = DomainManager.Character.IsTemporaryIntelligentCharacter(charId) || DomainManager.Character.IsTemporaryEnemy(charId);
		_orgInfo = character.GetOrganizationInfo();
		_creatingLocationAdventureCoreId = DomainManager.Adventure.QueryRuntimeWhereCharacterIn(character)?.CoreId ?? 0;
	}

	public CharacterCreationMeta()
	{
	}

	public CharacterCreationMeta(CharacterCreationMeta other)
	{
		_createDate = other._createDate;
		_creatingType = other._creatingType;
		_isTemporary = other._isTemporary;
		_orgInfo = other._orgInfo;
		_creatingLocationAdventureCoreId = other._creatingLocationAdventureCoreId;
	}

	public void Assign(CharacterCreationMeta other)
	{
		_createDate = other._createDate;
		_creatingType = other._creatingType;
		_isTemporary = other._isTemporary;
		_orgInfo = other._orgInfo;
		_creatingLocationAdventureCoreId = other._creatingLocationAdventureCoreId;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 20;
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 5;
		pCurrData += 2;
		*(int*)pCurrData = _createDate;
		pCurrData += 4;
		*pCurrData = _creatingType;
		pCurrData++;
		*pCurrData = (_isTemporary ? ((byte)1) : ((byte)0));
		pCurrData++;
		pCurrData += _orgInfo.Serialize(pCurrData);
		*(int*)pCurrData = _creatingLocationAdventureCoreId;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			_createDate = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			_creatingType = *pCurrData;
			pCurrData++;
		}
		if (fieldCount > 2)
		{
			_isTemporary = *pCurrData != 0;
			pCurrData++;
		}
		if (fieldCount > 3)
		{
			pCurrData += _orgInfo.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			_creatingLocationAdventureCoreId = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
