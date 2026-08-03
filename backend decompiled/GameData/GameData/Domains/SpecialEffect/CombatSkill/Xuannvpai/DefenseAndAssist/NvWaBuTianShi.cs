using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.DefenseAndAssist;

public class NvWaBuTianShi : DefenseSkillBase
{
	private Injuries _originInjuries;

	public NvWaBuTianShi()
	{
	}

	public NvWaBuTianShi(CombatSkillKey skillKey)
		: base(skillKey, 8506)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(281, EDataModifyType.Custom, -1);
		_originInjuries = base.CombatChar.GetInjuries();
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		if (base.CombatChar.GetDefeatMarkCollection().GetTotalCount() >= GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()])
		{
			Injuries newInjuries = base.CombatChar.GetInjuries().Subtract(_originInjuries);
			bool anyHealed = false;
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				sbyte injuryValue = newInjuries.Get(bodyPart, !base.IsDirect);
				if (injuryValue > 0)
				{
					base.CombatChar.RemoveInjury(context, bodyPart, !base.IsDirect, injuryValue);
					anyHealed = true;
				}
			}
			if (anyHealed)
			{
				DomainManager.Combat.UpdateBodyDefeatMark(context, base.CombatChar);
				ShowSpecialEffectTips(0);
			}
		}
		DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
	}

	protected override void OnDefendSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		DomainManager.Combat.AddToCheckFallenSet(base.CombatChar.GetId());
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 281)
		{
			return dataValue;
		}
		return dataValue || base.CanAffect;
	}
}
