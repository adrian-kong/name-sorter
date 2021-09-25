# name-sorter
[![Build Status](https://api.travis-ci.com/adrian-kong/name-sorter.svg?branch=master)](https://api.travis-ci.com/adrian-kong/name-sorter)

Practicing C# for coding assessment

## Note

- Sort by last name then given names i.e "a b c" and "a b c d" compares "c" with "d" if same, "a b" with "a b c"

## Input/Output

```
Janet Parsons
Vaughn Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter
```
Gives
```
Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Leo Gardner
Vaughn Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter
Shelby Nathan Yoder
```

## Download

See releases: https://github.com/adrian-kong/name-sorter/releases/tag/v1.0

## Setup

Run releases, default file path is unsorted-names-list.txt, else provide path in args

```sh
name-sorter ./unsorted-names-list.txt
```
