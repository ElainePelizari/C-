using Escola.DAL;
using Escola.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Escola.View
{
    /// <summary>
    /// Interaction logic for frmCadastrarAluno.xaml
    /// </summary>
    public partial class frmCadastrarAluno : Window
    {
        public Aluno aluno = new Aluno();

        public frmCadastrarAluno()
        {
            InitializeComponent();
            HabilitarCampos(false);
        }

        public void HabilitarCampos(bool habilitar)
        {
            if (habilitar)
            {
                btnAlterar.IsEnabled = true;
                btnExcluir.IsEnabled = true;
                btnGravarAluno.IsEnabled = false;
            }
            else
            {
                btnAlterar.IsEnabled = false;
                btnExcluir.IsEnabled = false;
                btnGravarAluno.IsEnabled = true;
            }
        }
        public void LimparCampos()
        {
            txtBuscarAluno.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            //dateDataNascimento.Clear();
            txtNome.Focus();
            HabilitarCampos(false);
        }

        private void BtnGravarAluno_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNome.Text))
            {
                //gravar no banco.
                aluno = new Aluno()
                {
                    Nome = txtNome.Text,
                    CPF = Convert.ToString(txtCPF.Text),
                    dataNasc = Convert.ToDateTime(dateDataNascimento.Text)
                };
                // Relacionamento criado
                Turma turma = new Turma
                {
                    NomeTurma = Convert.ToString(cbxTurmaAluno.SelectedValuePath)
                };
                turma = TurmaDAO.BuscarTurmaPorNome(turma);
                aluno.IdTurma = turma.Id;

                if (AlunoDAO.CadastrarAluno(aluno))
                {
                    LimparCampos();
                    MessageBox.Show("Aluno cadastrado com sucesso!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Esse aluno já está Cadastrado!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o nome!", "Escola WPF",
                  MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.ShowDialog();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            aluno.Nome = txtNome.Text;
            aluno.CPF = Convert.ToString(txtCPF.Text);
            aluno.dataNasc = Convert.ToDateTime(dateDataNascimento.Text);

            if (AlunoDAO.AlterarAluno(aluno))
            {
                LimparCampos();
                MessageBox.Show("Aluno alterado com sucesso!", "Escola WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Esse aluno já existe!", "Escola WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja excluir esse aluno?","Escola WPF", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Remover o aluno
                AlunoDAO.RemoverAluno(aluno);
                MessageBox.Show("Aluno excluido com sucesso!",
                    "Escola WPF",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparCampos();
            }
        }

        private void btnBuscarAluno_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarAluno.Text))
            {
                aluno = new Aluno
                {
                    CPF = txtBuscarAluno.Text
                };

                aluno = AlunoDAO.BuscarAlunoPorCPF(aluno);

                if (aluno != null)
                {
                    //Mostrar os dados
                    txtNome.Text = aluno.Nome;
                    txtCPF.Text = aluno.CPF.ToString();
                    dateDataNascimento.Text = aluno.dataNasc.ToString();
                    HabilitarCampos(true);
                }
                else
                {
                    MessageBox.Show("Esse aluno não existe!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o nome!", "Escola WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBuscarAluno_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cbxTurmaAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxTurmaAluno_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar todas as categorias para o combobox
            cbxTurmaAluno.ItemsSource = TurmaDAO.RetornarTurmas();
            //Configurar o que vai aparecer em cada item do combobox
            cbxTurmaAluno.DisplayMemberPath = "Nome";
            //Configurar o vai ficar escondido em cada item do combobox
            cbxTurmaAluno.SelectedValuePath = "NomeTurma";
        }
    }
}
