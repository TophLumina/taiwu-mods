using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class FeiJianShu : AttackBodyPart
{
	private const int ReducePowerValue = -20;

	public FeiJianShu()
	{
	}

	public FeiJianShu(CombatSkillKey skillKey)
		: base(skillKey, 7202)
	{
		BodyParts = new sbyte[1] { 2 };
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		int enemyCharId = enemyChar.GetId();
		List<short> skillList = enemyChar.GetAttackSkillList();
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		List<short> pool = ObjectPool<List<short>>.Instance.Get();
		pool.Clear();
		pool.AddRange(skillList.Where((short x) => x >= 0 && DomainManager.Combat.GetReduceSkillPowerInCombat(new CombatSkillKey(enemyCharId, x), effectKey) == 0));
		short skillId = (short)((pool.Count > 0) ? pool.GetRandom(context.Random) : (-1));
		ObjectPool<List<short>>.Instance.Return(pool);
		if (skillId >= 0)
		{
			DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(enemyCharId, skillId), effectKey, -20);
			ShowSpecialEffectTips(1);
		}
	}
}
