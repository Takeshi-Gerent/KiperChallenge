import axios from 'axios'
import config from 'config'

const searchByApartment = async ( number, block ) => {
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Dweller/byapartment',
        params: {
            'Apartment.Number' : number,
            'Apartment.Block': block 
        }
    });
    return result;
}

const searchByDweller = async (name, birthdate, telephone, cpf, email) => {
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Dweller/bydweller',
        params: {
            'Dweller.Name': name,
            'Dweller.BirthDate': birthdate,
            'Dweller.Telephone': telephone,
            'Dweller.CPF': cpf,
            'Dweller.Email': email
        }
    });
    return result;

}

const get = async (id) => {
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Dweller/' + id,
    });
    return result.data;   
}

export default {
    searchByApartment,
    searchByDweller,
    get
};