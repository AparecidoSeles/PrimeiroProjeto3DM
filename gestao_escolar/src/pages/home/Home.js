import '../../assets/css/home/Home.css';

import { Component } from "react";
import Header from '../../components/header/Header';

class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
        }
    }


    render() {
        return (
            <div className='home-body'>
                <div className='home-content'>
                    <Header/>
                    <main className='home-main'>
                        <div className='home-text'>
                            <h1>Visão geral</h1>
                            <p>Confira a quantidade de salas e equipamentos da escola.</p>
                        </div>
                        <section className='home-section'>
                            <div className='home-card'>
                                <header><h1>Salas</h1></header>
                                <span>5</span>
                            </div>
                            <div className='home-card'>
                                <header><h1>Equipamentos</h1></header>
                                <span>3</span>
                            </div>
                        </section>
                    </main>

                </div>
            </div>
        )
    }
}

export default Home;