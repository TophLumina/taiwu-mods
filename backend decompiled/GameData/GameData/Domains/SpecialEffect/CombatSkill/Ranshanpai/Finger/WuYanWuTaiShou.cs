using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Finger;

public class WuYanWuTaiShou : CombatSkillEffectBase
{
	private readonly sbyte[] _requirePersonalities = new sbyte[5] { 0, 1, 2, 3, 4 };

	private const sbyte AddTrickOrMarkNeedPersonalityCount = 3;

	private const sbyte AddTrickOrMarkCount = 2;

	private const short FameMultiplier = 3;

	public WuYanWuTaiShou()
	{
	}

	public WuYanWuTaiShou(CombatSkillKey skillKey)
		: base(skillKey, 7102, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power) && CalcAbovePersonalityCount() >= 3)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, base.CurrEnemyChar, 20, 2, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, base.CurrEnemyChar);
			}
			RecordFameAction(context);
			ShowSpecialEffectTips(0);
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}

	private int CalcAbovePersonalityCount()
	{
		Personalities selfPersonalities = CharObj.GetPersonalities();
		Personalities enemyPersonalities = base.CurrEnemyChar.GetCharacter().GetPersonalities();
		int personalityCount = 0;
		sbyte[] requirePersonalities = _requirePersonalities;
		foreach (sbyte type in requirePersonalities)
		{
			if (selfPersonalities[type] > enemyPersonalities[type])
			{
				personalityCount++;
			}
		}
		return personalityCount;
	}

	private void RecordFameAction(DataContext context)
	{
		GameData.Domains.Character.Character selfChar = base.CombatChar.GetCharacter();
		GameData.Domains.Character.Character enemyChar = base.CurrEnemyChar.GetCharacter();
		short selfFameId = (short)(40 + ((!base.IsDirect) ? 1 : 0));
		short enemyFameId = (short)(base.IsDirect ? 52 : 53);
		selfChar.RecordFameAction(context, selfFameId, -1, 3);
		enemyChar.RecordFameAction(context, enemyFameId, -1, 3);
	}
}
