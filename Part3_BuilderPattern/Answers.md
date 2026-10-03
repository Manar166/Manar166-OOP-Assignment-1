 ```text
 
 1-Why is a single 20 - parameter constructor for this class a problem in practice?

  call - site readability:having a constructor with 20 parameters
  makes it difficult for developers to understand what each parameter represents,
  leading to confusion and potential misuse of the class.
  It can also make the code harder to read and maintain,
  as it becomes less clear what the purpose of each argument is.

 and what happens the day someone adds one more optional property?

  call - site maintainability: adding an additional optional property would require modifying the constructor,
  potentially breaking existing code that relies on the previous constructor signature.
  This can lead to increased maintenance overhead and the risk of introducing bugs when making changes to the class.





 2- Is this purely a "constructor is too long" problem, or is there a deeper design issue with putting ~20 loosely
 related properties on a single class in the first place?
  ~20 loosely related properties may indicate a violation of the Single Responsibility Principle(SRP).
  ```

  ```text
   

   Task 3.3

  *  why is this composed version better than the single big builder from Task 3.2?
     everything is more organized and easier to read, and the code is more maintainable.
    and every class has its own builder, 
    so if we want to change the way we build an address,
    we can do that without affecting the other builders.
    and applays SRP (Single Responsibility Principle) and OCP (Open/Closed Principle) principles.
    
     can AddressBuilder guarantee a complete address on its own, without the
      parent object knowing anything about street/city/zip rules?

      yes , AddressBuilder can guarantee a complete address on its own,
      without the parent object knowing anything about street/city/zip rules.

 Reuse — the exact same AddressBuilder is used for both billing and shipping. What would you have had
   to duplicate without it?

 i would have had to duplicate the code for building an address for both billing and shipping,
 which would have led to code duplication and increased maintenance overhead.
 By using the same AddressBuilder, we can ensure consistency and reduce the risk of errors.



 Readability at the call site — compare constructing the object with Task 3.2's single builder versus this
     composed version

 the Composed version is more readable at the call site,
 because it clearly shows the structure of the invoice and its components.
 **/

  ```