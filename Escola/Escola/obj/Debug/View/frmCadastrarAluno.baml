   M S B A M L   `   `   `  ����A  =Escola, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Escola.ViewEscola.View  5   	   #    Escola.View.frmCadastrarAluno   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Escola.View     5   	     � Title$  frmCadastrarAluno��5   	   $	��347��6#   $	��298��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��201* �6   �� 5      $	��91* �6   .+�5   
   �� $
��Nome��6   $
��Left=�6   $��26��6:   $��0,79,0,0q�6F   $	��Top=�6X   $��70��6p   �� 5   
   -   5         ��Name$ txtNome��5      $
��Left=�6#   $��26��6>   $��	89,79,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $��Informe nome do aluno��6q   $	��Top=�6�   $	��188��6�   $��1��6�   $��2��6�   �� 5   
   $	��CPF��6   $
��Left=�6   $��24��69   $��	0,110,0,0q�6E   $	��Top=�6X   $��70��6p   �� 5   
   -   5        $ txtCPF��5      $
��Left=�6"   $��24��6=   $��
89,110,0,0q�6I   $
 Wrap=�6]   $��Informe CPF do aluno��6q   $	��Top=�6�   $	��188��6�   $��2��6�   $��2��6�   �� 5   
   $��Data 
Nascimento��6   $
��Left=�64   $��43��6O   $��	0,134,0,0q�6[   $	��Top=�6n   $��84��6�    J� RenderTransformOrigin$ 0.489,0.951&�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dateDataNascimento��5      $
��Left=�61   $��29��6L   $��
89,139,0,0q�6X   $	��Top=�6l   $	��188��6�   $��3��6�   $��2��6�   �� 5   
   -   5         ��Name$ btnGravarAluno��5      $��Gravar��6)   $
��Left=�6:   $��27��6U   $��
10,223,0,0q�6a   $	��Top=�6u   $��74��6�   $��4��6�   �� 5   
   -   5        $ 	btnVoltar��5      $��Voltar��6$   $
��Left=�65   $��27��6P   $��108,268,0,0q�6\   $	��Top=�6q   $��72��6�   $��9��6�   �� 5   
   -   5        $ 
btnExcluir��5      $��Excluir��6%   $
��Left=�67   $��28��6R   $��	5,223,0,0q�6^   $	��Top=�6q   $��72��6�   $��8��6�   $��1��6�   �� 5   
   -   5        $ 
btnAlterar��5      $��Alterar��6%   $
��Left=�67   $��28��6R   $��108,223,0,0q�6^   $	��Top=�6s   $��72��6�   $��7��6�   �� 5   
   -   5        $ btnBuscarAluno��5      $��Buscar��6)   $
��Left=�6:   $��29��6U   $��
199,38,0,0q�6a   $	��Top=�6u   $��78��6�   $��6��6�   $��2��6�   �� 5   
   -	   5         ��Name$ btnBuscarNome��5      $
��Nome��6'   $
��Left=�66   $��23��6Q   $��0,10,0,0q�6]   $	��Top=�6o   $��65��6�   �� 5   
   -
   5        $ txtBuscarAluno��5      $
��Left=�6*   $��23��6E   $��	89,10,0,0q�6Q   $
 Wrap=�6d   $��Digite o nome��6x   $	��Top=�6�   $	��188��6�    J� 	AllowDrop . 	 J� IsHitTestVisible	 . $��5��6  $��2��6  �� 5   
   $��Turma��6   $
��Left=�6    $��26��6;   $��	5,177,0,0q�6G   $	��Top=�6Z   $��65��6r   �� 5   
   -   5        
 ��Name$
 cbxTurmaAluno��5      $��2��6*   $
��Left=�6>   $��26��6Y   $��
89,177,0,0q�6e   $	��Top=�6y   $	��188��6�   6�   5      5      