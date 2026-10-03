```text


Design problems in the C++ source code:

1-Using Global Variables

The Problem: All system data lives as global variables accessible and modifiable by any function in the application

Why It Is a Problem: Global variables destroy invariant enforcement
Any function can bypass validation functions like addLineToOrder and directly overwrite productStock or orderIsPaid

What Could Go Wrong:

Automated testing or running concurrent instances is impossible because state cannot be isolated or reinitialized cleanly

Debugging data corruption requires searching every line of code in the entire file rather than inspecting a dedicated class or repository boundary




2- Parallel Arrays Instead of Encapsulated Domain Entities

The Problem: Related properties of core entities are shattered across separate, unlinked arrays

What Could Go Wrong: If an operation modifies, inserts, removes, or sorts elements in one array without identically updating all companion arrays, the data will be wrong 

3- Fixed capicity for Data 
Why It Is a Problem: The system relies on static global stack memory instead of dynamic collections (e.g., std::vector), creating artificial operational ceilings and wasting fixed memory up front regardless of actual usage.

What Could Go Wrong:

The system refuses to process the 51st customer or 101st order, halting business operations abruptly.

 2-dimensional fixed array (lineProductIndexes[100][20]) allocates space for 2,000 order lines unconditionally, wasting memory when orders contain only 1 or 2 items, while failing if an enterprise order requires 21 items.

```