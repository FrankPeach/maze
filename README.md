# PeopleNet Maze

This api will take in a maze and return to you the solution

## Getting Started

The maze solver will default to http://localhost:8080/solvemaze
You may also run the unit tests.

### Prerequisites

The service will take in a string either via JSON or as text/plain with the following characters:
 . represents an open road
 # represents a blocked road
 A represents the starting point
 B represents the destination point

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

Here is an examle curl using text/plain
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

### Known Issues

An exception will be thrown if there is no starting position, no ending position or if it is impossible to get from point A to point B
The exception will be shown in the result! This is not production ready!


