   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	        SalesWPFApp.WindowProducts   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  WindowProducts��5   	   $	��450��6    $	��405��6-   .��5	      � .+�5
   
   �� $	��400��6   $
��Auto��6!   ���	#FF39E5E5.+�5      �� $��Add new Product��6   $��30(�6.   �� 5      $��	Category*��6   �� 5      -   5         ��Name$ 
cbCategory��5       �� DisplayMemberPath$ CategoryName��6+    �� SelectedValuePath$ 
CategoryId��6L    �� SelectedValue 6k   �� *
CategoryId+ � DataContext 6�   �� *SelectedItem+ �� ElementName$ 	lvProduct���� 5      $��Product Name*��6   �� 5      -   5         ��Name$ txtProductName��5   6    �� TextWrapping$
 Wrap=�6   $	��400��6*   66   �� 5      $��Weight*��6   �� 5      -   5        $ 	txtWeight��5   6   $
 Wrap=�6   $	��400��6*   66   �� 5      $��Unit Price*��6   �� 5      -   5        $ txtUnitPrice��5      $
 Wrap=�6,   $	��400��6@   �� 5      $��Unit in Stock*��6   �� 5      -   5        $ txtUnitInStock��5      $
 Wrap=�6.   $	��400��6B   �� 5      $��43��6   	 �� Orientation$	 
Horizontal=�6%   $��Center=�6>   .+�5      �� -   5        
 ��Name$
 btnPrdRefresh��5      $��Refresh��60   $��90��6B   $��-1,1,1,1q�6M   $��5,5,0,5q�6`   $��2,1,1,1q�6q   6�   �� 5      -   5        $
 	btnPrdAdd��5      $	��Add��6,   $��90��6:   $��-1,1,1,1q�6E   $��5,5,0,5q�6X   $��2,1,1,1q�6i   6�   5      5      5      5      