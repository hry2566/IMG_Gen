
using System;
using System.Windows.Forms;
using System.IO;

namespace IMG_Gen2
{
    public class cls_treenode : TreeNode
    {
        private string nodePath;
        private cls_treenode[] node = new cls_treenode[0];

        public cls_treenode(string path, string nodeName)
        {
            nodePath = nodeName + "\\";
            this.Text = nodeName.Replace(path, "");

            if (Directory.Exists(nodeName))
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(nodePath);
                System.IO.FileInfo[] files = di.GetFiles("*.jpg", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.FileInfo f in files)
                {
                    Array.Resize(ref node, node.Length + 1);
                    node[node.Length - 1] = new cls_treenode(nodePath, f.FullName);
                }
                files = di.GetFiles("*.bmp", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.FileInfo f in files)
                {
                    Array.Resize(ref node, node.Length + 1);
                    node[node.Length - 1] = new cls_treenode(nodePath, f.FullName);
                }
                files = di.GetFiles("*.png", System.IO.SearchOption.AllDirectories);
                foreach (System.IO.FileInfo f in files)
                {
                    Array.Resize(ref node, node.Length + 1);
                    node[node.Length - 1] = new cls_treenode(nodePath, f.FullName);
                }
                this.Nodes.AddRange(node);
            }
        }
    }
}
