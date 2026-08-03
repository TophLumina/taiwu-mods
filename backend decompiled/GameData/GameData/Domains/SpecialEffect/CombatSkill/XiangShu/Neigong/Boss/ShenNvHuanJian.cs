using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ShenNvHuanJian : BossNeigongBase
{
	private static readonly sbyte[] AddPursueOdds = new sbyte[5] { 80, 60, 40, 20, 20 };

	private const int AddDamagePercent = 200;

	public ShenNvHuanJian()
	{
	}

	public ShenNvHuanJian(CombatSkillKey skillKey)
		: base(skillKey, 16100)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 76, EDataModifyType.Add, -1);
		AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 76)
		{
			return AddPursueOdds[dataKey.CustomParam0];
		}
		if (dataKey.FieldId == 69 && base.CombatChar.PursueAttackCount > 0)
		{
			return 200;
		}
		return 0;
	}
}
