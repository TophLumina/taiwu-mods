using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class VillagerRoleRecordElement : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CharacterId = 0;

		public const ushort CharacterTemplateId = 1;

		public const ushort RoleTemplateId = 2;

		public const ushort Personalities = 3;

		public const ushort CombatSkillAttainments = 4;

		public const ushort LifeSkillAttainments = 5;

		public const ushort Avatar = 6;

		public const ushort Name = 7;

		public const ushort Date = 8;

		public const ushort Count = 9;

		public static readonly string[] FieldId2FieldName = new string[9] { "CharacterId", "CharacterTemplateId", "RoleTemplateId", "Personalities", "CombatSkillAttainments", "LifeSkillAttainments", "Avatar", "Name", "Date" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public int CharacterId;

	[SerializableGameDataField(FieldIndex = 1)]
	public short CharacterTemplateId;

	[SerializableGameDataField(FieldIndex = 2)]
	public short RoleTemplateId;

	[SerializableGameDataField(FieldIndex = 3)]
	public Personalities Personalities;

	[SerializableGameDataField(FieldIndex = 4)]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField(FieldIndex = 5)]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField(FieldIndex = 6)]
	public AvatarRelatedData Avatar;

	[SerializableGameDataField(FieldIndex = 7)]
	public NameRelatedData Name;

	[SerializableGameDataField(FieldIndex = 8)]
	public int Date;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 114;
		totalSize = ((Avatar == null) ? (totalSize + 2) : (totalSize + (2 + Avatar.GetSerializedSize())));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 9;
		pCurrData += 2;
		*(int*)pCurrData = CharacterId;
		pCurrData += 4;
		*(short*)pCurrData = CharacterTemplateId;
		pCurrData += 2;
		*(short*)pCurrData = RoleTemplateId;
		pCurrData += 2;
		pCurrData += Personalities.Serialize(pCurrData);
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		if (Avatar != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 2;
			int fieldSize = Avatar.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)pSubDataCount = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += Name.Serialize(pCurrData);
		*(int*)pCurrData = Date;
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
			CharacterId = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 1)
		{
			CharacterTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 2)
		{
			RoleTemplateId = *(short*)pCurrData;
			pCurrData += 2;
		}
		if (fieldCount > 3)
		{
			pCurrData += Personalities.Deserialize(pCurrData);
		}
		if (fieldCount > 4)
		{
			pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		}
		if (fieldCount > 5)
		{
			pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		}
		if (fieldCount > 6)
		{
			ushort fieldSize = *(ushort*)pCurrData;
			pCurrData += 2;
			if (fieldSize > 0)
			{
				if (Avatar == null)
				{
					Avatar = new AvatarRelatedData();
				}
				pCurrData += Avatar.Deserialize(pCurrData);
			}
			else
			{
				Avatar = null;
			}
		}
		if (fieldCount > 7)
		{
			pCurrData += Name.Deserialize(pCurrData);
		}
		if (fieldCount > 8)
		{
			Date = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}
