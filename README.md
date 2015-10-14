# String  Compare

Simple strings Compares (measuring the difference between two sequences)

# Compare algorithms

* Levenshtein distance
* Tanimoto coefficient

## Installation

Download last release https://github.com/NickRimmer/StringCompare/releases 

or install from NuGet https://www.nuget.org/packages/StringCompareMeasure. To install run the following command in the Package Manager Console
```
Install-Package StringCompareMeasure
```

## Usage

    var howMuch = "hello"
          .CompareLevenshtein("Hello world");
    //or  .CompareTanimoto("Hello world");

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :D

## History

_No history :P_


## License

https://opensource.org/licenses/MIT
