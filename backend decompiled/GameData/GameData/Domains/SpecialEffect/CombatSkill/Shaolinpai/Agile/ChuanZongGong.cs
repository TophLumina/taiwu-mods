using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.GameDataBridge;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Agile;

public class ChuanZongGong : AgileSkillBase
{
	private const sbyte ChangeMoveSpeed = 40;

	private DataUid _defendSkillUid;

	private bool _affecting;

	public ChuanZongGong()
	{
	}

	public ChuanZongGong(CombatSkillKey skillKey)
		: base(skillKey, 1400)
	{
		ListenCanAffectChange = true;
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 9, -1), EDataModifyType.TotalPercent);
		}
		else
		{
			int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
			for (int i = 0; i < charList.Length; i++)
			{
				if (charList[i] >= 0)
				{
					AffectDatas.Add(new AffectedDataKey(charList[i], 9, -1), EDataModifyType.TotalPercent);
				}
			}
		}
		_defendSkillUid = new DataUid(8, 10, (ulong)base.CharacterId, 63u);
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_defendSkillUid, base.DataHandlerKey, OnDefendSkillChanged);
		_affecting = false;
		UpdateCanAffect(context, default(DataUid));
		if (_affecting)
		{
			ShowSpecialEffectTips(0);
		}
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_defendSkillUid, base.DataHandlerKey);
	}

	protected override void OnMoveSkillCanAffectChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
	}

	private void OnDefendSkillChanged(DataContext context, DataUid dataUid)
	{
		UpdateCanAffect(context, default(DataUid));
		if (_affecting)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void UpdateCanAffect(DataContext context, DataUid dataUid)
	{
		bool canAffect = base.CanAffect && base.CombatChar.GetAffectingDefendSkillId() >= 0;
		if (_affecting == canAffect)
		{
			return;
		}
		_affecting = canAffect;
		if (base.IsDirect)
		{
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, 9);
			return;
		}
		int[] charList = DomainManager.Combat.GetCharacterList(!base.CombatChar.IsAlly);
		for (int i = 0; i < charList.Length; i++)
		{
			if (charList[i] >= 0)
			{
				DomainManager.SpecialEffect.InvalidateCache(context, charList[i], 9);
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (!_affecting)
		{
			return 0;
		}
		if (dataKey.FieldId == 9)
		{
			return base.IsDirect ? 40 : (-40);
		}
		return 0;
	}
}
