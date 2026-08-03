using System;
using GameData.Common;

namespace GameData.Dependencies;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class BaseDataDependencyAttribute : Attribute
{
	public DomainDataType SourceType;

	public DataUid[] SourceUids;

	public InfluenceCondition Condition;

	public InfluenceScope Scope;
}
