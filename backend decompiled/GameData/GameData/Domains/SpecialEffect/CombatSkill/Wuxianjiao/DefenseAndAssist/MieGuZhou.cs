using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.DefenseAndAssist;

public class MieGuZhou : DefenseSkillBase
{
	public MieGuZhou()
	{
	}

	public MieGuZhou(CombatSkillKey skillKey)
		: base(skillKey, 12703)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 180, -1), EDataModifyType.Custom);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
		ShowSpecialEffectTips(0);
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
		CombatCharacter srcChar = (base.IsDirect ? base.CombatChar : base.CurrEnemyChar);
		CombatCharacter dstChar = (base.IsDirect ? base.CurrEnemyChar : base.CombatChar);
		short removedWugTemplateId = srcChar.RandomExistWug(context.Random);
		if (removedWugTemplateId >= 0)
		{
			EatingItems srcEatingItems = srcChar.GetCharacter().GetEatingItems();
			int srcWugIndex = srcEatingItems.IndexOfWug(removedWugTemplateId);
			if (srcWugIndex >= 0)
			{
				short duration = srcEatingItems.GetDuration(srcWugIndex);
				srcChar.GetCharacter().RemoveWug(context, removedWugTemplateId);
				sbyte wugType = Config.Medicine.Instance[removedWugTemplateId].WugType;
				short wugTemplateId = ItemDomain.GetWugTemplateId(wugType, (sbyte)(base.IsDirect ? 2 : 0));
				dstChar.AddWug(context, wugTemplateId, base.CharacterId, EWugReplaceType.CombatOnly, duration);
				ShowSpecialEffectTips(1);
			}
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 180 && dataKey.CustomParam0 != base.CharacterId)
		{
			return false;
		}
		return dataValue;
	}
}
