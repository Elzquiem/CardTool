   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  C ?CardTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:CardToolCardTool 3clr-namespace:CardTool.HelpersCardTool.Helpers    CardTool.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6sys&clr-namespace:System;assembly=mscorlib     'selfclr-namespace:CardTool     4	Converterclr-namespace:CardTool.Helpers     -     � Title$   The Expirables - Card Tool�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ CanMinimize=�$
��1024��$	��500��$
��1024��$	��500�� � Icon$ Ressources/logo.ico�� � 	Resources +  %CardTool.Helpers.ImageSourceConverter   ImageSourceConverter S� 
MethodName S� 
ObjectType   System.Enum  SfxDataProvider S� MethodParameters M� TypeName  CategoryDataProvider  EffectDataProvider	 �� 
TargetType
 �� Property �� Value �� CornerRadius � ToolTip �� ElementName �� Path  HeaderTemplateArrowUp F�Name  HeaderTemplateArrowDown��%F  &	        &	      &	 ;     &	 r     '�� �     &	 
    &	 �      S� $ 	GetValues��"   M� $ self:SfxType��S� $ 	GetValues��"   M� $ self:Category��S� $ 	GetValues��"   M� $ self:CardEffect���� "	 ��.��� 
 �@=�ErrorTemplate �� .R�]� ��. .+��� 
���  ��$��right=�$��5,0,0,0q�$��20��$��20��$ 10�� �� $ customAdorner��$8 2AdornedElement.(Validation.Errors)[0].ErrorContent�._��� $��!��$��center=�$��center=�$
��Bold"�
��������� $��customAdorner��$��Center=�.v��� 
���  ��$��1q��� .R�]� .+��� $��Center=����� F� $ arrow��$��2��
��� ���+����@KL ��� ���� ��� р�� @KL �@KL ��� 	�� .R�]� .+��� $��Center=����� F� $ arrow��$��2��
��� ���+����@KL @KL р�� ��� ���� @KL �@KL @KL 	 J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$
 Open��  -   $
 Save��  -   $ self:CustomCommands.Exit��  -   $! self:CustomCommands.AddCard��  -   $" self:CustomCommands.EditCard��  -   $$ self:CustomCommands.DeleteCard��  -   $# self:CustomCommands.ClearDeck��  -	   $" self:CustomCommands.AddImage��.��� .+�]� .+�o� $	��Top=�.@�m� ���� *UITranslation.MenuFile+.@�m�  m� Command$
 Open������ *UITranslation.MenuItemOpen+m� $
 Save������ *UITranslation.MenuItemSave+m� $ self:CustomCommands.Exit������ *UITranslation.MenuItemExit+m� $��Edition��.@�m� $��Vider le deck��$# self:CustomCommands.ClearDeck���� -
   $��CardDeck��$
��Left=�$��10q�$	��454������ $ CardCollection� �� UpdateSourceTrigger$ PropertyChanged=� �� View �� .P��� $
��U.Id�� �� Width$	 150�� �� DisplayMemberBinding �� $ CardUniqueId��� $��Titre��$	 150�� �� $ 	CardTitle��� $��
Catégorie��$	 150�� �� $ CardCategory��� $��Bottom=� �� Orientation$ 
Horizontal=�$��Center=�.+��� $��10q�$��5q�$��Ajouter��$!��self:CustomCommands.AddCard���� $��10q�$��5q�$��Editer��$"��self:CustomCommands.EditCard���� $��10q�$��5q�$��	Supprimer��$$��self:CustomCommands.DeleteCard��� $��Right=�$��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $	��200 � � ColumnDefinitions �� $
��Auto ��� $��* ��� $��30 ��� $
��Auto ��� $��* ��� $��30 �.+��� $��0��$��0��$��Titre :���� -   $��
TitleField��$��0��$��1��$��3q����� $ CurrentCard.CardTitle�$ PropertyChanged=� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . �� $��1��$��0��$��Coût :���� -   $��	CostField��$��1��$��1��$��3q����� $ CurrentCard.CardCost�$ PropertyChanged=� .  . �� $��2��$��0��$��Catégorie :���� -   $��CategoryField��$��2��$��1��$��3q�����  �� Source# [  �� SelectedItem �� $ CurrentCard.CardCategory��� $��0��$��3��$��Unique ID :���� -   $��IdField��$��0��$��4��$��3q����� $ CurrentCard.CardUniqueId�$ PropertyChanged=� .  . �� $��1��$��3��$��Global ID :���� -   $��1��$��4��$��3q����� $ CurrentCard.CardGlobalId�$ PropertyChanged=� .  . �� $��2��$��3��$��SFX :���� -   $��SfxField��$��2��$��4��$��3q����� # [  �� $ CurrentCard.CardSfx��� $��6��$��0��$��Description :���� -   $��DescriptionField��$��6��$��1��$��3��$��3q� �� AcceptsReturn .   �� TextWrapping$
  Wrap=�! �� 	IsEnabled! . " � Language$" fr-FR����� $! CurrentCard.CardDescription��� $��6��$��4��$��2��$��5q�$"��self:CustomCommands.AddImage��.���� .+��� $
��Fill=����� $ CurrentCard.CardImagePath�# �� 	Converter## [  