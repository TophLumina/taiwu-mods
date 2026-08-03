using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class YueNvJianFa : CombatSkillEffectBase
{
	private const sbyte ChangePursueOdds = 50;

	public YueNvJianFa()
	{
	}

	public YueNvJianFa(CombatSkillKey skillKey)
		: base(skillKey, 2304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (!IsSrcSkillPerformed)
		{
			if (PowerMatchAffectRequire(power))
			{
				IsSrcSkillPerformed = true;
				AddMaxEffectCount();
				AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 76 : 109), EDataModifyType.TotalPercent, -1);
				ShowSpecialEffectTips(0);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else if (PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (IsSrcSkillPerformed && (base.IsDirect ? attacker.GetId() : defender.GetId()) == base.CharacterId)
		{
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 76)
		{
			return 50;
		}
		if (dataKey.FieldId == 109)
		{
			return -50;
		}
		return 0;
	}
}
