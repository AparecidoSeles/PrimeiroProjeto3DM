import { Component } from "react";
import Header from "../../components/header/Header";
import api from '../../services/api';
import '../../assets/css/classroom/Classroom.css';
import deleteIcon from '../../assets/icons/delete-icon.svg';
import editIcon from '../../assets/icons/edit-icon.svg';

class Classroom extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: '',
            floor: '',
            m2: 0,
            idSalaAlterado: 0,
            idEscola: 1,
            listaSalas: [],
            isLoading: false,
            mensagem: ''
        }
    }

    updateStateInput = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
        console.log(campo.target.value)
    }

    buscarSalas = async () => {
        const resposta = await api.get('/Sala', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
        this.setState({ listaSalas: resposta.data })
    };

    buscarSalaId = (sala) => {
        this.setState({
            idSalaAlterado: sala.idSala,
            name: sala.nome,
            floor: sala.andar,
            m2: sala.metragem,
        })
    }

    cadastrarSala = (event) => {
        this.setState({ isLoading: true })
        event.preventDefault();
        let sala = {
            nome: this.state.name,
            andar: this.state.floor,
            metragem: this.state.m2,
            idEscola: this.state.idEscola
        }
        if (this.state.idSalaAlterado !== 0) {
            api('/sala/' + this.state.idSalaAlterado, {
                method: 'PUT',
                data: JSON.stringify(sala),
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': 'Bearer ' + localStorage.getItem('user-token')
                }

            })
                .then(resposta => {
                    if (resposta.status === 204) {
                        this.setState({ mensagem: 'Sala atualizada!', isLoading: false  })
                    }
                })
                .then(this.buscarSalas)
        }
        else {
            api('/sala', {
                method: 'POST',
                data: JSON.stringify(sala),
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': 'Bearer ' + localStorage.getItem('user-token')
                }
            })
                .then(resposta => {
                    if (resposta.status === 201) {
                        this.setState({ mensagem: 'Sala cadastrada!', isLoading: false })
                    }
                })
                .then(this.buscarSalas)
        }

    }

    exluirSala = (sala) => {
        api('/sala/' + sala.idSala, {
            method: 'DELETE',
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 204) {
                    this.buscarSalas()
                    console.log('Deu certo! Excluiu!')
                }
            })
    }

    componentDidMount() {
        this.buscarSalas();
    }

    render() {
        return (
            <div className='class-body'>
                <div className='class-content'>
                    <Header />
                    <main className='class-main'>
                        <div className='class-text'>
                            <h1>Salas</h1>
                            <p>Preencha os campos abaixo para adicionar uma nova sala.</p>
                        </div>

                        <section className='class-section'>
                            <h1>{this.state.idSalaAlterado !== 0 ? 'Atualização de sala' : 'Cadastro de Sala'}</h1>
                            <span>{this.state.mensagem}</span>
                            <form className='class-form' onSubmit={this.cadastrarSala}>
                                <input type='text' placeholder='Nome' className='class-input input-name' name='name' value={this.state.name} onChange={this.updateStateInput} />
                                <input type='text' placeholder='Andar' className='class-input input-floor' name='floor' value={this.state.floor} onChange={this.updateStateInput} />
                                <input type='text' placeholder='Metragem' className='class-input input-m2' name='m2' value={this.state.m2} onChange={this.updateStateInput} />
                                <button type='submit' className='class-button'>{this.state.idSalaAlterado !== 0? 'Atualizar': 'Cadastrar'}</button>
                            </form>
                        </section>


                        <section className='class-list'>
                            <div className='class-text'>
                                <div className='class-text-title'>
                                    <h1>Salas</h1>
                                    <h2>Qtd. </h2>
                                    <span>{this.state.listaSalas.length}</span>
                                </div>
                                <p>Confira todas as salas existentes. Para editar ou excluir, utilize os ícones.</p>
                            </div>

                            <div className='class-list-container'>
                                <h1>Listagem das salas</h1>
                                <ul className='class-list-content'>
                                    {
                                        this.state.listaSalas.map(sala => {
                                            return (
                                                <li className='class-list-li' key={sala.nome}>
                                                    <div className='class-list-name'>
                                                        <p>{sala.nome}</p>
                                                    </div>
                                                    <div className='class-list-floor'>
                                                        <p>{sala.andar}</p>
                                                    </div>
                                                    <div className='class-list-m2' >
                                                        <p>{sala.metragem}</p>
                                                    </div>
                                                    <div className='class-list-icons' >
                                                        <figure onClick={() => this.buscarSalaId(sala)}>
                                                            <img src={editIcon} alt='Ícone de edição' />
                                                        </figure>
                                                        <figure onClick={() => this.exluirSala(sala)}>
                                                            <img src={deleteIcon} alt='Ícone de exclusão' />
                                                        </figure>
                                                    </div>
                                                </li>
                                            )
                                        })
                                    }
                                </ul>
                            </div>
                        </section>

                    </main>

                </div>
            </div>
        )
    }
}

export default Classroom;