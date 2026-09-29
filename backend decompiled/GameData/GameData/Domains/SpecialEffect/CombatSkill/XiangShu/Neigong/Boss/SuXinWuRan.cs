using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class SuXinWuRan : BossNeigongBase
{
	private const sbyte AddPowerUnit = 20;

	private readonly List<DataUid> _enemyMarkUids = new List<DataUid>();

	public SuXinWuRan()
	{
	}

	public SuXinWuRan(CombatSkillKey skillKey)
		: base(skillKey, 16112)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(327, EDataModifyType.Custom, -1);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		foreach (DataUid dataUid in _enemyMarkUids)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(dataUid, base.DataHandlerKey);
		}
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		int[] enemyList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		foreach (int enemyCharId in enemyList)
		{
			if (enemyCharId >= 0)
			{
				DataUid markUid = ParseCombatCharacterDataUid(enemyCharId, 50);
				_enemyMarkUids.Add(markUid);
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(markUid, base.DataHandlerKey, OnMarkChanged);
			}
		}
		AppendAffectedAllEnemyData(context, 199, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && power >= 100 && Config.CombatSkill.Instance[skillId].EquipType == 1)
		{
			if (base.CurrEnemyChar.GetDefeatMarkCollection().DieMarkList.Count == SharedConstValue.DefeatNeedDieMarkCount - 1 && !base.CurrEnemyChar.CheckImmunityAndShowEffect(EMarkType.Health))
			{
				base.CurrEnemyChar.GetCharacter().SetHealth(0, context);
			}
			base.CurrEnemyChar.AddDieMark(context, SkillKey, 1);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnMarkChanged(DataContext context, DataUid dataUid)
	{
		DomainManager.SpecialEffect.InvalidateCache(context, (int)dataUid.SubId0, 199);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 199)
		{
			DefeatMarkCollection markCollection = DomainManager.Combat.GetElement_CombatCharacterDict(dataKey.CharId).GetDefeatMarkCollection();
			int dieMarkCount = 0;
			for (int i = 0; i < markCollection.DieMarkList.Count; i++)
			{
				if (markCollection.DieMarkList[i].Equals(SkillKey))
				{
					dieMarkCount++;
				}
			}
			return 20 * dieMarkCount;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 327)
		{
			return true;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
