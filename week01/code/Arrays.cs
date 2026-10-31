public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Problem-solving plan:
        // 1. Create a new double array with a size equal to length.
        // 2. Use a for loop to visit each index in the array.
        // 3. Multiply the starting number by the current index plus one.
        // 4. Store the calculated multiple at the current array index.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;


    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Problem-solving plan:
        // 1. Create a temporary list to store the elements to be moved.
        // 2. Calculate the starting index of the last 'amount' elements.
        // 3. Loop through the original list from the starting index
        //    to the last element.
        // 4. Add each selected element to the temporary list.
        // 5. Remove the selected elements from the original list,
        //    starting at the calculated starting index.
        // 6. Insert the temporary elements at the beginning of the
        //    original list, maintaining their original order.

        List<int> temporaryList = new List<int>();

        int startIndex = data.Count - amount;

        for (int i = startIndex; i < data.Count; i++)
        {
            temporaryList.Add(data[i]);
        }

        for (int i = 0; i < amount; i++)
        {
            data.RemoveAt(startIndex);
        }

        for (int i = 0; i < temporaryList.Count; i++)
        {
            data.Insert(i, temporaryList[i]);
        }
    }

}
