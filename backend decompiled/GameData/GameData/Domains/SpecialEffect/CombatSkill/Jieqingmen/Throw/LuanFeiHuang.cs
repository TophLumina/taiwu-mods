using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Throw;

public class LuanFeiHuang : CombatSkillEffectBase
{
	private const int ReducePowerPercent = -50;

	private static readonly CValuePercentBonus ReduceFlawPercent = -50;

	private static readonly CValuePercent ProgressPercent = 50;

	private static readonly sbyte[] RandomFlawLevels = new sbyte[2] { 0, 1 };

	private bool _autoCasting;

	public LuanFeiHuang()
	{
	}

	public LuanFeiHuang(CombatSkillKey skillKey)
		: base(skillKey, 13304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.TotalPercent, base.SkillTemplateId);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			DoAddFlaw(context);
			if (_autoCasting)
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * ProgressPercent);
			}
		}
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (charId == base.CharacterId && newWeapon.Item.GetItemSubType() == 2)
		{
			DoCastFree(context);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (SkillKey.IsMatch(charId, skillId) && _autoCasting)
		{
			_autoCasting = false;
			InvalidateCache(context, 199);
		}
	}

	private void DoAddFlaw(DataContext context)
	{
		int count = (base.IsDirect ? base.CombatChar : base.EnemyChar).GetContinueTricksAtStart(19);
		if (count > 0)
		{
			if (_autoCasting)
			{
				count = Math.Max(count * ReduceFlawPercent, 1);
			}
			ShowSpecialEffectTips(0);
			for (int i = 0; i < count; i++)
			{
				sbyte level = RandomFlawLevels.GetRandom(context.Random);
				DomainManager.Combat.AddFlaw(context, base.EnemyChar, level, SkillKey, -1);
			}
		}
	}

	private void DoCastFree(DataContext context)
	{
		if (DomainManager.Combat.CanCastSkill(base.CombatChar, base.SkillTemplateId, costFree: true, checkRange: true))
		{
			_autoCasting = true;
			InvalidateCache(context, 199);
			DomainManager.Combat.CastSkillFree(context, base.CombatChar, base.SkillTemplateId);
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.SkillKey == SkillKey && dataKey.FieldId == 199 && _autoCasting)
		{
			return -50;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
