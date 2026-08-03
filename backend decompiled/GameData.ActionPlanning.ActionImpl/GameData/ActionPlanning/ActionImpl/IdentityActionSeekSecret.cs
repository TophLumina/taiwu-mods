using System.Collections.Generic;
using System.Linq;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Information;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionSeekSecret : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort SecretInfoMetaDataId = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "SecretInfoMetaDataId" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public SecretInformationId SecretInfoMetaDataId = SecretInformationId.Invalid;

	public static bool MatchTargetCharacter(DataContext context, Character character, Character targetChar, ContextArgGroupHandle args)
	{
		int targetCharId = targetChar.GetId();
		IReadOnlyCollection<SecretInformationId> targetSecrets = DomainManager.Information.QueryCharacterKnownSecretInformationIds(targetCharId);
		if (targetSecrets == null || targetSecrets.Count <= 0)
		{
			return false;
		}
		int selfCharId = character.GetId();
		IReadOnlyCollection<SecretInformationId> selfSecrets = DomainManager.Information.QueryCharacterKnownSecretInformationIds(selfCharId);
		if (selfSecrets == null || selfSecrets.Count <= 0)
		{
			return true;
		}
		foreach (SecretInformationId infoId in targetSecrets)
		{
			if (!selfSecrets.Contains(infoId))
			{
				return true;
			}
		}
		return false;
	}

	public bool OfflineInitActionData(DataContext context, Character character, ContextArgGroupHandle argGroup, CharacterActionData actionData)
	{
		int targetCharId = actionData.TargetCharId;
		int selfCharId = character.GetId();
		IReadOnlyCollection<SecretInformationId> targetSecrets = DomainManager.Information.QueryCharacterKnownSecretInformationIds(targetCharId);
		IReadOnlyCollection<SecretInformationId> selfSecrets = DomainManager.Information.QueryCharacterKnownSecretInformationIds(selfCharId);
		List<int> metaIdList = context.AdvanceMonthRelatedData.IntList.Occupy();
		if (selfSecrets == null || selfSecrets.Count <= 0)
		{
			foreach (SecretInformationId secretId in targetSecrets)
			{
				metaIdList.Add((int)secretId);
			}
		}
		else
		{
			foreach (SecretInformationId secretId2 in targetSecrets)
			{
				if (!selfSecrets.Contains(secretId2))
				{
					metaIdList.Add((int)secretId2);
				}
			}
		}
		SecretInfoMetaDataId = (SecretInformationId)metaIdList.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.IntList.Release(ref metaIdList);
		return SecretInfoMetaDataId.Valid;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		if (DomainManager.Information.CharacterHasSecretInformation(character.GetId(), SecretInfoMetaDataId))
		{
			return false;
		}
		if (DomainManager.Information.QuerySecretOccurence(SecretInfoMetaDataId) == null)
		{
			return false;
		}
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		DomainManager.Information.ReceiveSecretInformation(context, SecretInfoMetaDataId, selfCharId, targetCharId);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		short infoTemplateId = DomainManager.Information.QuerySecretOccurence(SecretInfoMetaDataId).TemplateId;
		lifeRecordCollection.AddIdentityActionChengZhen21(selfCharId, currDate, targetCharId, location, infoTemplateId);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SecretInfoMetaDataId.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 1;
		pCurrData += 2;
		int fieldSize = SecretInfoMetaDataId.Serialize(pCurrData);
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
			pCurrData += SecretInfoMetaDataId.Deserialize(pCurrData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
