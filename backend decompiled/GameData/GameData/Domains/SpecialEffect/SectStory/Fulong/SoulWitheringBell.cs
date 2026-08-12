using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.SectStory.Fulong;

public class SoulWitheringBell : CombatStateEffectBase
{
	private static readonly List<ushort> AllFieldIds = new List<ushort> { 8, 7, 9, 14, 11, 13, 10, 12, 16, 15 };

	private static readonly CValuePercent MinorAttributePercent = 50;

	private DataUid _dataUid;

	private bool _transferred;

	protected override short CombatStateId => 241;

	public SoulWitheringBell(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		foreach (ushort fieldId in AllFieldIds)
		{
			CreateAffectedData(fieldId, EDataModifyType.Custom, -1);
		}
		_dataUid = ParseCombatCharacterDataUid(base.EnemyChar.GetId(), 50);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_dataUid, base.DataHandlerKey, OnDefeatMarkChanged);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_dataUid, base.DataHandlerKey);
		base.OnDisable(context);
	}

	private void OnDefeatMarkChanged(DataContext context, DataUid arg2)
	{
		CombatCharacter enemyChar = DomainManager.Combat.GetMainCharacter(!base.CombatChar.IsAlly);
		if (_transferred || !DomainManager.Combat.IsCharacterHalfFallen(enemyChar))
		{
			return;
		}
		_transferred = true;
		DomainManager.Combat.RemoveCombatState(context, base.CombatChar, 0, CombatStateId);
		DomainManager.Combat.AddCombatState(context, enemyChar, 0, 242, 100, reverse: false, applyEffect: true, base.CharacterId);
		DomainManager.Combat.ShowSpecialEffectTips(base.CharacterId, 1717, 0);
		foreach (ushort fieldId in AllFieldIds)
		{
			AppendAffectedData(context, enemyChar.GetId(), fieldId, EDataModifyType.Custom, -1);
			RemoveAffectedData(context, base.CharacterId, fieldId);
		}
		DomainManager.TaiwuEvent.OnEvent_SoulWitheringBellTransfer();
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (!AllFieldIds.Contains(dataKey.FieldId))
		{
			return dataValue;
		}
		if (_transferred ? (dataKey.CharId == base.CharacterId) : (dataKey.CharId != base.CharacterId))
		{
			return dataValue;
		}
		return dataValue * MinorAttributePercent;
	}
}
