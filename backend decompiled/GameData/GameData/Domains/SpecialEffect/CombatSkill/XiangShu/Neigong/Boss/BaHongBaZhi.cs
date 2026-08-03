using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class BaHongBaZhi : BossNeigongBase
{
	private const sbyte AddDamage = 120;

	private const sbyte ReduceDamage = -60;

	public BaHongBaZhi()
	{
	}

	public BaHongBaZhi(CombatSkillKey skillKey)
		: base(skillKey, 16107)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.TotalPercent, -1);
		AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		return (dataKey.FieldId == 69) ? 120 : (-60);
	}
}
