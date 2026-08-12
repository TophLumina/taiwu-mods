using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Agile;

public class MengHuXiaShanShi : AgileSkillBase
{
	private const sbyte PenetrateAddPercent = 60;

	private short _affectingLegSkill;

	public MengHuXiaShanShi()
	{
	}

	public MengHuXiaShanShi(CombatSkillKey skillKey)
		: base(skillKey, 5401)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_CastLegSkillWithAgile(OnCastLegSkillWithAgile);
	}

	private void OnCastLegSkillWithAgile(DataContext context, CombatCharacter combatChar, short legSkillId)
	{
		if (base.CanAffect && combatChar == base.CombatChar)
		{
			AutoRemove = false;
			_affectingLegSkill = legSkillId;
			if (AffectDatas == null || AffectDatas.Count == 0)
			{
				AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 64 : 65), EDataModifyType.TotalPercent, legSkillId);
			}
			ShowSpecialEffectTips(0);
			Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _affectingLegSkill)
		{
			Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
			if (AgileSkillChanged)
			{
				RemoveSelf(context);
			}
			else
			{
				AutoRemove = true;
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _affectingLegSkill)
		{
			return 0;
		}
		if (dataKey.FieldId == 64 || dataKey.FieldId == 65)
		{
			return 60;
		}
		return 0;
	}
}
