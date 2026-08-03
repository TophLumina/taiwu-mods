using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class XiangMoGuangMingQuan : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 40;

	private const sbyte AddRangeUnit = 10;

	private const sbyte ChangeMorality = 125;

	private int _addPower;

	private int _addRange;

	public XiangMoGuangMingQuan()
	{
	}

	public XiangMoGuangMingQuan(CombatSkillKey skillKey)
		: base(skillKey, 1107, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		sbyte targetType = (sbyte)(base.IsDirect ? 1 : 3);
		sbyte enemyType = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly).GetCharacter().GetBehaviorType();
		_addPower = 40 * Math.Abs(targetType - enemyType);
		_addRange = 10 * Math.Abs(targetType - enemyType);
		if (_addPower > 0)
		{
			AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, base.SkillTemplateId), EDataModifyType.Add);
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, base.SkillTemplateId), EDataModifyType.Add);
			ShowSpecialEffectTips(0);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		sbyte targetType = (sbyte)(base.IsDirect ? 1 : 3);
		CombatCharacter enemyCombatChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		GameData.Domains.Character.Character enemyChar = enemyCombatChar.GetCharacter();
		HitOrAvoidInts selfHits = CharObj.GetHitValues();
		HitOrAvoidInts enemyAvoids = enemyChar.GetAvoidValues();
		sbyte enemyType = enemyChar.GetBehaviorType();
		if (PowerMatchAffectRequire(power) && selfHits.Items[3] > enemyAvoids.Items[3] && targetType != enemyType)
		{
			enemyChar.ChangeBaseMorality(context, (enemyType > targetType) ? 125 : (-125));
			ShowSpecialEffectTips(1);
			if (enemyChar.GetBehaviorType() == targetType && enemyCombatChar.AiController.CanFlee())
			{
				enemyCombatChar.SetNeedUseOtherAction(context, 2);
				AppendAffectedData(context, enemyCombatChar.GetId(), 124, EDataModifyType.AddPercent, -1);
			}
			else
			{
				RemoveSelf(context);
			}
		}
		else
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 124)
		{
			RemoveSelf(DomainManager.Combat.Context);
			return -67;
		}
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return _addRange;
		}
		return 0;
	}
}
