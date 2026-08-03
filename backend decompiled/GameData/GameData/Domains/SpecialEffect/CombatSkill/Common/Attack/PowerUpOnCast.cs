using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public abstract class PowerUpOnCast : CombatSkillEffectBase
{
	protected int PowerUpValue;

	protected virtual EDataModifyType ModifyType => EDataModifyType.Add;

	protected PowerUpOnCast()
	{
	}

	protected PowerUpOnCast(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		if (PowerUpValue > 0)
		{
			CreateAffectedData(199, ModifyType, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			OnCastSelf(context, power, interrupted);
			RemoveSelf(context);
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
			return PowerUpValue;
		}
		return 0;
	}

	protected virtual void OnCastSelf(DataContext context, sbyte power, bool interrupted)
	{
	}
}
