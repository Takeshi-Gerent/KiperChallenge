import React, { useContext } from 'react';
import StoreContext from 'components/Store/Context';
import './Home.css'

const PagesHome = () => {
    const { setToken } = useContext(StoreContext);
    return (
        <div className="pages-home">
            Parab�ns, voc� conseguiu
            <br />
            <button type="button" onClick={() => setToken(null)}>
                Sair
      </button>
        </div>
    );
};

export default PagesHome;