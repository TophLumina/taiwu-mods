using System.Collections.Generic;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.DefenseAndAssist;

public class XinWoLiangMieZhou : AssistSkillBase
{
	private const sbyte ChangeNeiliAllocationPercent = 60;

	private const sbyte AffectedDefeatMarkThreshold = 50;

	private readonly List<DataUid> _teammateDefeatMarkUid = new List<DataUid>();

	private readonly List<int> _ignoreTeammateCharIds = new List<int>();

	public XinWoLiangMieZhou()
	{
	}

	public XinWoLiangMieZhou(CombatSkillKey skillKey)
		: base(skillKey, 15805)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		foreach (DataUid uid in _teammateDefeatMarkUid)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(uid, base.DataHandlerKey);
		}
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (!DomainManager.Combat.IsMainCharacter(base.CombatChar))
		{
			return;
		}
		int[] teamCharIds = DomainManager.Combat.GetCharacterList(base.CombatChar.IsAlly);
		int[] array = teamCharIds;
		foreach (int teamCharId in array)
		{
			if (teamCharId != base.CharacterId && teamCharId >= 0 && DomainManager.Combat.TryGetElement_CombatCharacterDict(teamCharId, out var teamCombatChar))
			{
				DataUid uid = new DataUid(8, 10, (ulong)teamCharId, 50u);
				GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(uid, base.DataHandlerKey, OnDefeatMarkChanged);
				_teammateDefeatMarkUid.Add(uid);
				if (TeammateReachAffectedMarkCount(teamCombatChar))
				{
					_ignoreTeammateCharIds.Add(teamCharId);
				}
			}
		}
	}

	private unsafe void OnDefeatMarkChanged(DataContext context, DataUid dataUid)
	{
		int teammateCharId = (int)dataUid.SubId0;
		if (!DomainManager.Combat.TryGetElement_CombatCharacterDict(teammateCharId, out var combatChar) || combatChar.IsAlly != base.CombatChar.IsAlly || combatChar == base.CombatChar || !base.CanAffect)
		{
			return;
		}
		if (!TeammateReachAffectedMarkCount(combatChar))
		{
			_ignoreTeammateCharIds.Remove(teammateCharId);
		}
		else
		{
			if (_ignoreTeammateCharIds.Contains(teammateCharId))
			{
				return;
			}
			_ignoreTeammateCharIds.Add(teammateCharId);
			NeiliAllocation neiliAllocation = combatChar.GetNeiliAllocation();
			CombatCharacter affectChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
			for (byte type = 0; type < 4; type++)
			{
				int changeValue = neiliAllocation.Items[(int)type] * 60 / 100;
				if (changeValue > 0)
				{
					affectChar.ChangeNeiliAllocation(context, type, changeValue * (base.IsDirect ? 1 : (-1)));
				}
			}
			ShowEffectTips(context);
			ShowSpecialEffectTips(0);
		}
	}

	private bool TeammateReachAffectedMarkCount(CombatCharacter combatChar)
	{
		return combatChar.GetDefeatMarkCollection().GetTotalCount() >= GlobalConfig.NeedDefeatMarkCount[DomainManager.Combat.GetCombatType()] * 50 / 100;
	}
}
