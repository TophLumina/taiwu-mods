using System.Collections.Generic;
using System.Text;

namespace GameData.ActionPlanning.Interface;

public interface IGraph<in TContext, TNode>
{
	IEnumerable<TNode> GetNeighborNodes(TNode from);

	int GetWeight(TContext context, TNode from, TNode to);

	void ToDotFileString(StringBuilder stringBuilder);
}
