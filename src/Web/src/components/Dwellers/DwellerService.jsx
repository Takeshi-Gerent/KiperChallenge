import axios from 'axios'
import config from 'config'

const searchByApartment = async ( number, block ) => {
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Dweller/byapartment',
        params: {
            'Number' : number,
            'Block': block 
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
            'Name': name,
            'BirthDate': birthdate,
            'Telephone': telephone,
            'CPF': cpf,
            'Email': email
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

const update = async (data) => {
    let result = await axios({
        method: 'put',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Dweller',
        data: data
    })
        .then((result) => { return result.data; })
        .catch((error) => { console.log(error.message); return { message: 'Não foi possível atualizar o morador.' } });
    return result;
}

export default {
    searchByApartment,
    searchByDweller,
    get,
    update
};