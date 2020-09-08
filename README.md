# Covid Programming Test

## Problem statement
We are having performance issues with the engine of our simple chatbot.

## Description
Running the console app will load in the data from a csv file, initialize an engine instance and run a few search queries, printing out the results in the console. The only changes you have to make are in the Engine class. 

The engine is based on full word matching. The lowercase words of the question in the data and the lowercase words of the query are being generated. The count of the intersection of these sets of words determines the score of the match. For instance the query "when was SARS exactly identified" yields a score of 4 for the question "When was SARS-CoV-2 first identified?".
