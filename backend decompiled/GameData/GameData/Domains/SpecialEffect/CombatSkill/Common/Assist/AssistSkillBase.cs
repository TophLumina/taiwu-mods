using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

public class AssistSkillBase : CombatSkillEffectBase
{
	protected bool SetConstAffectingOnCombatBegin;

	private DataUid _skillCanUseUid;

	private DataUid _skillCanAffectUid;

	protected bool CanAffect
	{
		get
		{
			CombatSkillData combatSkillData;
			return DomainManager.Combat.TryGetCombatSkillData(base.CharacterId, base.SkillTemplateId, out combatSkillData) && combatSkillData.GetLeftCdFrame() == 0 && combatSkillData.GetCanAffect();
		}
	}

	protected AssistSkillBase()
	{
	}

	protected AssistSkillBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_skillCanUseUid = ParseCombatSkillDataUid(1);
		_skillCanAffectUid = ParseCombatSkillDataUid(9);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_skillCanUseUid, base.DataHandlerKey, OnCanUseChanged);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_skillCanAffectUid, base.DataHandlerKey, OnCanUseChanged);
		if (SetConstAffectingOnCombatBegin)
		{
			Events.RegisterHandler_CombatBegin(OnCombatBegin);
		}
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_skillCanUseUid, base.DataHandlerKey);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_skillCanAffectUid, base.DataHandlerKey);
		base.OnDisable(context);
	}

	protected virtual void OnCanUseChanged(DataContext context, DataUid dataUid)
	{
	}

	private void OnCombatBegin(DataContext context)
	{
		SetConstAffecting(context, affecting: true);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
	}

	protected void SetConstAffecting(DataContext context, bool affecting)
	{
		DomainManager.Combat.GetCombatSkillData(base.CharacterId, base.SkillTemplateId).SetConstAffecting(affecting, context);
	}

	protected void ShowEffectTips(DataContext context)
	{
		DomainManager.Combat.GetCombatSkillData(base.CharacterId, base.SkillTemplateId).SetShowAffectTips(showAffectTips: true, context);
	}
}
