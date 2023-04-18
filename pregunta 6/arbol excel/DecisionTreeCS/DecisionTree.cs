using System;
using System.Collections.Generic;

namespace DecisionTreeCS {
  class DecisionTree {
    Dataset dataset;
    DecisionNode root;

    // This function is used to generate the tree (aka training).
    // It will recursively work out each Node and save it with a
    // private method called BuildTree (defined below).
    public void Fit(Dataset dataset) {
      this.dataset = dataset;
      root = BuildTree(dataset);
    }

    // We expose this two variables as public properties
    // with the Pascal naming convention.
    public Dataset Dataset => dataset;

    public DecisionNode Root => root;

    // This function will recursively traverse the tree, matching
    // the Row with the current node Question, until we reach a Leaf.
    public DecisionNode Predict(Row row, DecisionNode node = null) {
      // If we don't have a root, we can't do anything
      if (root == null)
        return null;

      if (node == null)
        node = root;

      // We return if this node is a Leaf
      if (node.IsLeaf)
        return node;

      // If this row matches this Question, we enter the true branch
      if (node.question.Match(row))
        return Predict(row, node.trueBranch);

      // Otherwise we use the false branch
      return Predict(row, node.falseBranch);
    }

    // This function will recursively create the tree 
    private static DecisionNode BuildTree(Dataset dataset) {
      // We find the best gain and question
      (double gain, Question question) = FindBestSplit(dataset);

      // Once we reach a gain of 0, this is the end of the route
      if (gain == 0)
        return new DecisionNode(dataset);

      // If there's more gain, we need to partition using the best question
      (Dataset trueRows, Dataset falseRows) = PartitionDataset(dataset, question);

      // Then we recursively generate the true and false branch and return that
      DecisionNode trueBranch = BuildTree(trueRows);
      DecisionNode falseBranch = BuildTree(falseRows);

      return new DecisionNode(question, trueBranch, falseBranch);
    }

    // This function finds how many times each label appears in a dataset.
    public static Dictionary<string, int> GetClassCount(Dataset dataset) {
      Dictionary<string, int> counts = new Dictionary<string, int>();
      foreach (Row row in dataset) {
        string label = row[row.Count - 1].ToString();
        if (!counts.ContainsKey(label))
          counts[label] = 0;
        counts[label] += 1;
      }
      return counts;
    }

    // This function uses a Question to partition a Dataset
    // into different sub-datasets for the true and falso branch.
    public static (Dataset trueRows, Dataset falseRows) PartitionDataset(Dataset dataset, Question question) {
      // We must use the same Headers, that's why we copy them over
      // to the new Dataset
      Dataset trueRows = new Dataset(dataset.Headers);
      Dataset falseRows = new Dataset(dataset.Headers);
      foreach (Row row in dataset) {
        if (question.Match(row))
          trueRows.Add(row);
        else
          falseRows.Add(row);
      }
      return (trueRows, falseRows);
    }

    // This function gets the Gini Impurity used to calculate the
    // best question for each dataset we get. This is later used to calculate
    // the information gain, which is also used to test the best question.
    public static double CalculateGini(Dataset dataset) {
      // We first get the count of different labels we have in this dataset
      Dictionary<string, int> counts = GetClassCount(dataset);
      // We assume the impurity is the maximum (1)
      double impurity = 1;
      // We loop over each different label, calculating its probability
      // in the dataset and substracting that to the power of two to the impurity.
      foreach (KeyValuePair<string, int> label in counts) {
        double probability = Convert.ToDouble(label.Value) / Convert.ToDouble(dataset.Count);
        impurity -= Math.Pow(probability, 2);
      }
      return impurity;
    }

    // This function uses the Gini Impurity to get the information gain,
    // which is then used to get the best question from an specific dataset.
    public static double CalculateInfoGain(Dataset left, Dataset right, double current) {
      // First, we calculate the probability of the left element count. For that, we just
      // sum both of the counts to get the total of elements in the dataset. We use this
      // value to divide by the count of elements in the left side. We can then just
      // substract this value to 1 and we get the probability of elements of the right branch.
      double avg = Convert.ToDouble(left.Count) / Convert.ToDouble(left.Count + right.Count);
      // We then use the current Gini (received by parameter) and subtract the sum of both
      // probabilities multiplied by their Gini impurity.
      return current - (avg * CalculateGini(left) + (1 - avg) * CalculateGini(right));
    }

    // This function is used to find the best split available from this dataset.
    // It is meant to be used recusively until we find the ideal tree.
    public static (double gain, Question question) FindBestSplit(Dataset dataset) {
      // First, we initialize the values that will be returned
      double bestGain = 0;
      Question bestQuestion = null;
      // We need to save the Gini of the dataset we are working on.
      // This is then used to calculate the information gain.
      double currentGini = CalculateGini(dataset);
      // Remember that Dataset.MaxFeatureCount returns all the features - 1.
      // This is because the last column is always used as the label.
      int featureCount = dataset.MaxFeatureCount;

      // We loop over each feature
      for (int i = 0; i < featureCount; ++i) {
        // Get each unique value found in this feature column
        HashSet<Feature> features = dataset.GetUniqueValues(i);

        // For each of this features, we test creating a Question using
        // it. If it is better than the one we already have, we save it
        // as the best. At the end, we will have found the best Question
        // for this dataset.
        foreach (Feature feature in features) {
          Question question = new Question(i, dataset.Headers[i], feature);
          (Dataset trueRows, Dataset falseRows) = PartitionDataset(dataset, question);
          // If this Question doesn't partition the dataset at all, then we omit the rest
          if (trueRows.Count == 0 || falseRows.Count == 0)
            continue;
          double gain = CalculateInfoGain(trueRows, falseRows, currentGini);
          if (gain > bestGain) {
            bestGain = gain;
            bestQuestion = question;
          }
        }
      }

      return (bestGain, bestQuestion);
    }

    public override string ToString() => TreeToString(root);

    private static string TreeToString(DecisionNode node, string spacing = "") {
      if (node.IsLeaf)
        return $"{spacing}Resultado: {node}\n";

      string str = $"{spacing}{node.question}\n";
      str += $"{spacing}--> Sí:\n";
      str += TreeToString(node.trueBranch, spacing + "  ");
      str += $"{spacing}--> No:\n";
      str += TreeToString(node.falseBranch, spacing + "  ");

      return str;
    }
  }
}
