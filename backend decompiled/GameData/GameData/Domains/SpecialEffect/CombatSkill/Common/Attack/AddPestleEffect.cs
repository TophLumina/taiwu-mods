using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class AddPestleEffect : CombatSkillEffectBase
{
	protected string PestleEffectName;

	protected AddPestleEffect()
	{
	}

	protected AddPestleEffect(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			ItemKey weaponKey = DomainManager.Combat.GetUsingWeaponKey(base.CombatChar);
			if (ItemTemplateHelper.GetItemSubType(weaponKey.ItemType, weaponKey.TemplateId) == 5)
			{
				CombatWeaponData weaponData = DomainManager.Combat.GetElement_WeaponDataDict(weaponKey.Id);
				weaponData.SetPestleEffect(context, base.CharacterId, PestleEffectName, new SkillEffectKey(base.SkillTemplateId, base.IsDirect));
				ShowSpecialEffectTips(0);
			}
		}
		RemoveSelf(context);
	}
}
