using System.Collections.Generic;

namespace GameData.Domains.Character.Relation;

public class PotentialRelatedCharacters
{
	public readonly List<int> AdoptiveParents = new List<int>();

	public readonly List<int> AdoptiveChildren = new List<int>();

	public readonly List<int> AdoptiveBrothersAndSisters = new List<int>();

	public readonly List<int> SwornBrothersAndSisters = new List<int>();

	public readonly List<int> HusbandsAndWives = new List<int>();

	public readonly List<int> Mentors = new List<int>();

	public readonly List<int> Mentees = new List<int>();

	public readonly List<int> Friends = new List<int>();

	public readonly List<int> Adored = new List<int>();

	public readonly List<int> BoyAndGirlFriends = new List<int>();

	public readonly List<int> Enemies = new List<int>();

	public void OfflineClear()
	{
		AdoptiveParents.Clear();
		AdoptiveChildren.Clear();
		AdoptiveBrothersAndSisters.Clear();
		SwornBrothersAndSisters.Clear();
		HusbandsAndWives.Clear();
		Mentors.Clear();
		Mentees.Clear();
		Friends.Clear();
		Adored.Clear();
		BoyAndGirlFriends.Clear();
		Enemies.Clear();
	}
}
