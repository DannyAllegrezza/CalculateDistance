## Coding Challenge
Your task is to write a working program that reads data from the "location data.txt" file, sorts the data, and outputs the result.

Sort the locations in ascending order by distance from the decimal degrees location 0,0.

Write the program in C#, Java, or JavaScript.  Email all code, configuration files, and sorted output in a zipped file.


## Requirements I came up with
1. The application must read the data from a text file
2. The application must parse each line, identifying the latitude and longitude points
3. The application must be able to handle lat/long in two formats (1. degrees with compass directions, 2. signed decimal degrees without compass direction, where negative indicates west/south)
4. The application must calculate the distance between two locations, where location 1 is always 0*,0*, and the 2nd location is the location from the locationdata file.
5. The application must sort the locations, in ascending order, based on their distance from 0,0
6. The application must output the results
7. The application must be able to handle invalid coordinate data (ex: 1000, -10000)

## My Solution
For my solution, I chose to use the C# programming language. I created a C# Library and a console application. 

### ***To Run The App:
Either click the "FindTheDistance.exe" file in THIS directory, OR launch the FindTheDistance.sln file, load Visual Studio, Build, and then click the "Run" button. You can run in either Debug or Release.

What you will find inside of this directory is:

1. `FindTheDistance.exe` - This is a shortcut to the Release version of the executable.
2. `FindTheDistance.sln` - A Visual Studio Solution file. Please click this file to launch Visual Studio and from there you can explore my code, compile, debug, and launch my solution.
3. `FindTheDistance` (Folder) - This is the project solution folder that contains all of my code and logic
4. `FindTheDistanceTest` (Folder) - This folder contains the Unit Tests for my app
5. `TestResults` (Folder) - Logs of unit tests that have been performed
6. `sorted locations data.txt` - This is a text file that shows the sorted data. This is a static file that I have simply pasted my results into. The App does not write to this file.

## My Thought Process
When I read this problem I assumed it was fairly simple at first! However, digging into the data showed that there was much more to the task than originally presented to me.

I have programmed against the above requirements I listed. The biggest detail is that I am calculating the distance between two Locations (lets use Location1 and Location2). Location1, or the Origin, is always (0,0). So I have built an app that calculates the distance from (0,0) and any given data in the text file.

- I have tried to handle most of the common exceptions. A few things I noticed about the data is that there is a location that is invalid (Nowhere), and a location with no name at all. I caught the location with invalid data via a unit test.
- Unit tests were added to check over my business logic. There are still edge cases that could be added, but this is a good starting point.
- I tried to separate each entity into their own appropriate class. The "Business" folder contains the Coordinate and Location class. The `"CommonIO"` folder contains the `DistanceMath`, `FileHelper`, and `LocationDisplay` classes, and finally the `"Data"` folder contains the location data.txt file.
- I tried to avoid using the `static` keyword when possible. They can make things hard to mock and unit test, especially in a real world project.
- I found the "Haversine" formula online and implemented it in the `DistanceMath` class.
- I realized that we need to convert Cardinal values (values with N, S, W, E) to their proper degree value. I handle this in the FileHelper class as part of the data cleanup.
- I implemented the `IComparable` interface on my Location class. This allows you to implement a really nice Sort function on the Location data. I am sorting based on a property called "DistanceFromOrigin" which exists on the Location class.

## How I handled errors
I've handled a few of the edge cases that I noticed:

1. A Location with an empty/blank Name
2. A Location with an invalid Latitude or Longitude
3. File IO errors

For the first situation, I do a simple check inside of the Location class constructor

```
public Location(string name, Coordinate coords)
{
    if (String.IsNullOrEmpty(name))
    {
        this.Name = "N/A -- No Location Name Provided!";
    }
    else
    {
        this.Name = name;
    }
    this.Coordinate = coords; 
}
```

This assigns the name to "N/A -- No Location Name Provided!".

For the second case, I have modified the setter properties of the Latitude and Longitude fields of the Coordinate class.

If you pass in invalid data, I throw a new exception. The values will default to 0,0 for the invalid Location. This conveniently puts them at the top of the list of sorted data. I also modify the Location.Name property to show `(NOT VALID LOCATION!)`

For the third case (File IO) I have made a decent solution. Essentially, the app looks up 2 directors to find the "Data" folder and then reads the text file. This could probably be handled more efficiently in further iterations. If the file is not found, you will see an error on the Console window that will tell you how you can correct the issue. It will tell you a directory path where it is expecting to read the file. If you want, you can always create a folder at this path and then place your text file inside of it.


## Questions?

Please email me at danny@dannyallegrezza.com !
