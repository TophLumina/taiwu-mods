using System.Collections.Generic;
using System.Linq;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class BaiMeiJianFa : AttackBodyPart
{
	private const int ReducePowerValue = -20;

	public BaiMeiJianFa()
	{
	}

	public BaiMeiJianFa(CombatSkillKey skillKey)
		: base(skillKey, 2302)
	{
		BodyParts = new sbyte[1] { 2 };
		ReverseAddDamagePercent = 30;
	}

	protected override void OnCastAffectPower(DataContext context)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		int enemyCharId = enemyChar.GetId();
		List<short> enemyCharAgileSkillList = enemyChar.GetAgileSkillList();
		SkillEffectKey effectKey = new SkillEffectKey(base.SkillTemplateId, base.IsDirect);
		List<short> agileSkillRandomPool = ObjectPool<List<short>>.Instance.Get();
		agileSkillRandomPool.Clear();
		agileSkillRandomPool.AddRange(enemyCharAgileSkillList.Where((short x) => x >= 0 && DomainManager.Combat.GetReduceSkillPowerInCombat(new CombatSkillKey(enemyCharId, x), effectKey) == 0));
		short agileSkillId = (short)((agileSkillRandomPool.Count > 0) ? agileSkillRandomPool.GetRandom(context.Random) : (-1));
		ObjectPool<List<short>>.Instance.Return(agileSkillRandomPool);
		if (agileSkillId >= 0)
		{
			DomainManager.Combat.ReduceSkillPowerInCombat(context, new CombatSkillKey(enemyCharId, agileSkillId), effectKey, -20);
			ShowSpecialEffectTips(1);
		}
	}
}
