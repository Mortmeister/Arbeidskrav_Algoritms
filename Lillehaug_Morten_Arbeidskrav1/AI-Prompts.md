AI prompts used during the assignment

### Understanding the assignment

1. “Can you explain what this assignment is asking me to do, in simple terms?”
2. “Can you break the assignment into smaller tasks so I can work through them one at a time?”
3. “What does the requirement to count comparisons actually mean in this assignment?”
4. “Can you explain the difference between linear search, binary search, and sorting?”

### Linear search

1. “What exactly does the LinearSearch method need to return?”
2. “How can I make the linear search work for FirstName, LastName and Mobile without writing three separate search methods?”
3. “Can you explain why the linear search has to continue through the entire array even after finding a match?”
4. “I thought that best case meant finding the first occurrence and the worst case meant finding the last occurrence of a match. In other words stopping the search at these points. Is that correct for this assignment?”
5. “The assignment says return every match. Does that mean even the best-case search has to inspect all 200 contacts?”
6. “Can you check my LinearSearch implementation and explain what each part does?”
7. “How should I count comparisons in the linear search?”
8. “How do I ensure that it returns -1 if there are no matches?”
9. “Can you give me four specific tests that satisfy the assignment requirements for linear search?”
10. “My linear search gives 200 comparisons for every test. Is the number of comparisons always equal to the length of the array?”

### Sorting


1. “I need one Level 1 and one Level 2 sorting algorithm. Can you rate the different algorithms by complexity?”
2. “Can you explain Bubble Sort in simple and pracitical terms?”
3. “Can you explain Merge Sort  in simple and pracitical terms?”
4. “What does it mean that the sorting algorithm has to work in place?”
5. “Explain the temporary buffer / array concept in Merge Sort”
6. “How should I count comparisons and swaps in Bubble Sort?”
7. “For Merge Sort, should I count assignments as moves?”
8. “Can you check my Bubble Sort without rewriting everything for me?”
9. “Can you check my Merge Sort implementation and point out any problems?”
10. “How can I make the same sorting code support FirstName, LastName and Mobile?”
11. “How can I make the sorting work in both ascending and descending order?”
12. “Can you explain what a comparison delegate is and why it is useful here?”
13. “I need to test that both algorithms work with all three fields and both directions. Help me create a temporary verification test.”
14. “The verification tests passed. Which test code should I remove because it was only temporary?”
15. “How should I create the three required input shapes: as supplied, already sorted, and reverse sorted?”
16. “Does sorting a copy of the original array violate the requirement to sort in place?”
17. “Can you check whether my method still sorts the actual array in place while using a copy only for testing?”
18. “Here are my Bubble Sort measurements. Do they look correct with regards to the algorithm?”
19. “Here are my Merge Sort measurements. Can you explain why the number of moves is the same for all three input shapes?”


### Binary search

1. “Explain exactly what the binary search needs to do.”
2. “Why does binary search require the array to already be sorted?”
3. “Can you explain the left, middle and right indexes in binary search?”
4. “How can I write one generic binary search method that works for FirstName, LastName and Mobile?”
5. “What should binary search return when the value isn’t found?”
6. “The assignment says duplicates must return the first occurrence. Why doesn’t a normal binary search automatically do that?”
7. “How can I modify my binary search so that it continues looking to the left after finding a match?”
8. “Can you explain this first-occurrence logic without giving me a completely different implementation?”
9. “How do I handle an empty array?”
10. “How do I handle an array containing only one element?”
11. “What should happen if the target is smaller than the smallest value?”
12. “What should happen if the target is larger than the largest value?”
13. “For the duplicate test, the assignment asks me to print the entry immediately before the returned index. How does that prove it is the first occurrence?”
14. “Why am I getting 7 or 8 comparisons for binary search on 200 contacts?”
15. “How does that compare with log2(200)?”

### Comparing linear and binary search

1. “Why does linear search use 200 comparisons while binary search only uses around 8?”
2. “How should I explain the difference between O(n) and O(log n)?”
3. “How many searches do I need to perform before the cost of sorting is recovered?”
4. “Can we calculate that break-even point using my actual comparison counts rather than theoretical numbers?”

### Final checking

1. “Can you check whether my final code still meets the assignment requirements after removing the temporary verification tests?”
2. “Can you check whether my reported comparison and swap/move numbers match the actual console output?”
3. “Can you review the final report for missing requirements without changing anything?”

⸻

### Reflection on using AI

I used AI primarily as a sparring partner and learning aid, rather than simply asking it to produce finished work. The most useful part was being able to work through the assignment in small steps. The searching and sorting concepts were sometimes difficult to understand, especially because several requirements depended on details such as counting comparisons, handling duplicate values, and distinguishing between an algorithm’s theoretical complexity and its actual measured behaviour.
