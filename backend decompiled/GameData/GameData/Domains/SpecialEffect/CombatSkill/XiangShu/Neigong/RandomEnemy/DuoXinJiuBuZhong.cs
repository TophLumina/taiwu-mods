using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class DuoXinJiuBuZhong : MinionBase
{
	private const short EffectRequireFrame = 300;

	private const sbyte PoisonBaseValue = 50;

	private const sbyte PoisonLevel = 2;

	private static readonly Dictionary<sbyte, sbyte> PoisonTypeDict = new Dictionary<sbyte, sbyte>
	{
		[0] = 3,
		[1] = 0,
		[2] = 4,
		[3] = 2,
		[4] = 1,
		[5] = 5
	};

	public DuoXinJiuBuZhong()
	{
	}

	public DuoXinJiuBuZhong(CombatSkillKey skillKey)
		: base(skillKey, 16005)
	{
	}

	public override bool IsOn(int counterType)
	{
		return MinionBase.CanAffect;
	}

	protected override IEnumerable<int> CalcFrameCounterPeriods()
	{
		yield return 300;
	}

	public override void OnProcess(DataContext context, int counterType)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		NeiliProportionOfFiveElements neiliProportion = enemyChar.GetCharacter().GetNeiliProportionOfFiveElements();
		sbyte fiveElementsType = (sbyte)NeiliType.Instance[enemyChar.GetNeiliType()].FiveElements;
		int poisonValue = ((fiveElementsType != 5) ? (50 * neiliProportion[fiveElementsType] / 100) : 50);
		DomainManager.Combat.AddPoison(context, base.CombatChar, enemyChar, PoisonTypeDict[fiveElementsType], 2, poisonValue, -1);
	}
}
