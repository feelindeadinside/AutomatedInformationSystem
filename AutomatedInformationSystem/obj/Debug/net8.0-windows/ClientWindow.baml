   M S B A M L   `   `   `  ����U  QAutomatedInformationSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AutomatedInformationSystemAutomatedInformationSystem  5   	   -    'AutomatedInformationSystem.ClientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   :local(clr-namespace:AutomatedInformationSystem     5   	     � Title$  АИС - Клиент��5   	   $	��580��5	   	   $	��950��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   ���#1B1B1B � 	Resources 5       �� 
TargetType   ButtonStyle �� Property �� Value �� 
TargetType ��Name �� CornerRadius��%�  &	        �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 15(�6)   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 2q�60   �� 5       � ��
 �����6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $ 15��61   ���#026c59$��2q�6X   
������ ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � �� �#FFFFFF6+   5      5       .��5"      � .+�5#   
   � .+�5%   
   � $��Center=�6   $	��Top=�6,   $	��950��6D   $��80��6P   	 � ColumnDefinitions	 5&      �� 5'      $��* �6#   �� 5(      $��* �6#   �� 5)      $��* �6#   �� 5*      $��* �6#   .+�5-      �� $ 15��6   
������ $��10q�6@   $��0��6L   ._�5.      �� -   5        $'��!Посмотреть товары��5.      $	��200��65   $��50��6A   #��[  6M   6r   5/      �� 50      $ 15��6   
������ $��10q�6@   $��1��6L   ._�51      �� -   5        $#��Создать продажу��51      $	��200��63   $��50��6?   #��[  6K   6p   52      �� 53      $ 15��6   
������ $��10q�6@   $��2��6L   ._�54      �� -   5        $)��#Посмотреть продажи��54      $	��200��66   $��50��6B   #��[  6N   6s   55      56      �� 59   
   -   5        
 ��Name$
 ProductListPanel��59      $��Bottom=�6/   $��Center=�6J   $	��100q�6g   $y�	Collapsed=�6t   .+�5:      �� -   5         ��Name$ ProductListTextBlock��5:      
�������$��16(�6I   5;      �� 5=   
   -   5        $
 CreateSalePanel��5=      $��Center=�6.   $��Center=�6I   $y�	Collapsed=�6f   $��20q�6}   .+�5>      �� 
�������$��18(�6+   KIВыберите товар и количество для продажи6b   �� 5?      -   5         ��Name$ ProductComboBox��5?      $	��200��60   $��10q�6<   �� 5@      -   5         ��Name$ QuantityTextBox��5@      $	��200��6/   $��10q�6;   $)��#Введите количество��6G   �� 5A      -	   5        $#��Создать продажу��5A      $	��200��6/   $��50��6;   #��[  6G   6l   5B      �� 5E   
   -
   5        $
 SalesListPanel��5E      $��Center=�6-   $��Center=�6H   $	��100q�6e   $y�	Collapsed=�6r   .+�5F      �� -   5        $ SalesListTextBlock��5F      
�������$��16(�6G   5G      5I      5J      5K      