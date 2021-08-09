import { Component } from 'react';
import deleteIcon from '../../assets/icons/delete-icon.svg';
import editIcon from '../../assets/icons/edit-icon.svg';
import '../../assets/css/equipment/Equipment.css';
import Header from '../../components/header/Header';
import api from '../../services/api';

class Equipment extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaEquipamentos: [],
            marca: '',
            descricao: '',
            idSala: 0,
            patrimonio: '',
            serie: '',
            idTipo: 0,
            ativo: true,
            nome: '',
            idEquipamentoAlterado: 0,
            mensagem: '',
            isloading: false
        }
    }
    updateStateInput = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
        console.log(campo.target.value)
    }

    buscarEquipamentos = async () => {
        const resposta = await api.get('/equipamento', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
        this.setState({ listaEquipamentos: resposta.data })
        console.log(this.state.listaEquipamentos)
    }

    buscarEquipamentosId = (equip) => {
        this.setState({
            idEquipamentoAlterado: equip.idEquipamento,
            marca: equip.marca,
            descricao: equip.descricao,
            idSala: equip.idSala,
            patrimonio: equip.numeroPatrimonio,
            serie: equip.numeroSerie,
            idTipo: equip.idTipoEquipamento,
            ativo: equip.situacao,
            nome: equip.nome
        })
    }

    cadastrarEquipamentos = (event) => {
        this.setState({ isloading: true })
        event.preventDefault();
        let equip = {
            nome: this.state.nome,
            marca: this.state.marca,
            numeroSerie: this.state.serie,
            descricao: this.state.descricao,
            numeroPatrimonio: this.state.patrimonio,
            situacao: this.state.ativo,
            idTipoEquipamento: this.state.idTipo,
            idSala: this.state.idSala
        }

        if (this.state.idEquipamentoAlterado !== 0) {
            api('/equipamento/' + this.state.idEquipamentoAlterado, {
                method: 'PUT',
                data: JSON.stringify(equip),
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': 'Bearer ' + localStorage.getItem('user-token')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        this.setState({ mensagem: 'Equipamento atualizado', isloading: false })
                    }
                })
                .then(this.buscarEquipamentos())
        }
        else {
            api('/equipamento', {
                method: 'POST',
                data: JSON.stringify(equip),
                headers: {
                    "Content-Type": "application/json",
                    'Authorization': 'Bearer ' + localStorage.getItem('user-token')
                }
            })
            .then(resposta => {
                if (resposta.status === 201) {
                    this.setState({ mensagem: 'Equipamento cadastrado!', isLoading: false })

                }
            })
            .then(this.buscarEquipamentos())
        }
    }

    excluirSala = (equip) =>{
        api('/equipamento/' + equip.idEquipamento, {
            method: 'DELETE',
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('user-token')
            }
        })
            .then(resposta => {
                if (resposta.status === 204) {
                    this.buscarEquipamentos()
                    console.log('Deu certo! Excluiu!')
                }
            })
    }

    componentDidMount() {
        this.buscarEquipamentos();
    }

    render() {
        return (
            <div className='equip-body'>
                <div className='equip-content'>
                    <Header />
                    <main className='equip-main'>
                        <div className='equip-text'>
                            <h1>Equipamentos</h1>
                            <p>Preencha os campos abaixo para adicionar um novo equipamento.</p>
                        </div>

                        <section className='equip-section'>
                            <h1>{this.state.idEquipamentoAlterado !== 0? 'Atualização de equipamento' : 'Cadastro de equipamento'}</h1>
                            <span>{this.state.mensagem}</span>
                            <form className='equip-form' onSubmit={this.cadastrarEquipamentos}>
                                <div className='equip-form-content'>
                                    <div>
                                        <input type='text' placeholder='Nome' className='equip-input input-nome' name='nome' value={this.state.nome} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Nº patrimônio' className='equip-input input-patrimonio' name='patrimonio' value={this.state.patrimonio} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Marca' className='equip-input input-marca' name='marca' value={this.state.marca} onChange={this.updateStateInput} />
                                        <select placeholder='Sala' value={this.state.idSala} name='idSala' onChange={this.updateStateInput} className='equip-input input-sala '>
                                            {
                                                this.state.listaEquipamentos.map(equip => {
                                                    return (
                                                        <option key={equip.idEquipamento} value={equip.idSala}>{equip.idSalaNavigation.nome}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                    </div>
                                    <div>
                                        <input type='text' placeholder='Descrição' className='equip-input input-descricao' name='descricao' value={this.state.descricao} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Nº de série' className='equip-input input-serie' name='serie' value={this.state.serie} onChange={this.updateStateInput} />
                                        <select placeholder='Tipo de equipamento' name='idTipo' className='equip-input input-tipo' onChange={this.updateStateInput} value={this.state.idTipo}>
                                            {
                                                this.state.listaEquipamentos.map(equip => {
                                                    return (
                                                        <option key={equip.idEquipamento} value={equip.idTipoEquipamento}>{equip.idTipoEquipamentoNavigation.nomeTipoEquipamento}</option>
                                                    )
                                                })
                                            }
                                        </select>
                                        <select placeholder='Ativo/Inativo' className='equip-input equip-select' onChange={this.updateStateInput} name='ativo' value={this.state.ativo}>
                                            <option value={this.state.ativo = true}>Ativo</option>
                                            <option value={this.state.ativo = false} >Inativo</option>
                                        </select>
                                    </div>
                                </div>

                                <button type='submit' className='equip-button'>{this.state.idEquipamentoAlterado !== 0 ? 'Atualizar' : 'Cadastrar'}</button>
                            </form>
                        </section>
                        <section className='equip-list'>
                            <div className='equip-text'>
                                <div className='equip-text-title'>
                                    <h1>Equipamentos</h1>
                                    <h2>Qtd. </h2>
                                    <span>{this.state.listaEquipamentos.length}</span>
                                </div>
                                <p>Confira todos os equipamentos existentes. Para editar ou excluir, utilize os ícones.</p>
                            </div>
                            <div className='equip-list-container'>
                                <h1>Listagem dos equipamentos</h1>
                                <ul className='equip-list-content'>
                                    {
                                        this.state.listaEquipamentos.map(equip => {
                                            return (
                                                <li className='equip-list-li' key={equip.idEquipamento}>
                                                    <div className='equip-list-div'>
                                                        <div className='equip-list-marca'>
                                                            <p>{equip.nome}</p>
                                                        </div>
                                                        <div className='equip-list-serie'>
                                                            <p>{equip.numeroSerie}</p>
                                                        </div>
                                                        <div className='equip-list-patrimonio' >
                                                            <p>{equip.numeroPatrimonio}</p>
                                                        </div>
                                                        <div className='equip-list-icons' >
                                                            <figure onClick={() =>this.buscarEquipamentosId(equip)}>
                                                                <img src={editIcon} alt='Ícone de edição' />
                                                            </figure>

                                                        </div>
                                                    </div>
                                                    <div className='equip-list-line'></div>

                                                    <div className='equip-list-div'>
                                                        <div className='equip-list-descricao'>
                                                            <p>{equip.marca}</p>
                                                        </div>
                                                        <div className='equip-list-tipo'>
                                                            <p>{equip.idTipoEquipamentoNavigation.nomeTipoEquipamento}</p>
                                                        </div>
                                                        <div className='equip-list-ativo' >
                                                            <p>{equip.situacao === true ? 'Ativo' : 'Inativo'}</p>
                                                        </div>
                                                        <div className='equip-list-icons' >

                                                            <figure onClick={() => this.excluirSala(equip)}>
                                                                <img src={deleteIcon} alt='Ícone de exclusão' />
                                                            </figure>
                                                        </div>
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
export default Equipment;