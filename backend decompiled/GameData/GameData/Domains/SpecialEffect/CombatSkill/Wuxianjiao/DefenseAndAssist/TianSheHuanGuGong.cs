using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class TianSheHuanGuGong : AssistSkillBase
{
	private const sbyte AutoHealSpeed = 1;

	private const sbyte FatalDamageRequireInjuryCount = 4;

	private bool _canAffect;

	private bool _affecting;

	public TianSheHuanGuGong()
	{
	}

	public TianSheHuanGuGong(CombatSkillKey skillKey)
		: base(skillKey, 12808)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_canAffect = false;
		_affecting = false;
		CreateAffectedData(191, EDataModifyType.Custom, -1);
		CreateAffectedData(192, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateAffecting(context);
	}

	protected override void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
		UpdateAffecting(context);
	}

	private void UpdateAffecting(DataContext context)
	{
		bool affecting = base.CanAffect;
		if (affecting == _affecting)
		{
			return;
		}
		_affecting = affecting;
		List<short> speedList = (base.IsDirect ? base.CombatChar.OuterInjuryAutoHealSpeeds : base.CombatChar.InnerInjuryAutoHealSpeeds);
		SetConstAffecting(context, _affecting);
		if (_affecting)
		{
			speedList.Add(1);
			return;
		}
		speedList.Remove(1);
		if (speedList.Count <= 0)
		{
			base.CombatChar.ClearInjuryAutoHealProgress(context, !base.IsDirect);
		}
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (defender == base.CombatChar)
		{
			_canAffect = attacker.NormalAttackBodyPart >= 0 && base.CombatChar.GetInjuries().Get(attacker.NormalAttackBodyPart, !base.IsDirect) < 4;
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (defender == base.CombatChar)
		{
			_canAffect = false;
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (defender == base.CombatChar)
		{
			_canAffect = attacker.SkillAttackBodyPart >= 0 && base.CombatChar.GetInjuries().Get(attacker.SkillAttackBodyPart, !base.IsDirect) < 4;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (isAlly != base.CombatChar.IsAlly && DomainManager.Combat.GetCombatCharacter(base.CombatChar.IsAlly, tryGetCoverCharacter: true) == base.CombatChar)
		{
			_canAffect = false;
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataValue <= 0 || !base.CanAffect || !_canAffect || dataKey.CustomParam0 != ((!base.IsDirect) ? 1 : 0))
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 191) <= 1u)
		{
			dataValue = 0;
			ShowSpecialEffectTips(0);
		}
		return dataValue;
	}
}
