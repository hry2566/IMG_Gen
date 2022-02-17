
namespace IMG_Gen2
{
    public class cls_treenode : TreeNode
    {
        cls_treenode[] node = new cls_treenode[0];
        public cls_treenode(string nodeName, string rootPath)
        {
            this.Text = nodeName;
            if (System.IO.Directory.Exists(rootPath + nodeName))
            {
                rootPath = rootPath + nodeName + "\\";
                string[] subFolders = System.IO.Directory.GetDirectories(
                rootPath, "*", System.IO.SearchOption.TopDirectoryOnly);

                for (int i = 0; i < subFolders.Length;i++)
                {
                    string[] split = subFolders[i].Split("\\");
                    string folderName = split[split.Length - 1];

                    if(folderName!="pos" && folderName!="mask" && folderName!="split")
                    {
                        Array.Resize(ref node, node.Length + 1);
                        node[node.Length - 1] = new(folderName, rootPath);
                    }
                }
                this.Nodes.AddRange(node);
                node= AddFileNode(rootPath, "*.jpg");
                this.Nodes.AddRange(node);
                node= AddFileNode(rootPath, "*.bmp");
                this.Nodes.AddRange(node);
                node= AddFileNode(rootPath, "*.png");
                this.Nodes.AddRange(node);
                node= AddFileNode(rootPath, "*.gif");
                this.Nodes.AddRange(node);
            }
        }
        internal static cls_treenode[] AddFileNode(string rootPath,string fileExp)
        {
            cls_treenode[] node = new cls_treenode[0];

            string[] subfiles = System.IO.Directory.GetFiles(
                rootPath, fileExp, System.IO.SearchOption.TopDirectoryOnly);
                for (int i = 0; i < subfiles.Length;i++)
                {
                    string[] split = subfiles[i].Split("\\");
                    string fileName = split[split.Length - 1];

                    Array.Resize(ref node, node.Length + 1);
                    node[node.Length - 1] = new(fileName, rootPath);
                }
            return node;
        }
    }
}
