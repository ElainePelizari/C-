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
    /// Interaction logic for CadastrarTurmas.xaml
    /// </summary>
    public partial class CadastrarTurmas : Window
    {
        public Turma turma = new Turma();

        public CadastrarTurmas()
        {
            InitializeComponent();
            HabilitarCampos(false);
        }

        public void HabilitarCampos(bool habilitar)
        {
            if (habilitar)
            {
                btnAlterarTurma.IsEnabled = true;
                btnGravarTurma.IsEnabled = false;
            }
            else
            {
                btnAlterarTurma.IsEnabled = false;
                btnGravarTurma.IsEnabled = true;
            }
        }
        public void LimparCampos()
        {
            txtNomeTurma.Clear();
            txtNomeTurma.Focus();
            HabilitarCampos(false);
        }

        private void txtNomeTurma_TextChanged(object sender, TextChangedEventArgs e)
        {

        }     // https://profdouglasbarcelos.github.io/

        private void btnGravarTurma_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomeTurma.Text))
            {
                //gravar no banco.
                turma = new Turma()
                {
                    NomeTurma = txtNomeTurma.Text,
                };
                // Relacionamento criado
                 Professor professor = new Professor()
                {
                    CPF = Convert.ToString(cbxNomeProfessor.SelectedValue)
                };

                professor = ProfessorDAO.BuscarProfessorPorCPF(professor);
                turma.IdProfessor = professor.Id;

                if (TurmaDAO.CadastrarTurma(turma))
                {
                    LimparCampos();
                    MessageBox.Show("Turma cadastrado com sucesso!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Essa turma já está Cadastrada!", "Escola WPF",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Favor preencher o nome!", "Escola WPF",
                  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnVoltarTurma_Click(object sender, RoutedEventArgs e)
        {
            frmPrincipal frm = new frmPrincipal();
            frm.ShowDialog();
        }

        private void btnAlterarTurma_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxNomeProfessor_Loaded(object sender, RoutedEventArgs e)
        {
            //Carregar todas as categorias para o combobox
            cbxNomeProfessor.ItemsSource = ProfessorDAO.RetornaProfessor();
            //Configurar o que vai aparecer em cada item do combobox
            cbxNomeProfessor.DisplayMemberPath = "Nome";
            //Configurar o vai ficar escondido em cada item do combobox
            cbxNomeProfessor.SelectedValuePath = "CPF";
        }

        private void cbxNomeProfessor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
