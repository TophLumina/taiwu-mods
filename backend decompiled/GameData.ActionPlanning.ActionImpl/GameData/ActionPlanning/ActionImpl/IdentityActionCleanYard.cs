using Config.ConfigCells.Character;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionCleanYard : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	bool ICharacterActionImpl.CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	void ICharacterActionImpl.PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		PresetInventoryItem presetItem = actionData.Template.RandomItemRewards.GetRandom(context.Random);
		ItemKey itemKey = DomainManager.Item.CreateItem(context, presetItem.Type, presetItem.TemplateId);
		character.AddInventoryItem(context, itemKey, 1);
		DomainManager.LifeRecord.GetLifeRecordCollection().AddIdentityActionEmei1(date: DomainManager.World.GetCurrDate(), location: character.GetLocation(), selfCharId: character.GetId(), itemType: itemKey.ItemType, itemTemplateId: itemKey.TemplateId);
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
