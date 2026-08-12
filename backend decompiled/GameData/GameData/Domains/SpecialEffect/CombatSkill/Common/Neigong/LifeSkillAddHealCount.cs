using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public class LifeSkillAddHealCount : CombatSkillEffectBase
{
	private const sbyte AddHealCountPercentBase = 25;

	private const sbyte AttainmentAddRatio = 10;

	protected sbyte RequireLifeSkillType;

	private int _addHealCountPercent;

	protected LifeSkillAddHealCount()
	{
	}

	protected LifeSkillAddHealCount(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData((ushort)(base.IsDirect ? 119 : 122), EDataModifyType.AddPercent, -1);
		int attainment = CharObj.GetLifeSkillAttainment(RequireLifeSkillType);
		_addHealCountPercent = 25 + attainment / 10;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 119 || fieldId == 122) ? true : false)
		{
			return _addHealCountPercent;
		}
		return 0;
	}
}
