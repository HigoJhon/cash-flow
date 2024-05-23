import { useEffect, useState } from "react";
import "../style/pages/login.css";
import { Navigate } from "react-router-dom";
import { postRequest } from "../Service/Request";

function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isLogged, setIsLogged] = useState(false);
  const [error, setError] = useState('');

  useEffect(() => {}, [email, password]);

  const login = async (e) => {
    e.preventDefault();

    try {
      if (email && password) {
        const response = await postRequest('/User/login', { email, password });
        console.log(response);
        setIsLogged(true);
      } else {
        setError('Por favor, insira email e senha.');
      }
    } catch (error) {
      console.error('Axios error:', error.response ? error.response.data : error.message);
      setError('Ocorreu um erro ao tentar fazer login.');
    }
  };

  if (isLogged) return <Navigate to="/home" />;

  return (
    <section className="user-login-area">
      <form onSubmit={login}>
        <h1>Login</h1>
        <input
          id="email-input"
          type="email"
          className="login_input"
          placeholder="Login"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          aria-required="true"
        />
        <input
          id="password-input"
          type="password"
          className="login_input"
          placeholder="Senha"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          aria-required="true"
        />
        {error && <p className="error-message">{error}</p>}
        <a href="/newPassword">Recuperar senha</a>
        <button 
          className="login_button"
          type="submit"
          onClick={login}
        >
          Entrar
        </button>
        <p>
          Não tem uma conta? <a href="/newUser">Crie uma</a>
        </p>
      </form>
    </section>
  );
}

export default Login;
