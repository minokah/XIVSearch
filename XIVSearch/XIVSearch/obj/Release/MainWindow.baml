   M S B A M L   `   `   `  ���� D  @XIVSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:XIVSearch	XIVSearch      XIVSearch.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:XIVSearch       � Title$  FFXIV Search��$	��450��$	��920�� � 
ResizeMode$ CanMinimize=�.��� ���	#FF1E1E1E$��0q� � ColumnDefinitions �� .+�� $
��Left=�$	��419��$	��Top=�$��63�����	#FFF0F0F0.+��� -    ��Name$ SidebarMenu��$
��Left=�$��63��$	��Top=�$��63��$��Resources/Logo.png�� � Cursor$
 Hand���� -   $ SidebarSearch��$
��Left=�$��63��$	��Top=�$��63��$��Resources/Search.png��$��0,68,0,0q� J� Opacity$	 0.5Q�$
 Hand���� -   $ SidebarCSearch��$
��Left=�$��63��$	��Top=�$��63��$��Resources/CSearch.png��$��	0,136,0,0q�$	 0.5Q�$
 Hand���� -   $ SidebarSettings��$
��Left=�$��63��$	��Top=�$��63��$��Resources/Sidebar.png��$��	0,346,0,0q�$	 0.5Q�$
 Hand��� -    �Name$ CharacterFrame��$
��Left=�$	��419��$��63,0,0,0q�$	��Top=�$	��851��$ 1Q�$y�Hidden=�.+��� -   $ CharacterCard��$
��Left=�$	��419��$	��Top=�$	��307��$���~https://img2.finalfantasyxiv.com/f/0afb42c62fb49a08c6c2aae7642ce19a_2e97c13fdd593d15d543093f8a37b6f0fl0_640x873.jpg?1635892830��$y�Visible=�� -   $ CharacterBanner��$
��Left=�$��88��$��	307,0,0,0q�$	��Top=�$	��544������  �� EndPoint$ 0.5,1&� � MappingMode$ RelativeToBoundingBox=�	 �� 
StartPoint$	 0.5,0&�.��� 
 � Color$
 	#FFE0B319�� � Offset$	 0.3Q�� $
 	#FF856C21��.+��� -    ��Name$ CharacterName��$��Player Name��$
��Left=�$��10,6,0,0q�$	��Top=�
�������$��28(�$
��Bold"�$��Dubai)��� -	   $ CharacterJob��$	��Job��$��Right=�$��	0,10,23,0q�$	��Top=����	#FFFFC500$��24(�$
��Bold"�$��Dubai)��� -
   $ CharacterJobLevel��$��Lv. 99��$��Right=�$��	0,43,23,0q�$	��Top=�
�������$��16(�$
��Bold"�$��Dubai)��� -   $ CharacterWorld��$��Server (Data Center)��$
��Left=�$��	10,43,0,0q�$	��Top=����	#FFE2E2E2$��16(�$��Dubai)��� -   $ CharacterJobIcon��$
��Left=�$��28��$��
445,47,0,0q�$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/E/d0Tx-vhnsMYfYpGe9MvslemEfg.png��� -   $ CharacterGCBanner��$
��Left=�$��61��$��
307,88,0,0q�$	��Top=�$	��544������ $ 0.5,1&�$	 0.5,0&�.��� $
 	#FFF0F0F0��$ 1Q�� $
 	#FFA6A6A6��.+��� -   $ CharacterGCLogo��$
��Left=�$��37��$��	20,11,0,0q�$	��Top=�$��37��$A��;https://ffxiv.gamerescape.com/w/images/a/aa/Recruiticon.png���� -   $ CharacterGC��$��No Allegiance��$
��Left=�$��	65,-1,0,0q�$	��Top=����	#FF1E1E1E$��20(�$��Dubai)�$
��Bold"��� -   $ CharacterGCRank��$1��+This person has not joined a Grand Company.��$
��Left=�$��	65,24,0,0q�$	��Top=����	#FF1E1E1E$��16(�$��Dubai)�� $
��Left=�$��81��$��307,149,0,0q�$	��Top=�$	��544��.+��� -   $ CharacterGender��$
��Left=�$��37��$��	20,20,0,0q�$	��Top=�$��37��$p��jhttps://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/male-sign_2642-fe0f.png���� -   $ CharacterRace��$
��Race��$
��Left=�$��62,0,0,0q�$	��Top=����	#FFFFC500$��20(�$��Dubai)�$
��Bold"��� -   $ CharacterRaceClan��$
��Clan��$
��Left=�$��	62,24,0,0q�$	��Top=�
�������$��16(�$��Dubai)��� -   $ CharacterNameday��$��Nameday��$
��Left=�$��	62,44,0,0q�$	��Top=�
�������$��16(�$��Dubai)��� -   $ CharacterCity��$��Right=�$��25��$��	0,24,53,0q�$	��Top=�$��25��$L��Fhttps://img.finalfantasyxiv.com/lds/h/u/ZHuDKgNULSbEA_VTXdjeA9MlEs.png���� -   $ CharacterGuardian��$��Right=�$��25��$��	0,24,23,0q�$	��Top=�$��25��$L��Fhttps://img.finalfantasyxiv.com/lds/h/T/3mefpQgIoLOwIfEiTxmEuoncW8.png��� -   $ CharacterFCFrame��$
��Left=�$��54��$��307,230,0,0q�$	��Top=�$	��544��$y�Hidden=�.+��� -   $ CharacterFCCrest��$
��Left=�$��37��$��20,7,0,0q�$	��Top=�$��37��$p��jhttps://emojipedia-us.s3.dualstack.us-west-1.amazonaws.com/thumbs/120/facebook/304/male-sign_2642-fe0f.png�� J� RenderTransformOrigin$ 0.541,0.216&��� -   $ CharacterFC��$��Free Company��$
��Left=�$��	62,-5,0,0q�$	��Top=����	#FFFFC500$��20(�$��Dubai)�$
��Bold"��� -   $ CharacterFCTag��$��Clan Tag��$
��Left=�$��	62,18,0,0q�$	��Top=�
�������$��16(�$��Dubai)�� $
��Left=�$	��135��$��307,284,0,0q�$	��Top=�$	��544��.+�� $
��Left=�$��54��$��	20,10,0,0q�$	��Top=�$��27��.+��� -   $ CharacterJobPLD��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/E/d0Tx-vhnsMYfYpGe9MvslemEfg.png��$ 0.963,0.536&��� -   $ CharacterJobPLDLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��	47,10,0,0q�$	��Top=�$��27��.+��� -   $ CharacterJobWAR��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/y/A3UhbjZvDeN3tf_6nJ85VP0RY0.png��$ 0.963,0.536&��� -   $ CharacterJobWARLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��	74,10,0,0q�$	��Top=�$��27��.+��� -   $ CharacterJobDRK��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/l/5CZEvDOMYMyVn2td9LZigsgw9s.png��$ 0.963,0.536&��� -    $ CharacterJobDRKLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
101,10,0,0q�$	��Top=�$��27��.+��� -!   $ CharacterJobGNB��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/8/hg8ofSSOKzqng290No55trV4mI.png��$ 0.963,0.536&��� -"   $ CharacterJobGNBLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
128,10,0,0q�$	��Top=�$��27��.+��� -#   $ CharacterJobWHM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/7/i20QvSPcSQTybykLZDbQCgPwMw.png��$ 0.963,0.536&��� -$   $ CharacterJobWHMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
155,10,0,0q�$	��Top=�$��27��.+��� -%   $ CharacterJobSCH��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/7/WdFey0jyHn9Nnt1Qnm-J3yTg5s.png��$ 0.963,0.536&��� -&   $ CharacterJobSCHLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
182,10,0,0q�$	��Top=�$��27��.+��� -'   $ CharacterJobAST��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/1/erCgjnMSiab4LiHpWxVc-tXAqk.png��$ 0.963,0.536&��� -(   $ CharacterJobASTLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
209,10,0,0q�$	��Top=�$��27��.+��� -)   $ CharacterJobMNK��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/K/HW6tKOg4SOJbL8Z20GnsAWNjjM.png��$ 0.963,0.536&��� -*   $ CharacterJobMNKLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
236,10,0,0q�$	��Top=�$��27��.+��� -+   $ CharacterJobDRG��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/m/gX4OgBIHw68UcMU79P7LYCpldA.png��$ 0.963,0.536&��� -,   $ CharacterJobDRGLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
263,10,0,0q�$	��Top=�$��27��.+��� --   $ CharacterJobNIN��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/0/Fso5hanZVEEAaZ7OGWJsXpf3jw.png��$ 0.963,0.536&��� -.   $ CharacterJobNINLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
290,10,0,0q�$	��Top=�$��27��.+��� -/   $ CharacterJobSAM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/m/KndG72XtCFwaq1I1iqwcmO_0zc.png��$ 0.963,0.536&��� -0   $ CharacterJobSAMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
317,10,0,0q�$	��Top=�$��27��.+��� -1   $ CharacterJobBRD��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/F/KWI-9P3RX_Ojjn_mwCS2N0-3TI.png��$ 0.963,0.536&��� -2   $ CharacterJobBRDLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
344,10,0,0q�$	��Top=�$��27��.+��� -3   $ CharacterJobMCH��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/E/vmtbIlf6Uv8rVp2YFCWA25X0dc.png��$ 0.963,0.536&��� -4   $ CharacterJobMCHLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
373,10,0,0q�$	��Top=�$��27��.+��� -5   $ CharacterJobDNC��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/t/HK0jQ1y7YV9qm30cxGOVev6Cck.png��$ 0.963,0.536&��� -6   $ CharacterJobDNCLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
400,10,0,0q�$	��Top=�$��27��.+��� -7   $ CharacterJobBLM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/P/V01m8YRBYcIs5vgbRtpDiqltSE.png��$ 0.963,0.536&��� -8   $ CharacterJobBLMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
427,10,0,0q�$	��Top=�$��27��.+��� -9   $ CharacterJobSMN��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/h/4ghjpyyuNelzw1Bl0sM_PBA_FE.png��$ 0.963,0.536&��� -:   $ CharacterJobSMNLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
454,10,0,0q�$	��Top=�$��27��.+��� -;   $ CharacterJobRDM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/q/s3MlLUKmRAHy0pH57PnFStHmIw.png��$ 0.963,0.536&��� -<   $ CharacterJobRDMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
481,10,0,0q�$	��Top=�$��27��.+��� -=   $ CharacterJobBLU��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/p/jdV3RRKtWzgo226CC09vjen5sk.png��$ 0.963,0.536&��� ->   $ CharacterJobBLULevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��	20,64,0,0q�$	��Top=�$��27��.+��� -?   $ CharacterJobCRP��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/v/YCN6F-xiXf03Ts3pXoBihh2OBk.png��$ 0.963,0.536&��� -@   $ CharacterJobCRPLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��	47,64,0,0q�$	��Top=�$��27��.+��� -A   $ CharacterJobBSM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/5/EEHVV5cIPkOZ6v5ALaoN5XSVRU.png��$ 0.963,0.536&��� -B   $ CharacterJobBSMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��	74,64,0,0q�$	��Top=�$��27��.+��� -C   $ CharacterJobARM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/G/Rq5wcK3IPEaAB8N-T9l6tBPxCY.png��$ 0.963,0.536&��� -D   $ CharacterJobARMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
101,64,0,0q�$	��Top=�$��27��.+��� -E   $ CharacterJobGSM��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/L/LbEjgw0cwO_2gQSmhta9z03pjM.png��$ 0.963,0.536&��� -F   $ CharacterJobGSMLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
128,64,0,0q�$	��Top=�$��27��.+��� -G   $ CharacterJobLTW��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/b/ACAcQe3hWFxbWRVPqxKj_MzDiY.png��$ 0.963,0.536&��� -H   $ CharacterJobLTWLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
155,64,0,0q�$	��Top=�$��27��.+��� -I   $ CharacterJobWVR��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/X/E69jrsOMGFvFpCX87F5wqgT_Vo.png��$ 0.963,0.536&��� -J   $ CharacterJobWVRLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
182,64,0,0q�$	��Top=�$��27��.+��� -K   $ CharacterJobALC��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/C/bBVQ9IFeXqjEdpuIxmKvSkqalE.png��$ 0.963,0.536&��� -L   $ CharacterJobALCLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
209,64,0,0q�$	��Top=�$��27��.+��� -M   $ CharacterJobCUL��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/m/1kMI2v_KEVgo30RFvdFCyySkFo.png��$ 0.963,0.536&��� -N   $ CharacterJobCULLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
236,64,0,0q�$	��Top=�$��27��.+��� -O   $ CharacterJobMIN��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/A/aM2Dd6Vo4HW_UGasK7tLuZ6fu4.png��$ 0.963,0.536&��� -P   $ CharacterJobMINLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
263,64,0,0q�$	��Top=�$��27��.+��� -Q   $ CharacterJobBTN��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/I/jGRnjIlwWridqM-mIPNew6bhHM.png��$ 0.963,0.536&��� -R   $ CharacterJobBTNLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
290,64,0,0q�$	��Top=�$��27��.+��� -S   $ CharacterJobFSH��$
��Left=�$��28��$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/x/B4Azydbn7Prubxt7OL9p1LZXZ0.png��$ 0.963,0.536&��� -T   $ CharacterJobFSHLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
344,64,0,0q�$	��Top=�$��27��.+��� -U   $ CharacterJobEureka��$
��Left=�$��28��$	��Top=�$��27��$R��Lhttps://ffxiv.gamerescape.com/w/images/thumb/d/db/061833.png/32px-061833.png��$ 0.963,0.536&��� -V   $ CharacterJobEurekaLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� $
��Left=�$��54��$��
371,64,0,0q�$	��Top=�$��27��.+��� -W   $ CharacterJobBozja��$
��Left=�$��28��$	��Top=�$��27��$e��_https://static.wikia.nocookie.net/finalfantasy/images/0/01/FFXIV_Bozja_Icon.png/revision/latest��$ 0.963,0.536&��� -X   $ CharacterJobBozjaLevel��$��99��$��2,22,1,0q�$	��Top=�
�������$��13(�$��Dubai)�$ 4.796,0.405&�$��28��� -Y   $ ItemSearchFrame��$
��Left=�$	��421��$��63,0,0,0q�$	��Top=�$	��851��$y�Hidden=�{�.  $ 1Q� K� ZIndex$ -1��.+��� $��Item Search��$
��Left=�$��	21,10,0,0q�$	��Top=�
�������$
��Bold"�$��24(�$��Dubai)��� -Z    ��Name$ ItemSearchBox��$
��Left=�$��35��$��	21,82,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��295��$��Dubai)�$��21(����	#FF3E3E3E
������� �� SelectionBrush �	#FF811B1B��Z� �� $)��#Enter an item name to find out more��$
��Left=�$��	21,45,0,0q�$	��Top=�
�������$��16(�$��Dubai)�� -[   $ ItemSearchErrorFrame��$
��Left=�$��40��$��
21,355,0,0q�$	��Top=�$	��295�����	#FFFF3030$y�Hidden=�.+��� -\   $ ItemSearchErrorMessage��$��Error Message��$
��Left=�$��37,3,0,0q�$	��Top=�$��Dubai)�$��14(�$ 0.495,-0.324&�
�������$��30���� $
��Left=�$��40��$	��Top=�$��40��$��Resources/ErrorWhite.png��$��2,-1,0,0q��� -]    ��Name$ ItemSearchFind��
���   �$��1q�$
��Left=�$��30��$��
21,122,0,0q�$	��Top=�$	��295�� �� CornerRadius$ 5�����	#FF3993E4$
 Hand��._��� $��Search��$��-1q�
�������$��30��$��Dubai)�$��15(�$��Center=��� -^    ��Name$ ItemSearchResults��$
��Left=�$	��366��$��
466,45,0,0q�$	��Top=�$	��375����Z� ��Z� ��Z� � -_   $ ItemSearchResultsHeader��$
��Left=�$��45��$��	456,0,0,0q�$	��Top=�$	��385��$y�Hidden=����� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF2B2B2B��$ 0Q�� $
 	#FF1B1B1B��$ 1Q�.+��� $��Results��$
��Left=�$��10,6,0,0q�$	��Top=�
�������$��Dubai)�$��18(�$
��Bold"�� $
��Left=�$��29��$��
21,187,0,0q�$	��Top=�$	��295�����	#FFCB1818.+��� $	��Job��$
��Left=�$	��Top=�
�������$��16(�$��Dubai)�$��40��$��Center=�$��29��$��0,-3,0,0q��� -`    ��Name$ ItemSearchFilterJob��$
��Left=�$��89,0,0,0q�$	��Top=�$	��206��
���   �$��29��$��Dubai)�$��16(���Z� ��Z� .@��� $��
Tanky Tank��
���   �$��Dubai)����	#00000000�� $��Healy Healer���� $��Damaging DPS��� -a   $ CharSearchFrame��$
��Left=�$	��421��$��63,0,0,0q�$	��Top=�$	��851��$y�Hidden=�{�.  $ 1Q�$ -1��.+��� $��Character Lookup��$
��Left=�$��	21,10,0,0q�$	��Top=�
�������$
��Bold"�$��24(�$��Dubai)��� -b   $ CharSearchBox��$
��Left=�$��35��$��	21,82,0,0q�$
 Wrap=�$	��Top=�$	��295��$��Dubai)�$��21(����	#FF3E3E3E
������� �	#FF811B1B��Z� �� $+��%Enter a character's name to find them��$
��Left=�$��	21,45,0,0q�$	��Top=�
�������$��16(�$��Dubai)�� -c   $ CSearchErrorFrame��$
��Left=�$��40��$��
21,355,0,0q�$	��Top=�$	��295�����	#FFFF3030$y�Hidden=�.+��� -d   $ CSearchErrorMessage��$��Error Message��$
��Left=�$��37,3,0,0q�$	��Top=�$��Dubai)�$��14(�$ 0.495,-0.324&�
�������$��30���� $
��Left=�$��40��$	��Top=�$��40��$��Resources/ErrorWhite.png��$��2,-1,0,0q��� -e   $ CharSearchFind��
���   �$��1q�$
��Left=�$��30��$��
21,122,0,0q�$	��Top=�$	��295��$ 5�����	#FF3993E4$
 Hand��._��� $��Search��$��-1q�
�������$��30��$��Dubai)�$��15(�$��Center=��� -f   $ CharSearchResults��$
��Left=�$	��366��$��
466,45,0,0q�$	��Top=�$	��375����Z� ��Z� ��Z� � -g   $ CharSearchResultsHeader��$
��Left=�$��45��$��	456,0,0,0q�$	��Top=�$	��385��$y�Hidden=����� $ 0.5,1&�$	 0.5,0&�.��� $
 	#FF2B2B2B��$ 0Q�� $
 	#FF1B1B1B��$ 1Q�.+��� $��Results��$
��Left=�$��10,6,0,0q�$	��Top=�
�������$��Dubai)�$��18(�$
��Bold"�� -h   $ 	MenuFrame��$
��Left=�$	��421��$��63,0,0,0q�$	��Top=�$	��851��$ 1Q�$y�Hidden=�$ 0��.+��� $#��Final Fantasy XIV Search Tool��$
��Left=�$��	21,10,0,0q�$	��Top=�
�������$
��Bold"�$��24(�$��Dubai)��� $<��6Search for things from the critically acclaimed MMORPG��$
��Left=�$��	21,45,0,0q�$	��Top=�
�������$��16(�$��Dubai)��� $
��Left=�$	��622��$��500,-27,-271,-174q�$	��Top=�$	��622��$��Resources/Moogle.png��{�.  �� $��1q�$
��Left=�$	��103��$��
20,281,0,0q�$	��Top=�$	��398��$ 5�����	#FF525CC9._�� .+�A� $
��Left=�$��87��$��19,7,0,0q�$	��Top=�$��87������  �� ImageSource$# Resources/ProfileTemplate.png���� $��Select Character��$
��Left=�$��
159,17,0,0q�$	��Top=�
�������$��20(�$��Dubai)�$
��Bold"��� $��Perks go here��$��181,45,111,18q�
�������$��16(�$��Dubai)��� -i   $ TopographyFilter��$
��Left=�$	��658��$��-92,-136,-116,-101q�$	��Top=�$
��1122��$��Resources/Topo.png��$ 0.5,0.5&�$ -2��$	 0.2Q�$y�Hidden=�z�V� .~��� �� ��  �� Angle$ 19.345Q�T� � -j   $ SettingsFrame��$
��Left=�$	��421��$��63,0,0,0q�$	��Top=�$	��851��$ 1Q�$y�Hidden=�$ -1��.+��� $��Settings��$
��Left=�$��	20,10,0,0q�$	��Top=�
�������$
��Bold"�$��24(�$��Dubai)�A� $
��Left=�$��65��$��
20,288,0,0q�$	��Top=�$��65������ $ Resources/Credit.png���� $��minokah��$
��Left=�$��
96,289,0,0q�$	��Top=�
�������$��20(�$��Dubai)�$
��Bold"��� $#��Windows Xp (Malboro, Crystal)��$��96,315,540,68q�
�������$��16(�$��Dubai)��� $��Settings? What settings?��$
��Left=�$��
20,115,0,0q�$	��Top=�
�������$��16(�$��Dubai)��� $��1q�$
��Left=�$��32��$��
96,353,0,0q�$	��Top=�$��98��$ 5��
�������._�� -k   $ SettingsGitHub��$
��Left=�$��32��$��-1q�$	��Top=�$��98��$
 Hand��.+��� $
��Left=�$��24��$��7,4,0,0q�$	��Top=�$��24��$��Resources/GitHub.png���� $��GitHub��$��
32,-1,7,-5q�
���   �$��16(�$��Dubai)�$
��Bold"��� $
��Left=�$	��450��$��287,-15,-11,-14q�$	��Top=�$	��575��$ ��Resources/SettingsBlur.png��{�.  $	 0.5Q�� -l   $ 	ItemFrame��$
��Left=�$	��419��$��63,0,0,0q�$	��Top=�$	��851��$ 1Q�$y�Visible=�.+�� -m   $ 
ItemBanner��$
��Left=�$��88��$	��Top=�$	��851������ $ 0.5,1&�$ RelativeToBoundingBox=�$	 0.5,0&�.��� $
 	#FFEA87B9��$	 0.3Q�� $
 	#FFBCB2DA��.+��� -n   $ ItemName��$��	Item Name��$
��Left=�$��	112,6,0,0q�$	��Top=�
�������$��28(�$
��Bold"�$��Dubai)��� -o   $ ItemJob��$	��Job��$��Right=�$��	0,10,23,0q�$	��Top=����	#FFFFC500$��24(�$
��Bold"�$��Dubai)��� -p   $ ItemJobLevel��$��Lv. 99��$��Right=�$��	0,43,23,0q�$	��Top=�
�������$��16(�$
��Bold"�$��Dubai)��� -q   $ 	ItemLevel��$��Item Level 999��$
��Left=�$��
112,43,0,0q�$	��Top=����	#FFE2E2E2$��16(�$��Dubai)��� -r   $ ItemJobIcon��$
��Left=�$��28��$��
750,47,0,0q�$	��Top=�$��27��$L��Fhttps://img.finalfantasyxiv.com/lds/h/E/d0Tx-vhnsMYfYpGe9MvslemEfg.png���� -s   $ ItemIcon��$
��Left=�$��70��$��20,8,0,0q�$	��Top=�$��70���� -t   $ ItemDescription��$��Description��$
��Left=�$��
20,110,0,0q�$	��Top=����	#FFE2E2E2$��16(�$��Dubai)�