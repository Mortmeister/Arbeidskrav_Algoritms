# Searching and Sorting — Arbeidskrav 1

# 1. Searching unsorted data

| Field     | 	Target      | Case                     | 	Matches | 	Comparisons |
|-----------|-------------|--------------------------|---------|-------------|
| Last Name | 	Bjerke      | First record (Best Case) | 	9       | 	200         |
| Last Name | 	 Hansen     | Last record (Worst Case) | 	7       | 	200         |
| Last Name | 	NotASurname | 	Absent                   | 0       | 	200         |
| Mobile    | 	00000000    | Absent	                   | 0       | 	200         |



The linear search needed 200 comparisons for an absent surname value, and the same for every absent value because the algorithm must check every value in the array before it can conclude that there is no match. The best-case and worst-case tests also required 200 comparisons because this implementation must return every match, so it cannot stop after finding the first match. This differs from the usual best-case O(1) behaviour of a linear search that stops at the first match. Finding nine matches did not cost more comparisons than finding none, both required 200 comparisons. The number of matches affected the number of returned results, but not the number of contacts examined. 

# 2. Sorting

I implemented Bubble Sort and Merge Sort and measured them with the supplied, already sorted, and reverse-sorted data.

| Algorithm   | 	Input          | 	Comparisons | 	Swaps/Moves  |
|-------------|----------------|-------------|--------------|
| Bubble Sort | 	As supplied    | 	19,864      | 	10,543 swaps |
| Bubble Sort | 	Already sorted | 	199         | 	0 swaps      |
| Bubble Sort | 	Reverse sorted | 	19,897      | 	19,537 swaps |
| Merge Sort  | 	As supplied    | 	1,281       | 	3,088 moves  |
| Merge Sort  | 	Already sorted | 	812         | 	3,088 moves  |
| Merge Sort  | 	Reverse sorted | 	864         | 	3,088 moves  |

Merge Sort did fewer comparisons than Bubble Sort on all three input shapes. Bubble Sort was helped strongly by already sorted data, its early exit check meant only 199 comparisons and no swaps. It was hurt most by reverse-sorted data, which produced 19,537 swaps. Bubble Sort has O(n) best-case, O(n²) average-case and O(n²) worst-case time complexity, with O(1) extra space. Merge Sort has O(n log n) best, average and worst-case time complexity, with O(n) extra space for the temporary merge buffer. My measured results agree with these general patterns. In particular, Bubble Sort changed greatly with the input shape, while Merge Sort stayed much more consistent. Merge Sort always made 3,088 moves in my implementation, while the number of comparisons changed between 812 and 1,281.
# 3. Searching sorted data

Binary search results

| Field        | 	Target     | 	Result    | 	Comparisons |
|--------------|------------|-----------|-------------|
| 1	Mobile      | 96657088   | 	Index 163 | 	8           |
| 4	LastName    | Amundsen   | 	Index 2   | 	8           |
| 5	LastName    | Alfredosen | 	-1        | 	8           |
| 6	FirstName   | Guro       | 	Index 45  | 	8           |

Linear search on the same targets, for comparison:

| Target     | 	Comparison (linear) | Comparison (Binary) | 
|------------|---------------------|---------------------|
| 	96657088   | 200                 | 	8                   | 	
| 	Amundsen   | 200                 | 	8                   | 	
| 	Alfredosen | 200                 | 	8                   | 	
| 	Guro       | 200                 | 	8                   | 	

Binary search needed 7–8 comparisons in the full set of tests against 200 contacts. This is close to log₂(200), which is about 7.64. To guarantee the first occurrence of a duplicated value, my implementation does not stop at the first match. It records the matching index and continues searching the left half until no earlier match is possible. For Amundsen, the returned index was 2 and the previous value was Aas. For Guro, index 45 had Geir immediately before it. Sorting itself required 1,281 comparisons and 3,088 moves for Merge Sort on the supplied data. A linear search costs 200 comparisons per search, so considering comparisons alone, the sorting work is recovered after roughly 7 searches. The actual break-even point depends on the cost of the sorting moves as well, so this is only a comparison / count estimate.

# 4. Insight

The most useful thing these results taught me is that the choice of algorithm depends on both the data and what the operation has to accomplish. Linear search had to inspect all 200 contacts because I needed every matching result, while binary search reduced the search to only 7–8 comparisons after sorting. Bubble Sort could be extremely cheap on already sorted data, but its reverse-sorted run required 19,897 comparisons and 19,537 swaps. Merge Sort was much more consistent, using 812–1,281 comparisons across the three input shapes. Seeing these differences in my own measurements made the practical effect of choosing an algorithm much clearer than just knowing the complexity notation.

# Appendix A: Complexity Reference

| Operation     | 	Best       | 	Average    | 	Worst      | 	Space |
|---------------|------------|------------|------------|-------|
| Linear Search | 	O(1)       | 	O(n)       | 	O(n)       | 	O(1)  |
| Binary Search | 	O(1)       | 	O(log n)   | 	O(log n)   | 	O(1)  |
| Bubble Sort   | 	O(n)       | 	O(n²)      | 	O(n²)      | 	O(1)  |
| Merge Sort    | 	O(n log n) | 	O(n log n) | 	O(n log n) | 	O(n)  |

# Appendix B: Console Results

Question 1 - Linear Search
Test 1 - Best case - LastName: Bjerke
Target: Bjerke
Matches: 9
Comparisons: 200

Test 2 - Worst case - FirstName: Camilla
Target: Camilla
Matches: 7
Comparisons: 200

Test 3 - Absent surname
Target: NonExistent
Matches: 0
Comparisons: 200

Test 4 - Absent mobile
Target: 00000000
Matches: 0
Comparisons: 200

QUESTION 2 - BUBBLE SORT

Bubble Sort - As supplied
Comparisons: 19864
Swaps: 10543

Bubble Sort - Already sorted
Comparisons: 199
Swaps: 0

Bubble Sort - Reverse sorted
Comparisons: 19897
Swaps: 19537

MERGE SORT TEST

Comparisons: 1290
Moves: 3088
First 10 mobile numbers:
40168267
40231899
40334125
40363245
40472537
40595021
40596355
40758228
40762016
41042432

QUESTION 3 - BINARY SEARCH

Test 1 - Mobile 96657088
Expected: index of 96657088
Result: Index=163, Comparisons=8

Test 2 - Mobile 00000000
Expected: -1
Result: Index=−1, Comparisons=7

Test 3 - Mobile 99999999
Expected: -1
Result: Index=−1, Comparisons=8

Test 4 - LastName Amundsen
Result: Index=2, Comparisons=8
Entry before result: Stian Aas
Value before result: Aas
Returned value: Amundsen

Test 5 - LastName Alfredosen
Expected: -1
Result: Index=−1, Comparisons=8

Test 6 - FirstName Guro
Result: Index=45, Comparisons=8
Entry before result: Geir Bjerke
Value before result: Geir
Returned value: Guro

Test 7 - Empty array
Expected: -1
Result: Index=−1, Comparisons=0

Test 8 - Single element
Expected: 0
Result: Index=0, Comparisons=1

LINEAR SEARCH FOR COMPARING WITH BINARY SEARCH

Mobile 96657088
Matches: 1
Comparisons: 200

LastName Amundsen
Matches: 9
Comparisons: 200

FirstName Guro
Matches: 3
Comparisons: 200

MERGE SORT MEASUREMENTS

Merge Sort - As supplied
Comparisons: 1281
Moves: 3088

Merge Sort - Already sorted
Comparisons: 812
Moves: 3088

Merge Sort - Reverse sorted
Comparisons: 864
Moves: 3088

EDGE CASE TESTS

Empty Bubble Sort: Comparisons=0, Swaps=0
Empty Merge Sort: Comparisons=0, Moves=0
Single Bubble Sort: Comparisons=0, Swaps=0
Single Merge Sort: Comparisons=0, Moves=0