using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class MoHeJiaLuoDao : CombatSkillEffectBase
{
	private const short AddGoneMadInjury = 100;

	private const int DisorderOfQiPerEffectCount = 1000;

	private const sbyte BuffEnemyCount = 18;

	private const sbyte MaxCostOnce = 6;

	private const int ChangeNeiliAllocationValue = 5;

	private int _delayDisorderOfQi;

	private int _delayFatalDamages;

	private readonly OuterAndInnerInts[] _delayDamages = new OuterAndInnerInts[7];

	private bool _delaying;

	private int ChangeNeiliAllocationDirection => base.IsDirect ? 1 : (-1);

	private bool CanBuffEnemy => base.EffectCount >= 18;

	public MoHeJiaLuoDao()
	{
	}

	public MoHeJiaLuoDao(CombatSkillKey skillKey)
		: base(skillKey, 11208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(320, EDataModifyType.Custom, -1);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_delaying = true;
			_delayDisorderOfQi = 0;
			_delayFatalDamages = 0;
			for (int i = 0; i < _delayDamages.Length; i++)
			{
				_delayDamages[i] = default(OuterAndInnerInts);
			}
			DomainManager.Combat.AddGoneMadInjury(context, base.CombatChar, skillId, 100);
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() != base.CharacterId && (!CanBuffEnemy || defender.GetId() != base.CharacterId))
		{
			return;
		}
		int canAddCount = Math.Min(6, base.EffectCount);
		if (canAddCount > 0)
		{
			ShowSpecialEffectTips(attacker.GetId() == base.CharacterId, 2, 3);
			ReduceEffectCount(canAddCount);
			int delta = canAddCount * 5 * ChangeNeiliAllocationDirection;
			CombatCharacter target = (base.IsDirect ? attacker : defender);
			for (byte i = 0; i < 4; i++)
			{
				target.ChangeNeiliAllocation(context, i, delta);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		_delaying = false;
		int effectCount = base.EffectCount;
		bool isFullPower = PowerMatchAffectRequire(power);
		if (isFullPower)
		{
			ShowSpecialEffectTips(1);
		}
		if (isFullPower)
		{
			effectCount += _delayFatalDamages / base.CombatChar.GetDamageStepCollection().FatalDamageStep;
			effectCount += _delayDisorderOfQi / 1000;
		}
		else
		{
			base.CombatChar.AddFatalDamage(context, _delayFatalDamages, -1, -1, -1);
			base.CombatChar.GetCharacter().ChangeDisorderOfQi(context, _delayDisorderOfQi);
		}
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			OuterAndInnerInts damage = _delayDamages[bodyPart];
			if (isFullPower)
			{
				effectCount += CalcEffectCount(damage.Outer, inner: false, bodyPart);
				effectCount += CalcEffectCount(damage.Inner, inner: true, bodyPart);
			}
			else
			{
				DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, base.CombatChar, bodyPart, damage.Outer, damage.Inner, -1, updateDefeatMark: false);
			}
		}
		if (isFullPower && effectCount > 0)
		{
			DomainManager.Combat.AddSkillEffect(context, base.CombatChar, base.EffectKey, (short)effectCount, (short)effectCount, autoRemoveOnNoCount: true);
		}
		DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
	}

	private int CalcEffectCount(int damage, bool inner, sbyte bodyPart)
	{
		DamageStepCollection damageStepCollection = base.CombatChar.GetDamageStepCollection();
		Injuries injuries = base.CombatChar.GetInjuries();
		int[] damageSteps = (inner ? damageStepCollection.InnerDamageSteps : damageStepCollection.OuterDamageSteps);
		int injuryCount = damage / damageSteps[bodyPart];
		if (injuries.Get(bodyPart, inner) + injuryCount <= 6)
		{
			return injuryCount;
		}
		injuryCount = 6 - injuries.Get(bodyPart, inner);
		damage -= injuryCount * damageSteps[bodyPart];
		return injuryCount + damage / damageStepCollection.FatalDamageStep;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !_delaying || dataKey.FieldId != 114)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		sbyte part = (sbyte)dataKey.CustomParam2;
		if (dataKey.CustomParam1 == 1)
		{
			_delayDamages[part].Inner += (int)dataValue;
		}
		else
		{
			_delayDamages[part].Outer += (int)dataValue;
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return 0L;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !_delaying || dataKey.FieldId != 320)
		{
			return dataValue;
		}
		bool inner = dataKey.CustomParam0 == 1;
		sbyte part = (sbyte)dataKey.CustomParam1;
		if (dataKey.CustomParam2 == 1)
		{
			_delayDisorderOfQi += dataValue;
		}
		else if (part < 0)
		{
			_delayFatalDamages += dataValue;
		}
		else if (inner)
		{
			_delayDamages[part].Inner += dataValue;
		}
		else
		{
			_delayDamages[part].Outer += dataValue;
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return 0;
	}
}
