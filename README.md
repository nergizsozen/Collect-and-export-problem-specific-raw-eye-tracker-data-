# eye-tracking
This is a fully functional project written in C# and Python to collect the eye-gaze data collected from users of a complex software diagram. The eye-tracker device used in this project was Tobii Pro 4C eye-tracker. 

This project was a small section of my PhD thesis study, which I investigated the "Effect of Working Memory Capacity for the Understandability of Complex Software Diagrams". You can access the entire document by this title. The functionality of this project is as follows:

* Create a custom screen that displays a complex software diagram positioned on the left and multiple-choice comprehension questions positioned on the right.
* Collects the response(answers) to comprehension questions along with the user_id, response(answer) time, and eye-data of the user including timestamp, coordinates of the eye-fixations, fixation duration. You can check all the eye-metrics I used inside the code using Python language along with the PyGaze toolBox. The collected data then exported to a .csv file uniquely named for every single user.
* Example  images of the environment screens are provided in the images folder.

## How to install this project on your own environment
1. Download the project
2. Use visual studio to open the project
3. Place the entire project folder inside the VB Projects source file. (When you create a new project, Visual Studio saves it to its default location, %USERPROFILE%\source\repos)



##How to tweak this project for your own uses

Since this work was a unique piece of scientific project that was approved by a number of authorities as a part of my PhD thesis study, direct use of the code for academic or commercial purposes are unethical and might cause high similarity indexes. Consider modifying the code regarding your own problem context. 

Contact for any additional questions: nergizsozen







