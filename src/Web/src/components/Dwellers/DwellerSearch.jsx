import React from 'react';
import styled from 'styled-components';
import DwellerSearchForm from './DwellerSearchForm';


const Styles = styled.div`
  .cabecalho {
    margin: 10px 0px;    
  }
  .btn {
    margin-top: -7px;
  }
`;



const DwellerSearch = () => {

	return (

		<div className="DwellerSearch">
			<Styles>
				<div>
					<div className="cabecalho p-3 mb-2 bg-info text-white">
						Moradores - Busca						
					</div>
				</div>
				<DwellerSearchForm />
			</Styles>
			
		</div>

	);
}

export default DwellerSearch;