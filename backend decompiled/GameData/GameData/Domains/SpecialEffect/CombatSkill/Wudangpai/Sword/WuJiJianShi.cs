using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Sword;

public class WuJiJianShi : CombatSkillEffectBase
{
	private const sbyte AddPower = 40;

	private DataUid _tricksUid;

	private bool _affecting;

	private bool _attacking;

	public WuJiJianShi()
	{
	}

	public WuJiJianShi(CombatSkillKey skillKey)
		: base(skillKey, 4208, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_affecting = true;
		_attacking = false;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 208, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 145, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 146, base.SkillTemplateId), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 74, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 85, base.SkillTemplateId), EDataModifyType.Custom);
		Events.RegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.RegisterHandler_OverflowTrickRemoved(OnOverflowTrickRemoved);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (base.IsDirect)
		{
			_tricksUid = new DataUid(8, 10, (ulong)base.CharacterId, 28u);
			GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_tricksUid, base.DataHandlerKey, UpdateAffecting);
		}
		else
		{
			_tricksUid = new DataUid(0, 0, ulong.MaxValue);
			Events.RegisterHandler_CombatBegin(UpdateEnemyChar);
			Events.RegisterHandler_CombatCharChanged(OnCombatCharChanged);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_ChangeWeapon(OnChangeWeapon);
		Events.UnRegisterHandler_OverflowTrickRemoved(OnOverflowTrickRemoved);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		if (!base.IsDirect)
		{
			Events.UnRegisterHandler_CombatBegin(UpdateEnemyChar);
			Events.UnRegisterHandler_CombatCharChanged(OnCombatCharChanged);
		}
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_tricksUid, base.DataHandlerKey);
	}

	private void OnChangeWeapon(DataContext context, int charId, bool isAlly, CombatWeaponData newWeapon, CombatWeaponData oldWeapon)
	{
		if (isAlly == base.IsDirect)
		{
			UpdateAffecting(context, default(DataUid));
		}
	}

	private void OnOverflowTrickRemoved(DataContext context, int charId, bool isAlly, int removedCount)
	{
		if (isAlly == base.IsDirect)
		{
			UpdateAffecting(context, default(DataUid));
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_attacking = true;
			InvalidateCaches(context);
			if (_affecting)
			{
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			_attacking = false;
			InvalidateCaches(context);
		}
	}

	private void OnCombatCharChanged(DataContext context, bool isAlly)
	{
		if (isAlly != base.CombatChar.IsAlly)
		{
			UpdateEnemyChar(context);
		}
	}

	private void UpdateEnemyChar(DataContext context)
	{
		CombatCharacter currEnemy = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		if (_tricksUid.SubId0 != ulong.MaxValue)
		{
			GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_tricksUid, base.DataHandlerKey);
		}
		_tricksUid = new DataUid(8, 10, (ulong)currEnemy.GetId(), 28u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_tricksUid, base.DataHandlerKey, UpdateAffecting);
		UpdateAffecting(context, _tricksUid);
	}

	private void UpdateAffecting(DataContext context, DataUid dataUid)
	{
		CombatCharacter trickChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly));
		bool canAffect = !trickChar.AnyUsableTrick;
		if (_affecting != canAffect)
		{
			_affecting = canAffect;
			InvalidateCaches(context, updateTricks: true);
		}
	}

	private void InvalidateCaches(DataContext context, bool updateTricks = false)
	{
		if (updateTricks)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 208);
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
		}
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 145);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 146);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 74);
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 85);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_affecting || !_attacking)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return 40;
		}
		if (dataKey.FieldId == 145 || dataKey.FieldId == 146)
		{
			return 10000;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_affecting || !_attacking)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 85)
		{
			return false;
		}
		return dataValue;
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_affecting || !_attacking)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 74)
		{
			return -1;
		}
		return dataValue;
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId || !_affecting)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 208)
		{
			dataValue.Clear();
		}
		return dataValue;
	}
}
