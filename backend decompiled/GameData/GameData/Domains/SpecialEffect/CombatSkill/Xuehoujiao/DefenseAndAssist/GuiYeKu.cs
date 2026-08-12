using System.Linq;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class GuiYeKu : DefenseSkillBase
{
	private readonly sbyte[] _requirePersonalities = new sbyte[5] { 0, 1, 2, 3, 4 };

	private const sbyte AffectOddsDirect = 50;

	private const sbyte AffectOddsReverse = 20;

	public GuiYeKu()
	{
	}

	public GuiYeKu(CombatSkillKey skillKey)
		: base(skillKey, 15702)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (!isFightBack || !hit || attacker != base.CombatChar || !base.CanAffect)
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		Personalities selfPersonalities = CharObj.GetPersonalities();
		Personalities enemyPersonalities = enemyChar.GetCharacter().GetPersonalities();
		int count = _requirePersonalities.Count((sbyte type) => selfPersonalities[type] > enemyPersonalities[type] && context.Random.CheckPercentProb(base.IsDirect ? 50 : 20));
		if (count > 0)
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.AddTrick(context, enemyChar, 20, count, addedByAlly: false);
			}
			else
			{
				AddPowerDamageMind(context, enemyChar, count);
			}
			ShowSpecialEffectTips(0);
		}
	}
}
