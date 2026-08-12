using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class JinShangYuDingQuan : ChangePoisonLevel
{
	private const sbyte ReduceSkillPrepareSpeedPercent = 50;

	protected override sbyte AffectPoisonType => 2;

	public JinShangYuDingQuan()
	{
	}

	public JinShangYuDingQuan(CombatSkillKey skillKey)
		: base(skillKey, 8104)
	{
	}

	protected override void OnAffecting(DataContext context)
	{
		int charId = AffectingSkillKey.CharId;
		ShowSpecialEffectTips(1);
		if (!AffectDatas.ContainsKey(new AffectedDataKey(charId, 194, -1)))
		{
			AppendAffectedData(context, charId, 194, EDataModifyType.TotalPercent, -1);
		}
		else
		{
			DomainManager.SpecialEffect.InvalidateCache(context, charId, 194);
		}
	}

	protected override int AffectingGetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 194)
		{
			if (base.IsDirect && dataKey.CharId == base.CharacterId)
			{
				return 50;
			}
			if (!base.IsDirect && dataKey.CharId == base.CurrEnemyChar.GetId())
			{
				return -50;
			}
		}
		return 0;
	}
}
