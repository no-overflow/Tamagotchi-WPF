   M S B A M L   `   `   `  ���� E  AUi.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:De.HsFlensburg.ClientApp042.Ui.Desktop&De.HsFlensburg.ClientApp042.Ui.Desktop  C ?Logic.Ui, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Oclr-namespace:De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;assembly=Logic.Ui/De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels A    ;De.HsFlensburg.ClientApp042.Ui.Desktop.EditTamagotchiWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Flocal4clr-namespace:De.HsFlensburg.ClientApp042.Ui.Desktop     f
viewModelsOclr-namespace:De.HsFlensburg.ClientApp042.Logic.Ui.ViewModels;assembly=Logic.Ui       � Title$  Edit Tamagotchi�� � 
ResizeMode$ NoResize=�$	��340��$	��380�� � DataContext ��    ViewModelLocator �� Source# [   �� Path$&  TheEditTamagotchiWindowViewModel�{���   MessageListener# [ $ BindableProperty� � 	Resources  �� 
StartPoint �� EndPoint  gradientBrushRainbow � Color	 � Offset  gradientBrushRainbowButton " gradientBrushRainbowBackground  MyButton
 �� 
TargetType �� Property �� Value �� FallbackValue �� 
TargetType ��Name �� Triggers P� Property P� Value��%�  &	       &	 �     &	 �    &	 |    7  �� $	 0,0&�$	 1,1&�.��� $ 	#FFFF4B4B��$	 0Q�� $ 	#FFFF8100��$		 0.2Q�� $ 	#FFFFD400��$		 0.4Q�� $ 	#FF7BFF00��$		 0.6Q�� $ 	#FF00FFDA��$		 0.7Q�� $ 	#FF7200FF��$		 1.0Q��� $	 0,0&�$	 1,1&�.��� $ 	#FFFF2B2B��$	 0Q�� $ 	#FFFF8100��$		 0.1Q�� $ 	#FFFFD400��$		 0.3Q�� $ 	#FF3AFF00��$		 0.5Q�� $ 	#FF00B5FF��$		 0.6Q�� $ 	#FF7200FF��$		 0.9Q��� $	 0,0&�$	 1,1&�.��� $ 	#FFFF8282��$	 0Q�� $ 	#FFF0912F��$		 0.1Q�� $ 	#FFFFDC32��$		 0.3Q�� $ 	#FF84FF5F��$		 0.5Q�� $ 	#FF4ECCFF��$		 0.6Q�� $ 	#FFA65EFF��$		 0.9Q��� "
 ��.���  � �� �� * MyTamagotchi.Model.ButtonColor+8   ��  � ��
 �������  � ��$ Center=���  � ��$ Center=���  � ��$
 10 5q���  � ��$ 14(���  � ��$	 0.7q���  � �� �� " ��.R�� .+��� $ Border��#��z��#��z��#��z���� #��z��#��z��#��z����.  P�  � �� . . ���  �@J�OpacityMask �	#AA888888��  � ��$	 2 1q�P�  �@J�IsMouseOver . . ���  � ��$ 0q���  � ��
 �����P�  � {� .  . ���  � �� �#ADADAD.��� ���� *$"MyTamagotchi.Model.BackgroundColor+# [  � RowDefinitions �� $��1* ��� $��3* ��� $��3* ��� $��1* � � ColumnDefinitions �� �� �� .+��� $��20(�$��0��$��3��$
��Bold"�$��Center=�$��Center=����� *MyTamagotchi.Name+A� $��1��$��0��$��3�� A� Rows$ 2�� A� Columns$ 3��.+��� $
��Name��$��1��$��0��$
��Bold"�$��Center=�$��Center=��� $��30��$	��120��$��1��$��1��$��Center=�$��Center=����� *MyTamagotchi.Name+�� #��[ $��12q�$
��Save������ *SaveTamagotchiCommand+�� $��Current Color��$��1��$��0��$
��Bold"�$��Center=�$��Center=��� $��30��$	��120��$��1��$��1��$��Center=�$��Center=����� *$"MyTamagotchi.Model.TamagotchiColor+# [ A� $��2��$��0��$��3��$ 2��$ 4��$��5q�.+��� $��Change Color��$��1��$��0��$��2��$
��Bold"�$��Center=�$��Center=��� #��[ 
���  ��$	��Red������ *ChangeColorToRedCommand+�� #��[ 
��� ���
���   �$��Orange������ *ChangeColorToOrangeCommand+�� #��[ 
��� ���
���   �$��Yellow������ *ChangeColorToYellowCommand+�� #��[ 
��� � �$��Green������ *ChangeColorToGreenCommand+�� #��[ 
����  �$
��Blue������ *ChangeColorToBlueCommand+�� #��[ 
���� ��$��Violet������ *ChangeColorToVioletCommand+�� #��[ #��[ 
���   �$��Rainbow������ *ChangeColorToRainbowCommand+�� $��3��$��0��$��3��#��[ $��4q�$��Reset Tamagotchi������ *ResetTamagotchiCommand+