using System;

namespace GameData.Utilities.Reflection;

public class DeepCopyDepthOverflowException : Exception
{
	public DeepCopyDepthOverflowException(object obj, Type type)
		: base($"Deep copy {obj} by {type} overflow")
	{
	}
}
