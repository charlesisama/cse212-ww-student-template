
using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);

        // If the list is empty, point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, only head will be affected.
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // Create a new node.
        Node newNode = new(value);

        // If the list is empty, the new node becomes both head and tail.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Connect the new node to the current tail.
            newNode.Prev = _tail;
            _tail.Next = newNode;

            // Update tail to the new node.
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has zero or one item, both references become null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item, update the head.
        else if (_head is not null)
        {
            _head.Next!.Prev = null;
            _head = _head.Next;
        }
    }

    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // If the list has zero or one item, both references become null.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            // Disconnect the last node.
            _tail.Prev!.Next = null;

            // Move tail to the previous node.
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr;
                    newNode.Next = curr.Next;
                    curr.Next!.Prev = newNode;
                    curr.Next = newNode;
                }

                return;
            }

            curr = curr.Next;
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // Start searching from the head.
        Node? curr = _head;

        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the matching node is the head, use RemoveHead.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If the matching node is the tail, use RemoveTail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Otherwise, reconnect the surrounding nodes.
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }

                // Stop after removing the first matching node.
                return;
            }

            // Move to the next node.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace them with 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // Start searching from the head.
        Node? curr = _head;

        while (curr is not null)
        {
            // Replace the value if it matches.
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }

            // Continue searching through the entire list.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list.
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List.
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head;

        while (curr is not null)
        {
            yield return curr.Data;
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List.
    /// </summary>
    public IEnumerable Reverse()
    {
        // Start at the end of the linked list.
        var curr = _tail;

        while (curr is not null)
        {
            // Return the current node's value.
            yield return curr.Data;

            // Move backward to the previous node.
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable array)
    {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
