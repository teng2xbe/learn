namespace algo
{
    public static class SumOccurrence
    {
        public static int FindNumberOfOccurrence(int[] array, int sumToFind)
        {
            var bt = new Tree(array[0], sumToFind);
            for (var i = 1; i < array.Length; i++)
            {
                bt.AddNode(array[i]);
            }
            return bt.GetNumberOfSum();
        }

    }

    public class Tree
    {
        private Node head;
        private int sum;
        

        public Tree(int firsData, int sum)
        {
            head = new Node {Data = firsData};
            this.sum = sum;
        }

        public void AddNode(int data)
        {
            AddNode(head, data);
        }

        private void AddNode(Node current, int data)
        {
            if (current.Data == data)
            {
                current.Counter++;
                return;
            }
            if (current.Data + data == sum)
            {
                if (current.Left == null)
                {
                    current.Left = new Node { Data = data };
                    return;
                }
                AddNode(current.Left, data);
            }
            else
            {
                if (current.Right == null)
                {
                    current.Right = new Node { Data = data };
                    return;
                }
                AddNode(current.Right, data);
            }            
        }

        public int GetNumberOfSum()
        {
            var current = head;
            var depth = GetNumberOfSum(current);
            while (current.Right != null)
            {
                depth += GetNumberOfSum(current.Right);
                current = current.Right;
            }

            return depth;
        }

        private int GetNumberOfSum(Node node)
        {
            if (node.Left != null)
            {
                if (node.Counter == 0)
                {
                    return 1;
                }
                return 1 + node.Left.Counter;
            }
            if (node.Data*2 == sum)
            {
                return node.Counter/2;
            }
            return 0;
        }
    }

    public class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Counter { get; set; }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.FileSystem;
using Directory = System.IO.Directory;

namespace ConsoleApp2
{
    class Program
    {
        private static readonly Regex r = new Regex("[^0-9]");
        private static Dictionary<string, string> _files =  new Dictionary<string, string>();
        static void Main(string[] args)
        {
            GetDirs("C:\\");
            foreach (var file in _files)
            {
                File.Move(file.Key, file.Value);
            }
        }

        public static string GetFilename(string path)
        {
            var dirs = ImageMetadataReader.ReadMetadata(path);
            var size = dirs.OfType<FileMetadataDirectory>().FirstOrDefault()?.GetDescription(2);
            var orig = dirs.OfType<FileMetadataDirectory>().FirstOrDefault()?.GetDescription(1);
            var model = dirs.OfType<ExifIfd0Directory>().FirstOrDefault()?.GetDescription(272);
            var taken = dirs.OfType<ExifIfd0Directory>().FirstOrDefault()?.GetDescription(306);

            if (string.IsNullOrWhiteSpace(size) || string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(taken) || string.IsNullOrWhiteSpace(orig))
                return null;

            var newName = $"{r.Replace(taken, "")}_{model}_{r.Replace(size, "")}{Path.GetExtension(path)}";
            ;
            return $"{path.Replace(orig, newName)}";
        }

        public static void GetDirs(string path)
        {
            var q = new Queue<string>();
            q.Enqueue(path);

            while (q.Count > 0)
            {
                path = q.Dequeue();

                foreach (var d in Directory.GetDirectories(path))
                {
                    q.Enqueue(d);
                }

                foreach (var directory in Directory.GetDirectories(path))
                {
                    foreach (var file in Directory.GetFiles(directory))
                    {
                        var name = GetFilename(file);
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            _files.Add(file, name);
                        }
                    }
                }
            }
            
        }
    }
}
