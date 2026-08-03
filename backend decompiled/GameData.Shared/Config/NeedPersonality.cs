using System;

namespace Config;

[Serializable]
public struct NeedPersonality(sbyte type, int count)
{
	public sbyte PersonalityType = type;

	public int NeedCount = count;
}
