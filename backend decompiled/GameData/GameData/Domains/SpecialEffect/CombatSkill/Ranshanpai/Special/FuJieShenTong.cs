using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Special;

public class FuJieShenTong : CombatSkillEffectBase
{
	private const int ReduceNeiliAllocationBasePercent = 20;

	private const int ReduceNeiliAllocationUnitPercent = 5;

	private DataUid _neiliAllocationUid;

	private bool _affecting;

	public FuJieShenTong()
	{
	}

	public FuJieShenTong(CombatSkillKey skillKey)
		: base(skillKey, 7308, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(217, EDataModifyType.Custom, base.SkillTemplateId);
		CreateAffectedData(289, EDataModifyType.Custom, base.SkillTemplateId);
		_neiliAllocationUid = ParseNeiliAllocationDataUid();
		GameData.GameDataBridge.GameDataBridge.AddPostDataModificationHandler(_neiliAllocationUid, base.DataHandlerKey, OnNeiliAllocationChanged);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		GameData.GameDataBridge.GameDataBridge.RemovePostDataModificationHandler(_neiliAllocationUid, base.DataHandlerKey);
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnNeiliAllocationChanged(DataContext context, DataUid arg2)
	{
		UpdateAffecting(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		UpdateAffecting(context);
		ShowSpecialEffectTips(0);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId || !PowerMatchAffectRequire(power))
		{
			return;
		}
		CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
		CombatCharacter targetChar = (base.IsDirect ? enemyChar : base.CombatChar);
		Dictionary<byte, int> neiliAllocationTypeCounter = ObjectPool<Dictionary<byte, int>>.Instance.Get();
		foreach (short bannedSkillId in targetChar.GetBannedSkillIds(requireNotInfinity: true))
		{
			if (base.IsDirect)
			{
				DomainManager.Combat.ResetSkillCd(context, targetChar, bannedSkillId);
			}
			else
			{
				DomainManager.Combat.ClearSkillCd(context, targetChar, bannedSkillId);
			}
			DomainManager.Combat.AddGoneMadInjury(context, enemyChar, bannedSkillId);
			ShowSpecialEffectTipsOnceInFrame(1);
			ShowSpecialEffectTipsOnceInFrame(2);
			byte neiliAllocationType = Config.CombatSkill.Instance[bannedSkillId].GetRelatedNeiliAllocationType();
			neiliAllocationTypeCounter[neiliAllocationType] = neiliAllocationTypeCounter.GetOrDefault(neiliAllocationType) + 1;
		}
		foreach (KeyValuePair<byte, int> item in neiliAllocationTypeCounter)
		{
			item.Deconstruct(out var key, out var value);
			byte neiliAllocationType2 = key;
			int count = value;
			CValuePercent percent = 20 + 5 * count;
			int reduceNeiliAllocation = base.CombatChar.GetNeiliAllocation()[neiliAllocationType2] * percent;
			base.CombatChar.ChangeNeiliAllocation(context, neiliAllocationType2, -reduceNeiliAllocation);
		}
	}

	private void UpdateAffecting(DataContext context)
	{
		bool affecting = !base.CombatChar.AnyLowerThanOriginNeiliAllocation();
		if (affecting != _affecting)
		{
			_affecting = affecting;
			DomainManager.Combat.UpdateSkillCanUse(context, base.CombatChar, base.SkillTemplateId);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey)
		{
			return dataValue;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		bool result = fieldId switch
		{
			217 => false, 
			289 => _affecting, 
			_ => dataValue, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
