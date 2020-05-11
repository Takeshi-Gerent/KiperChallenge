import { createContext } from 'react';

const StoreContext = createContext({
    token: null,
    setToken: () => { },
    isAuthenticated: false
});

export default StoreContext;