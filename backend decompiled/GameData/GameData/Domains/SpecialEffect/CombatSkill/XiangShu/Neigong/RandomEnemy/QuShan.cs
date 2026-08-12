using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class QuShan : MinionBase
{
	private const sbyte RequireMarkPerDistance = 3;

	private DataUid _enemyMarkUid;

	private int _addAttackDistance;

	public QuShan()
	{
	}

	public QuShan(CombatSkillKey skillKey)
		: base(skillKey, 16001)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, -1), EDataModifyType.Add);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyMarkUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateEnemyDataUid(context);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyMarkUid, base.DataHandlerKey);
			UpdateEnemyDataUid(context);
		}
	}

	private void UpdateEnemyDataUid(DataContext context)
	{
		_enemyMarkUid = ParseCombatCharacterDataUid(base.EnemyChar.GetId(), 50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyMarkUid, base.DataHandlerKey, UpdateAddDistance);
		UpdateAddDistance(context, default(DataUid));
	}

	private void UpdateAddDistance(DataContext context, DataUid dataUid)
	{
		int markCount = base.EnemyChar.GetDefeatMarkCollection().GetTotalCount();
		_addAttackDistance = markCount / 3 * 10;
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !MinionBase.CanAffect)
		{
			return 0;
		}
		return _addAttackDistance;
	}
}
