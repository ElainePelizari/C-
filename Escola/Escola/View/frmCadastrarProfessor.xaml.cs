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
    /// Interaction logic for frmCadastrarProfessor.xaml
    /// </summary>
    public partial class frmCadastrarProfessor : Window
    {
        public Professor professor = new Professor();

        public frmCadastrarProfessor()
        {
            InitializeComponent();
            HabilitarCampos(false);
        }

        public void HabilitarCampos(bool habilitar)
        {
            if (habilitar)
            {
                btnAlterarProfessor.IsEnabled = true;
                btnExcluirProfessor.IsEnabled = true;
                btnGravarProfessor.IsEnabled = false;
            }
            else
            {
                btnAlterarProfessor.IsEnabled = false;
                btnExcluirProfessor.IsEnabled = false;
                btnGravarProfessor.IsEnabled = true;
            }
        }
        public void LimparCampos()
        {
            txtBuscarProfessor.Clear();
            txtNomeProfessor.Clear();
            txtCPFProfessor.Clear();
            //dateDataNascimento.Clear();
            txtNomeProfessor.Focus();
            HabilitarCampos(false);
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnBuscarProfessor_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarProfessor.Text))
            {
                professor = new Professor
                {
                    CPF = txtBuscarProfessor.Text
                };

                professor = ProfessorDAO.BuscarProfessorPorCPF(professor);

                if (professor != null)
                {
                    //Mostrar os dados
                    txtNomeProfessor.Text = professor.Nome;
                    txtCPFProfessor.Text = professor.CPF.ToString();
                    dateNascimentoProfessor.Text = professor.dataNasc.ToString();
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

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txrCPFProfessor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnGravarProfessor_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeProfessor.Text))
            {
                //gravar no banco.
                professor = new Professor()
                {
                    Nome = txtNomeProfessor.Text,
                    CPF = Convert.ToString(txtCPFProfessor.Text),
                    dataNasc = Convert.ToDateTime(dateNascimentoProfessor.Text)
                };
                if (ProfessorDAO.CadastrarProfessor(professor))
                {
                    LimparCampos();
                    MessageBox.Show("Professor cadastrado com sucesso!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Esse professor já está Cadastrado!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o nome!", "Escola WPF",
                  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterarProfessor_Click(object sender, RoutedEventArgs e)
        {
            professor.Nome = txtNomeProfessor.Text;
            professor.CPF = Convert.ToString(txtCPFProfessor.Text);
            professor.dataNasc = Convert.ToDateTime(dateNascimentoProfessor.Text);

            if (ProfessorDAO.AlterarProfessor(professor))
            {
                LimparCampos();
                MessageBox.Show("Professor alterado com sucesso!", "Escola WPF",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Esse professor já existe!", "Escola WPF",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluirProfessor_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja excluir esse professor?", "Escola WPF", MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                //Remover o professor
                ProfessorDAO.RemoverProfessor(professor);
                MessageBox.Show("Professor excluido com sucesso!",
                    "Escola WPF",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimparCampos();
            }
        }

        private void btnVoltarProfessor_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.ShowDialog();
        }
    }
}
