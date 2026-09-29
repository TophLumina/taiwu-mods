using System;
using System.Collections.Generic;
using GameData.Domains.Combat;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializeTo(typeof(uint))]
public readonly record struct ImmunityMask
{
	public uint Storage => (uint)((ushort)_marks | ((byte)_poisons << 16));

	private readonly BoolArray16 _marks;

	private readonly BoolArray8 _poisons;

	private const int PoisonImmunityBitOffset = 16;

	public ImmunityMask(uint storage)
	{
		_marks = (ushort)storage;
		_poisons = (byte)(storage >> 16);
	}

	public static explicit operator uint(ImmunityMask mask)
	{
		return mask.Storage;
	}

	public static explicit operator ImmunityMask(uint storage)
	{
		return new ImmunityMask(storage);
	}

	public ImmunityMask SetMarkImmunity(EMarkType markType, bool isImmune)
	{
		if (markType < EMarkType.Outer || markType >= (EMarkType)16)
		{
			return this;
		}
		return new ImmunityMask(_marks.ReadonlySet((int)markType, isImmune), _poisons);
	}

	public bool IsImmune(EMarkType markType)
	{
		if (markType >= EMarkType.Outer && markType < (EMarkType)16)
		{
			return _marks[(int)markType];
		}
		return false;
	}

	public ImmunityMask SetPoisonImmunity(sbyte poisonType, bool isImmune)
	{
		if ((poisonType < 0 || poisonType >= 6) ? true : false)
		{
			return this;
		}
		return new ImmunityMask(_marks, _poisons.ReadonlySet(poisonType, isImmune));
	}

	public bool IsImmuneToPoison(sbyte poisonType)
	{
		if (poisonType >= 0 && poisonType < 6)
		{
			return _poisons[poisonType];
		}
		return false;
	}

	private ImmunityMask(BoolArray16 marks, BoolArray8 poisons)
	{
		_marks = marks;
		_poisons = poisons;
	}

	public static ImmunityMask operator +(ImmunityMask l, ImmunityMask r)
	{
		return new ImmunityMask(l._marks | r._marks, l._poisons | r._poisons);
	}

	public static ImmunityMask From(IImmunityMaskProvider provider)
	{
		if (provider == null)
		{
			return default(ImmunityMask);
		}
		ImmunityMask mask = default(ImmunityMask).SetMarkImmunity(EMarkType.Outer, provider.OuterInjuryImmunity).SetMarkImmunity(EMarkType.Inner, provider.InnerInjuryImmunity).SetMarkImmunity(EMarkType.Flaw, provider.FlawImmunity)
			.SetMarkImmunity(EMarkType.Acupoint, provider.AcupointImmunity)
			.SetMarkImmunity(EMarkType.Mind, provider.MindImmunity)
			.SetMarkImmunity(EMarkType.Fatal, provider.FatalImmunity)
			.SetMarkImmunity(EMarkType.Die, provider.DieImmunity)
			.SetMarkImmunity(EMarkType.Health, provider.HealthImmunity);
		IReadOnlyList<bool> poisonImmunities = provider.PoisonImmunities;
		if (poisonImmunities == null)
		{
			return mask;
		}
		int poisonCount = Math.Min(poisonImmunities.Count, 6);
		for (sbyte poisonType = 0; poisonType < poisonCount; poisonType++)
		{
			mask = mask.SetPoisonImmunity(poisonType, poisonImmunities[poisonType]);
		}
		return mask;
	}
}
