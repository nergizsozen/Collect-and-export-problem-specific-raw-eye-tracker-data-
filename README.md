#Collect-export-problem-specific-raw-eye-tracker-data

This project was a small section of my PhD thesis study, which I investigated the "Effect of Working Memory Capacity for the Understandability of Complex Software Diagrams".
*You can access the full article from the repository.


This is a functional project written in C# and Python to collect the eye-gaze data gathered from users which solved a multiple choice comprehension test on a complex software diagram. The eye-tracker device used in this project was Tobii Pro 4C eye-tracker. The collected data is then used for calculating some of the necessary eye-tracking metrics suggested in Holmqvist and Petrusel et.al. 


The functionality of this project is as follows:


* Create a custom screen that displays a complex software diagram positioned on the left and multiple-choice comprehension questions positioned on the right.
* Collect the response(answers) to comprehension questions along with the timestamp, user_id, question number, response(answer), answer time, and eye-data of the user including, coordinates of the lef adn right eye, etc. You can check all the eye-metrics I used inside the code and in my article  using Python language along with the PyGaze toolBox. The collected raw data then exported to a .csv file uniquely named for every single user.
* Splitter.py splits the raw data for each user (participant) according to the problem requirements.
* The splitted raw data for each participant is then used to calculate the eye-tracking metrics:
    1. totalFixation (Holmqvist)
    2. totalDurationOfFixations(Holmqvist)
    3. avgDurationOfAllFix(Holmqvist)
    4. totalRelevantDuration(Holmqvist)
    5. avgDurationOfRelFix(Holmqvist)
    6. scanPathPrecision (Petrusel et.al)
    7. scanPathRecall (Petrusel et.al)
by FixationAnalysis.py 
*Question Id as well as the answer to the question is exported to a seperate .csv file by answersofeachuser.py for every single user.

* Images used in the form application of the project environment  are provided in the images folder.


## How to install this project to your  environment
1. Download the project
2. Use visual studio to open the project
3. Place the entire project folder inside the VB Projects source file. (When you create a new project, Visual Studio saves it to its default location, %USERPROFILE%\source\repos)


##How to tweak this project for your own uses

Since this work was a unique piece of scientific project that was approved by a number of authorities as a part of my PhD thesis study, direct use of the code for academic or commercial purposes are unethical and might cause high similarity indexes. Consider modifying the code regarding your own problem context. 

This program is distributed in the hope that it will be useful,
*but WITHOUT ANY WARRANTY; without even the implied warranty of	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.









