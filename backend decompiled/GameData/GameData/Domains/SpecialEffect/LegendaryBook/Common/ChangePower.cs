using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Common;

public class ChangePower : CombatSkillEffectBase
{
	private const sbyte AddSelfPower = 20;

	private const sbyte ReduceEnemyPower = -20;

	protected ChangePower()
	{
		IsLegendaryBookEffect = true;
	}

	protected ChangePower(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			AppendAffectedData(context, base.CharacterId, 199, EDataModifyType.AddPercent, -1);
			AppendAffectedAllEnemyData(context, 199, EDataModifyType.AddPercent, -1);
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		ClearAffectedData(context);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return (dataKey.CharId == base.CharacterId) ? 20 : (-20);
		}
		return 0;
	}
}
