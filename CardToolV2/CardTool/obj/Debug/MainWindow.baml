   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   C ?CardTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CardToolCardTool 5   	   3clr-namespace:CardTool.HelpersCardTool.Helpers 5   	      CardTool.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   'selfclr-namespace:CardTool     5   	   4	Converterclr-namespace:CardTool.Helpers     5   	   -   5          � Title$   The Expirables - Card Tool��5   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanMinimize=�5
   	   $
��1024��5   	   $	��500��6   $
��1024��6$   $	��500��64    � Icon$ Ressources/logo.ico��6D    � 	Resources 5      +  %CardTool.Helpers.ImageSourceConverter   ImageSourceConverter S� 
MethodName S� 
ObjectType   System.Enum  SfxDataProvider S� MethodParameters M� TypeName  CategoryDataProvider  EffectDataProvider	 �� 
TargetType
 �� Property �� Value �� CornerRadius � ToolTip �� ElementName �� Path  HeaderTemplateArrowUp F�Name  HeaderTemplateArrowDown��%u  &	        &	      &	 |     &	 �     '�� R    &	 �    &	 ]      5      6#   S� 5      $ 	GetValues��6   "  6.    5      M� 5      $ self:SfxType��6   5      S� 5      $ 	GetValues��6   "  6.    5      M� 5      $ self:Category��6   5      S� 5      $ 	GetValues��6   "  6.    5       M� 5!      $ self:CardEffect��6   5#      �� 5&      "	 ��6
   .�5'      �� 
 �@=�ErrorTemplate 5(      �� 5)      .R�5*      ]� ��. .+�5+   	   �� 
���  ��$��right=�6!   $��5,0,0,0q�68   $��20��6I   $��20��6T   $ 10��6`    5,   %   �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._�5-   
   �� $��!��6   $��center=�6   $��center=�68   $
��Bold"�6U   
�������5.      5/   
   �� 50   	   $��customAdorner��6#   $��Center=�68   .v�51   
   �� 
���  ��$��1q�6#   52   
   53   	   54      56      57      �� 5:      .R�5;      ]� .+�5<      �� $��Center=�6   ��6-   �� F� 5=      $ arrow��6   $��2��5>      
��� ���+����@KL ��� ���� ��� р�� @KL �@KL ��� 	5@      5A      5B      �� 5D      .R�5E      ]� .+�5F      �� $��Center=�6   ��6-   �� F� 5G      $ arrow��6   $��2��5H      
��� ���+����@KL @KL р�� ��� ���� @KL �@KL @KL 	5J      5K      5L      5N       J� CommandBindings 5S      )  #System.Windows.Input.CommandBinding  5V      -   5           Command$
 Open��5V      6F     5W      -   5        $
 Save��5W      6F     5[      -   5        $ self:CustomCommands.Exit��5[      6Z     5\      -   5        $! self:CustomCommands.AddCard��5\      6`     5]      -   5        $" self:CustomCommands.EditCard��5]      6b     5^      -   5        $$ self:CustomCommands.DeleteCard��5^      6f     5_      -   5        $# self:CustomCommands.ClearDeck��5_      6d     5`      -	   5        $" self:CustomCommands.AddImage��5`      6b   .��5l      � .+�5m      ]� .+�5p      o� $	��Top=�6
   .@�5q      m� ��6   �� *UITranslation.MenuFile+.@�5s      m�  m� Command$
 Open��6>   ��6   �� *UITranslation.MenuItemOpen+6>   m� 5t      $
 Save��6>   ��6   �� *UITranslation.MenuItemSave+6>   m� 5u      $ self:CustomCommands.Exit��6>   ��6   �� *UITranslation.MenuItemExit+6>   5v      m� 5w      $��Edition��6   .@�5x      m� $��Vider le deck��6   $# self:CustomCommands.ClearDeck��6'   5y      5z      �� 5}      -
   5        $��CardDeck��5}   <   $
��Left=�6   $��10q�6$   $	��454��60   ��5~      �� $ CardCollection� �� UpdateSourceTrigger$ PropertyChanged=� �� View 5�      �� 5�      .P�5�      �� $
��U.Id��6    �� Width$	 150��6%    �� DisplayMemberBinding 62   �� $ CardUniqueId��� 5�      $��Titre��6   $	 150��6&    62   �� $ 	CardTitle��� 5�      $��
Catégorie��6   $	 150��6*    66   �� $ CardCategory�5�      5�      �� 5�      $��Bottom=�6    �� Orientation$ 
Horizontal=�6(   $��Center=�6A   .+�5�      �� $��10q�6   $��5q�6   $��Ajouter��6%   $!��self:CustomCommands.AddCard��67   �� 5�      $��10q�6   $��5q�6   $��Editer��6%   $"��self:CustomCommands.EditCard��66   �� 5�      $��10q�6   $��5q�6   $��	Supprimer��6%   $$��self:CustomCommands.DeleteCard��69   5�      � 5�      $��Right=�6
   $��10q�6!    � RowDefinitions 5�      �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $
��Auto �6   �� 5�      $��* �6   �� 5�      $
��Auto �6   �� 5�      $��* �6   �� 5�      $	��200 �6    � ColumnDefinitions 5�      �� 5�      $
��Auto �6   �� 5�      $��* �6   �� 5�      $��30 �6   �� 5�      $
��Auto �6   �� 5�      $��* �6   �� 5�      $��30 �6   .+�5�      �� $��0��6   $��0��6   $��Titre :��6)   �� 5�      -   5        $��
TitleField��5�   Z   $��0��6   $��1��6   $��3q�6+   ��5�      �� $ CurrentCard.CardTitle�$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� 5�      $��1��6   $��0��6   $��Coût :��6)   �� 5�      -   5        $��	CostField��5�   Z   $��1��6   $��1��6   $��3q�6+   ��5�      �� $ CurrentCard.CardCost�$ PropertyChanged=� .  . �� 5�      $��2��6   $��0��6   $��Catégorie :��6)   �� 5�      -   5        $��CategoryField��5�   �   $��2��6   $��1��6   $��3q�6,   ��67   ��  �� Source# [  �� SelectedItem 6}   �� $ CurrentCard.CardCategory�6�   �� 5�      $��0��6   $��3��6   $��Unique ID :��6)   �� 5�      -   5        $��IdField��5�   Z   $��0��6   $��4��6   $��3q�6+   ��5�      �� $ CurrentCard.CardUniqueId�$ PropertyChanged=� .  . �� 5�      $��1��6   $��3��6   $��Global ID :��6)   �� 5�      -   5        $��1��5�      $��4��6   $��3q�6+   ��5�      �� $ CurrentCard.CardGlobalId�$ PropertyChanged=� .  . �� 5�      $��2��6   $��3��6   $��SFX :��6)   �� 5�      -   5        $��SfxField��5�   �   $��2��6   $��4��6   $��3q�6,   ��67   �� # [  6x   �� $ CurrentCard.CardSfx�6�   �� 5�      $��6��6   $��0��6   $��Description :��6)   �� 5�      -   5        $��DescriptionField��5�   _   $��6��6   $��1��6   $��3��6+   $��3q�6?    �� AcceptsReturn .   �� TextWrapping$
  Wrap=�5�      ! �� 	IsEnabled! . " � Language$" fr-FR�6J   ��5�      �� $! CurrentCard.CardDescription��� 5�      $��6��6   $��4��6   $��2��6*   $��5q�6>   $"��self:CustomCommands.AddImage��6I   .��5�      �� .+�5�      �� $
��Fill=�6q   ��6   �� $ CurrentCard.CardImagePath�# �� 	Converter## [  6q   5�      5�      5�      5�      5�      5�      