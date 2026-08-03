using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class QuXueFa : AssistSkillBase
{
	private const sbyte AddPercent = 50;

	private static readonly int[] PoisonAffectThresholdValues = new int[6] { -1, -15, -25, -25, -200, -200 };

	public QuXueFa()
	{
	}

	public QuXueFa(CombatSkillKey skillKey)
		: base(skillKey, 10705)
	{
		SetConstAffectingOnCombatBegin = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(73, EDataModifyType.TotalPercent, -1);
			return;
		}
		CreateAffectedAllEnemyData(243, EDataModifyType.Add, -1);
		ShowSpecialEffectTips(0);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!base.CanAffect)
		{
			return 0;
		}
		if (!base.IsDirect && !base.IsCurrent)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((fieldId == 73 || fieldId == 243) ? true : false)
		{
			if (base.IsDirect)
			{
				ShowSpecialEffectTipsOnceInFrame(0);
			}
			return (dataKey.FieldId == 73) ? 50 : PoisonAffectThresholdValues[dataKey.CustomParam0];
		}
		return 0;
	}
}
