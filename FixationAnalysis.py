# -*- coding: utf-8 -*-
import pandas as pd
from detectors import fixation_detection
from gazeplotter import draw_fixations

"""
Created on Tue Jun 18 21:54:17 2019

@author: Sozen_Nergiz
"""

q1_regions=[
         [28,31,62,379],
         [129,193,1184,295],
         [1142,88,1372,178],
         [28,379,68,557],
         [65,530,400,628],
         [280,394,436,478]
            
        ]

q2_regions=[
         [420,46,848,154],
         [113,196,583,300]            
        ]

q3_regions=[
         [27,31,63,379],
         [1144,91,1287,180],
         [1258,529,1492,628]            
        ]

q4_regions=[
         [27,378,63,757],
         [450,526,656,641],
         [709,467,804,541]            
        ]

q5_regions=[
         [843,772,1206,1057]
         ]

q6_regions=[
         [27,31,63,379],
         [27,378,63,757],
         [1144,91,1287,180],
         [277,393,449,476],
         [1361,543,1497,626]
         ]

q7_regions=[
         [27,31,63,379],
         [754,204,975,379],
         [871,58,983,148]            
        ]

q8_regions=[
         [27,758,718,1053]
         ]

def is_in_related_region(fx,fy,question_region_matrix):
    for i in range(len(question_region_matrix)):
        center_x=(question_region_matrix[i][2]+question_region_matrix[i][0])/2.0 
        center_y=(question_region_matrix[i][1]+question_region_matrix[i][3])/2.0 
       ## print(question_region_matrix[i][2])
        distance_x=abs(center_x-fx)
        distance_y=abs(center_y-fy)
        bounding_box_half_width=abs(question_region_matrix[i][2]-question_region_matrix[i][0])/2.0
        bounding_box_half_height=abs(question_region_matrix[i][1]-question_region_matrix[i][3])/2.0
       # print("centerx:"+str(center_x)+",fx:"+str(fx)+", centery:"+str(center_y)+", fy:"+str(fy))
        #print(str(distance_x)+" "+str(distance_y)+" "+str(bounding_box_half_width)+" "+str(bounding_box_half_height))
        if distance_x <=bounding_box_half_width and distance_y <=bounding_box_half_height: 
            return 1
    return 0
            

def get_full_file_path(filename):
    return 'd:\Sozen_Nergiz\Desktop\DESKTOP FOLDERS\ANALYSIS CODES PYGAZE\data_nergiz\Split\{}'.format(filename)


for i in range(1,49):
    for j in range(1,9):
    
        if __name__ == '__main__':
            participant = "P"+str(i)+"Result__"+str(j)
            filename = '{}.csv'.format(participant)
            data_frame = pd.read_csv(get_full_file_path(filename), delimiter=';', decimal=',')
         
            print ("{} raws read from CSV File {}".format(len(data_frame), filename))
                
            x_values  = []
            y_values = []
            timestamp_values = []
            
            raw_data = data_frame[['GazeX', 'GazeY', 'Timestamp']].values
            
            for line in raw_data:
                x_values.append(line[0])
                y_values.append(line[1])
                timestamp_values.append(int(line[2])/1000)
            
            Sfix, Efix = fixation_detection(x_values, y_values, timestamp_values)
        
            fixation_start = []
            fixation_end = []
            fixation_duration = []
            fixation_x = []
            fixation_y = []
            inRegions = []
            regionCounter=0
            totalFixation=len(Efix)
            counterQuestionRatio=-1
            totalDurationOfFixations=0
            totalRelevantDuration=0
            relevantRegion=1
            avgDurationOfRelFix=0
            for fixation in Efix:
                fixation_start.append(fixation[0])
                fixation_end.append(fixation[1])
                fixation_duration.append(fixation[2])
                totalDurationOfFixations=totalDurationOfFixations+fixation[2]
                fixation_x.append(fixation[3])
                fixation_y.append(fixation[4])
                inRegion=-1   
                if j==1:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q1_regions)
                    counterQuestionRatio=regionCounter/len(q1_regions)
                    relevantRegion=len(q1_regions)
                elif j==2:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q2_regions)
                    counterQuestionRatio=regionCounter/len(q2_regions)
                    relevantRegion=len(q2_regions)
                elif j==3:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q3_regions)
                    counterQuestionRatio=regionCounter/len(q3_regions)
                    relevantRegion=len(q3_regions)
                elif j==4:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q4_regions)
                    counterQuestionRatio=regionCounter/len(q4_regions)
                    relevantRegion=len(q4_regions)
                elif j==5:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q5_regions)
                    counterQuestionRatio=regionCounter/len(q5_regions)
                    relevantRegion=len(q5_regions)
                elif j==6:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q6_regions)
                    counterQuestionRatio=regionCounter/len(q6_regions)
                    relevantRegion=len(q6_regions)
                elif j==7:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q7_regions)
                    counterQuestionRatio=regionCounter/len(q7_regions)
                    relevantRegion=len(q7_regions)
                elif j==8:
                    inRegion=is_in_related_region(fixation[3],fixation[4],q8_regions)
                    counterQuestionRatio=regionCounter/len(q8_regions)
                    relevantRegion=len(q8_regions)
                  #  print(inRegion)
                if(inRegion==1):
                    regionCounter=regionCounter+1
                    totalRelevantDuration=totalRelevantDuration+fixation[2]
                inRegions.append(inRegion)
            if(regionCounter>0):
                avgDurationOfRelFix=totalRelevantDuration/regionCounter
                
          
            if(totalFixation>0):
                avgDurationOfAllFix=totalDurationOfFixations/totalFixation
                print(str(avgDurationOfAllFix))
                counterEfixRatio=regionCounter/totalFixation
                scanPathPrecision=100*regionCounter/totalFixation
                scanPathRecall=scanPathPrecision/relevantRegion
                
                
                tf=[]
                tf.append(totalFixation)
                tdf=[]
                tdf.append(totalDurationOfFixations)
                adaf=[]
                adaf.append(avgDurationOfAllFix)
                trd=[]
                trd.append(totalRelevantDuration)
                adrf=[]
                adrf.append(avgDurationOfRelFix)
                spp=[]
                spp.append(scanPathPrecision)
                spr=[]
                spr.append(scanPathRecall)
            
                pd.DataFrame({'Participant Id':str(i), 'Question Number':str(j), 'Total Fixations': tf,  'Total duration of Fixations':tdf, 'Avg duration of all fixations':adaf, 
                                          'Total DurationOfRelevantFixation': trd, 'Avg DurationOfRelevantFixation': adrf,
                                          'scan path precision':spp,'Scan path recall':spr}).to_csv('Analysis{}.csv',mode='a',index=False)
        
     
          
                    
#                pd.DataFrame({'F Start': fixation_start,  'F End':fixation_end, 'F Duration':fixation_duration, 
#                                  'F x': fixation_x, 'F y': fixation_y,'In Region':inRegions}).to_csv('Analysis{}.csv'.format(participant), decimal='.')
    
#            draw_fixations(Efix, (1920, 1080), imagefile=get_full_file_path('question1.jpg'), 
#                                  savefilename=get_full_file_path('images\question'+str(j)+'_participant{}_heatmap.jpg'.format(participant)))
                
            
            