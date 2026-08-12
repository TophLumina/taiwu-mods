using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.EquipmentMastery;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Special;

public class SuiShiChu : CombatSkillEffectBase
{
	private const int StateFrame = 1200;

	private const int AddAffectOdds = 50;

	public SuiShiChu()
	{
	}

	public SuiShiChu(CombatSkillKey skillKey)
		: base(skillKey, 11300, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(338, EDataModifyType.TotalPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 1200;
	}

	public override bool IsOn(int counterType)
	{
		return base.EffectCount > 0;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		ReduceEffectCount();
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool _)
	{
		if (SkillKey.IsMatch(charId, skillId) && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 338 || base.EffectCount <= 0)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		EEquipmentMasteryType type = (EEquipmentMasteryType)dataKey.CustomParam0;
		if (type != ((!base.IsDirect) ? EEquipmentMasteryType.Armor : EEquipmentMasteryType.Weapon))
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 50;
	}
}
