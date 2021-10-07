# Anagrams Kata

[![Build](https://github.com/xenxi/anagrams-kata/actions/workflows/build.yml/badge.svg)](https://github.com/xenxi/anagrams-kata/actions/workflows/build.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=alert_status)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=bugs)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=code_smells)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=coverage)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=ncloc)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=xenxi_anagrams-kata&metric=sqale_index)](https://sonarcloud.io/dashboard?id=xenxi_anagrams-kata)

The instructions are kept short on purpose. The participants should come up with some questions regarding the requirements on their own and the facilitator should act as product owner who can answer them. Key with this kata when doing tdd is to find all the baby steps so you never reach a point where you have to write a huge block of code without having tests to back it up. In addition, readability of the code and performance can be tricky.

## Instructions
Write a program that finds all possible anagrams for a submitted input word. A 4 mb wordlist is included as datasource.
Use test driven development (tdd) and pair programming when possible.

## Easy examples

| input | anagram |
| --- | --- |
| below | elbow |
| angered | enraged |
| creative | reactive |
| observe | verbose |

## Things to consider
* input word null/empty/whitespace (empty result)
* input word only one character (empty result)
* case sensitive? (no)
* validate input word = is it contained in wordlist? (not necessary)
* include input word in result? (no - just the anagrams)
* validation of datasource: distinct, whitespaces, etc.
* sorting of result
* multiple words as input
  * "moon starer" -> "astronomer"
  * should "moon starer" also return "moonstarer"? 
* performance
* readability
* tip for the algorithm: Find a key that all anagrams of a word have in common 

## Tricky bonus round
Is it possible to find multiple words anagrams?
	
| input | anagram |
| --- | --- |
| schoolmaster | the classroom |
| astronomer | moon starer |

## Constraint

1. Setup a git repository (or use another SCM that supports resets)
2. Setup a timer for 2 minutes interval when you start
3. Write exactly one test
	- If the timer rings and the test is red then revert and start over
	- If you finish your test earlier: no problem, reset the timer and continue
4. Restart timer
5. Go to 3.
