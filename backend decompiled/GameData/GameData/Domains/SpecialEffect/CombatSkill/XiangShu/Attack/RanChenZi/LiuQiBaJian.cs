using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.RanChenZi;

public class LiuQiBaJian : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 10;

	private const sbyte TransferCount = 6;

	private int _addPower;

	public LiuQiBaJian()
	{
	}

	public LiuQiBaJian(CombatSkillKey skillKey)
		: base(skillKey, 17134, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_addPower = 10 * base.CombatChar.GetDefeatMarkCollection().MindMarkList.Count;
		if (_addPower > 0)
		{
			CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
			ShowSpecialEffectTips(0);
		}
		sbyte[] taskStatus = new sbyte[3]
		{
			DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(7).JuniorXiangshuTaskStatus,
			DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(5).JuniorXiangshuTaskStatus,
			DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(4).JuniorXiangshuTaskStatus
		};
		bool goodEnding = !taskStatus.Exist((sbyte status) => status != 6);
		bool badEnding = !taskStatus.Exist((sbyte status) => status != 5);
		if (goodEnding || badEnding)
		{
			if (goodEnding)
			{
				base.CurrEnemyChar.RemoveMindMark(context, 2, random: true);
			}
			else
			{
				base.CurrEnemyChar.AddMindMark(context, 2, -1);
			}
			ShowSpecialEffectTips(goodEnding, 2, 3);
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId != base.CharacterId || skillId != base.SkillTemplateId)
		{
			return;
		}
		if (PowerMatchAffectRequire(power))
		{
			List<bool> markList = base.CombatChar.GetDefeatMarkCollection().MindMarkList;
			if (markList.Count > 0)
			{
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly);
				int transferCount = Math.Min(6, markList.Count);
				for (int i = 0; i < transferCount; i++)
				{
					base.CombatChar.TransferRandomMindMark(context, enemyChar);
				}
				DomainManager.Combat.AddToCheckFallenSet(enemyChar.GetId());
				ShowSpecialEffectTips(1);
			}
		}
		RemoveSelf(context);
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
