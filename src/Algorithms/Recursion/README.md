# Basic Recursion

 A recursive function is a function that calls itself. 
 Each successive call works on a more refined set of inputs, bringing us closer and closer to the solution of a problem. 
 A terminating condition defines the state at which a recursive function should return instead of making another recursive call.

# Tail Recursion

A recursive function is said to be tail recursive if all recursive calls within it are tail recursive.
A recursive call is tail recursive when it is the last statement that will be executed within the body of a function and its return value is not a part of an expression.

This characteristic is important because most modern compilers automatically generate code to take advantage of it.
When a compiler detects a call that is tail recursive, it overwrites the current activation record instead of pushing a new one onto the stack.

