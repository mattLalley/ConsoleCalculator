# Console Calculator
A simple console based calculator written in c#.

### Prerequisites
* Visual Studio or Rider

### Installation
1. Get pre-requisite software.
2. Clone the source: `https://github.com/mattLalley/ConsoleCalculator.git`
3. Open and Run the project

### Frameworks/Dependencies
NUnit

### Usage
This calculator can calculate results using expressions in the form:

```
5 + 5 * 7 / 3 
```

When an `=` is part of an expression a result will be returned.

```
5 + 5 * 7 / 3 =
Result: 16.6666666666667
```

This calculator supports `-+*/!` and `1/x`.
`1/x` returns the reciprocal of a number and should be used like this:

```
10 1/x =
Result: 0.1
```

Use `C` to clear the previous number

```
10 + 5 C + 1 =
Result: 12
```

Use `A` to clear all

Use `Q` to Quit
