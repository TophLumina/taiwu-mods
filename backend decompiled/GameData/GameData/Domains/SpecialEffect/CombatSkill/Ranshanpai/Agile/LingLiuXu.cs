using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class LingLiuXu : BuffHitOrDebuffAvoid
{
	protected override sbyte AffectHitType => 1;

	public LingLiuXu()
	{
	}

	public LingLiuXu(CombatSkillKey skillKey)
		: base(skillKey, 7406)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(248, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(234, EDataModifyType.Custom, -1);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int num = fieldId switch
		{
			248 => dataKey.CustomParam0, 
			234 => dataKey.CustomParam1, 
			_ => -1, 
		};
		if (1 == 0)
		{
		}
		int hitType = num;
		bool affected = CheckAffected(dataKey, hitType);
		if (affected)
		{
			ShowSpecialEffectTipsOnceInFrame(0);
		}
		ushort fieldId2 = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId2 switch
		{
			248 => dataValue || affected, 
			234 => dataValue && !affected, 
			_ => base.GetModifiedValue(dataKey, dataValue), 
		};
		if (1 == 0)
		{
		}
		return result;
	}

	private bool CheckAffected(AffectedDataKey dataKey, int hitType)
	{
		if (!base.CanAffect)
		{
			return false;
		}
		if (dataKey.IsNormalAttack)
		{
			return hitType == AffectHitType;
		}
		int charId = ((dataKey.FieldId == 248) ? dataKey.CharId : dataKey.CustomParam2);
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills((charId: charId, skillId: dataKey.CombatSkillId), out var skill))
		{
			PredefinedLog.Show(7, base.EffectId, $"CheckAffected with unexpected skillKey {dataKey.SkillKey}");
			return false;
		}
		int rate = skill.GetHitDistribution()[hitType];
		return DomainManager.Combat.Context.Random.CheckPercentProb(rate);
	}
}
