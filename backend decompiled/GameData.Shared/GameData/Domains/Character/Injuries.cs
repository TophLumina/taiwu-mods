using System;
using System.Runtime.Serialization;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[Serializable]
public struct Injuries : ISerializableGameData, ISerializable
{
	public const sbyte MaxLevel = 6;

	private const int Capacity = 8;

	public unsafe fixed sbyte Items[16];

	public bool AnyInner => HasAnyInjury(isInnerInjury: true);

	public bool AnyOuter => HasAnyInjury(isInnerInjury: false);

	public unsafe void Initialize()
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = 0L;
			((long*)items)[1] = 0L;
		}
	}

	public unsafe Injuries(params sbyte[] injuries)
	{
		for (int i = 0; i < 14; i++)
		{
			sbyte level = injuries[i];
			if (level > 6)
			{
				throw new Exception("Invalid injury levels: " + string.Join(", ", injuries));
			}
			Items[i] = level;
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		return 16;
	}

	public unsafe int Serialize(byte* pData)
	{
		fixed (sbyte* pItems = Items)
		{
			*(long*)pData = *(long*)pItems;
			((long*)pData)[1] = ((long*)pItems)[1];
		}
		return 16;
	}

	public unsafe int Deserialize(byte* pData)
	{
		fixed (sbyte* items = Items)
		{
			*(long*)items = *(long*)pData;
			((long*)items)[1] = ((long*)pData)[1];
		}
		return 16;
	}

	public unsafe Injuries(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* items = Items)
		{
			*(ulong*)items = info.GetUInt64("0");
			((long*)items)[1] = (long)info.GetUInt64("1");
		}
	}

	public unsafe void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		fixed (sbyte* pItems = Items)
		{
			info.AddValue("0", *(ulong*)pItems);
			info.AddValue("1", ((ulong*)pItems)[1]);
		}
	}

	public unsafe (sbyte outer, sbyte inner) Get(sbyte bodyPartType)
	{
		int index = bodyPartType * 2;
		return (outer: Items[index], inner: Items[index + 1]);
	}

	public unsafe sbyte Get(sbyte bodyPartType, bool isInnerInjury)
	{
		return Items[bodyPartType * 2 + (isInnerInjury ? 1 : 0)];
	}

	public unsafe int GetSum()
	{
		int sum = 0;
		for (int i = 0; i < 14; i++)
		{
			sum += Items[i];
		}
		return sum;
	}

	public int GetSum(sbyte bodyPart)
	{
		var (outer, inner) = Get(bodyPart);
		return outer + inner;
	}

	public unsafe int GetMax()
	{
		int max = 0;
		for (int i = 0; i < 14; i++)
		{
			max = Math.Max(max, Items[i]);
		}
		return max;
	}

	public (sbyte outer, sbyte inner) GetBothSum()
	{
		sbyte sumOuter = 0;
		sbyte sumInner = 0;
		for (sbyte i = 0; i < 7; i++)
		{
			(sbyte outer, sbyte inner) tuple = Get(i);
			sbyte outer = tuple.outer;
			sbyte inner = tuple.inner;
			sumOuter += outer;
			sumInner += inner;
		}
		return (outer: sumOuter, inner: sumInner);
	}

	public unsafe bool HasAnyInjury()
	{
		fixed (sbyte* pItems = Items)
		{
			if (*(long*)pItems == 0L)
			{
				return ((long*)pItems)[1] != 0;
			}
			return true;
		}
	}

	public unsafe bool HasAnyInjury(bool isInnerInjury)
	{
		for (int i = (isInnerInjury ? 1 : 0); i < 14; i += 2)
		{
			if (Items[i] > 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool AllPartsFully(bool isInnerInjury)
	{
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			if (Get(bodyPart, isInnerInjury) < 6)
			{
				return false;
			}
		}
		return true;
	}

	public sbyte GetLightestPart(bool isInner, bool mustCanChanged = true)
	{
		sbyte lightestInjuryPart = -1;
		sbyte lightestInjuryValue = sbyte.MaxValue;
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			sbyte injuryValue = Get(bodyPart, isInner);
			if ((!mustCanChanged || injuryValue < 6) && injuryValue < lightestInjuryValue)
			{
				lightestInjuryPart = bodyPart;
				lightestInjuryValue = injuryValue;
			}
		}
		return lightestInjuryPart;
	}

	public unsafe void Set(sbyte bodyPartType, bool isInnerInjury, sbyte value)
	{
		int index = bodyPartType * 2 + (isInnerInjury ? 1 : 0);
		Items[index] = MathUtils.Clamp(value, (sbyte)0, (sbyte)6);
	}

	public unsafe void Change(sbyte bodyPartType, bool isInnerInjury, int delta)
	{
		int index = bodyPartType * 2 + (isInnerInjury ? 1 : 0);
		Items[index] = (sbyte)MathUtils.Clamp(Items[index] + delta, 0, 6);
	}

	public unsafe void Change(int internalIndex, sbyte delta)
	{
		Items[internalIndex] = (sbyte)MathUtils.Clamp(Items[internalIndex] + delta, 0, 6);
	}

	public unsafe void Change(Injuries delta)
	{
		for (int i = 0; i < 14; i++)
		{
			Items[i] = (sbyte)MathUtils.Clamp(Items[i] + delta.Items[i], 0, 6);
		}
	}

	public unsafe void Change(Injuries delta, bool outerInjuryImmunity, bool innerInjuryImmunity)
	{
		for (int i = 0; i < 7; i++)
		{
			int outerIndex = i * 2;
			if (!outerInjuryImmunity)
			{
				Items[outerIndex] = (sbyte)MathUtils.Clamp(Items[outerIndex] + delta.Items[outerIndex], 0, 6);
			}
			int innerIndex = outerIndex + 1;
			if (!innerInjuryImmunity)
			{
				Items[innerIndex] = (sbyte)MathUtils.Clamp(Items[innerIndex] + delta.Items[innerIndex], 0, 6);
			}
		}
	}

	public unsafe Injuries Subtract(Injuries other)
	{
		Injuries delta = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			delta.Items[i] = (sbyte)(Items[i] - other.Items[i]);
		}
		return delta;
	}

	public unsafe Injuries GetReversed()
	{
		Injuries reversed = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = (sbyte)(-Items[i]);
		}
		return reversed;
	}

	public unsafe Injuries MaxZero()
	{
		Injuries reversed = default(Injuries);
		for (int i = 0; i < 14; i++)
		{
			reversed.Items[i] = Math.Max(Items[i], 0);
		}
		return reversed;
	}

	public unsafe bool Equals(Injuries other)
	{
		bool result = true;
		for (int i = 0; i < 14; i++)
		{
			if (Items[i] != other.Items[i])
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
