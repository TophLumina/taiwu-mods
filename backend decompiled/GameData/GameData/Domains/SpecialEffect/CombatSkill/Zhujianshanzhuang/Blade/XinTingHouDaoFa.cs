using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Blade;

public class XinTingHouDaoFa : BladeUnlockEffectBase
{
	private const int SilenceFrame = 1800;

	private CombatCharacter _reducePowerChar;

	private int ReducePowerPercent => base.IsDirectOrReverseEffectDoubling ? (-50) : (-25);

	protected override IEnumerable<short> RequireWeaponTypes
	{
		get
		{
			yield return 10;
		}
	}

	public XinTingHouDaoFa()
	{
	}

	public XinTingHouDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 9200)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	protected override bool CanDoAffect()
	{
		return base.CurrEnemyChar.GetAffectingDefendSkillId() >= 0;
	}

	public override void DoAffectAfterCost(DataContext context, int weaponIndex)
	{
		ShowSpecialEffectTips(base.IsDirect, 2, 1);
		short skillId = base.CurrEnemyChar.GetAffectingDefendSkillId();
		DomainManager.Combat.ClearAffectingDefenseSkill(context, base.CurrEnemyChar);
		DomainManager.Combat.AddGoneMadInjury(context, base.CurrEnemyChar, skillId);
		DomainManager.Combat.SilenceSkill(context, base.CurrEnemyChar, skillId, 1800);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 199, EDataModifyType.AddPercent, -1);
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId) && base.IsReverseOrUsingDirectWeapon)
		{
			_reducePowerChar = base.CurrEnemyChar;
			InvalidateCache(context, _reducePowerChar.GetId(), 199);
			ShowSpecialEffectTips(base.IsDirect, 1, 0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && _reducePowerChar != null)
		{
			int reducePowerCharId = _reducePowerChar.GetId();
			_reducePowerChar = null;
			InvalidateCache(context, reducePowerCharId, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (_reducePowerChar == null || dataKey.CharId != _reducePowerChar.GetId() || dataKey.FieldId != 199)
		{
			return 0;
		}
		return (_reducePowerChar.GetAffectingDefendSkillId() == dataKey.CombatSkillId) ? ReducePowerPercent : 0;
	}
}
