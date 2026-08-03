using System;
using System.Collections.Generic;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionFarm : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		Location location = character.GetLocation();
		MapBlockData currBlock = DomainManager.Map.GetBlock(location);
		RecoverBlock(context, currBlock);
		List<MapBlockData> neighborBlocks = context.AdvanceMonthRelatedData.Blocks.Occupy();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, neighborBlocks);
		foreach (MapBlockData neighborBlock in neighborBlocks)
		{
			RecoverBlock(context, neighborBlock);
		}
		context.AdvanceMonthRelatedData.Blocks.Release(ref neighborBlocks);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddIdentityActionChengZhen22(selfCharId, currDate, location);
	}

	private void RecoverBlock(DataContext context, MapBlockData blockData)
	{
		if (blockData.GetConfig().ResourceCollectionType < 0)
		{
			return;
		}
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			short maxResource = blockData.MaxResources[resourceType];
			short currResource = blockData.CurrResources[resourceType];
			if (maxResource > 0)
			{
				blockData.CurrResources[resourceType] = (short)Math.Clamp(maxResource * 20 / 100 + currResource, 0, maxResource);
			}
		}
		DomainManager.Map.SetBlockData(context, blockData);
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
