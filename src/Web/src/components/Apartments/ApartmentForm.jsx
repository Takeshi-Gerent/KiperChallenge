import React, { Component } from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import ApartmentService from "./ApartmentService";
import { Form, FormControl, InputGroup, Button, Table, Modal } from 'react-bootstrap';
import { FaUserEdit, FaUserMinus } from "react-icons/fa";
import styled from 'styled-components';
import Moment from 'moment';
import InputMask from 'react-input-mask'

const Styles = styled.div`
  .cabecalho {
    margin: 10px 0px;    
  }
  .btn {
    margin-top: -7px;
  }
`;

const ValidationFeedback = styled.div`
    width: 100%;
    margin-top: .25rem;
    font-size: 80%;
    color: #dc3545;
`;


class ApartmentForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: { id: 0, number: '', block: '', dwellers: [] }, showModalDweller: false, dwellerIndex: -1, dwellerIsValid: false,
            apartmentValidation: { number: false, atLeastOneDweller: false },
            dwellerValidation: { name: false, birthDate: false, telephone: false, cpf: false, email: false },
            modalDweller: {
                id: 0,
                name: '',
                birthDate: '',
                formatedBirthDate: '',
                telephone: '',
                cpf: '',
                email: ''
            },
            showDwellerModalErrors: false
        };
        this.editMode = false;
        Moment.locale('br');
    };

    handleChange = ({ target }) => {
        this.setState(prevState => ({ data: { ...prevState.data, [target.name]: target.value } }));
    }

    componentDidMount() {
        if (!(typeof this.props.match.params.id === 'undefined')) {
            this.editMode = true;
            this.getApartment(this.props.match.params.id);
        }
    }

    getApartment = (id) => {
        ApartmentService.get(id).then((result) => this.setState({ data: result }));
    }

    onSubmit = event => {
        event.preventDefault();
        const data = this.state.data;
        if (this.editMode) {
            ApartmentService.update(data).then((result) => {
                alert(result.message);
                if (result.success) {                                     
                    this.props.history.push("/apartamentos/alterar/" + result.apartmentId);
                }
            });
        } else {
            ApartmentService.save(data).then((result) => {
                console.log(result);
                alert(result.message);
                if (result.success) {
                    this.props.history.push("/apartamentos/alterar/" + result.apartmentId);
                }
            });
        }
    };

    removeApartment = () => {
        const data = { id: this.state.data.id };
        ApartmentService.remove(data).then((result) => {
            console.log(result);
            alert(result.message);
            if (result.success) {
                this.props.history.push("/apartamentos");
            }
        });
    };

    newDweller = () => {
        return {
            id: 0,
            name: '',
            birthDate: '',
            formatedBirthDate: '',
            telephone: '',
            cpf: '',
            email: ''
        }
    }

    editDweller = (index) => {
        this.setState({ dwellerIndex: index });
        this.setModalDweller(this.state.data.dwellers[index]);
        this.setState({ showModalDweller: true });
    }

    removeDweller = (index) => {
        var dwellers = this.state.data.dwellers;
        dwellers.splice(index, 1);
        this.setState(prevState => ({ data: { ...prevState.data, dwellers: dwellers } }));
    }

    saveDweller = () => {
        const index = this.state.dwellerIndex;
        let dwellers = this.state.data.dwellers;
        let dweller = this.state.modalDweller;
        dweller.birthDate = Moment(this.state.modalDweller.formatedBirthDate, 'DD/MM/YYYY').toJSON();
        index >= 0 ? dwellers[index] = dweller : dwellers.push(dweller);        
        this.setState(prevState => ({ data: { ...prevState.data, dwellers: dwellers } }));
    }

    handleSaveAndCloseModal = () => {        
        if (this.isValidModalDweller()) {
            this.saveDweller();
            this.handleCloseModal();
        }
    }

    handleCloseModal = () => {
        this.setState({ showModalDweller: false });
    }

    handleShowModal = () => {
        this.setState({ dwellerIndex: -1 });
        this.setModalDweller(this.newDweller());
        this.setState({ showModalDweller: true });
    }

    setModalDweller = (data) => {        
        let modalDweller = data;
        modalDweller.formatedBirthDate = Moment(data.birthDate).format("DD/MM/YYYY");        
        this.setState({ modalDweller: data });
        this.validateDweller('name', modalDweller.name);
        this.validateDweller('formatedBirthDate', modalDweller.formatedBirthDate);
        this.validateDweller('cpf', modalDweller.cpf);
        this.validateDweller('telephone', modalDweller.telephone);
        this.validateDweller('email', modalDweller.email);
    }

    handleModalChange = ({ target }) => {
        
        this.setState(prevState => ({ modalDweller: { ...prevState.modalDweller, [target.name]: target.value } }),
            () => { this.validateDweller(target.name, target.value); }
        );
    }

    validateDweller = (fieldName, value) => {        
        switch (fieldName) {
            case 'name':
                let nameValid = (value.trim() !== "");
                this.setState(prevState => ({ dwellerValidation: { ...prevState.dwellerValidation, [fieldName]: nameValid } }));
                break;
            case 'formatedBirthDate':
                let birthValid = Moment(value, "DD/MM/YYYY").isValid();
                this.setState(prevState => ({
                    dwellerValidation: {
                        ...prevState.dwellerValidation, ['birthDate']: birthValid } }));
                break;
            case 'cpf':
                let cpfValid = (value.trim() !== "") && /^\d{3}\.\d{3}\.\d{3}\-\d{2}$/.test(value);
                this.setState(prevState => ({ dwellerValidation: { ...prevState.dwellerValidation, [fieldName]: cpfValid } }));
                break;
            case 'telephone':
                let telephoneValid = (value.trim() !== "") && /(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})/.test(value);
                this.setState(prevState => ({ dwellerValidation: { ...prevState.dwellerValidation, [fieldName]: telephoneValid } }));
                break;
            case 'email':
                let emailValid = (value.trim() !== "") && /^[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/.test(value);
                this.setState(prevState => ({ dwellerValidation: { ...prevState.dwellerValidation, [fieldName]: emailValid } }));
                break;
            default: break;
        }
    }

    isValidModalDweller = () => {
        this.setState({ showDwellerModalErrors: false });
        let isValid = this.state.dwellerValidation.name &&
            this.state.dwellerValidation.birthDate &&
            this.state.dwellerValidation.cpf &&
            this.state.dwellerValidation.telephone &&
            this.state.dwellerValidation.email;
        this.setState({ showDwellerModalErrors: !isValid });
        return isValid;
    }

    render() {


        return (
            <React.Fragment>
                <div>
                    <Styles>
                        <div className="cabecalho p-3 mb-2 bg-info text-white">
                            Apartamento
                            {this.editMode ? <><Button onClick={this.removeApartment} variant="outline-light" className="btn float-right align-middle">Excluir apartamento</Button></> : <></>}
                                
                        </div>
                    </Styles>
                    <Modal size="sm" show={this.state.showMessage} onHide={this.handleCloseMessageModal}>
                        <Modal.Header closeButton>
                            <Modal.Title>
                                {this.state.Message}
                            </Modal.Title>
                        </Modal.Header>
                    </Modal>

                    <Form onSubmit={this.onSubmit}>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>Número</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="number" value={this.state.data.number} onChange={this.handleChange} ref={input => this.number = input} />

                        </InputGroup>
                        <InputGroup className="mb-3" size="sm">
                            <InputGroup.Prepend><InputGroup.Text>Bloco</InputGroup.Text></InputGroup.Prepend>
                            <FormControl name="block" value={this.state.data.block} onChange={this.handleChange} ref={input => this.block = input} />
                        </InputGroup>

                        <Styles>
                            <div className="cabecalho p-3 mb-2 bg-info text-white">
                                Moradores
                                <Button onClick={this.handleShowModal} variant="outline-light" className="btn float-right align-middle">Incluir Morador</Button>
                            </div>
                        </Styles>

                        {this.state.data.dwellers.length ?
                            <Table striped bordered hover size="sm">
                                <thead>
                                    <tr>
                                        <th>Alterar</th>
                                        <th>Excluir</th>
                                        <th>Nome</th>
                                        <th>Nascimento</th>
                                        <th>Telefone</th>
                                        <th>CPF</th>
                                        <th>e-mail</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.state.data.dwellers.map((dweller, index) => (
                                        <tr key={index}>
                                            <td><Button onClick={() => this.editDweller(index)}><FaUserEdit /></Button></td>
                                            <td><Button onClick={() => this.removeDweller(index)}><FaUserMinus /></Button></td>
                                            <td>{dweller.name}</td>
                                            <td>{Moment(dweller.birthDate).format('DD/MM/YYYY')}</td>
                                            <td>{dweller.telephone}</td>
                                            <td>{dweller.cpf}</td>
                                            <td>{dweller.email}</td>
                                        </tr>
                                    ))
                                    }
                                </tbody>
                            </Table>
                            : <></>}
                        <Button type='submit' variant='primary'>Salvar</Button>
                    </Form>

                    <Modal show={this.state.showModalDweller} onHide={this.handleCloseModal}>
                        <Modal.Header closeButton>
                            <Modal.Title>Morador</Modal.Title>
                        </Modal.Header>
                        <Modal.Body>
                            <Form.Group>
                                <InputGroup className="mb-3" size="sm">
                                    <InputGroup.Prepend><InputGroup.Text>Nome</InputGroup.Text></InputGroup.Prepend>
                                    <FormControl name="name" value={this.state.modalDweller.name} onChange={this.handleModalChange} />
                                    {!this.state.dwellerValidation.name && this.state.showDwellerModalErrors ? <>
                                        <ValidationFeedback >Informe o nome</ValidationFeedback>
                                    </> : <></>}
                                </InputGroup>

                            </Form.Group>
                            <InputGroup className="mb-3" size="sm">
                                <InputGroup.Prepend><InputGroup.Text>Data de nascimento</InputGroup.Text></InputGroup.Prepend>
                                <InputMask mask="99/99/9999" name="formatedBirthDate" value={this.state.modalDweller.formatedBirthDate} onChange={this.handleModalChange} className="form-control" />
                                {!this.state.dwellerValidation.birthDate && this.state.showDwellerModalErrors ? <>
                                    <ValidationFeedback >Data de nascimento incorreta</ValidationFeedback>
                                </> : <></>}
                            </InputGroup>
                            <InputGroup className="mb-3" size="sm">
                                <InputGroup.Prepend><InputGroup.Text>Telefone</InputGroup.Text></InputGroup.Prepend>
                                <InputMask name="telephone" value={this.state.modalDweller.telephone} onChange={this.handleModalChange} className="form-control"
                                    mask="(99) 99999-9999" />
                                {!this.state.dwellerValidation.telephone && this.state.showDwellerModalErrors ? <>
                                    <ValidationFeedback>Telefone incorreto</ValidationFeedback>
                                </> : <></>}
                            </InputGroup>
                            <InputGroup className="mb-3" size="sm">
                                <InputGroup.Prepend><InputGroup.Text>CPF</InputGroup.Text></InputGroup.Prepend>
                                <InputMask name="cpf" value={this.state.modalDweller.cpf} onChange={this.handleModalChange} className="form-control"
                                    mask="999.999.999-99" />
                                {!this.state.dwellerValidation.cpf && this.state.showDwellerModalErrors ? <>
                                    <ValidationFeedback >CPF incorreto</ValidationFeedback>
                                </> : <></>}
                            </InputGroup>
                            <InputGroup className="mb-3" size="sm">
                                <InputGroup.Prepend><InputGroup.Text>e-mail</InputGroup.Text></InputGroup.Prepend>
                                <FormControl name="email" value={this.state.modalDweller.email} onChange={this.handleModalChange} />
                                {!this.state.dwellerValidation.email && this.state.showDwellerModalErrors ? <>
                                    <ValidationFeedback >e-mail incorreto</ValidationFeedback>
                                </> : <></>}
                            </InputGroup>
                        </Modal.Body>
                        <Modal.Footer>
                            <Button variant="secondary" onClick={this.handleCloseModal}>
                                Fechar
                            </Button>
                            <Button variant="primary" onClick={this.handleSaveAndCloseModal}>
                                Salvar
                            </Button>
                        </Modal.Footer>
                    </Modal>
                </div>


            </React.Fragment>
        );

    }
}

ApartmentForm.propTypes = {
    editMode: PropTypes.bool
}

ApartmentForm.defaultProps = {
    editMode: false
}

export default withRouter(ApartmentForm);