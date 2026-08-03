using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Sword;

public class ShiErLuYuChangCiJian : SwordUnlockEffectBase
{
	private const int EffectAddCastProgress = 40;

	private int SelfAddCastProgress => base.IsDirectOrReverseEffectDoubling ? 80 : 40;

	protected override IEnumerable<sbyte> RequirePersonalityTypes
	{
		get
		{
			yield return 3;
		}
	}

	protected override int RequirePersonalityValue => 50;

	public ShiErLuYuChangCiJian()
	{
	}

	public ShiErLuYuChangCiJian(CombatSkillKey skillKey)
		: base(skillKey, 9100)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		base.OnDisable(context);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && CombatSkillEquipType.IsAttack(skillId))
		{
			CValuePercent percent = 0;
			if (skillId == base.SkillTemplateId && base.IsReverseOrUsingDirectWeapon)
			{
				percent += (CValuePercent)SelfAddCastProgress;
			}
			if (base.EffectCount > 0)
			{
				ReduceEffectCount();
				percent += (CValuePercent)40;
			}
			if (!(percent <= 0))
			{
				DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * percent);
				ShowSpecialEffectTips(base.IsDirect, 1, 0);
			}
		}
	}
}
