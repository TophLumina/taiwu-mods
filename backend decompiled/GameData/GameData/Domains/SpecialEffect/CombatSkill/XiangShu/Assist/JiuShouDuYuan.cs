using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Helper;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class JiuShouDuYuan : AssistSkillBase
{
	private const int RequireCounter = 9;

	private int _acceptCounter;

	private int _makeCounter;

	private bool _affecting;

	public JiuShouDuYuan()
	{
	}

	public JiuShouDuYuan(CombatSkillKey skillKey)
		: base(skillKey, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(76, EDataModifyType.Custom, -1);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (_affecting && attacker == base.CombatChar)
		{
			_affecting = false;
			base.CombatChar.CanNormalAttackInPrepareSkill = false;
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (!base.CombatChar.NeedUseGoldenWire && base.CombatChar.GetBossPhase() > 0)
		{
			int delta = newCount - oldCount;
			if (key == HeavenlyEmperorHelper.AcceptDamageEffectKey && delta > 0)
			{
				_acceptCounter += delta;
			}
			else if (key == HeavenlyEmperorHelper.MakeDamageEffectKey && delta < 0)
			{
				_makeCounter += Math.Abs(delta);
			}
			if (_acceptCounter >= 9 || _makeCounter >= 9)
			{
				_affecting = true;
				base.CombatChar.NeedFreeAttack = true;
				base.CombatChar.NeedUseGoldenWire = true;
				base.CombatChar.CanNormalAttackInPrepareSkill = true;
				_acceptCounter = (_makeCounter = 0);
				ShowSpecialEffectTips(0);
			}
		}
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 76 && _affecting)
		{
			return 100;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
