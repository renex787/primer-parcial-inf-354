using System.Windows.Forms;

namespace DecisionTreeCS {
  partial class TreeViewActivity : Form {
    public TreeViewActivity(DecisionTree tree) {
      InitializeComponent();
      // Stop redrawing each update
      treeView.BeginUpdate();
      // Recusively add each node to the Tree View
      TreeNode root = RenderTree(tree.Root);
      _ = treeView.Nodes.Add(root);
      // Finish this update
      treeView.EndUpdate();
    }

    static TreeNode RenderTree(DecisionNode node) {
      if (node.IsLeaf)
        return new TreeNode($"Resultado: {node}");

      TreeNode treeNode = new TreeNode(node.question.ToString());
      TreeNode trueBranch = treeNode.Nodes.Add("Verdadero");
      _ = trueBranch.Nodes.Add(RenderTree(node.trueBranch));
      TreeNode falseBrach = treeNode.Nodes.Add("Falso");
      _ = falseBrach.Nodes.Add(RenderTree(node.falseBranch));

      return treeNode;
    }
  }
}
