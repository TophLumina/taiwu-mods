using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AttackSkillFiveElementsType : CombatSkillEffectBase
{
	private const sbyte AffectSkillCount = 3;

	private const sbyte AffectSkillCounteringCount = 2;

	private const sbyte AffectSkillCounteredCount = 1;

	private const short SkillCdFrame = 1200;

	private const sbyte ReducePower = -30;

	protected sbyte AffectFiveElementsType;

	protected AttackSkillFiveElementsType()
	{
	}

	protected AttackSkillFiveElementsType(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
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
		if (PowerMatchAffectRequire(power))
		{
			DoAffecting(context, AffectFiveElementsType, 3);
			if (AffectFiveElementsType != 5)
			{
				DoAffecting(context, FiveElementsType.Countered[AffectFiveElementsType], 1);
				DoAffecting(context, FiveElementsType.Countering[AffectFiveElementsType], 2);
			}
		}
		RemoveSelf(context);
	}

	private void DoAffecting(DataContext context, sbyte fiveElementsType, int maxAffectCount)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerReduceDict = DomainManager.Combat.GetAllSkillPowerReduceInCombat();
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		foreach (short skillId in enemyChar.GetRandomUnrepeatedBanableSkillIds(context.Random, maxAffectCount, Predicate, -1, -1))
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, skillId, 1200);
			}
			else
			{
				DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(enemyChar.GetId(), skillId), effectKey, -30);
			}
			ShowSpecialEffectTipsOnceInFrame(0);
		}
		bool Predicate(short skillTemplateId)
		{
			CombatSkillKey key = new CombatSkillKey(enemyChar.GetId(), skillTemplateId);
			if (!FiveElementsEquals(key, fiveElementsType))
			{
				return false;
			}
			SkillPowerChangeCollection collection;
			return base.IsDirect || !powerReduceDict.TryGetValue(key, out collection) || !collection.EffectDict.ContainsKey(base.EffectKey);
		}
	}
}
