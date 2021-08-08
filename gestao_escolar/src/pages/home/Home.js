import '../../assets/css/home/Home.css';

import { Component } from "react";
import Header from '../../components/header/Header';
import api from '../../services/api';

class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            salas: '',
            equipamentos: '',
            listaSalas: [],
            listaEquipamentos: []
        }
    }

    buscarSalas = async () => {
        const resposta = await api.get('/Sala', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
        this.setState({listaSalas: resposta.data})
    };

    buscarEquipamentos = async () => {
        const resposta = await api.get('/Equipamento', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
        this.setState({listaEquipamentos: resposta.data})
    };

    componentDidMount() {
        this.buscarSalas();
        this.buscarEquipamentos();
    }


    render() {
        return (
            <div className='home-body'>
                <div className='home-content'>
                    <Header />
                    <main className='home-main'>
                        <div className='home-text'>
                            <h1>Visão geral</h1>
                            <p>Confira a quantidade de salas e equipamentos da escola.</p>
                        </div>
                        <section className='home-section'>
                            <div className='home-card'>
                                <header><h1>Salas</h1></header>
                                <span>{this.state.listaSalas.length}</span>
                            </div>
                            <div className='home-card'>
                                <header><h1>Equipamentos</h1></header>
                                <span>{this.state.listaEquipamentos.length}</span>
                            </div>
                        </section>
                    </main>

                </div>
            </div>
        )
    }
}

export default Home;