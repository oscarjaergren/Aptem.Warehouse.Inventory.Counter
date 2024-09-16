# Warehouse Inventory Counter

## Project Description

The Warehouse Inventory Counter is a C# application that processes warehouse inventory messages in two different formats and outputs a consolidated count of items.

# Personal Notes

Assumption
In a real world scenario this would likely be an service bus message subscriber
so the idea is that this is an application to either simulate those messages or test them out
versioning has been implemented using the factory to work with the scenario, but could also be done with feature flags and API versionings if this were an API


Uses explicit variables instead of var (personal preference for readability)
In a proper application this would use ILogger instead of Console.Write and use template logging instead

Principles such as  functional 
- Solid
- TDD
- Functional (Pure & Immutability)

## Features

- Supports two input formats without needing user specification:
  - **Part 1 Format**: Each letter represents one item (e.g., `aaaa bb c`).
  - **Part 2 Format**: Starts with `#p2#`. Each item is represented by a number followed by a letter (e.g., `#p2# 4a 2b 1c`).
- Outputs the total count of each item type in the format `{count}{item}` sorted alphabetically.
- Command-line interface for easy usage.
- Supports reading input from a file and writing output to a file.
- Comprehensive error handling with helpful messages.
- Unit tests covering various cases and edge conditions.


## Setup and Running Instructions

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Building the Project

1. Clone the repository or copy the source code into a local directory.
2. Navigate to the project directory.

# Technical Requirements

Input Parsing
Part 1
We need to integrate with a system which counts items in a warehouse. The system will handle counting the items, 
and will send us a message containing the result of the count when it's complete. Before we store the results of the 
count, we need to total the items in the message.
A message has the following properties:
• Each type of item in stock is represented by a unique letter (e.g. a)
• Each occurrence of a letter indicates 1 item of that type in stock.
• Different stacks of items are delimited with spaces in a message
• Multiple stacks of the same type of item may exist in a message.

Write a program that accepts a string as input, and counts the total number of each item in the message. Write these 
totals to the console.

Example
Input: 
aaaa eeeeee bb c aa ccc d
Output: 
6a 2b 4c 1d 6e

Part 2
The customer saw some of your compressed output on a screen-share with a member of the support team, and they 
really liked it!
They've started using a similar format for their messages as well:
• Each type of item in stock is represented by a unique letter (e.g. a)
• Each item is preceded by a number, indicating the amount of that item in a stack.
• Different stacks of items are delimited with spaces in a message
• Multiple stacks of the same type of item may exist in a message.

However, they can't upgrade all of their warehouses at once. Some warehouses will use the new format, and others 
will still use the old format. New messages will start with #p2#.
Extend your program to cope with either a "Part 1" or a "Part 2" message. The output should be the same as in Part 1.

Example
Input: 
#p2# 4a 4b 7c 2a 5d 2a 6d 1e 2d
Output: 
9a 4b 7c 13d 1e

Notes:
Purpose might be to see how you deal with extension of code
I.e create a part 1, how do you extend this code to work with more things without interrupting the first part?

Rules seems quite clear, simple tech test. 