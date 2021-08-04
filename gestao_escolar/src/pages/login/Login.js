import axios from "axios";
import { React, Component } from "react";
import api from "../../services/api";
import '../../assets/css/login/Login.css';
import ilustration from '../../assets/images/login_image.png';
import logo from '../../assets/images/login_logo.png';


class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            senha : '',
            email: '',
            error: '',
            isLoading: false
        };
    };

    logar = (event) =>{
        event.preventDefault()
        this.setState({error: '', isLoading: true});
        axios.post(api+'', {
            email: this.state.email,
            senha: this.state.senha
        })
        .then(response => {
            if(response.status === 200){
                localStorage.setItem('user-token', response.data.token)
                this.props.history.push('/home')
            }
        })
        .catch(() =>{
            this.setState({error: 'E-mail ou senha inválidos, tente novamente!', isLoading: false})
        })
    }

    updateStateInput = (campo) =>{
        this.setState({[campo.target.name]: campo.target.value})
        console.log(campo.target.value)
    }

    render() {
        return (
            <main className='main-content'>
                <section className='ilustration-section'>
                    <figure>
                        <img src={ilustration} alt='Ilustração de um sistema de gerenciamento'/>
                    </figure>
                </section>
                <section className='form-section'>
                    <figure className='form-figure'>
                        <img src={logo} alt='Logo do SENAI'/>
                    </figure>
                    <form className='form-form' onSubmit={this.logar}>
                        <p className='form-error'>{this.state.error}</p>
                        <input className='form-input input-email' type='email' name='email' value={this.state.email} onChange={this.updateStateInput} placeholder='Digite seu e-mail'/>
                        <input className='form-input input-senha' type='password' name='senha' value={this.state.senha} onChange={this.updateStateInput} placeholder='Digite sua senha'/>
                        {
                            this.state.isLoading === true &&
                            <button className='form-button' type='submit' >Carregando...</button>
                        }
                        {
                            this.state.isLoading === false &&
                            <button className='form-button' type='submit' disabled={this.state.senha === '' || this.state.email === '' ? 'none': ''} >Entrar</button>

                        }
                    </form>
                </section>
            </main>

        );
    };
}

export default Login;