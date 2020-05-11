import React, { useContext } from 'react';
import Container from 'react-bootstrap/Container';
import StoreContext from 'components/Store/Context';
import { Link } from 'react-router-dom';
import { Navbar, Nav } from 'react-bootstrap';

export const Layout = (props) => {
    const { setToken } = useContext(StoreContext);    
    function handleLogout() {
        setToken(null);
    }

    return (
        <Container>
            <Navbar fluid="true" collapseOnSelect bg="dark" >
                <Navbar.Brand><Link to="/">Controle de Condomínio</Link></Navbar.Brand>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto" >
                        <Nav.Item><Nav.Link href="/apartamentos" className="text-white">Apartamentos</Nav.Link></Nav.Item>
                        <Nav.Item><Nav.Link href="/moradores" className="text-white">Moradores</Nav.Link></Nav.Item>
                        <Nav.Item onClick={handleLogout}><Nav.Link className="text-white">Logout</Nav.Link></Nav.Item>                    
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
            <Container fluid>
                {props.children}
            </Container>
        </Container>
    )
}