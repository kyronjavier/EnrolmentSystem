using EnrolmentSystem;
using System;
public class BinaryTreeNode<T> where T : IComparable<T>
{
    public T Value { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }

    public BinaryTreeNode(T value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

public class BinaryTree<T> where T : IComparable<T>
{
    public BinaryTreeNode<T> Root { get; private set; }

    public void Add(T value)
    {
        if (Root == null)
        {
            Root = new BinaryTreeNode<T>(value);
        }
        else
        {
            AddTo(Root, value);
        }
    }

    private void AddTo(BinaryTreeNode<T> node, T value)
    {
        if (value.CompareTo(node.Value) < 0)
        {
            if (node.Left == null)
            {
                node.Left = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(node.Left, value);
            }
        }
        else
        {
            if (node.Right == null)
            {
                node.Right = new BinaryTreeNode<T>(value);
            }
            else
            {
                AddTo(node.Right, value);
            }
        }
    }

    public void InOrderTraversal(Action<T> action)
    {
        InOrderTraversal(Root, action);
    }

    private void InOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left, action);
            action(node.Value);
            InOrderTraversal(node.Right, action);
        }
    }

    public void PreOrderTraversal(Action<T> action)
    {
        PreOrderTraversal(Root, action);
    }

    private void PreOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            action(node.Value);
            PreOrderTraversal(node.Left, action);
            PreOrderTraversal(node.Right, action);
        }
    }

    public void PostOrderTraversal(Action<T> action)
    {
        PostOrderTraversal(Root, action);
    }

    private void PostOrderTraversal(BinaryTreeNode<T> node, Action<T> action)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left, action);
            PostOrderTraversal(node.Right, action);
            action(node.Value);
        }
    }
}
