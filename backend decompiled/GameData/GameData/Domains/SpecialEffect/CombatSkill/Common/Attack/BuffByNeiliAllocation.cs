using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class BuffByNeiliAllocation : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private const sbyte ChangeNeiliAllocation = 12;

	protected byte RequireNeiliAllocationType;

	private DataUid _selfNeiliAllocationUid;

	private DataUid _enemyNeiliAllocationUid;

	private bool _inited;

	protected virtual bool ShowTipsOnAffecting => true;

	protected bool Affecting { get; private set; }

	protected BuffByNeiliAllocation()
	{
	}

	protected BuffByNeiliAllocation(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		_inited = false;
		_selfNeiliAllocationUid = ParseNeiliAllocationDataUid();
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey, UpdateAffecting);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_selfNeiliAllocationUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private unsafe void UpdateAffecting(DataContext context, DataUid dataUid)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		NeiliAllocation selfNeiliAllocation = base.CombatChar.GetNeiliAllocation();
		NeiliAllocation selfOrigNeiliAllocation = base.CombatChar.GetOriginNeiliAllocation();
		NeiliAllocation enemyNeiliAllocation = currEnemy.GetNeiliAllocation();
		bool canAffect = ((!base.IsDirect) ? (selfNeiliAllocation.Items[(int)RequireNeiliAllocationType] < selfOrigNeiliAllocation.Items[(int)RequireNeiliAllocationType] && selfNeiliAllocation.Items[(int)RequireNeiliAllocationType] < enemyNeiliAllocation.Items[(int)RequireNeiliAllocationType]) : (selfNeiliAllocation.Items[(int)RequireNeiliAllocationType] > selfOrigNeiliAllocation.Items[(int)RequireNeiliAllocationType] && selfNeiliAllocation.Items[(int)RequireNeiliAllocationType] > enemyNeiliAllocation.Items[(int)RequireNeiliAllocationType]));
		if (Affecting != canAffect)
		{
			Affecting = canAffect;
			if (_inited)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
				OnInvalidCache(context);
			}
			if (Affecting && ShowTipsOnAffecting)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCombatBegin(DataContext context)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		_enemyNeiliAllocationUid = ParseNeiliAllocationDataUid(currEnemy.GetId());
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey, UpdateAffecting);
		_inited = true;
		UpdateAffecting(context, _enemyNeiliAllocationUid);
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey);
			_enemyNeiliAllocationUid = ParseNeiliAllocationDataUid(currEnemy.GetId());
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_enemyNeiliAllocationUid, base.DataHandlerKey, UpdateAffecting);
			UpdateAffecting(context, _enemyNeiliAllocationUid);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && Affecting)
		{
			base.CombatChar.ChangeNeiliAllocation(context, RequireNeiliAllocationType, base.IsDirect ? (-12) : 12);
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!Affecting)
		{
			return 0;
		}
		if (dataKey.FieldId == 199 && dataKey.CharId == base.CharacterId && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return 40;
		}
		return GetAffectedModifyValue(dataKey);
	}

	protected virtual void OnInvalidCache(DataContext context)
	{
	}

	protected virtual int GetAffectedModifyValue(AffectedDataKey dataKey)
	{
		return 0;
	}
}
