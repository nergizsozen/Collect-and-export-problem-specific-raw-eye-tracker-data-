# -*- coding: utf-8 -*-
"""
Created on Fri Sep 13 14:33:34 2019

@author: Sozen_Nergiz
"""

import pandas as pd


def get_full_file_path(filename):
    return 'd:\Sozen_Nergiz\Desktop\ANALYSIS CODES PYGAZE\data_nergiz\Split{}'.format(filename)


participant = '1'
filename = '{}.csv'.format(participant)
data_frame = pd.read_csv(get_full_file_path(filename), delimiter=';', decimal=',')
data_frame.dropna(how='any',subset=['GazeX','GazeY',	'L-PupilDiameter',	'R-PupilDiameter'])
pd.set_option('display.max_columns', None)
#pd.set_option('display.max_rows', None)
data_frame.head()
#data_frame.to_csv(r'd:\Sozen_Nergiz\Desktop\ANALYSIS CODES PYGAZE\Frame.csv', index = None, header=True)
for i in range(10):
    print(data_frame['GazeX'][i])