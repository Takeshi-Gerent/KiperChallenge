import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import DwellerService from './DwellerService';

import { Form, FormControl, InputGroup, Button, Table, Card, Tabs, Tab } from 'react-bootstrap';
import { FaUserEdit } from "react-icons/fa";
import styled from 'styled-components';

const Styles = styled.div`
  .cabecalho {
    margin: 10px 0px;    
  }
  .btn {
    margin-top: -7px;
  }
`;


class DwellerSearchForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: {
                byApartment: { number: '', block: '' },
                byDweller: { name: '', birthdate: '', telephone: '', cpf: '', email: '' },
                resultSearch : []
            }
        };        
    };

    handleChangeByApartment = ({ target }) => {
        this.setState(prevState => ({ data: { ...prevState.data, byApartment: { [target.name]: target.value } } }));
    }

    handleChangeByDweller = ({ target }) => {
        this.setState(prevState => ({ data: { ...prevState.data, byDweller: { [target.name]: target.value } } }));
    }

    searchByApartment = () => {        
        DwellerService.searchByApartment(this.state.data.byApartment.number, this.state.data.byApartment.block).then(
            (result) => { console.log(result.data); this.setState(prevState => ({ data: { ...prevState.data, resultSearch: result.data.dwellers } })); }
            );

        
    }

    searchByDweller = () => {

        DwellerService.searchByDweller(
            this.state.data.byDweller.name,
            this.state.data.byDweller.birthdate,
            this.state.data.byDweller.telephone,
            this.state.data.byDweller.cpf,
            this.state.data.byDweller.email
            
        ).then(
            (result) => { console.log(result.data); this.setState(prevState => ({ data: { ...prevState.data, resultSearch: result.data.dwellers } })); }
        );
    }

    editDweller = (id) => {
        this.props.history.push('/moradores/alterar/' + id + '');
    }

    render() {
        return (
            <React.Fragment>
                <Styles>
                    <Tabs defaultActiveKey="byApartment" id="searchType">
                        <Tab eventKey="byApartment" title="Por Apartamento">
                            <Card>
                                <Card.Header bg="light">                            
                                    Busca por apartemento                            
                                </Card.Header>
                                <Card.Body>

                                    <Form >
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>Número</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="number" value={this.state.data.byApartment.number} onChange={this.handleChangeByApartment} />

                                        </InputGroup>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>Bloco</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="block" value={this.state.data.byApartment.block} onChange={this.handleChangeByApartment} />
                                        </InputGroup>

                                        <Button variant="primary" className="btn float-right align-middle" onClick={this.searchByApartment}>Buscar</Button>
                                    </Form>
                                </Card.Body>
                            </Card>
                        </Tab>
                        <Tab eventKey="byDweller" title="Por Morador">
                            <Card>
                                <Card.Header bg="light">
                                    Busca por moradores
                                </Card.Header>
                                <Card.Body>

                                    <Form>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>Nome</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="name" value={this.state.data.byDweller.name} onChange={this.handleChangeByDweller} />
                                        </InputGroup>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>Data de nascimento</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="birthdate" value={this.state.data.byDweller.birthdate} onChange={this.handleChangeByDweller} />
                                        </InputGroup>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>Telefone</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="telephone" value={this.state.data.byDweller.telephone} onChange={this.handleChangeByDweller} />
                                        </InputGroup>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>CPF</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="cpf" value={this.state.data.byDweller.cpf} onChange={this.handleChangeByDweller} />
                                        </InputGroup>
                                        <InputGroup className="mb-3" size="sm">
                                            <InputGroup.Prepend><InputGroup.Text>e-mail</InputGroup.Text></InputGroup.Prepend>
                                            <FormControl name="email" value={this.state.data.byDweller.email} onChange={this.handleChangeByDweller} />
                                        </InputGroup>
                                        <Button variant="primary" className="btn float-right align-middle" onClick={this.searchByDweller}>Buscar</Button>
                                    </Form> 
                                </Card.Body>
                            </Card>
                        </Tab>
                    </Tabs>
                    {this.state.data.resultSearch.length ?
                        <>
                            <Card>
                                <Card.Header bg="light">
                                    Resultado
                                </Card.Header>
                                <Card.Body>
                                    <Table striped bordered hover size="sm">
                                        <thead>
                                            <tr>
                                                <th>Alterar</th>
                                                <th>Nome</th>
                                                <th>Nascimento</th>
                                                <th>Telefone</th>
                                                <th>CPF</th>
                                                <th>e-mail</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            {this.state.data.resultSearch.map((dweller, index) => (
                                                <tr >
                                                    <td><Button onClick={() => this.editDweller(dweller.id)}><FaUserEdit /></Button></td>
                                                    <td>{dweller.name}</td>
                                                    <td>{dweller.birthdate}</td>
                                                    <td>{dweller.telephone}</td>
                                                    <td>{dweller.cpf}</td>
                                                    <td>{dweller.email}</td>
                                                </tr>
                                            ))
                                            }
                                        </tbody>
                                    </Table>
                                </Card.Body>
                            </Card>
                        </>
                        : <></>
                    }
                </Styles>
            </React.Fragment>
        );

    }
}

export default withRouter(DwellerSearchForm);