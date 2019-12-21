//题目：给定一个二叉搜索树（Binary Search Tree），把它转换成为累加树（Greater Tree)，
//使得每个节点的值是原来的节点值加上所有大于它的节点值之和。
//例：输入: 二叉搜索树:
//            5
//          /   \
//         2     13
//   输出: 转换为累加树:
//           18
//          /   \
//        20     13

//这是第一次的提交记录
//执行用时136ms，超过84.00%的C#提交记录=0=
//思路是因为二叉树的定义，所以其中序遍历的顺序是从小到大的
//所以把中序遍历换一下，遍历顺序就会从大到小


public class Solution 
{
    public int add = 0;
    
    public TreeNode ConvertBST(TreeNode root)
    {
        if(root== null) return root;
        ConvertBST(root.right);
        root.val += add;
        add = root.val;
        ConvertBST(root.left);
        return root;
    }
}