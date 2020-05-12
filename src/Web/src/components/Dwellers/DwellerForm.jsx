import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import DwellerService from "./DwellerService";
import { Form, FormControl, InputGroup, Button } from 'react-bootstrap';
import styled from 'styled-components';
import Moment from 'moment';

const Styles = styled.div`
  .cabecalho {
    margin: 10px 0px;    
  }
  .btn {
    margin-top: -7px;
  }
`;


class DwellerForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: {
                id: 0, name: '', birthDate: '', formatedBirthDate: '',telephone: '', cpf: '', email: '', apartment: { id: 0, number: '', block: '' }
            }
        };
    };

    handleChange = ({ target }) => {
        this.setState(prevState => ({ data: { ...prevState.data, [target.name]: target.value } }));
    }

    componentDidMount() {               

        if (!(typeof this.props.match.params.id === 'undefined')) {       
            this.getDweller(this.props.match.params.id);
        }
    }

    getDweller = (id) => {
        DwellerService.get(id).then((result) => {
            result.formatedBirthDate = Moment(result.birthDate).format("DD/MM/YYYY");
            this.setState({ data: result });                   
        });        
    }

    editApartment = () => {
        this.props.history.push('/apartamentos/alterar/' + this.state.data.apartment.id);
    }

    onSubmit = event => {
        event.preventDefault();
        const data = this.state.data;
        data.birthDate = Moment(data.formatedBirthDate, 'DD/MM/YYYY').toJSON();
        DwellerService.update(data).then((result) => {
            alert(result.message);
            if (result.success) {                
                this.props.history.push("/moradores/alterar/" + result.dwellerId);
            }
        });

    };

    render() {
        return (
            <React.Fragment>
                <div>
                    <Styles>
                        <div className="cabecalho p-3 mb-2 bg-info text-white">
                            Morador - Apartamento {this.state.data.apartment.number} Bloco {this.state.data.apartment.block}
                            <Button onClick={this.editApartment} variant="outline-light" className="btn float-right align-middle">Editar Apartamento</Button>
                        </div>
                    </Styles>

                    <Form onSubmit={this.onSubmit}>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>Nome</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="name" value={this.state.data.name} onChange={this.handleChange} />
                        </InputGroup>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>Data de nascimento</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="formatedBirthDate" value={this.state.data.formatedBirthDate} onChange={this.handleChange} />
                        </InputGroup>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>Telefone</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="telephone" value={this.state.data.telephone} onChange={this.handleChange} />
                        </InputGroup>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>CPF</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="cpf" value={this.state.data.cpf} onChange={this.handleChange} />
                        </InputGroup>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>e-mail</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="email" value={this.state.data.email} onChange={this.handleChange} />
                        </InputGroup>

                        <Button type='submit' variant='primary'>Salvar</Button>
                    </Form>
                </div>
            </React.Fragment>
        );

    }
}

export default withRouter(DwellerForm);