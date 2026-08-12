using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Agile;

public class ZuiWoDongHai : AgileSkillBase
{
	private static readonly CValuePercent MinCostBreathOrStancePercent = 50;

	private short _affectingSkill;

	private int _changePower;

	private CValuePercent AddPowerPercent => EatingWine ? 40 : 20;

	private CValuePercent ReducePowerPercent => EatingWine ? 50 : 100;

	private bool EatingWine => CharObj.GetEatingItems().ContainsWine();

	public ZuiWoDongHai()
	{
	}

	public ZuiWoDongHai(CombatSkillKey skillKey)
		: base(skillKey, 14405)
	{
		ListenCanAffectChange = !base.IsDirect;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_affectingSkill = -1;
		_changePower = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.TotalPercent);
		if (base.IsDirect)
		{
			Events.RegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 225, -1), EDataModifyType.Custom);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 226, -1), EDataModifyType.Custom);
			Events.RegisterHandler_CastSkillOnLackBreathStance(OnCastSkillOnLackBreathStance);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.IsDirect)
		{
			Events.UnRegisterHandler_CostBreathAndStance(OnCostBreathAndStance);
		}
		else
		{
			Events.UnRegisterHandler_CastSkillOnLackBreathStance(OnCastSkillOnLackBreathStance);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCostBreathAndStance(DataContext context, int charId, bool isAlly, int costBreath, int costStance, short skillId)
	{
		if (charId == base.CharacterId && base.CanAffect && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			int breathValue = base.CombatChar.GetBreathValue();
			int stanceValue = base.CombatChar.GetStanceValue();
			_affectingSkill = skillId;
			_changePower = (breathValue * 100 / 30000 + stanceValue * 100 / 4000) * AddPowerPercent;
			if (breathValue > 0)
			{
				DomainManager.Combat.ChangeBreathValue(context, base.CombatChar, -breathValue);
			}
			if (stanceValue > 0)
			{
				DomainManager.Combat.ChangeStanceValue(context, base.CombatChar, -stanceValue);
			}
			if (_changePower > 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				ShowSpecialEffectTips(0);
			}
			AutoRemove = false;
		}
	}

	private void OnCastSkillOnLackBreathStance(DataContext context, CombatCharacter combatChar, short skillId, int lackBreath, int lackStance, int costBreath, int costStance)
	{
		if (combatChar == base.CombatChar && base.CanAffect && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			int breathStancePercent = 0;
			if (lackBreath < 0)
			{
				breathStancePercent += lackBreath * 100 / costBreath;
			}
			if (lackStance < 0)
			{
				breathStancePercent += lackStance * 100 / costStance;
			}
			_affectingSkill = skillId;
			_changePower = breathStancePercent * ReducePowerPercent;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
			AutoRemove = false;
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			return;
		}
		if (AgileSkillChanged)
		{
			RemoveSelf(context);
			return;
		}
		_affectingSkill = -1;
		if (_changePower != 0)
		{
			_changePower = 0;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		}
		AutoRemove = true;
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 1)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 225)
		{
			int costBreath = dataKey.CustomParam0;
			return base.CombatChar.GetBreathValue() >= costBreath * MinCostBreathOrStancePercent;
		}
		if (dataKey.FieldId == 226)
		{
			int costStance = dataKey.CustomParam0;
			return base.CombatChar.GetStanceValue() >= costStance * MinCostBreathOrStancePercent;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _affectingSkill)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _changePower;
		}
		return 0;
	}
}
