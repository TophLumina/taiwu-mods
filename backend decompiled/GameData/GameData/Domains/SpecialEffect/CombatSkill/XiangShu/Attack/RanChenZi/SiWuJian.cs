using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class SiWuJian : CombatSkillEffectBase
{
	private const sbyte AddProgressUnit = 25;

	private const sbyte AddPowerUnit = 40;

	private int _addProgress;

	private int _addPower;

	private DataUid _bossPhaseUid;

	private long _assistEffectId;

	public SiWuJian()
	{
	}

	public SiWuJian(CombatSkillKey skillKey)
		: base(skillKey, 17133, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addProgress = 0;
		_addPower = 0;
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		_bossPhaseUid = new DataUid(8, 10, (ulong)base.CharacterId, 100u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_bossPhaseUid, base.DataHandlerKey, OnBossPhaseChanged);
		sbyte[] taskStatus = new sbyte[2]
		{
			DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(2).JuniorXiangshuTaskStatus,
			DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(3).JuniorXiangshuTaskStatus
		};
		bool goodEnding = !taskStatus.Exist((sbyte status) => status != 6);
		bool badEnding = !taskStatus.Exist((sbyte status) => status != 5);
		if (goodEnding || badEnding)
		{
			SiWuJianAssist effect = new SiWuJianAssist(SkillKey, goodEnding);
			DomainManager.SpecialEffect.Add(context, effect);
			_assistEffectId = effect.Id;
			ShowSpecialEffectTips(goodEnding, 2, 3);
		}
		else
		{
			_assistEffectId = -1L;
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_bossPhaseUid, base.DataHandlerKey);
		if (_assistEffectId >= 0)
		{
			DomainManager.SpecialEffect.Remove(context, _assistEffectId);
		}
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && _addProgress > 0)
		{
			DomainManager.Combat.ChangeSkillPrepareProgress(base.CombatChar, base.CombatChar.SkillPrepareTotalProgress * _addProgress / 100);
			ShowSpecialEffectTips(1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!(charId != base.CharacterId || skillId != base.SkillTemplateId || interrupted))
		{
			_addProgress += 25;
			_addPower += 40;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 199);
			ShowSpecialEffectTips(0);
		}
	}

	private void OnBossPhaseChanged(DataContext context, DataUid dataUid)
	{
		if (base.CombatChar.GetBossPhase() > 3)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return 0;
	}
}
