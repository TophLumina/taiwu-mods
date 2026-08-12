using System;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Sword;

public class PuDuJianFa : CombatSkillEffectBase
{
	private const sbyte ChangeInfection = 50;

	public PuDuJianFa()
	{
	}

	public PuDuJianFa(CombatSkillKey skillKey)
		: base(skillKey, 5201, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker == base.CombatChar && skillId == base.SkillTemplateId)
		{
			IsSrcSkillPrepared = true;
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		if (IsSrcSkillPrepared && base.CombatChar.IsAlly && combatStatus == 3 && DomainManager.Combat.GetCombatType() == 2)
		{
			GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetMainCharacter(!base.CombatChar.IsAlly).GetCharacter();
			if (enemyChar.GetFeatureIds().Contains(210))
			{
				int infection = enemyChar.GetXiangshuInfection();
				int deltaValue = (base.IsDirect ? Math.Max(-50, 100 - infection) : Math.Min(50, 200 - infection - 1));
				ItemKey ropeKey = DomainManager.Item.CreateItem(context, 12, 82);
				base.CombatChar.GetCharacter().AddInventoryItem(context, ropeKey, 1);
				enemyChar.ChangeXiangshuInfection(context, deltaValue);
				DomainManager.Combat.AppendGetChar(enemyChar.GetId());
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("CombatOver", "CharIdSeizedInCombat", enemyChar.GetId());
				DomainManager.TaiwuEvent.SetListenerEventActionISerializableArg("CombatOver", "ItemKeySeizeCharacterInCombat", ropeKey);
				DomainManager.TaiwuEvent.SetListenerEventActionIntArg("CombatOver", "UseItemKeySeizeCharacterId", base.CombatChar.GetId());
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(!base.CombatChar.IsAlly);
			if (!DomainManager.Combat.IsCharacterFallen(enemyChar))
			{
				RemoveSelf(context);
			}
		}
	}
}
