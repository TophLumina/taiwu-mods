using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.Animal;

public abstract class AnimalEffectBase : CombatSkillEffectBase
{
	protected bool CanAffect => base.CombatChar.AnimalConfig != null;

	protected bool IsElite => base.CombatChar.AnimalConfig?.IsElite ?? false;

	protected AnimalEffectBase()
	{
	}

	protected AnimalEffectBase(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
	}

	public override void OnDataAdded(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 217, EDataModifyType.Custom, base.SkillTemplateId);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || dataKey.FieldId != 217)
		{
			return dataValue;
		}
		return false;
	}
}
