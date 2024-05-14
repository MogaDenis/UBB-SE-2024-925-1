using NamespaceCBlurred_Frontend.NamespaceGPT;

namespace NamespaceCBlurred_Frontend
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Main", typeof(MainPage));
            Routing.RegisterRoute("LogIn", typeof(LogInPage));
            Routing.RegisterRoute("SignUp", typeof(SignUpPage));
            Routing.RegisterRoute("ForgotPassword", typeof(ForgotPasswordPage));
            Routing.RegisterRoute("Search", typeof(SearchPage));
            Routing.RegisterRoute("Save", typeof(SavePage));
        }
    }
}
