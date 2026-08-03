using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class ChangChunZhi : ChangePoisonLevel
{
	private const int DirectPoisonResist = -4;

	private const int ReversePoisonResist = 2;

	protected override sbyte AffectPoisonType => 1;

	public ChangChunZhi()
	{
	}

	public ChangChunZhi(CombatSkillKey skillKey)
		: base(skillKey, 3101)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData((ushort)(base.IsDirect ? 233 : 232), EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (IsMatchOwnAffect(dataKey.SkillKey))
		{
			ushort fieldId = dataKey.FieldId;
			if (1 == 0)
			{
			}
			int num = fieldId switch
			{
				233 => -4, 
				232 => 2, 
				_ => 0, 
			};
			if (1 == 0)
			{
			}
			int effectValue = num;
			if (effectValue != 0)
			{
				ShowSpecialEffectTipsOnceInFrame(1);
				return effectValue * base.EffectCount;
			}
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
