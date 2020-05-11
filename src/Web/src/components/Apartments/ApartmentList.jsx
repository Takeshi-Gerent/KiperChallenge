import React, { useState, useEffect } from 'react';
import ApartmentService from './ApartmentService'
import { Col, Row, Button } from 'react-bootstrap';
import ApartmentWidget from './ApartmentWidget';
import styled from 'styled-components';
import { useHistory } from 'react-router-dom'


const Styles = styled.div`
  .wdgt {    
    margin: 10px 0px;    
  }
  .wdgtcard {
	cursor: pointer;
  }
  .cabecalho {
    margin: 10px 0px;    
  }
  .btn {
    margin-top: -7px;
  }
`;



const ApartmentList = () => {
	const [apartments, setApartments] = useState([]);
	const history = useHistory();

	useEffect(() => {
		getAllApartments();
	}, [])

	const getAllApartments = () => {
		
		ApartmentService.getAll().then((result) => setApartments(result));
		
	};

	const editApartment = (id) => {
		history.push('/apartamentos/alterar/'+id+'');
	}

	const newApartment = () => {
		history.push('/apartamentos/novo');
    }

	return (

		<div className="AparmentList">
			<Styles>
				<div>
					<div className="cabecalho p-3 mb-2 bg-info text-white">
						Apartamentos
                <Button variant="outline-light" className="btn float-right align-middle" onClick={newApartment}>Incluir</Button>
					</div>
				</div>
				<Row>			
					{apartments && apartments.map((apartment, index) => (
						<Col sm="2" md="2" className="wdgt" key={apartment.id}>
						<ApartmentWidget
							
							className="wdgtcard"
							color="info"
								number={apartment.number}
								block={apartment.block}
								dwellerCount={apartment.dwellersCount}
								onClick={() => editApartment(apartment.id)} />
					</Col>

				))}				
				</Row>
			</Styles>
			
		</div>

	);
}

export default ApartmentList;