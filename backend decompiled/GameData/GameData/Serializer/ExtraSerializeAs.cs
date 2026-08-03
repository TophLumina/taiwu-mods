using System;
using System.Collections.Generic;
using GameData.Adventure;
using GameData.Combat.Cricket;
using GameData.Domains.Adventure;
using GameData.Domains.Combat;

namespace GameData.Serializer;

public static class ExtraSerializeAs
{
	public static readonly Dictionary<Type, Type> ExtraSerializeAsAttribute = new Dictionary<Type, Type>
	{
		{
			typeof(EAdventureParameterType),
			typeof(byte)
		},
		{
			typeof(ECricketCombatPropertyType),
			typeof(sbyte)
		},
		{
			typeof(DefeatMarkKey),
			typeof(int)
		},
		{
			typeof(AdventureBlockIndex),
			typeof(AdventureBlockIndexForSerialize)
		},
		{
			typeof(EBuildingScaleEffect),
			typeof(int)
		}
	};
}
