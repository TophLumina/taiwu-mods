using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.BreakBodyEffect;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class QiShiErDiShaQuan : AddBreakBodyFeature
{
	public QiShiErDiShaQuan()
	{
	}

	public QiShiErDiShaQuan(CombatSkillKey skillKey)
		: base(skillKey, 15102)
	{
		AffectBodyParts = new sbyte[2] { 5, 6 };
	}
}
