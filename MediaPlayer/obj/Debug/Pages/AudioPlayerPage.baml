   M S B A M L   `   `   `  ����L  HSimpleAudioPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:SimpleAudioPlayer.PagesSimpleAudioPlayer.Pages  5      -    'SimpleAudioPlayer.Pages.AudioPlayerPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:SimpleAudioPlayer.Pages     5        N� Title$  AudioPlayerPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5        $��ButtonStart��5      $��0��6$   $��0��5      
������ $��26��5      $��26��6$   $��
8, 8, 0, 8q�60   .��5      �� $��../Icons/play.png��6   5      �� 5!   
   -   5        $��ButtonPause��5!      $��1��6$   $��0��5"      
������ $��26��5%      $��26��6   $��
8, 8, 0, 8q�6(   .��5&      �� $��../Icons/pause.png��6   5'      �� 5)   
   -   5        $��
ButtonStop��5)      $��2��6#   $��0��5*      
������ $��26��5,      $��26��6    $��
8, 8, 0, 8q�6,   .��5-      �� $��../Icons/stop.png��6   5.      r� 50   
   -   5         r�Name$ MediaElementAudioPlayer��50      $y�	Collapsed=�52      $��1��53       r� LoadedBehavior$ Manual=�54      �� 56   
   -   5        $��SliderAudioPlayer��56      $��3��6*   $��Center=�58       �� IsSelectionRangeEnabled . $��12, 8, 8, 12q�5=      $��0��5>       �� SelectionEnd 5<      ��  �� ElementName$ SliderAudioPlayer�� �� Path$ Value�	 � 	Resources	 5@      
 �� Color��%�   (��       5B      * SystemColors.HighlightBrushKey+)(�� %     5E      *&$SystemColors.ControlDarkDarkBrushKey+)�� 5A      $
 #075888��5C      �� 5D      $
 Silver��5F      5G      5I      �� 5K   
   -   5        $��TextBlockTime��5K      $��4��6)   $��00/00��5L      $��0,8,8,8q�5M      $��Center=�5N      $��0��5O      �� 5Q   
   $��Громкость��6   $��8,8,0,8q�5R      $��0��5S      $��2��6$   $��1��68   �� 5U   
   -   5        $��SliderVolume��5U      $��8,8,8,8q�5V      $��80��5W      $��80��5X       . $
��Left=�5[       � Maximum$
 10.0Q�5]       � Minimum$	 0.0Q�6     � Value$	 5.0Q�6.   $��2��5^      $��2��6!   $��1��65    5\      �� $ SliderVolume��$ Value�	 5`      ��%�   (��       5b      * SystemColors.HighlightBrushKey+)(�� %     5e      *&$SystemColors.ControlDarkDarkBrushKey+)�� 5a      $
 #075888��5c      �� 5d      $
 Silver��5f      5g      5i      5k      5l      