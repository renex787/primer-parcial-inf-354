using System;
using System.Collections.Generic;
using System.Linq;

namespace DecisionTreeCS {
  class DecisionNode {
    // We can make all of this public since they can't be reassinged
    // due to the readonly property.
    public readonly Question question = null;
    public readonly DecisionNode trueBranch = null;
    public readonly DecisionNode falseBranch = null;
    public readonly Dataset dataset = null;
    public readonly Dictionary<string, int> predictions = null;

    // There's only two ways to create a DecisionNode (see constructors):
    // either by passing a Question with the true and false branches
    // (which means that this is NOT a leaf). The other way is by
    // using passing a Dataset, which will only happen when this
    // Node is a Leaf. That's why we check for that here.
    public bool IsLeaf => predictions != null;

    public DecisionNode(Question question, DecisionNode trueBranch, DecisionNode falseBranch) {
      this.question = question;
      this.trueBranch = trueBranch;
      this.falseBranch = falseBranch;
    }

    public DecisionNode(Dataset dataset) {
      this.dataset = dataset;
      predictions = DecisionTree.GetClassCount(dataset);
    }

    public override string ToString() {
      if (IsLeaf) {
        double total = predictions.Aggregate(0.0, (acc, x) => acc + x.Value);
        string str = "{ ";
        foreach (KeyValuePair<string, int> value in predictions) {
          int percent = (int)Math.Round(value.Value / total * 100, 0);
          str += $"'{value.Key}': {percent}%, ";
        }
        str = str.Remove(str.Length - 2);
        str += " }";
        return str;
      }

      return question.ToString();
    }
  }
}
