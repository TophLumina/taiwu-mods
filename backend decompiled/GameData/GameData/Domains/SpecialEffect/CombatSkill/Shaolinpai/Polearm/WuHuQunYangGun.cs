using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Polearm;

public class WuHuQunYangGun : CombatSkillEffectBase
{
	private const sbyte PrepareProgressPercent = 50;

	private DataUid _defendSkillUid;

	public WuHuQunYangGun()
	{
	}

	public WuHuQunYangGun(CombatSkillKey skillKey)
		: base(skillKey, 1304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 223, base.SkillTemplateId), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, (ushort)(base.IsDirect ? 206 : 205), base.SkillTemplateId), EDataModifyType.TotalPercent);
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
		DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 206 : 205));
		if (base.CombatChar.GetAffectingDefendSkillId() >= 0)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && base.CombatChar.GetAffectingDefendSkillId() >= 0)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * 50 / 100);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 206 || dataKey.FieldId == 205)
		{
			return (base.CombatChar.GetAffectingDefendSkillId() >= 0) ? (-100) : 0;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 223)
		{
			return true;
		}
		return dataValue;
	}
}
