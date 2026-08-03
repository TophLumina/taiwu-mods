using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class ZheTianBiRiGong : DefenseSkillBase
{
	private const short AddDamageUnit = 160;

	private DataUid _defendSkillUid;

	public ZheTianBiRiGong()
	{
	}

	public ZheTianBiRiGong(CombatSkillKey skillKey)
		: base(skillKey, 14507)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_defendSkillUid = new DataUid(8, 10, (ulong)base.CharacterId, 63u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defendSkillUid, base.DataHandlerKey, OnDefendSkillChanged);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defendSkillUid, base.DataHandlerKey);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
	}

	private void OnDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		if (base.CombatChar.GetAffectingDefendSkillId() == base.SkillTemplateId)
		{
			AppendAffectedAllEnemyData(context, 89, EDataModifyType.Custom, -1);
			AppendAffectedAllEnemyData(context, 270, EDataModifyType.Custom, -1);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, !base.CombatChar.IsAlly, -1);
		}
		else
		{
			ClearAffectedData(context);
			DomainManager.Combat.UpdateAllTeammateCommandUsable(context, !base.CombatChar.IsAlly, -1);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!isAlly);
			if (enemyChar.TeammateBeforeMainChar >= 0 || enemyChar.TeammateAfterMainChar >= 0 || !DomainManager.Combat.IsMainCharacter(enemyChar))
			{
				DomainManager.Combat.ForceAllTeammateLeaveCombatField(context, !isAlly);
				ShowSpecialEffectTips(0);
			}
		}
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Bounce || dataKey.CustomParam1 != ((!base.IsDirect) ? 1 : 0) || !base.CanAffect)
		{
			return dataValue;
		}
		List<int> enemyList = ObjectPool<List<int>>.Instance.Get();
		enemyList.Clear();
		enemyList.AddRange(DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly));
		enemyList.RemoveAll((int id) => id < 0);
		DataContext context = DomainManager.Combat.Context;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		int damagePercent = 100 + 160 * (enemyList.Count - 1);
		int damageValue = (int)(dataValue / enemyList.Count * damagePercent / 100);
		for (int i = 1; i < enemyList.Count; i++)
		{
			CombatCharacter enemyChar = DomainManager.Combat.GetElement_CombatCharacterDict(enemyList[i]);
			DomainManager.Combat.AddInjuryDamageValue(base.CombatChar, enemyChar, bodyPart, base.IsDirect ? damageValue : 0, (!base.IsDirect) ? damageValue : 0, base.SkillTemplateId);
		}
		ObjectPool<List<int>>.Instance.Return(enemyList);
		ShowSpecialEffectTips(1);
		return damageValue;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId || !base.CanAffect || dataKey.FieldId != 270)
		{
			return dataValue;
		}
		return false;
	}
}
