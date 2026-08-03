using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class SuNvTianYin : CombatSkillEffectBase
{
	private const sbyte DirectRequireTrickCount = 3;

	private const sbyte ReverseRequireMarkCount = 6;

	private int _affectMindMarkCount;

	public SuNvTianYin()
	{
	}

	public SuNvTianYin(CombatSkillKey skillKey)
		: base(skillKey, 8308, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (base.IsDirect ? (defender.GetTrickCount(20) >= 3) : (defender.GetDefeatMarkCollection().MindMarkList.Count >= 6))
			{
				ClearAffectingAgileSkill(context, defender);
				DomainManager.Combat.ClearAffectingDefenseSkill(context, defender);
				ShowSpecialEffectTips(0);
			}
			if (!base.IsDirect)
			{
				_affectMindMarkCount = base.CurrEnemyChar.GetDefeatMarkCollection().MindMarkList.Count;
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		int markOrTrickCount = (base.IsDirect ? base.CurrEnemyChar.GetTrickCount(20) : _affectMindMarkCount);
		if (PowerMatchAffectRequire(power) && markOrTrickCount > 0)
		{
			List<NeedTrick> removeTricks = ObjectPool<List<NeedTrick>>.Instance.Get();
			removeTricks.Clear();
			removeTricks.Add(new NeedTrick(20, (byte)markOrTrickCount));
			if (base.IsDirect)
			{
				DomainManager.Combat.RemoveTrick(context, base.CurrEnemyChar, removeTricks, removedByAlly: false);
			}
			else
			{
				base.CurrEnemyChar.RemoveMindMark(context, markOrTrickCount, random: false);
			}
			ObjectPool<List<NeedTrick>>.Instance.Return(removeTricks);
			base.CurrEnemyChar.AddFatalMark(context, markOrTrickCount, -1, -1);
			ShowSpecialEffectTips(1);
		}
		RemoveSelf(context);
	}
}
