using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class XieZiGouHunJiao : CombatSkillEffectBase
{
	private const sbyte AddPower = 20;

	private const sbyte StatePowerUnit = 20;

	public XieZiGouHunJiao()
	{
	}

	public XieZiGouHunJiao(CombatSkillKey skillKey)
		: base(skillKey, 15303, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetCharacter();
		if (base.IsDirect ? (CharObj.GetMoveSpeed() > enemyChar.GetMoveSpeed()) : (CharObj.GetAttackSpeed() > enemyChar.GetAttackSpeed()))
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (power > 0)
			{
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 73 : 74), 20 * power / 10);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 20;
		}
		return 0;
	}
}
