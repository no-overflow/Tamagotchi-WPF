   M S B A M L   `   `   `  ����E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp042.Ui.Desktop&De.HsFlensburg.ClientApp042.Ui.Desktop  5   	   C ?Logic.Ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Oclr-namespace:De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;assembly=Logic.Ui/De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels 5   	   A    ;De.HsFlensburg.ClientApp042.Ui.Desktop.EditTamagotchiWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Flocal4clr-namespace:De.HsFlensburg.ClientApp042.Ui.Desktop     5   	   f
viewModelsOclr-namespace:De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;assembly=Logic.Ui     5   	     � Title$  Edit Tamagotchi��5	   	    � 
ResizeMode$ NoResize=�6!   $	��340��67   $	��380��6D    � DataContext 5   
   �� 5         ViewModelLocator �� Source# [  6    �� Path$&  TheEditTamagotchiWindowViewModel�5      68   {�5   
   �� 5        MessageListener# [ 6   $ BindableProperty�6@   5       � 	Resources 5       �� 
StartPoint �� EndPoint  gradientBrushRainbow � Color	 � Offset  gradientBrushRainbowButton " gradientBrushRainbowBackground  MyButton
 �� 
TargetType �� Property �� Value �� FallbackValue �� 
TargetType ��Name �� Triggers P� Property P� Value��%  &	       &	 b    &	 �    &	 &    7  �� 5   
   $	 0,0&�6   $	 1,1&�6/   .��5      � $ 	#FFFF4B4B��6   $	 0Q�6-   � 5      $ 	#FFFF8100��6   $		 0.2Q�6-   � 5      $ 	#FFFFD400��6   $		 0.4Q�6-   � 5      $ 	#FF7BFF00��6   $		 0.6Q�6-   � 5      $ 	#FF00FFDA��6   $		 0.7Q�6-   � 5      $ 	#FF7200FF��6   $		 1.0Q�6-   5      �� 5   
   $	 0,0&�6   $	 1,1&�6/   .��5      � $ 	#FFFF2B2B��6   $	 0Q�6-   � 5       $ 	#FFFF8100��6   $		 0.1Q�6-   � 5!      $ 	#FFFFD400��6   $		 0.3Q�6-   � 5"      $ 	#FF3AFF00��6   $		 0.5Q�6-   � 5#      $ 	#FF00B5FF��6   $		 0.6Q�6-   � 5$      $ 	#FF7200FF��6   $		 0.9Q�6-   5%      �� 5'   
   $	 0,0&�6   $	 1,1&�6/   .��5(      � $ 	#FFFF8282��6   $	 0Q�6-   � 5)      $ 	#FFF0912F��6   $		 0.1Q�6-   � 5*      $ 	#FFFFDC32��6   $		 0.3Q�6-   � 5+      $ 	#FF84FF5F��6   $		 0.5Q�6-   � 5,      $ 	#FF4ECCFF��6   $		 0.6Q�6-   � 5-      $ 	#FFA65EFF��6   $		 0.9Q�6-   5.      �� 52   
   "
 ��6!   .�54      ��  � �� 6+   �� * MyTamagotchi.Model.ButtonColor+8   �� 55       � ��
 �����6+   �� 56       � ��$ Center=�6;   �� 57       � ��$ Center=�69   �� 58       � ��$
 10 5q�6(   �� 59       � ��$ 14(�6)   �� 5:       � ��$	 0.7q�60   �� 5;       � �� 5<      �� 5=      " ��6&   .R�5>      � .+�5?      �� $ Border��5@      #��z��5A      #��z��5B      #��z��5C      �� 5E      #��z��5F      #��z��5G      #��z��5H      ��. 5I      5J       5K      P� 5L       � �� . . �5M   "   ��  �@J�OpacityMask �	#AA8888886@   �� 5N   "    � ��$	 2 1q�6;   5O      P� 5P       �@J�IsMouseOver . . �5Q   "   ��  � ��$ 0q�6D   �� 5S   "    � ��
 �����6?   5T      P� 5U       � {� .  . �5V   "   ��  � �� �#ADADAD6?   5W      5Y      5[      5\      5]      .��5`      � ��6   �� *$"MyTamagotchi.Model.BackgroundColor+# [  � RowDefinitions 5a   
   �� 5b      $��1* �6   �� 5c      $��3* �6   �� 5d      $��3* �6   �� 5e      $��1* �6    � ColumnDefinitions 5g   
   �� 5h      6!   �� 5i      6!   �� 5j      6!   .+�5m   
   �� $��20(�6   $��0��6D   $��3��6Q   $
��Bold"�6e   $��Center=�6w   $��Center=�6�   ��6   �� *MyTamagotchi.Name+6�   A� 5o   
   $��1��6   $��0��6#   $��3��63    A� Rows$ 2��6G    A� Columns$ 3��6P   .+�5p      �� $
��Name��6   $��1��6#   $��0��60   $
��Bold"�6@   $��Center=�6R   $��Center=�6o   �� 5q      $��30��69   $	��120��6E   $��1��6Q   $��1��6^   $��Center=�6n   $��Center=�6�   ��6   �� *MyTamagotchi.Name+6�   �� 5r      #��[ 6   $��12q�67   $
��Save��6C   ��6R   �� *SaveTamagotchiCommand+�� 5s      $��Current Color��6   $��1��6,   $��0��69   $
��Bold"�6I   $��Center=�6[   $��Center=�6x   �� 5t      $��30��6�   $	��120��6�   $��1��6�   $��1��6�   $��Center=�6�   $��Center=�6�   ��6   �� *$"MyTamagotchi.Model.TamagotchiColor+# [ 6�   5u      A� 5w   
   $��2��6   $��0��6#   $��3��63   $ 2��6G   $ 4��6P   $��5q�6\   .+�5x      �� $��Change Color��6   $��1��6+   $��0��68   $��2��6H   $
��Bold"�6\   $��Center=�6n   $��Center=�6�   �� 5y      #��[ 6   
���  ��$	��Red��6H   ��6V   �� *ChangeColorToRedCommand+�� 5z      #��[ 6   
��� ���
���   �$��Orange��6^   ��6o   �� *ChangeColorToOrangeCommand+�� 5{      #��[ 6   
��� ���
���   �$��Yellow��6^   ��6o   �� *ChangeColorToYellowCommand+�� 5|      #��[ 6   
��� � �$��Green��6J   ��6Z   �� *ChangeColorToGreenCommand+�� 5}      #��[ 6   
����  �$
��Blue��6I   ��6X   �� *ChangeColorToBlueCommand+�� 5~      #��[ 6   
���� ��$��Violet��6O   ��6`   �� *ChangeColorToVioletCommand+�� 5      #��[ 6   #��[ 67   
���   �$��Rainbow��6}   ��6�   �� *ChangeColorToRainbowCommand+5�      �� 5�   
   $��3��6   $��0��6   $��3��6.   #��[ 6B   $��4q�6d   $��Reset Tamagotchi��6o   ��6�   �� *ResetTamagotchiCommand+5�      5�      