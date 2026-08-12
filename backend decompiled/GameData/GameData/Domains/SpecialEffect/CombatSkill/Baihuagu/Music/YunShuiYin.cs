using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class YunShuiYin : CombatSkillEffectBase
{
	private static readonly CValuePercent ChangeBreathAndStanceCost = 25;

	public YunShuiYin()
	{
	}

	public YunShuiYin(CombatSkillKey skillKey)
		: base(skillKey, 3300, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(301, EDataModifyType.Add, -1);
		Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (charId == base.CharacterId && base.EffectCount > 0 && (costBreath > 0 || costStance > 0))
		{
			ReduceEffectCount();
			short maxBreath = 30000;
			short maxStance = 4000;
			CValuePercent percent = (base.IsDirect ? CValuePercent.Parse(costBreath, maxBreath) : CValuePercent.Parse(costStance, maxStance));
			int addValue = (base.IsDirect ? maxStance : maxBreath) * percent * ChangeBreathAndStanceCost;
			if (base.IsDirect)
			{
				ChangeStanceValue(context, base.CombatChar, addValue);
			}
			else
			{
				ChangeBreathValue(context, base.CombatChar, addValue);
			}
			ShowSpecialEffectTips(1);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
			ShowSpecialEffectTips(0);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 301 && base.EffectCount > 0)
		{
			return base.IsDirect ? 1 : (-1);
		}
		return 0;
	}
}
