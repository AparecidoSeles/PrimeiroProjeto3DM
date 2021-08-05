import { Component } from "react";
import Header from "../../components/header/Header";
import '../../assets/css/classroom/Classroom.css';
import deleteIcon from '../../assets/icons/delete-icon.svg';
import editIcon from '../../assets/icons/edit-icon.svg';

class Classroom extends Component {
    constructor(props) {
        super(props);
        this.state = {
            name: 'Laboratório de Redes',
            floor: '3º andar',
            m2: '15m²',
            listaSalas: []
        }
    }

    updateStateInput = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
        console.log(campo.target.value)
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
                            <h1>Cadastro de sala</h1>
                            <form className='class-form'>
                                <input type='text' placeholder='Nome' className='class-input input-name' name='name' value={this.state.name} onChange={this.updateStateInput} />
                                <input type='text' placeholder='Andar' className='class-input input-floor' name='floor' value={this.state.floor} onChange={this.updateStateInput} />
                                <input type='text' placeholder='Metragem' className='class-input input-m2' name='m2' value={this.state.m2} onChange={this.updateStateInput} />
                                <button type='submit' className='class-button'>Cadastrar</button>
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
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
                                        </div>
                                    </li>
                                    <li className='class-list-li'>
                                        <div className='class-list-name'>
                                            <p>{this.state.name}</p>
                                        </div>
                                        <div className='class-list-floor'>
                                            <p>{this.state.floor}</p>
                                        </div>
                                        <div className='class-list-m2' >
                                            <p>{this.state.m2}</p>
                                        </div>
                                        <div className='class-list-icons' >
                                            <figure>
                                                <img src={editIcon} alt='Ícone de edição'/>
                                            </figure>
                                            <figure>
                                                <img src={deleteIcon} alt='Ícone de exclusão'/>
                                            </figure>
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

export default Classroom;