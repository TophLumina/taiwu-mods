using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class ChiXinWuGai : BossNeigongBase
{
	public ChiXinWuGai()
	{
	}

	public ChiXinWuGai(CombatSkillKey skillKey)
		: base(skillKey, 16113)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 116, EDataModifyType.Add, -1);
		AppendAffectedAllEnemyData(context, 116, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId && !DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar))
		{
			return 0;
		}
		CombatCharacter enemyChar = base.CurrEnemyChar;
		sbyte bodyPart = (sbyte)dataKey.CustomParam0;
		bool inner = dataKey.CustomParam1 == 1;
		if (dataKey.CharId == base.CharacterId)
		{
			return -enemyChar.GetInjuries().Get(bodyPart, inner);
		}
		return base.CombatChar.GetInjuries().Get(bodyPart, inner);
	}
}
