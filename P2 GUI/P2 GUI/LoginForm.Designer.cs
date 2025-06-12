namespace P2_GUI
{
  public partial class LoginForm : Form
        {

            private void btnLogin_Click(object sender, EventArgs e)
            {
                string usuario = txtUsuario.Text.Trim();
                string senha = txtSenha.Text.Trim();

                if ((usuario == "ADMIN" && senha == "123") || ValidarUsuarioCsv(usuario, senha))
                {
                    this.Hide();
                    var menu = new MenuPrincipalForm(usuario);
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private bool ValidarUsuarioCsv(string usuario, string senha)
            {
                string path = "Data/usuarios.csv";
                if (!File.Exists(path)) return false;

                var linhas = File.ReadAllLines(path);
                foreach (var linha in linhas)
                {
                    var partes = linha.Split(',');
                    if (partes[0] == usuario && partes[1] == senha)
                        return true;
                }
                return false;
        }
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Label lblUsuario;
        private Label lblSenha;
        private Button btnLogin;
    }
}

