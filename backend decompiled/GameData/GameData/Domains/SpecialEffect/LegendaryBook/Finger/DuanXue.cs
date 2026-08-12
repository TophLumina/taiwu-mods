using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.EquipmentEffect;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Finger;

public class DuanXue : EquipmentEffectBase
{
	private const int SilenceOdds = 50;

	private const short SilenceFrame = 240;

	public DuanXue()
	{
	}

	public DuanXue(int charId, ItemKey itemKey)
		: base(charId, itemKey, 40400, autoRemoveAfterCombat: false)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && attacker == base.CombatChar && IsCurrWeapon() && pursueIndex == 4 && context.Random.CheckPercentProb(50))
		{
			CombatCharacter enemyChar = base.CurrEnemyChar;
			short skillId = enemyChar.GetRandomBanableSkillId(context.Random, null, -1);
			if (skillId >= 0)
			{
				DomainManager.Combat.SilenceSkill(context, enemyChar, skillId, 240);
			}
		}
	}
}
