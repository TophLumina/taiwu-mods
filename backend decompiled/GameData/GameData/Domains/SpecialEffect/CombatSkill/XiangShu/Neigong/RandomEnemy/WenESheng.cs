using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class WenESheng : MinionBase
{
	private const sbyte AddHitUnit = 25;

	private int _addPercent;

	public WenESheng()
	{
	}

	public WenESheng(CombatSkillKey skillKey)
		: base(skillKey, 16000)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(32 + hitType), -1), EDataModifyType.TotalPercent);
		}
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateAddPercent(context);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			UpdateAddPercent(context);
		}
	}

	private void UpdateAddPercent(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		sbyte fameType = FameType.GetFameType(enemyChar.GetCharacter().GetFame());
		_addPercent = 25 * Math.Max(3 - fameType + 1, 0);
		for (sbyte hitType = 0; hitType < 4; hitType++)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(32 + hitType));
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !MinionBase.CanAffect)
		{
			return 0;
		}
		return _addPercent;
	}
}
