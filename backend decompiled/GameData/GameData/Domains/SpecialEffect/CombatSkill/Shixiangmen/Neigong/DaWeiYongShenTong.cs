using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;

public class DaWeiYongShenTong : ReduceMainAttribute
{
	private const int NeedMarkCount = 4;

	private const int UnitAffect = 2;

	private int MaxAddValue => base.IsDirect ? 50 : 100;

	protected override bool IsAffect => AffectChar.GetDefeatMarkCollection().FatalDamageMarkCount >= 4;

	protected override sbyte MainAttributeType => 0;

	private int CurrAddValue => Math.Min(base.CurrMainAttribute / 2, MaxAddValue) * ((!base.IsDirect) ? 1 : (-1));

	private CombatCharacter AffectChar => base.IsDirect ? base.CombatChar : base.EnemyChar;

	public DaWeiYongShenTong()
	{
	}

	public DaWeiYongShenTong(CombatSkillKey skillKey)
		: base(skillKey, 6004)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (base.IsDirect)
		{
			AppendAffectedData(context, 191, EDataModifyType.AddPercent, -1);
		}
		else
		{
			AppendAffectedAllEnemyData(context, 191, EDataModifyType.AddPercent, -1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != AffectChar.GetId() || dataKey.FieldId != 191 || !IsAffect)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam1;
		if (damageType != EDamageType.Direct)
		{
			return 0;
		}
		if (Math.Abs(CurrAddValue) > 0)
		{
			ShowSpecialEffectTips(0);
		}
		return CurrAddValue;
	}
}
