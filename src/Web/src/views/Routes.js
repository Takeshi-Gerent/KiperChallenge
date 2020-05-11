import React from 'react';
import { Route, Switch } from 'react-router-dom';
import Home from './Home/Home';
import StoreProvider from 'components/Store/Provider';
import RoutesPrivate from 'components/Routes/Private/Private';
import Login from './Login/Login';
import Apartment from './Apartment/Apartment'
import ApartmentEdit from './Apartment/ApartmentEdit'
import DwellerSearch from './Dweller/DwellerSearch'
import DwellerEdit from './Dweller/DwellerEdit'


export const Routes = () => {    
    return (
        <StoreProvider>
            <Switch>
                <Route path="/login" component={Login} />
                <RoutesPrivate exact path="/" component={Home} />                    
                <Route
                    path="/apartamentos"
                    render={({ match: { url }, ...props }) => {                        
                        return (
                            <>
                                <RoutesPrivate path={`${url}/`} component={Apartment} exact />
                                <RoutesPrivate exact {...props} path={`${url}/novo`} component={ApartmentEdit}  />
                                <RoutesPrivate {...props} path={`${url}/alterar/:id`} component={ApartmentEdit}  />                                
                            </>
                        )
                    }} />
                <Route
                    path="/moradores"
                    render={({ match: { url }, ...props }) => {
                        return (
                            <>
                                <RoutesPrivate path={`${url}/`} component={DwellerSearch} exact />                                
                                <RoutesPrivate {...props} path={`${url}/alterar/:id`} component={DwellerEdit} />
                            </>
                        )
                    }} />
            </Switch>
        </StoreProvider>
    );
};