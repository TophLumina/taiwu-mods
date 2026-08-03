using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class AutoAttackAndAddPower : CombatSkillEffectBase
{
	protected byte AttackRepeatTimes;

	protected sbyte AddPowerUnit;

	private int _addPower;

	protected AutoAttackAndAddPower()
	{
	}

	protected AutoAttackAndAddPower(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			AddMaxEffectCount();
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (defender == base.CombatChar && DomainManager.Combat.InAttackRange(attacker) && DomainManager.Combat.InAttackRange(base.CombatChar) && base.EffectCount > 0)
		{
			base.CombatChar.CanNormalAttackInPrepareSkill = true;
			base.CombatChar.NormalAttackFree();
			base.CombatChar.NormalAttackRepeatIsFightBack = true;
			base.CombatChar.NormalAttackLeftRepeatTimes = AttackRepeatTimes;
			base.CombatChar.SetIsFightBack(isFightBack: true, context);
			ReduceEffectCount();
			ShowSpecialEffectTips(0);
		}
		else if (attacker == base.CombatChar)
		{
			base.CombatChar.CanNormalAttackInPrepareSkill = false;
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId) && base.EffectCount > 0)
		{
			_addPower = AddPowerUnit * base.EffectCount;
			InvalidateCache(context, 199);
			ReduceEffectCount(base.EffectCount);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			_addPower = 0;
			InvalidateCache(context, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
