using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class ZhongXiangSheng : MinionBase
{
	private const sbyte ReducePercent = -80;

	private static readonly Dictionary<sbyte, ushort[]> BehaviorType2FieldIds = new Dictionary<sbyte, ushort[]>
	{
		[0] = new ushort[2] { 9, 10 },
		[1] = new ushort[2] { 13, 14 },
		[2] = new ushort[2] { 8, 7 },
		[3] = new ushort[2] { 16, 15 },
		[4] = new ushort[2] { 11, 12 }
	};

	private static readonly Dictionary<sbyte, sbyte> BehaviorSpecifyParam = new Dictionary<sbyte, sbyte> { { 2, -50 } };

	private bool _isCurrCombatChar;

	private DataUid _moralityUid;

	private sbyte _activatedEffectParam;

	public ZhongXiangSheng()
	{
	}

	public ZhongXiangSheng(CombatSkillKey skillKey)
		: base(skillKey, 16006)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_moralityUid, base.DataHandlerKey);
	}

	private void OnCombatBegin(DataContext context)
	{
		_isCurrCombatChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
		UpdateEnemyDataUid(context);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly == base.CombatChar.IsAlly)
		{
			bool isCurrChar = DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar);
			if (_isCurrCombatChar != isCurrChar)
			{
				_isCurrCombatChar = isCurrChar;
				InvalidateAffectDataCache(context);
			}
		}
		else if (base.IsDirect)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_moralityUid, base.DataHandlerKey);
			UpdateEnemyDataUid(context);
		}
	}

	private void UpdateAffected(DataContext context, DataUid dataUid)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		int enemyCharId = enemyChar.GetId();
		sbyte behaviorType = enemyChar.GetCharacter().GetBehaviorType();
		_activatedEffectParam = (sbyte)(BehaviorSpecifyParam.TryGetValue(behaviorType, out var specifyParam) ? specifyParam : (-80));
		ushort[] fieldIds = BehaviorType2FieldIds[behaviorType];
		ClearAffectedData(context);
		for (int i = 0; i < fieldIds.Length; i++)
		{
			AppendAffectedData(context, enemyCharId, fieldIds[i], EDataModifyType.TotalPercent, -1);
		}
	}

	private void UpdateEnemyDataUid(DataContext context)
	{
		_moralityUid = ParseCharDataUid(base.EnemyChar.GetId(), 77);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_moralityUid, base.DataHandlerKey, UpdateAffected);
		UpdateAffected(context, default(DataUid));
	}

	private void InvalidateAffectDataCache(DataContext context)
	{
		foreach (AffectedDataKey key in AffectDatas.Keys)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, key.CharId, key.FieldId);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_isCurrCombatChar || !MinionBase.CanAffect)
		{
			return 0;
		}
		return _activatedEffectParam;
	}
}
