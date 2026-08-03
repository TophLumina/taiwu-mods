using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class XueHouMoZhang : PoisonAddInjury
{
	private const int CastAddFatalDamageUnit = 33;

	private int _castMakeDamage;

	public XueHouMoZhang()
	{
	}

	public XueHouMoZhang(CombatSkillKey skillKey)
		: base(skillKey, 15107)
	{
		RequirePoisonType = 3;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (SkillKey.IsMatch(attackerId, combatSkillId))
		{
			_castMakeDamage += damageValue;
		}
	}

	protected override void OnCastMaxPower(DataContext context)
	{
		CombatCharacter enemyChar = base.CurrEnemyChar;
		CombatCharacter checkChar = (base.IsDirect ? enemyChar : base.CombatChar);
		byte poisonMarkCount = checkChar.GetDefeatMarkCollection().PoisonMarkList[RequirePoisonType];
		if (poisonMarkCount > 0)
		{
			CValuePercent fatalDamagePercent = 33 * poisonMarkCount;
			enemyChar.AddFatalDamage(context, _castMakeDamage * fatalDamagePercent, -1, -1, -1);
			for (int i = 0; i < poisonMarkCount; i++)
			{
				Injuries injuries = enemyChar.GetInjuries();
				bool isInner = !injuries.AllPartsFully(isInnerInjury: true) && (injuries.AllPartsFully(isInnerInjury: false) || context.Random.CheckPercentProb(50));
				AddPowerDamageInjury(context, enemyChar, isInner, poisonMarkCount);
			}
		}
		ShowSpecialEffectTips(1);
	}
}
