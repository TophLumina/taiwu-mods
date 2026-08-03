using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class QingGuoJueShi : BossNeigongBase
{
	private const sbyte DamageMultiplier = 3;

	public QingGuoJueShi()
	{
	}

	public QingGuoJueShi(CombatSkillKey skillKey)
		: base(skillKey, 16104)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 85, EDataModifyType.Custom, -1);
		AppendAffectedData(context, base.CharacterId, 89, EDataModifyType.Custom, -1);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || base.CombatChar.UsableTrickCount <= base.EnemyChar.UsableTrickCount)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 85)
		{
			return false;
		}
		return dataValue;
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || damageType != EDamageType.Direct || base.CombatChar.UsableTrickCount <= base.EnemyChar.UsableTrickCount)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 89)
		{
			return dataValue * 3;
		}
		return dataValue;
	}
}
