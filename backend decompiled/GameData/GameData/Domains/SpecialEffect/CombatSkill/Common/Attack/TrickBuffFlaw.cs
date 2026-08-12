using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class TrickBuffFlaw : CombatSkillEffectBase
{
	private const sbyte DirectTrickUnit = 3;

	protected sbyte RequireTrickType;

	public TrickBuffFlaw()
	{
	}

	public TrickBuffFlaw(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		Events.RegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnAttackSkillAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool hit)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId && hit && index >= 3 && base.IsDirect && CombatCharPowerMatchAffectRequire())
		{
			int trickCount = CalcTrickCount(attacker.GetTricks());
			int flawCount = trickCount / 3;
			if (flawCount > 0)
			{
				DamageCompareData damageCompare = DomainManager.Combat.GetDamageCompareData();
				int hitValue = (int)Math.Clamp((long)damageCompare.HitValue[attacker.SkillFinalAttackHitIndex] * (long)attacker.GetAttackSkillPower() / 100, 0L, 2147483647L);
				int avoidValue = damageCompare.AvoidValue[attacker.SkillFinalAttackHitIndex];
				int hitOdds = CFormula.FormulaCalcHitOdds(hitValue, avoidValue);
				int flawLevel = CFormula.CalcFlawOrAcupointLevel(hitOdds, isFlaw: true) + 1;
				DomainManager.Combat.AddFlaw(context, defender, (sbyte)flawLevel, SkillKey, attacker.SkillAttackBodyPart, flawCount);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power) && !base.IsDirect)
		{
			sbyte[] weaponTricks = base.CombatChar.GetWeaponTricks();
			int trickCount = 0;
			sbyte[] array = weaponTricks;
			foreach (sbyte trickType in array)
			{
				if (trickType == RequireTrickType)
				{
					trickCount++;
				}
			}
			if (OnReverseAffect(context, trickCount))
			{
				ShowSpecialEffectTips(0);
			}
		}
		RemoveSelf(context);
	}

	protected int CalcTrickCount(TrickCollection trickCollection)
	{
		IReadOnlyDictionary<int, sbyte> trickDict = trickCollection.Tricks;
		int trickCounter = 0;
		foreach (sbyte type in trickDict.Values)
		{
			if (type == RequireTrickType)
			{
				trickCounter++;
			}
		}
		return trickCounter;
	}

	protected virtual bool OnReverseAffect(DataContext context, int trickCount)
	{
		return false;
	}
}
