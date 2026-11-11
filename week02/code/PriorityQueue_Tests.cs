using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities, with the highest-priority item added last.
    // Expected Result: Dequeue returns the item with the highest priority.
    // Defect(s) Found: The original loop does not examine the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items with equal priority are dequeued in their original enqueue order.
    // Defect(s) Found: The original comparison uses >=, which selects the latest item when priorities tie.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 10);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue every item until the queue is empty.
    // Expected Result: Each item is returned once, and another dequeue throws InvalidOperationException.
    // Defect(s) Found: The original Dequeue method returns an item without removing it from the queue.
    public void TestPriorityQueue_RemovesDequeuedItems()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 2);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario: Dequeue from an empty priority queue.
    // Expected Result: InvalidOperationException is thrown with the correct message.
    // Defect(s) Found: None. The original implementation already handles an empty queue correctly.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}
