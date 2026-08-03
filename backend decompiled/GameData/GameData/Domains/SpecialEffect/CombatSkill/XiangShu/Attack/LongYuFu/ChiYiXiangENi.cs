using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.LongYuFu;

public class ChiYiXiangENi : CombatSkillEffectBase
{
	private const sbyte RequireInjury = 4;

	public ChiYiXiangENi()
	{
	}

	public ChiYiXiangENi(CombatSkillKey skillKey)
		: base(skillKey, 17124, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 219, base.SkillTemplateId), EDataModifyType.Custom);
		for (int i = 0; i < enemyList.Length; i++)
		{
			if (enemyList[i] >= 0)
			{
				AffectDatas.Add(new AffectedDataKey(enemyList[i], 169, -1), EDataModifyType.Custom);
			}
		}
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		Injuries injuries = base.CombatChar.GetInjuries();
		if (injuries.Get(5, isInnerInjury: false) < 4 && injuries.Get(6, isInnerInjury: false) < 4)
		{
			return;
		}
		int enemyCharId = base.CurrEnemyChar.GetId();
		Dictionary<CombatSkillKey, SkillPowerChangeCollection> powerDict = DomainManager.Combat.GetAllSkillPowerAddInCombat();
		List<CombatSkillKey> srcSkillList = ObjectPool<List<CombatSkillKey>>.Instance.Get();
		srcSkillList.Clear();
		foreach (CombatSkillKey skillKey in powerDict.Keys)
		{
			if (skillKey.CharId == enemyCharId)
			{
				srcSkillList.Add(skillKey);
			}
		}
		if (srcSkillList.Count > 0)
		{
			for (int i = 0; i < srcSkillList.Count; i++)
			{
				CombatSkillKey srcKey = srcSkillList[i];
				SkillPowerChangeCollection powerAddCollection = DomainManager.Combat.RemoveSkillPowerAddInCombat(context, srcKey);
				if (powerAddCollection != null)
				{
					DomainManager.Combat.AddSkillPowerInCombat(context, SkillKey, new SkillEffectKey(base.SkillTemplateId, isDirect: true), powerAddCollection.GetTotalChangeValue());
				}
			}
			ShowSpecialEffectTips(0);
		}
		ObjectPool<List<CombatSkillKey>>.Instance.Return(srcSkillList);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			DomainManager.Combat.UpdateSkillCanUse(context, DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.FieldId == 219)
		{
			return true;
		}
		if (dataKey.FieldId == 169 && !dataValue && (dataKey.CustomParam0 == 5 || dataKey.CustomParam0 == 6) && (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId || base.CombatChar.GetPerformingSkillId() == base.SkillTemplateId))
		{
			return true;
		}
		return dataValue;
	}
}
