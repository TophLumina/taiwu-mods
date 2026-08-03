using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class BiAnBaXianZi : CombatSkillEffectBase
{
	private static readonly int[] PoisonAffectThresholdValues = new int[6] { 1, 15, 25, 25, 200, 200 };

	private int _affectCharId;

	public BiAnBaXianZi()
	{
	}

	public BiAnBaXianZi(CombatSkillKey skillKey)
		: base(skillKey, 10401, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
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
				_affectCharId = (base.IsDirect ? base.CurrEnemyChar.GetId() : base.CharacterId);
				AppendAffectedData(context, _affectCharId, 163, EDataModifyType.Add, -1);
				AppendAffectedData(context, _affectCharId, 243, EDataModifyType.Add, -1);
				AddMaxEffectCount();
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

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!IsSrcSkillPerformed || dataKey.CharId != _affectCharId)
		{
			return 0;
		}
		if (dataKey.FieldId == 163)
		{
			ReduceEffectCount();
			return 1;
		}
		if (dataKey.FieldId == 243)
		{
			return PoisonAffectThresholdValues[dataKey.CustomParam0];
		}
		return 0;
	}
}
