import { Component } from 'react';
import deleteIcon from '../../assets/icons/delete-icon.svg';
import editIcon from '../../assets/icons/edit-icon.svg';
import '../../assets/css/equipment/Equipment.css';
import Header from '../../components/header/Header';

class Equipment extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaEquipamentos: [],
            marca: 'Sei lá',
            patrimonio: '2102012',
            serie: '3123213',
            tipo: 'Tbm não sei',
            ativo: true,
            descricao: 'asdasdasda'

        }
    }
    updateStateInput = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
        console.log(campo.target.value)
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
                            <h1>Cadastro de equipamento</h1>
                            <form className='equip-form'>
                                <div className='equip-form-content'>
                                    <div>
                                        <input type='text' placeholder='Marca' className='equip-input input-marca' name='marca' value={this.state.marca} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Nº patrimônio' className='equip-input input-patrimonio' name='patrimonio' value={this.state.patrimonio} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Descricao' className='equip-input input-descricao' name='descricao' value={this.state.descricao} onChange={this.updateStateInput} />

                                    </div>
                                    <div>
                                        <input type='text' placeholder='Nº de série' className='equip-input input-serie' name='serie' value={this.state.serie} onChange={this.updateStateInput} />
                                        <input type='text' placeholder='Tipo' className='equip-input input-tipo' name='tipo' value={this.state.tipo} onChange={this.updateStateInput} />
                                        <select placeholder='Ativo/Inativo' className='equip-input equip-select'>
                                            <option disabled selected>Ativo/Inativo</option>
                                            <option >Ativo</option>
                                            <option >Inativo</option>
                                        </select>
                                    </div>
                                </div>

                                <button type='submit' className='equip-button'>Cadastrar</button>
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
                                    <li className='equip-list-li'>
                                    <div className='equip-list-div'>
                                        <div className='equip-list-marca'>
                                            <p>{this.state.marca}</p>
                                        </div>
                                        <div className='equip-list-serie'>
                                            <p>{this.state.serie}</p>
                                        </div>
                                        <div className='equip-list-patrimonio' >
                                            <p>{this.state.patrimonio}</p>
                                        </div>
                                        <div className='equip-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição' />
                                            </figure>

                                        </div>
                                    </div>
                                    <div className='equip-list-line'></div>
                                    
                                    <div className='equip-list-div'>
                                        <div className='equip-list-descricao'>
                                            <p>{this.state.descricao}</p>
                                        </div>
                                        <div className='equip-list-tipo'>
                                            <p>{this.state.tipo}</p>
                                        </div>
                                        <div className='equip-list-ativo' >
                                            <p>{this.state.ativo === true? 'Ativo': 'Inativo'}</p>
                                        </div>
                                        <div className='equip-list-icons' >

                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão' />
                                            </figure>
                                        </div>
                                    </div>
                                    </li>
  
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