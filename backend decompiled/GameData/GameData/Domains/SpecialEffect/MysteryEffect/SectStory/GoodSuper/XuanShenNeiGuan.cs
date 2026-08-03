using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;

public class XuanShenNeiGuan : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	private const int RecoveryInjuryCount = 3;

	private bool _needRecoveryAfterCombatEnd;

	protected override short SpecialEffectId => 1771;

	public XuanShenNeiGuan()
	{
	}

	public XuanShenNeiGuan(int charId, int itemId)
		: base(charId, itemId, 50103)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_QiArtAffected(OnQiArtAffected);
		Events.RegisterHandler_CombatEnd(OnCombatEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_QiArtAffected(OnQiArtAffected);
		Events.UnRegisterHandler_CombatEnd(OnCombatEnd);
		base.OnDisable(context);
	}

	private void OnQiArtAffected(DataContext context, GameData.Domains.Character.Character character, short skillId)
	{
		if (character.GetId() == base.CharacterId)
		{
			if (DomainManager.Combat.IsCharInCombat(base.CharacterId, checkCombatStatus: false))
			{
				_needRecoveryAfterCombatEnd = true;
			}
			else
			{
				DoAffect(context);
			}
		}
	}

	private void OnCombatEnd(DataContext context)
	{
		if (_needRecoveryAfterCombatEnd)
		{
			DoAffect(context);
		}
		_needRecoveryAfterCombatEnd = false;
	}

	private void DoAffect(DataContext context)
	{
		short attainment = CharObj.GetLifeSkillAttainment(12);
		if (attainment < 500)
		{
			return;
		}
		bool anyChanged = false;
		Injuries injuries = CharObj.GetInjuries();
		foreach (InjuryKey item in CRandom.RandomInjuryByValue(context.Random, injuries, 3))
		{
			item.Deconstruct(out var BodyPart, out var Inner);
			sbyte bodyPart = BodyPart;
			bool inner = Inner;
			anyChanged = true;
			injuries.Change(bodyPart, inner, -1);
		}
		if (anyChanged)
		{
			CharObj.SetInjuries(injuries, context);
		}
	}
}
