using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionDuoMeditation : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private const int FavorabilityChange = 3000;

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int targetCharId = actionData.TargetCharId;
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddIdentityActionXuanNv3(selfCharId, currDate, targetCharId, location);
		MapBlockData currBlock = DomainManager.Map.GetBlock(location);
		List<int> charList = context.AdvanceMonthRelatedData.CharIdList.Occupy();
		HashSet<int> characterSet = currBlock.CharacterSet;
		if (characterSet != null && characterSet.Count > 0)
		{
			foreach (int blockCharId in currBlock.CharacterSet)
			{
				Character blockChar = DomainManager.Character.GetElement_Objects(blockCharId);
				if (blockChar.GetOrganizationInfo().SettlementId == character.GetOrganizationInfo().SettlementId && blockCharId != targetCharId && blockChar.IsInteractableAsIntelligentCharacter() && DomainManager.Character.TryGetRelation(blockCharId, selfCharId, out var relation) && FavorabilityType.GetFavorabilityType(relation.Favorability) != 1)
				{
					charList.Add(blockCharId);
				}
			}
		}
		int audienceCharId = charList.GetRandomOrDefault(context.Random, -1);
		context.AdvanceMonthRelatedData.CharIdList.Release(ref charList);
		if (audienceCharId >= 0)
		{
			Character audienceChar = DomainManager.Character.GetElement_Objects(audienceCharId);
			sbyte currFavorType = DomainManager.Character.GetFavorabilityType(audienceCharId, selfCharId);
			DomainManager.Character.ChangeFavorabilityOptionalMonthlyEvolution(context, audienceChar, character, (currFavorType > 1) ? (-3000) : 3000);
			lifeRecordCollection.AddIdentityActionXuanNv3Audience(audienceCharId, currDate, selfCharId, location, targetCharId);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 0;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		_ = *(ushort*)pData;
		int totalSize = (int)(pData + 2 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
