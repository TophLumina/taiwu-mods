using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class XiangNvQiCangWu : CombatSkillEffectBase
{
	private static readonly sbyte[] PowerChangeValue = new sbyte[6] { -20, 0, 20, 40, 60, 80 };

	private sbyte LowFavorReducePower = -40;

	private int _powerChangeValue;

	public XiangNvQiCangWu()
	{
	}

	public XiangNvQiCangWu(CombatSkillKey skillKey)
		: base(skillKey, 8304, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		int marryCharId = (base.IsDirect ? base.CurrEnemyChar.GetId() : base.CharacterId);
		HashSet<int> marryChars = DomainManager.Character.GetRelatedCharIds(marryCharId, 1024);
		short minFavor = short.MaxValue;
		foreach (int charId in marryChars)
		{
			if (!DomainManager.Character.IsCharacterAlive(charId))
			{
				short favor = DomainManager.Character.GetFavorability(charId, marryCharId);
				if (favor < minFavor)
				{
					minFavor = favor;
				}
			}
		}
		if (minFavor < short.MaxValue)
		{
			sbyte favorType = FavorabilityType.GetFavorabilityType(minFavor);
			_powerChangeValue = ((favorType <= 0) ? LowFavorReducePower : PowerChangeValue[favorType - 1]);
			if (_powerChangeValue != 0)
			{
				AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
				AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, base.SkillTemplateId), EDataModifyType.AddPercent);
				ShowSpecialEffectTips(_powerChangeValue > 0, 0, 1);
			}
		}
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
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
			return _powerChangeValue;
		}
		return 0;
	}
}
