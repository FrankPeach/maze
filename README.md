# PeopleNet Maze

This api will take in a maze and return to you the solution and the number of steps it took to solve

## Getting Started

The maze solver will default to http://localhost:8080/solvemaze

You may also run the unit tests.

Be sure to rebuild the solution or run ```Update-Package``` to restore nuget packages. 

### Prerequisites

The service will take in a string either via JSON or as text/plain with the following characters:
- ```.``` Represents an open road
- ```#``` represents a blocked road
- ```A``` represents the starting point
- ```B``` represents the destination point

 be sure to include new line characters to indicate the next row
 
Here is an example input
```
##########
#A...#...#
#.#.##.#.#
#.#.##.#.#
#.#....#B#
#.#.##.#.#
#....#...#
##########
```

Here is an example curl using text/plain
```
curl -X POST \
 http://localhost:8080/solvemaze \
 -H 'Content-Type: text/plain' \
 -H 'cache-control: no-cache' \
 -d '##########
#A...#...#
#.#.##.#.#
#.#.##.#.#
#.#....#B#
#.#.##.#.#
#....#...#
##########'
```

## Results
The result will the maze sent with the POST request with '@' symbols for the solution as well as the number of steps it took to solve.
The consumer should be sure to format the returned solution using the line feeds ```\r\n```

## Example Result
```
{
 "Steps": 14,
 "Solution": "
 ##########
 #A@@.#...#
 #.#@##.#.#
 #.#@##.#.#
 #.#@@@@#B#
 #.#.##@#@#
 #....#@@@#
 ##########"
}
```
### Known Issues

- An exception will be thrown if there is no starting position, no ending position or if it is impossible to get from point A to point B
- The exception will be shown in the result! This is not production ready!
- If there are two paths to the same destination the shorter one will be returned
- If there are multiple starting and/or ending points then the first one found will be used for both starting and ending. Also a duplicate starting point will not be evaluated as a open road (i.e. The solution path will not go through it)
- Any other characters than the ones listed in the prerequisites will be interpreted as the end of the line and may cause unexpected results.