   M S B A M L   `   `   `  ����D  @MVVMPairs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MVVMPairs.ViewsMVVMPairs.Views  5      #    MVVMPairs.Views.GameBoardView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:MVVMPairs.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6/   $��Center=�6L   $��18(�6g   ��6   �� *	IsRedTurn+6g   �� 5   
   $��1��6   $��Center=�6!   $��Center=�6>   �� 5      $�Numar piese rosi: ��6    �� 5      �6   �� *	RedPieces+5      �� 5   
   $��2��6   $��Center=�6!   $��Center=�6>   �� 5      $�Numar piese albastre: ��6    �� 5   
   �6   �� *
BluePieces+5       �� 5#   
   -   5        $
��grid��5#      $��3��6E   $��Center=�6R   $��Center=�6m   ��6#   �� *	GameBoard+��5$      �� 5%      .R�5&      �� ��6#   �� ��5'      �� 5(      .R�5)   "   ��  �� Orientation$ 
Horizontal=�6-   5*      ��5,      �� 5-      .R�5.   "   �� -   5        $��70��5.   )   $��70��64   $��2q�6@   ���#000000��6j   �� *	CellColor+._�5/   &   A� -   5        $��40��5/   .   $��40��69   ��6E   �� *Piece.Color+6b   50   #   51      53      54      56      57      58      