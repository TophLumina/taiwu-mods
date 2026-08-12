using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class XiaoJiuTianJiuShi : CombatSkillEffectBase
{
	private const sbyte ReduceBounceDamage = -80;

	private const sbyte RecoverBreathOrStance = 50;

	private int _costBreathOrStance;

	private bool _affected;

	public XiaoJiuTianJiuShi()
	{
	}

	public XiaoJiuTianJiuShi(CombatSkillKey skillKey)
		: base(skillKey, 8103, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				if (PowerMatchAffectRequire(power))
				{
					IsSrcSkillPerformed = true;
					AppendAffectedData(context, base.CharacterId, 103, EDataModifyType.TotalPercent, -1);
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
		else
		{
			if (Config.CombatSkill.Instance[skillId].EquipType != 1 || PowerMatchAffectRequire(power, 1) || interrupted)
			{
				return;
			}
			if (_costBreathOrStance > 0)
			{
				if (base.IsDirect)
				{
					ChangeStanceValue(context, base.CombatChar, _costBreathOrStance * 50 / 100);
				}
				else
				{
					ChangeBreathValue(context, base.CombatChar, _costBreathOrStance * 50 / 100);
				}
				ShowSpecialEffectTips(1);
			}
			_affected = false;
			ReduceEffectCount();
		}
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (base.CharacterId == charId && IsSrcSkillPerformed)
		{
			_costBreathOrStance = (base.IsDirect ? costStance : costBreath);
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
		if (dataKey.CharId != base.CharacterId || base.CombatChar.GetPerformingSkillId() < 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 103 && dataKey.CustomParam0 == ((!base.IsDirect) ? 1 : 0) && !CombatCharPowerMatchAffectRequire(1))
		{
			if (!_affected)
			{
				_affected = true;
				ShowSpecialEffectTips(0);
			}
			return -80;
		}
		return 0;
	}
}
