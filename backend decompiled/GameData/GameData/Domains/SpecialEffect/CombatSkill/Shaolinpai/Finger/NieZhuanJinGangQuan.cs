using System;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Finger;

public class NieZhuanJinGangQuan : CombatSkillEffectBase
{
	private const sbyte ReduceDamagePercent = -30;

	private const sbyte BouncePower = 80;

	private const sbyte PrepareProgressPercent = 50;

	private bool _affected;

	public NieZhuanJinGangQuan()
	{
	}

	public NieZhuanJinGangQuan(CombatSkillKey skillKey)
		: base(skillKey, 1204, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (defender.GetId() == base.CharacterId && _affected)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (IsSrcSkillPerformed && charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAutoCastingSkill())
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
			RemoveSelf(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				if (PowerMatchAffectRequire(power) && !base.CombatChar.GetAutoCastingSkill())
				{
					IsSrcSkillPerformed = true;
					_affected = false;
					AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, 111, EDataModifyType.Add, -1);
					AppendAffectedData(context, base.CharacterId, 177, EDataModifyType.Custom, -1);
					AddMaxEffectCount();
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		else if (_affected && isAlly != base.CombatChar.IsAlly && DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			if (DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true))
			{
				DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
				ShowSpecialEffectTips(1);
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !IsSrcSkillPerformed)
		{
			return 0;
		}
		if (dataKey.FieldId == 102 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			if (!_affected)
			{
				_affected = true;
				ShowSpecialEffectTips(0);
			}
			return -30;
		}
		if (dataKey.FieldId == 111 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0))
		{
			return 80;
		}
		return 0;
	}

	public override OuterAndInnerInts GetModifiedValue(AffectedDataKey dataKey, OuterAndInnerInts dataValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 177)
		{
			OuterAndInnerInts skillRange = DomainManager.Combat.GetSkillAttackRange(base.CombatChar, base.SkillTemplateId);
			dataValue.Outer = Math.Min(dataValue.Outer, skillRange.Outer);
			dataValue.Inner = Math.Max(dataValue.Inner, skillRange.Inner);
		}
		return dataValue;
	}
}
