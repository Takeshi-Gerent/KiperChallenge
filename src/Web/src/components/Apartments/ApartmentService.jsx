import axios from 'axios'
import config from 'config'

const getAll = async () => {    
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Apartment',
    });        
    return result.data;    
}

const get = async (id) => {
    let result = await axios({
        method: 'get',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Apartment/' + id,
    });    
    return result.data;   
}

const save = async (data) => {
    let result = await axios({
        method: 'post',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Apartment',
        data: data
    })
        .then((result) => { return result.data; })
        .catch((error) => { console.log(error.message); return { message: 'N�o foi poss�vel salvar o apartamento.' } });

    return result;
}

const update = async (data) => {    
    let result = await axios({
        method: 'put',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Apartment',
        data: data
    })
        .then((result) => { return result.data; })
        .catch((error) => { console.log(error.message); return { message: 'N�o foi poss�vel atualizar o apartamento.' } });
    return result;
}

const remove = async (data) => {
    let result = await axios({
        method: 'delete',
        headers: { 'Content-Type': 'application/json-patch+json' },
        url: config.BACKEND_API + '/Apartment',
        data: data
    })
        .then((result) => { return result.data; })
        .catch((error) => { console.log(error.message); return { message: 'N�o foi poss�vel excluir o apartamento.' } });
    return result;
}

export default {
    getAll,
    get,
    save,
    update,
    remove
};