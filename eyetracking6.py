# -*- coding: utf-8 -*-
"""
Created on Sat Mar  9 16:15:38 2019

@author: aking
"""

from detectors import fixation_detection, saccade_detection, blink_detection
from gazeplotter import draw_heatmap
import pandas as pd
import glob
import matplotlib.pyplot as plt
import datetime
import numpy as np



def set_csv(sentence_no,files):
    
    format = '%d.%m.%Y %H:%M:%S.%f'

    df = []
    
    
    for i in files:
        df.append(pd.read_excel(i, sheet_name='Worksheet'+str(sentence_no)).fillna(0.0))
        
    Reading_Time  = []
    df_X = []
    df_Y = []
    df4 = []
    
    for j in df:
        j = j[j['Eye'] == 'Right']
        df_X.append(j['X'].values)
        df_Y.append(j['Y'].values)
        df4.append(j['TimeStamp'])
        
      
    df_Time = []
    
    
    for t in df4:
        df3 = []
        for k in t:
            Time = datetime.datetime.strptime('20.12.2018 ' + k, format)
            df3.append(Time.timestamp() * 1000)
            
        df_Time.append(np.array(df3))
        

        
    df_fixation_Sfix = []
    df_fixation_Efix = []
    
    
    
    for x,y,time in zip(df_X,df_Y,df_Time):
        Sfix, Efix = fixation_detection(x*1920,y*1080,time)
        Reading_Time.append(len(x))
        df_fixation_Sfix.append(Sfix)
        df_fixation_Efix.append(Efix)
#        fig = draw_heatmap(fixations= Efix, dispsize=(1920,1080))
    
        
    df_saccade_Ssac = []
    df_saccade_Esac = []
    
    
    for x,y,time in zip(df_X,df_Y,df_Time):
        Ssac, Esac = saccade_detection(x*1920,y*1080,time)
        df_saccade_Ssac.append(Ssac)
        df_saccade_Esac.append(Esac)    
        
    
    return df_fixation_Efix, df_saccade_Esac, Reading_Time
    

    
def main(student_type):
    

    
    saccade = []
    fixation = []  
    df_reading_time = []
      
    for i in range(1,16):
        df_fixation_Efix, df_saccade_Esac, Reading_Time = set_csv(i,student_type)
        
        saccade.append(df_saccade_Esac)
        fixation.append(df_fixation_Efix)
        df_reading_time.append(Reading_Time)

    
    
    
    
    s1,sn,sd,f1,fn,fd,o1,c1,r1,f2 = [],[],[],[],[],[],[],[],[],[]
    
    parameter1 = 0
    
    for s,f,r in zip(saccade,fixation,df_reading_time):
        parameter2 = 0
        parameter1 = parameter1 + 1
        for s3,f3,r3 in zip(s,f,r):
            parameter2 = parameter2 +1
            s1.append(s3)
            sn.append(len(s3))
            sd.append(get_durations(s3))
            f1.append(f3)
            fn.append(len(f3))
            fd.append(get_durations(f3))
            r1.append(r3)
            if(student_type == dyslexia):
                o1.append(student_type[parameter2-1][51:-5])
            elif(student_type == nondyslexia):
                o1.append(student_type[parameter2-1][54:-5])
            c1.append(parameter1)
            if(f3 == []):
                f2.append(0)
            else:
                f2.append(f3[0][2])

    
    my_df  = pd.DataFrame({'Fixation': f1,  'Fixation Number':fn , 'First Fixation Duration':f2 , 'Fixation Duration':fd , 'Saccade':s1, 'Saccade Number':sn , 'Saccade Duration':sd  , 'Reading Time':r1 ,'Sentence_Number':c1, 'Student_Number':o1})
        
    return my_df


def get_durations(df):
    sum_duration = 0
    for i in df:
        sum_duration = sum_duration + i[2]
        
    return sum_duration
       



def chunks(l, n):
    for i in range(0, len(l), n):
        yield l[i:i+n]

if __name__ == '__main__':
    
    dyslexia = glob.glob('C:\\Users\\aking\\OneDrive\\Masaüstü\\Deneyler\\dyslexia\\*.xlsx')
    nondyslexia = glob.glob('C:\\Users\\aking\\OneDrive\\Masaüstü\\Deneyler\\nondyslexia\\*.xlsx')
    
    d = main(dyslexia)
    nd = main(nondyslexia)
    
    nd['label'] = 0
    d['label'] =1
    result=pd.concat([nd, d])
    
    result.to_csv('eyetracking_analyze_result.csv')
    

