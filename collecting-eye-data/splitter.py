# -*- coding: utf-8 -*-
"""
Created on Fri Sep 13 14:33:34 2019

@author: Sozen_Nergiz
"""

import pandas
questionCount = 8
participantCount = 48

for participantIndex in range(1, participantCount + 1):
    path = str(participantIndex) + ".csv"
    dataFrame = pandas.read_csv(path, sep=';',index_col=False, decimal=',' ,encoding="iso8859_9")
    cleanedFrame = pandas.DataFrame(dataFrame.dropna(subset=['GazeX', 'GazeY', 'L-PupilDiameter', 'R-PupilDiameter']))
    for questionIndex in range(1, questionCount + 1):    
        newFrame = cleanedFrame[cleanedFrame['QuestionId'] == questionIndex]
        fileName = "Split\\" + "P"+str(participantIndex) + "Result_"+str("_")+str(questionIndex)+".csv"
        newFrame.to_csv(fileName,sep=';', decimal=',' ,encoding="iso8859_9") 
        
        
frame1 = pandas.read_csv("Split\P1Result__1.csv",  sep=';',decimal=',' ,encoding="iso8859_9")
print(frame1.columns)
frame1[frame1['QuestionId'] == 1]


