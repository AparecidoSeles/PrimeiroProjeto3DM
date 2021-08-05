import { Component } from 'react';
import'../../assets/css/components/header/Header.css';
import logo from '../../assets/images/nav-bar-logo.png';
import menu from '../../assets/icons/menu.svg'

class Header extends Component{
    constructor(props){
        super(props);
        this.state = {
            userName: 'João Vitor'
        }
    }


    render(){
        return(
            <header className='header'>
            <nav className='nav'>
                <figure>
                    <a href='/home'><img src={logo} alt='Logo do SENAI' /></a>
                </figure>
                <ul>
                    <li><a href='/home'>Ínicio</a></li>
                    <li><a href='/classroom'>Sala</a></li>
                    <li><a href='/equipamento'>Equipamento</a></li>
                    <p className='user-name'>Olá, <span>{this.state.userName}</span>!</p>
                </ul>
                <figure className='menu-icon'>
                    <img src={menu} alt='Ícone de menu'/>
                </figure>
            </nav>
        </header>
        )
    }
}

export default Header;