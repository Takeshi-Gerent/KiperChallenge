import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Card } from 'react-bootstrap';


const propTypes = {
    color: PropTypes.string,
    number: PropTypes.number,
    block: PropTypes.string,
    dwellerCount: PropTypes.number,
    className: PropTypes.string
}

const defaultProps = {
    className: '',
    color: 'info',
    number: '',
    block: '',
    dwellerCount: '',
};

class ApartmentWidget extends Component {
    render() {
        const { className, color, number, block, dwellerCount, ...attributes } = this.props;

        return (
            <div className={className} {...attributes} >
                <Card>
                    <Card.Header className="text-center">{number}</Card.Header>
                    <Card.Body>
                        <div>
                            <div className="text-value">Bloco</div>
                            <div className="text-uppercase text-muted small">{block}</div>
                        </div>
                        <div>
                            <div className="text-value">Moradores</div>
                            <div className="text-uppercase text-muted small">{dwellerCount}</div>
                        </div>                    
                    </Card.Body>                    
                </Card>
            </div>
        );
    }
}

ApartmentWidget.propTypes = propTypes;
ApartmentWidget.defaultProps = defaultProps;

export default ApartmentWidget;
