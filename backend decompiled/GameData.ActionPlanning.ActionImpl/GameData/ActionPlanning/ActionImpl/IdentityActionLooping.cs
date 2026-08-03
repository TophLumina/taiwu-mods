using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.ActionPlanning.ActionImpl;

[AutoGenerateSerializableGameData(IsExtensible = true, NotForDisplayModule = true, NoCopyConstructors = true)]
public class IdentityActionLooping : ICharacterActionImpl, ISerializableGameData
{
	public static class FieldIds
	{
		public const ushort Count = 0;
	}

	private const int LoopCount = 3;

	public bool CheckValid(GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		return character.GetLoopingNeigong() >= 0;
	}

	public void PostExecute(DataContext context, GameData.Domains.Character.Character character, CharacterActionData actionData)
	{
		int selfCharId = character.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = character.GetLocation();
		DomainManager.LifeRecord.GetLifeRecordCollection().AddIdentityActionRanShan3(selfCharId, currDate, location);
		short loopingNeigong = character.GetLoopingNeigong();
		if (loopingNeigong < 0)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[loopingNeigong];
			var (neili, qiDisorder, extraNeiliAllocationProgress) = CombatSkillDomain.CalcNeigongLoopingEffect(context.Random, character, skillCfg);
			DomainManager.CombatSkill.ApplyNeigongLoopingEffect(context, character, loopingNeigong, neili, extraNeiliAllocationProgress);
			if (qiDisorder != 0)
			{
				character.ChangeDisorderOfQiRandomRecovery(context, qiDisorder);
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
