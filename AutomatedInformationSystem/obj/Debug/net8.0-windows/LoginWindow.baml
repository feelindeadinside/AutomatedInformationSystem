   M S B A M L   `   `   `  ����U  QAutomatedInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AutomatedInformationSystemAutomatedInformationSystem  5   	   ,    &AutomatedInformationSystem.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   :local(clr-namespace:AutomatedInformationSystem     5   	     � Title$  Вход��5   	   $	��580��5	   	   $	��950��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#1B1B1B � 	Resources 5         CustomTextBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name ��Name	 J� SnapsToDevicePixels
 �� Triggers P� Property P� Value �� 
TargetName  ButtonStyle �� CornerRadius��%�  &	        &	 �    �� 5   
   " ��6+   .�5      ��  � �� �#3333336+   �� 5       � �� �#CCCCCC6,   �� 5       �@��
CaretBrush
 �����6+   �� 5       � ��$ 0,0,0,2q�60   �� 5       � ��$ 5q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � .+�5      �� $ PART_ContentHost��6+   $|�false��6E   $��Hidden=�6W   $��Hidden=�6~   �� 5      $ border��6%   #��z��65   #��z��6a   #��z��6�   $
	 True��6�   5      
 5      P� 5       � {�$ false��6;   . �5   "   �� $ border��6)    � �� �#8888886T   �� 5   "    � �� �#8888886?   5      5!      5#      5$      �� 5&   
   " ��6   .�5'      ��  � ��
 �����6+   �� 5(       � ��$ 15(�6)   �� 5)       �@�Cursor$
 Hand��6'   �� 5*       � ��$ 2q�60   �� 5+       � ��
 �����6,   �� 5,       � �� 5-      �� 5.      " ��6&   .R�5/      �� $ border��6!   $ 15��61   ���#026c59$��2q�6X   
������ ._�50      �� $��Center=�6/   $��Center=�6L   51      52      54      �� 55       � �� �#FFFFFF6+   56      58      .��59      � .+�5:   
   �� $��Center=�6   $��Center=�62   .+�5;      �� $ ��Вход в аккаунт��5<      $��20(�5=      $��Normal$�5>      ���#FFFFFF$��Bottom=�5@      $��Center=�5A      $��Normal"�5B      $��0 -150 0 20q�5C      �� 5E      $	 15 ��6   
������ $��0 0 0 0q�5G      5H      �� 5I      -   5        $��UsernameTextBox��5K      #��[  5I      ���#FFFFFF
������ $%��Имя пользователя��5M      $��16(�5N      $��0 10 0 0q�5P      .��6(   5Q      �� 5R      -   5        $��PasswordTextBox��5U      #��[  5R      ���#FFFFFF
������ $��Пароль��5V      $��16(�5W      $��	0 10 0 10q�5Y      .��6)   5Z      �� 5[      $	 15 ��6   
������ $��0 15 0 0q�5]      ._�5^      �� -   5        $��
Войти��5^      $	��200��5_      $��40��5`      #��[ 5b      5c      �� 5d      $	 15 ��6   
������ $��0 15 0 0q�5f      ._�5g      �� -   5        $,��&Вернуться на главную��5g      $	��200��5h      $��40��5i      #��[ 5k      5l      5m      5n      5o      