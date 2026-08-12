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
public class IdentityActionReduceMemberXiangshuInfection : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private const int XiangshuInfectionChange = -50;

	public bool CheckValid(Character character, CharacterActionData actionData)
	{
		return true;
	}

	public void PostExecute(DataContext context, Character character, CharacterActionData actionData)
	{
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int charId = character.GetId();
		Location location = character.GetLocation();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddIdentityActionYuanshan5(charId, currDate, location);
		int[] targetCharIds = actionData.TargetCharIds;
		foreach (int targetCharId in targetCharIds)
		{
			if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var target))
			{
				target.ChangeXiangshuInfection(context, -50);
				lifeRecordCollection.AddIdentityActionYuanshan5Target(targetCharId, currDate, charId, location);
			}
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
