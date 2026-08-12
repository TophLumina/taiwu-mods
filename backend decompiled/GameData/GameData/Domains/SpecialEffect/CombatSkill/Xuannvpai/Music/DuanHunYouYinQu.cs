using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class DuanHunYouYinQu : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 10;

	private int _addPower;

	public DuanHunYouYinQu()
	{
	}

	public DuanHunYouYinQu(CombatSkillKey skillKey)
		: base(skillKey, 8302, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		sbyte happinessType = HappinessType.GetHappinessType((base.IsDirect ? base.CurrEnemyChar : base.CombatChar).GetHappiness());
		if (happinessType < 3)
		{
			_addPower = 10 * (3 - happinessType);
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
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
			if (power > 0)
			{
				DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CurrEnemyChar : base.CombatChar, 0, 42, power * 2);
			}
			sbyte happinessType = HappinessType.GetHappinessType((base.IsDirect ? base.CurrEnemyChar : base.CombatChar).GetHappiness());
			if (PowerMatchAffectRequire(power) && happinessType < 3)
			{
				int injuryCount = 3 - happinessType;
				base.CurrEnemyChar.WorsenRepeatableInjury(context, injuryCount);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey != SkillKey)
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
