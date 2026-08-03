using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class YiZhiYiPinHong : TrickBuffFlaw
{
	public YiZhiYiPinHong()
	{
	}

	public YiZhiYiPinHong(CombatSkillKey skillKey)
		: base(skillKey, 3102)
	{
		RequireTrickType = 7;
	}

	protected override bool OnReverseAffect(DataContext context, int trickCount)
	{
		int affectCount = trickCount / 2;
		int upgradeCount = 0;
		for (int i = 0; i < affectCount; i++)
		{
			upgradeCount += base.CurrEnemyChar.UpgradeRandomFlawOrAcupoint(context, isFlaw: true, 1, -1);
		}
		return upgradeCount > 0;
	}
}
